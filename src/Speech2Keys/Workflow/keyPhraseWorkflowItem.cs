/*
 * Created by SharpDevelop.
 * User: Peter
 * Date: 26.12.2014
 * Time: 23:20
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;

namespace Speech2Keys
{
	/// <summary>
	/// Description of keyPhraseWorkflowItem.
	/// </summary>
	public class KeyPhraseWorkflowItem : WorkflowItem
	{
		public KeyPhraseWorkflowItem(Form form) : base(form){}
		public override void InitializeForm(Command command)
		{
			((KeyPhraseForm)form).Clear();
			// if such a command already exists then prefill the list box
			if (command != null)
				((KeyPhraseForm)form).Fill(command);
		}
		
		public override bool FillCommandWithData(Command command)
		{
			return ((KeyPhraseForm)form).GetData(command);
		}
		
	}
}
