/*
 * Created by SharpDevelop.
 * User: Peter
 * Date: 01.01.2015
 * Time: 02:50
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

namespace Speech2Keys
{
	/// <summary>
	/// Description of Serializer.
	/// </summary>
	public class Serializer
	{
		public  List<int> Version; 
		static string VersionTag = "::VERSION";
	 	static string ProfileNameTag = "::PROFILENAME";
		static string StandardResponsesTag = "::STANDARDRESPONSES";
		static string CommandTag = "::COMMAND";
		static string CommandNameTag = "::NAME";
		static string KeyPhrasesTag = "::KEYPHRASES";
		static string ResponsesTag = "::RESPONSES";
		static string UseStandardResponsesTag = "::USESTANDARDRESPONSES";
	 	static string SequenceTag = "::SEQUENCE";
	 	static string ResponseInPostTag = "::RESPONSEINPOST";
	 	
	 	public Serializer()
		{
	 		Version = new List<int>(){1,1,0};
		}
		
	// need to (de)serialize string, string lists, bool, command 
		public void Serialize (CommandList commandList, string filename)
		{
//			using (FileStream fs = new FileStream( filename
//                                     , FileMode.OpenOrCreate
//                                     , FileAccess.ReadWrite)           )
			
			using (Stream stream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None, 0x1000, FileOptions.WriteThrough))
	   			using (StreamWriter fs = new StreamWriter(stream))
					{
							string version = (Globals.Version[0].ToString())+","
											+(Globals.Version[1].ToString())+","
											+(Globals.Version[2].ToString());
							fs.WriteLine(VersionTag);
							fs.WriteLine(version);
							fs.WriteLine(VersionTag+"_END");
							fs.WriteLine(ProfileNameTag);
							fs.WriteLine(commandList.ProfileName);
							fs.WriteLine(ProfileNameTag+"_END");
							fs.WriteLine(StandardResponsesTag);
							foreach (var s in commandList.standardResponses)
								fs.WriteLine(s);
							fs.WriteLine(StandardResponsesTag+"_END");
							foreach (var c in commandList.listOfCommands)
							{
								fs.WriteLine(CommandTag);
								fs.WriteLine(CommandNameTag);
								fs.WriteLine(c.name);
								fs.WriteLine(CommandNameTag+"_END");
								fs.WriteLine(KeyPhrasesTag);
								foreach (var k in c.keyPhrases)
								fs.WriteLine(k);
								fs.WriteLine(KeyPhrasesTag+"_END");
								fs.WriteLine(ResponsesTag);
								foreach (var r in c.responses)
								fs.WriteLine(r);
								fs.WriteLine(ResponsesTag+"_END");
								fs.WriteLine(UseStandardResponsesTag);
								if (c.useStandardResponses == true)
									fs.WriteLine("true");
								else
									fs.WriteLine("false");	
								fs.WriteLine(UseStandardResponsesTag+"_END");
								fs.WriteLine(ResponseInPostTag);
								if (c.responseInPost == true)
									fs.WriteLine("true");
								else
									fs.WriteLine("false");
								fs.WriteLine(ResponseInPostTag+"_END");
								fs.WriteLine(SequenceTag);
								foreach (var s in c.sequence)
								fs.WriteLine(s);
								fs.WriteLine(SequenceTag+"_END");
								fs.WriteLine(CommandTag+"_END");
							} 	
							fs.Flush();
			       			fs.BaseStream.Flush();
					}
	
		}
		public bool Deserialize (ref CommandList commandList, string filename)
		{

			commandList.Reset();
			var file = new StreamReader(filename);
			string line;
			
			while((line = file.ReadLine()) != null)
			{
				if (line == VersionTag)
				{
					line = file.ReadLine();
					if (line != null)
					{
						string[] version = line.Split(',');
						Version[0] = Convert.ToInt32(version[0]);
						Version[1] = Convert.ToInt32(version[1]);
						Version[2] = Convert.ToInt32(version[2]);
					}		
				}
				if (line == ProfileNameTag)
				{
					line = file.ReadLine();
					if (line != null)
						commandList.ProfileName = line;
				}
				if (line == StandardResponsesTag)
				{
					commandList.standardResponses.Clear();
					while(((line = file.ReadLine()) != null)  && !IsTag(line))
						commandList.standardResponses.Add(line);
				}
					
				if (line == CommandTag)
				{
					var command = new Command();
					while(((line = file.ReadLine()) != null) && line != CommandTag+"_END")
					{
						if (line == CommandNameTag)
						{
							line = file.ReadLine();
							command.name = line;
						}
						if (line == UseStandardResponsesTag)
						{
							line = file.ReadLine();
							if (line == "true")
								command.useStandardResponses = true;
							else
								command.useStandardResponses = false;
						}
						if (line == ResponseInPostTag)
						{
							line = file.ReadLine();
							if (line == "true")
								command.responseInPost = true;
							else
								command.responseInPost = false;
						}
					if (line == KeyPhrasesTag)
						while(((line = file.ReadLine()) != null)  && !IsTag(line))
							command.keyPhrases.Add(line);
					if (line == ResponsesTag)
						while(((line = file.ReadLine()) != null)  && !IsTag(line))
							command.responses.Add(line);
					if (line == SequenceTag)
						while(((line = file.ReadLine()) != null)  && !IsTag(line))
							command.sequence.Add(line);
					}
					string result;
					commandList.Add(command, out result);
				}
			}
			file.Close();
			return true;
		}
		
		bool IsTag (string line)
		{
			return (line.StartsWith("::"))? true : false;
		}	
	}
}
