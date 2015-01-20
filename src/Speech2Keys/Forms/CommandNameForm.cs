/*
 * Created by SharpDevelop.
 * User: Peter
 * Date: 24.12.2014
 * Time: 10:47
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Speech2Keys
{
	/// <summary>
	/// Description of CommandNameForm.
	/// </summary>
	public partial class CommandNameForm : Form, IWorkflow
	{
	
		public Workflow Workflow{get;set;}	
	
		
		public CommandNameForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			CommandNameTextBox.KeyUp += TextBoxKeyUp;
		
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void TextBoxKeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
		 	{
		 		e.Handled = true;
		 		NextButtonClick(sender, e);
		 	}
			if (e.KeyCode == Keys.Escape)
			{
				CancelButtonClick(sender, e);
				e.Handled = true;
			}
		}
		
		public void Clear()
		{
			this.CommandNameTextBox.Text = "";
		}
		
		public void Fill(Command command)
		{
			this.CommandNameTextBox.Text = command.name;
		}
		
		public bool GetData(Command command)
		{
			command.name = this.CommandNameTextBox.Text;
			
			if (Workflow.CommandNameIsDuplicate(command))
				Workflow.parentForm.AddMessage("Warning: The already defined command "+ command.name.ToUpper()+" will be overwritten");
			
			if (string.IsNullOrEmpty(this.CommandNameTextBox.Text))
			{
				CommandNameTextBox.Focus();
				return false;
			}
			return true;
		}
		void NextButtonClick(object sender, EventArgs e)
		{
			Workflow.NextWorkflowStep();
		}
		void CancelButtonClick(object sender, EventArgs e)
		{
			Workflow.AbortWorkflow();
		}
		public void FocusOnShow()
		{
			CommandNameTextBox.Focus();
		}
	}
}
