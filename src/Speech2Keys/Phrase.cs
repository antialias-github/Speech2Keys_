
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
	/// Description of Phrase
	/// </summary>
	public class Phrase
	{
		public int recognizedPosition;
		public string[] keywords;
		public string fullPhrase;
		Command command;
		
		public Phrase(string _phrase, Command _command )
		{
			fullPhrase = _phrase;
			keywords  = _phrase.Split(' ');
			
			recognizedPosition = 0;
			command = _command;
		}
		
		public bool RecognizedCommand(string recognizedWord, out int score,  out Command recognizedCommand)
		{ 
			score = 0;
			recognizedCommand = null;
			if (keywords.Length > recognizedPosition && keywords[recognizedPosition] == recognizedWord)
			{
				recognizedPosition++;
				if(keywords.Length == recognizedPosition)
				{
					score = keywords.Length;
					recognizedCommand = command;
					return true;
				}
			}
			return false;
		}
	}
}


