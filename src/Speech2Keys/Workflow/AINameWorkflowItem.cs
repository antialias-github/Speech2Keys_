/*
 * Created by SharpDevelop.
 * User: Peter
 * Date: 26.12.2014
 * Time: 00:24
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;

namespace Speech2Keys
{
	/// <summary>
	/// Description of AINameWorkflowItem.
	/// </summary>
	public class AINameWorkflowItem : WorkflowItem
	{
		public AINameWorkflowItem(Form form): base(form){}
	
		public override void InitializeForm(Command command)
		{
			// if such a command already exists then prefill the textbox
			((AINameForm)form).Clear();
			if (command != null)
				if (command.keyPhrases.Count != 0)
					((AINameForm)form).SetAIName(command.keyPhrases[0]);
		}
		
		public override bool FillCommandWithData(Command command)
		{
			string aIName = ((AINameForm)form).GetAIName();
			if (string.IsNullOrEmpty(aIName))
				return false;

			command.keyPhrases.Add(aIName);
			command.responses.Add("Listening");
			return true;
		}
	}
}
