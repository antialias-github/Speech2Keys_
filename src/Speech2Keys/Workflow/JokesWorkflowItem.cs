/*
 * Created by SharpDevelop.
 * User: Peter
 * Date: 26.12.2014
 * Time: 21:35
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;

namespace Speech2Keys
{
	/// <summary>
	/// Description of JokesWorkflowItem.
	/// </summary>
	public class JokesWorkflowItem : WorkflowItem
	{
		
		public JokesWorkflowItem(Form form): base(form){}
	
		public override void InitializeForm(Command command)
		{
			((JokesForm)form).Clear();
			if (command != null)
				((JokesForm)form).SetLabel(Convert.ToString(command.responses.Count - 1));
		}
		
		public override bool FillCommandWithData(Command command)
		{
			if (((JokesForm)form).clearJokes)
				command.responses.Clear();
			
			// iterate through the filenames and load the jokes
			foreach (var f in ((JokesForm)form).GetJokeFileNames())
			{
				string joke = "";
				string line = "";
			
				if (!File.Exists(f))
					continue;
			
				using (var file = new StreamReader(f))
				{
					while((line = file.ReadLine()) != null)
					{
						if (string.IsNullOrWhiteSpace(line))
						{
							if (!string.IsNullOrWhiteSpace(joke))
							{
								if (joke.EndsWith(","))
									continue;
								
								command.responses.Add(joke);
								joke = "";
							}
						}
						else
							joke += " " + line;		
					}
					if (!string.IsNullOrEmpty(joke))
						command.responses.Add(joke);
					file.Close();
				}
			}
			
			if (command.responses.Count == 0)
				command.responses.Add("I have nothing funny to say");
			return true;
		}
	}
}
