/*
 * Created by SharpDevelop.
 * User: Peter
 * Date: 27.12.2014
 * Time: 03:27
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;

namespace Speech2Keys
{
	/// <summary>
	/// Description of ProfileNameWorkflowItem.
	/// </summary>
	public class ProfileNameWorkflowItem : WorkflowItem
	{
		public ProfileNameWorkflowItem(Form form) : base(form){}
		
		public override void InitializeForm(Command command)
		{
			((ProfileNameForm)form).Clear();
		}
		
		public override bool FillCommandWithData(Command command)
		{
			return true;
		}
	}
}
