
	/*
 * Created by SharpDevelop.
 * User: Benutzer1
 * Date: 25.11.2014
 * Time: 19:38
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace Speech2Keys
{
	/// <summary>
	/// Description of TreeNode.
	/// </summary>
	public class PhraseList
	{
		List<Phrase> phraseList;
		int bestScore;
		List<Command> recognizedCommands;
		
		public PhraseList()
		{
			bestScore = 0;
			recognizedCommands = new List<Command>();
			phraseList = new List<Phrase>();
			
		}
		
		public void SetCommandList(CommandList _commandList)
		{
			phraseList.Clear();
			foreach (var command in _commandList.listOfCommands)
				foreach (string keyPhrase in command.keyPhrases)
				{
					phraseList.Add(new Phrase(keyPhrase, command));	
					List<string> individualWords = new List<string>();
					if (keyPhrase.Contains(" "))
					{
						string withoutSpaces = keyPhrase.Replace(" ",string.Empty);
						phraseList.Add(new Phrase(withoutSpaces, command));	
					}
				}	
		}
		
		public HashSet<string> ResetRecognition()
		{
			bestScore = 0;
			var keywords = new HashSet<string>();
			recognizedCommands.Clear();
			foreach (var p in phraseList)
			{
				p.recognizedPosition = 0;
				
				foreach (var k in p.keywords)
					keywords.Add(k);
			}
			return keywords;
		}

		public void RecognizePhrase(string recognizedWord)
		{
			int score = 0;
			Command command = null;
			foreach (var p in phraseList)
				if (p.RecognizedCommand(recognizedWord, out score, out command) == true)
				{
						if (score == bestScore)
							recognizedCommands.Add(command);
						
						if (score > bestScore)
						{
							recognizedCommands.Clear();
							recognizedCommands.Add(command);
						}
				}
		}
		
		public void ResetRecognizedCommands()
		{
			bestScore = 0;
			recognizedCommands.Clear();
		}
		
		public Command GetBestRecognizedCommand()
		{
			if( recognizedCommands.Count != 0) 
				return recognizedCommands[recognizedCommands.Count-1];
			else
				return null;
		}
	}
}


