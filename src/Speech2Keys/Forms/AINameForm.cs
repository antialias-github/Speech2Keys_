/*
 * Created by SharpDevelop.
 * User: Peter
 * Date: 24.12.2014
 * Time: 15:46
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Speech2Keys
{
	/// <summary>
	/// Description of AINameForm.
	/// </summary>
	public partial class AINameForm : Form, IWorkflow
	{
	
		public Workflow Workflow{get;set;}
		
		public AINameForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			AINameTextBox.KeyUp += TextBoxKeyUp;
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void TextBoxKeyUp(object sender, KeyEventArgs  e)
		{
			if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
		 	{
		 		e.Handled = true;
		 		FinishButtonClick(sender, e);
		 	}
			if (e.KeyCode == Keys.Escape)
			{
				CancelButtonClick(sender, e);
				e.Handled = true;
			}
		}
		
		public void Clear()
		{
			this.AINameTextBox.Text = "";
		}
		
		void FinishButtonClick(object sender, EventArgs e)
		{
			Workflow.EndWorkflow();
		}
		
		void CancelButtonClick(object sender, EventArgs e)
		{
			Workflow.AbortWorkflow();
		}
		
		public string GetAIName()
		{
			return this.AINameTextBox.Text;
		}
		
		public void SetAIName(string text)
		{
			this.AINameTextBox.Text = text;
			AINameTextBox.SelectionStart = 0;
  			AINameTextBox.SelectionLength = AINameTextBox.Text.Length;	
		}
		
		public void FocusOnShow()
		{
			AINameTextBox.Focus();
		}
		                        
	}
}
