/*
 * Created by SharpDevelop.
 * User: Peter
 * Date: 24.12.2014
 * Time: 17:14
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Speech2Keys
{
	/// <summary>
	/// Description of KeyPhraseForm.
	/// </summary>
	public partial class KeyPhraseForm : Form, IWorkflow
	{		
		public Workflow Workflow{get;set;}
		
		public KeyPhraseForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			keyPhraseTextBox.KeyUp += TextBoxKeyUp;
			keyPhraseListBox.KeyUp += ListBoxKeyUp;
			keyPhraseListBox.MouseDoubleClick += ListBoxMouseDoubleClick;
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void ListBoxKeyUp(object sender, KeyEventArgs  e)
		{
			if (e.KeyCode == Keys.Delete)
		    {
				for (int i = keyPhraseListBox.SelectedIndices.Count-1; i >= 0; i--)
					if (keyPhraseListBox.SelectedIndices[i] >=0)
						keyPhraseListBox.Items.RemoveAt(keyPhraseListBox.SelectedIndices[i]);		
			}
			keyPhraseTextBox.Focus();
			e.Handled = true;
		}
		
		void ListBoxMouseDoubleClick(object sender, MouseEventArgs e)
	    {
		    if (keyPhraseListBox.SelectedIndex!= -1)
		    	keyPhraseTextBox.Text = (string)(keyPhraseListBox.SelectedItems[0]);
		    
		    for (int i = keyPhraseListBox.SelectedIndices.Count-1; i >= 0; i--)
					if (keyPhraseListBox.SelectedIndices[i] >=0)
						keyPhraseListBox.Items.RemoveAt(keyPhraseListBox.SelectedIndices[i]);	
		    
		    keyPhraseTextBox.Focus();
	    }
		
		void TextBoxKeyUp(object sender, KeyEventArgs  e)
		{
			if (e.KeyCode == Keys.Enter)
		    {
				bool found = false;
				foreach (var i in keyPhraseListBox.Items)
					if (keyPhraseTextBox.Text == (string)i )
						found = true;
				if (!found)
				{
					keyPhraseListBox.Items.Add(keyPhraseTextBox.Text);
					keyPhraseTextBox.Text = "";
				}
				e.Handled = true;
			}
			if (e.KeyCode == Keys.Tab)
			{
				NextButtonClick(sender, e);
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
			this.keyPhraseListBox.Items.Clear();
			this.keyPhraseTextBox.Text = "";
		}
		
		public void Fill(Command command)
		{
			this.keyPhraseTextBox.Text = "";
			this.keyPhraseListBox.Items.Clear();
			foreach (var k in command.keyPhrases)
				this.keyPhraseListBox.Items.Add(k);
		}
		
		public bool GetData(Command command)
		{
			command.keyPhrases.Clear();
			foreach (var k in this.keyPhraseListBox.Items)
				command.keyPhrases.Add((string) k);
			if (!string.IsNullOrEmpty(keyPhraseTextBox.Text) && !command.keyPhrases.Contains(this.keyPhraseTextBox.Text))
				command.keyPhrases.Add(this.keyPhraseTextBox.Text);
			
			if (command.keyPhrases.Count == 0)
			{
				Workflow.parentForm.AddMessage("At least one keyphrase must be assigned!");
				keyPhraseTextBox.Focus();
			}
			if ((!Workflow.CheckConflictingKeyPhrases(command)) || command.keyPhrases.Count == 0)
				return false;
			
			return true;
		}
		
		public void SetKeyPhrases(List<string> phrases)
		{
			keyPhraseTextBox.Clear();
			keyPhraseListBox.Items.Clear();
			foreach (var p in phrases)
				keyPhraseListBox.Items.Add(p);
		}
		
		public List<string> GetKeyPhrases()
		{
			var result = new List<string>();
			
			foreach (var i in keyPhraseListBox.Items)
				result.Add((string)i);
			
			string text = keyPhraseTextBox.Text;
			if (!(string.IsNullOrEmpty(text) || result.Contains(text)))
				result.Add(keyPhraseTextBox.Text);
			
			return result;
		}
		
		void NextButtonClick(object sender, EventArgs e)
		{
			Workflow.NextWorkflowStep();
		}
		void BackButtonClick(object sender, EventArgs e)
		{
			Workflow.PreviousWorkflowStep();
		}
		void CancelButtonClick(object sender, EventArgs e)
		{
			Workflow.AbortWorkflow();
		}
		
		public void ShowBackButton()
		{
			this.backButton.Show();
		}
		public void HideBackButton()
		{
			this.backButton.Hide();
		}
		
		public void FocusOnShow()
		{
			keyPhraseTextBox.Focus();
		}
	}
}
