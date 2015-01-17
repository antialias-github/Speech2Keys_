/*
 * Created by SharpDevelop.
 * User: Peter
 * Date: 24.12.2014
 * Time: 11:10
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Speech2Keys
{
	/// <summary>
	/// Description of ProfileNameForm.
	/// </summary>
	public partial class ProfileNameForm : Form, IWorkflow
	{
		public Workflow Workflow{get;set;}
		
		public ProfileNameForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			profileNameTextBox.KeyUp += TextBoxKeyUp;
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void TextBoxKeyUp(object sender, KeyEventArgs  e)
		{
			if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
			{
				FinishButtonClick(sender, e);	
				e.Handled = true;
			}
			if (e.KeyCode == Keys.Escape)
			{
				CancelButtonClick(sender, e);
				e.Handled = true;
			}
		}
		
		public void Clear()
		{
			this.profileNameTextBox.Text = "";
		}
		
		public void Fill(string text)
		{
			this.profileNameTextBox.Text = text;
			profileNameTextBox.SelectionStart = 0;
  			profileNameTextBox.SelectionLength = profileNameTextBox.Text.Length;
		}
		
		public bool GetData (out string text)
		{
			text = this.profileNameTextBox.Text;
			if (string.IsNullOrEmpty(this.profileNameTextBox.Text))
			{
				profileNameTextBox.Focus();
				return false;
			}
			return true;
		}
		
		public void SetData (string text)
		{
			this.profileNameTextBox.Text = text;
		}
		
		void FinishButtonClick(object sender, EventArgs e)
		{
			Workflow.EndWorkflow();
		}
		void CancelButtonClick(object sender, EventArgs e)
		{
			Workflow.AbortWorkflow();
		}
		
		public void FocusOnShow()
		{
			profileNameTextBox.Focus();	
		}
	}
}
