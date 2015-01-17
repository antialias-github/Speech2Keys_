/*
 * Created by SharpDevelop.
 * User: Peter
 * Date: 10.11.2014
 * Time: 08:51
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;
using System.Collections.Generic;


	
namespace Speech2Keys
{
	/// <summary>
	/// Description of Command.
	/// </summary>
	[Serializable()]
	public class Command
	{
		
		public string name {get; set;}
		public List<string> keyPhrases;
		public List<string> responses;
		public bool useStandardResponses{get; set;}
		public List<string> sequence;
		public bool responseInPost;
		Random random;
		
		
		
		public Command()
		{
			responseInPost = true;
			random = new Random(Guid.NewGuid().GetHashCode());
			keyPhrases = new List<string>();
			responses = new List<string>();
			sequence = new List<string>();
			Clear();
		}
	
		
		public Command(Command command)
		{
			random = new Random(Guid.NewGuid().GetHashCode());
			this.name = command.name;
			keyPhrases = new List<string>();
			foreach (var k in command.keyPhrases)
				this.keyPhrases.Add(k);
			responses = new List<string>();
			foreach (var r in command.responses)
				this.responses.Add(r);
			this.useStandardResponses = command.useStandardResponses;
			foreach (var s in command.sequence)
				this.sequence.Add(s);
			this.responseInPost = command.responseInPost;
		}
		
		public void Clear()
		{
			name = "";
			keyPhrases.Clear();
			responses.Clear();
			sequence.Clear();
			useStandardResponses = false;
			responseInPost = true;
		}
		
		public bool isValid(out string error)
		{
			
			// a command is invalid if it has
			// an empty name
			// no keyPhrases are assiged
			// keyPhrases are duplicates of each other
			error = "";
			bool isValid = true;
			
			if (name.Trim(null).Length == 0)
			{
				error += "Invalid command name \n";
				isValid = false;
			}
				
			if (keyPhrases.Count == 0)
			{
				error+="No phrases assigned \n";
				isValid = false;
			}
			
			foreach (var k in keyPhrases)
				if (keyPhrases.IndexOf(k) != keyPhrases.LastIndexOf(k))
				{
					error+="Phrases "+ k + " is not unique \n";
					isValid = false;
				}	
			
			for (int i = 0; i<responses.Count; ++i)
				if (responses.LastIndexOf(responses[i]) != i)
					error+= "Info: Response '" + responses[i] +"' found more than once. (This may be intentional to have some responses occur more frequently).\n";

			return isValid;
		}
		
		public string GenerateResponse()
		{
			int index = random.Next(responses.Count);
			
			return (responses.Count == 0) ? 
				string.Empty : responses[index];
		}
	}
}
