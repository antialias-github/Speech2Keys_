/*
 * Created by SharpDevelop.
 * User: Peter
 * Date: 27.12.2014
 * Time: 02:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;

namespace Speech2Keys
{
	/// <summary>
	/// Description of KeyPressWorkflowItem.
	/// </summary>
	public class KeyPressWorkflowItem : WorkflowItem
	{
		public KeyPressWorkflowItem(Form form): base (form)
		{
		}
		
		public override void InitializeForm(Command command)
		{
			((KeyPressedForm)form).Clear();
			// if such a command already exists then prefill the list box
			if (command != null)
				((KeyPressedForm)form).Fill(command);
		}
		
		public override bool FillCommandWithData(Command command)
		{
			return ((KeyPressedForm)form).GetData(command);
		}
	}
}
