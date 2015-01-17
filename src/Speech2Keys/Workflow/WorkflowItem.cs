/*
 * Created by SharpDevelop.
 * User: Peter
 * Date: 25.12.2014
 * Time: 23:38
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;

namespace Speech2Keys
{
	/// <summary>
	/// Description of WorkflowItem.
	/// </summary>
	public abstract class WorkflowItem : IWorkflowItem
	{
		public Form form;
		public Command existingCommand;	
		public abstract bool FillCommandWithData(Command command);
		public abstract void InitializeForm(Command command);
	
		protected WorkflowItem(Form _form) {form = _form;}
	}
}
