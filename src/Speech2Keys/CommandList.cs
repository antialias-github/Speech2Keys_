/*
 * Created by SharpDevelop.
 * User: Peter
 * Date: 10.11.2014
 * Time: 08:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Speech2Keys
{
	/// <summary>
	/// Description of CommandList.
	/// </summary>
	[Serializable()]
	public class CommandList
	{	
		public string version;
		public List<Command> listOfCommands;
		// other config stuff
		public List<string> standardResponses;
		public string ProfileName;
		public string commandToBeErased;
		
		//TODO: add all other stuff here from the settings and config
		
		public CommandList()
		{
			version = "1,0,0";
			listOfCommands = new List<Command>();
			standardResponses = new List<string>();
			Reset();
		}
	
		public void Reset()
		{
			listOfCommands.Clear();
			commandToBeErased = "";
		}
		
		public bool Add(Command _command, out string result)
		{
			if (_command.isValid(out result) && ListIsValid(_command, out result))
			{
				RemoveCommand(_command.name); // overwrite duplicates
				// if the command uses standard responses plug them in
				RemoveCommand(commandToBeErased);
				if (_command.useStandardResponses)
					foreach (var s in standardResponses)
						if (!_command.responses.Contains(s))
							_command.responses.Add(s);
				
			    listOfCommands.Add(_command);
			    result +="Command added. \n";
			    return true;
			}
			
			result+="Command not added. Please resolve conflicts and try again \n";
			return false;
		}
	
		public bool CommandIsAlreadyDefined (string name)
		{
			foreach (var c in listOfCommands)
				if (c.name == name)
					return true;
			return false;
		}
		
		public Command GetCommand (string name)
		{
			foreach (var c in listOfCommands)
				if (c.name == name)
					return c;
			return null;
		}
		
		public void RemoveCommand (string _name)
		{
			Command foundCommand = null;
			foreach (var c in listOfCommands)
			{
				if (c.name == _name)
				{
					foundCommand = c;
					break;
				}
			}
			if (null != foundCommand)
				listOfCommands.Remove(foundCommand);
		}
		
		
		public bool ListIsValid(Command _command, out string error)
		{
			// check that list would be valid if _command was added to it
			// invalidation criteria:
			// - command contains a keyword/phrase that is already assigned in another command
			
			// ignore commands of the same name,as this one will be replaced
			
			error ="";
			bool isValid = true;
			
			// keyphrase already defined
			foreach (var c in listOfCommands)
				if (c.name != _command.name && c.name != commandToBeErased)
					foreach (var k in c.keyPhrases)
						if (_command.keyPhrases.Contains(k))				
						{
							error+= "keyword/phrase '" + k + "' already defined in command " + c.name +"\n";
							isValid = false;
						}
						
			return isValid;
		}
		
		
		
		public void CreateStandardCommands()
		{
			if (!CommandIsAlreadyDefined("AIName"))
		    {
				Command command1 = new Command();
				command1.name = "AIName";
				command1.keyPhrases.Add("Alexa");
				command1.responses.Add("Listening");
				listOfCommands.Add(command1);
		    }
				
			if (!CommandIsAlreadyDefined("Jokes"))
		    {
				Command command2 = new Command();
				command2.name = "Jokes";
				command2.keyPhrases.Add("Tell me a joke");
				command2.keyPhrases.Add("Give me a joke");
				command2.keyPhrases.Add("Tell me something funny");
				command2.responses.Add("I have nothing funny to say");
				listOfCommands.Add(command2);
			}
			
			if (!CommandIsAlreadyDefined("Pause Speech Recognition"))
		    {				
				Command command3 = new Command();
				command3.name = "Pause Speech Recognition";
				command3.keyPhrases.Add("Pause speech recognition");
				command3.keyPhrases.Add("Stop listening");
				command3.keyPhrases.Add("Go offline");
				command3.keyPhrases.Add("Deactivate speech recognition");
				command3.responses.Add("Going offline");
				listOfCommands.Add(command3);
			}
			
			if (!CommandIsAlreadyDefined("Reactivate Speech Recognition"))
		    {	
				Command command4 = new Command();
				command4.name = "Reactivate Speech Recognition";
				command4.keyPhrases.Add("Resume speech recognition");
				command4.keyPhrases.Add("Start listening");
				command4.keyPhrases.Add("Come online");
				command4.keyPhrases.Add("Reactivate speech recognition");
				command4.responses.Add("Back online");
				listOfCommands.Add(command4);
			}
			
			if (!CommandIsAlreadyDefined("Stop Speech Output"))
		    {	
				Command command5 = new Command();
				command5.name = "Stop Speech Output";
				command5.keyPhrases.Add("Shut up");
				command5.keyPhrases.Add("Stop speech output");
				command5.keyPhrases.Add("Be silent");
				command5.responses.Add("Shutting up");
				listOfCommands.Add(command5);
			}
			
			if (!CommandIsAlreadyDefined("Teamspeak on"))
		    {				
				Command command6 = new Command();
				command6.name = "Teamspeak on";
				command6.keyPhrases.Add("Teamspeak on");
				command6.keyPhrases.Add("Teamspeak");
				command6.responses.Add("Teamspeak on");
				command6.sequence.Add("/ down");
				listOfCommands.Add(command6);
			}
				
			if (!CommandIsAlreadyDefined("Teamspeak off"))
		    {						
				Command command7 = new Command();
				command7.name = "Teamspeak off";
				command7.keyPhrases.Add("over and out");
				command7.keyPhrases.Add("teamspeak off");
				command7.responses.Add("back online");
				command7.sequence.Add("/ up");
				listOfCommands.Add(command7);
			}
			
			if (!CommandIsAlreadyDefined("Turn Responses Off"))
		    {						
				Command command8 = new Command();
				command8.name = "Turn Responses Off";
				command8.keyPhrases.Add("turn responses off");
				command8.keyPhrases.Add("responses off");
				command8.responses.Add("verbose mode off");
				listOfCommands.Add(command8);
			}
			
			if (!CommandIsAlreadyDefined("Turn Responses On"))
		    {						
				Command command9 = new Command();
				command9.name = "Turn Responses On";
				command9.keyPhrases.Add("turn responses on");
				command9.keyPhrases.Add("responses on");
				command9.responses.Add("verbose mode on");
				listOfCommands.Add(command9);
			}
			
			
		}
		
		public void AddDefaultStandardResponses()
		{
			standardResponses.Clear();
			standardResponses.Add("Roger");
			standardResponses.Add("You got it");
			standardResponses.Add("Affirmative");
			standardResponses.Add("Will do");
		}
	}
}
