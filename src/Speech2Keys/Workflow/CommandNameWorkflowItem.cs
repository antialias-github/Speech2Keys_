/*
 * Created by SharpDevelop.
 * User: Peter
 * Date: 27.12.2014
 * Time: 02:01
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;

namespace Speech2Keys
{
	/// <summary>
	/// Description of CommandNameWorkflowItem.
	/// </summary>
	public class CommandNameWorkflowItem : WorkflowItem
	{
		public CommandNameWorkflowItem(Form form): base (form)
		{}
		
		public override void InitializeForm(Command command)
		{
			((CommandNameForm)form).Clear();
			// if such a command already exists then prefill the list box
			if (command != null)
				((CommandNameForm)form).Fill(command);
		}
		
		public override bool FillCommandWithData(Command command)
		{
			return ((CommandNameForm)form).GetData(command);
		}
	}
}
