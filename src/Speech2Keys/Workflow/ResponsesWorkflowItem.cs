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
using System.Collections.Generic;

namespace Speech2Keys
{
	/// <summary>
	/// Description of ResponsesWorkflowItem.
	/// </summary>
	public class ResponsesWorkflowItem : WorkflowItem
	{
		public ResponsesWorkflowItem(Form form): base (form)
		{
		}
		
		public override bool FillCommandWithData(Command command)
		{
			return ((ResponsesForm)form).GetData(command);
		}
		public override void InitializeForm(Command command)
		{
			((ResponsesForm)form).Clear();
			// if such a command already exists then prefill the list box
			if (command != null)
				((ResponsesForm)form).Fill(command);
		}
		public void InitializeForm(List<string> responses)
		{
			((ResponsesForm)form).Clear();
			// if such a command already exists then prefill the list box
			((ResponsesForm)form).SetData(responses);
		}
	}
}
