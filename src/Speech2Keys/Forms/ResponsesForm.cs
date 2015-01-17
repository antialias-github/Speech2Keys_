/*
 * Created by SharpDevelop.
 * User: Peter
 * Date: 24.12.2014
 * Time: 10:48
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Speech.Synthesis;

namespace Speech2Keys
{
	/// <summary>
	/// Description of ResponsesForm.
	/// </summary>
	public partial class ResponsesForm : Form, IWorkflow
	{
		public Workflow Workflow{get;set;}
		SpeechSynthesizer synthesizer;
		public ResponsesForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			responsesTextBox.KeyUp += TextBoxKeyUp;
			responsesListBox.KeyUp += ListBoxKeyUp;
			responsesListBox.MouseDoubleClick += ListBoxMouseDoubleClick;
			synthesizer = new SpeechSynthesizer();
			synthesizer.Volume = 100; 
            synthesizer.Rate = -2;
		}
		
		void ListBoxMouseDoubleClick(object sender, MouseEventArgs e)
	    {
		    if (responsesListBox.SelectedIndex!= -1)
		    {
		    	responsesTextBox.Text = (string)(responsesListBox.SelectedItems[0]);
		    	
		    	for (int i = responsesListBox.SelectedIndices.Count-1; i >= 0; i--)
					if (responsesListBox.SelectedIndices[i] >=0)
						responsesListBox.Items.RemoveAt(responsesListBox.SelectedIndices[i]);	
		    }
		    responsesTextBox.Focus();
	    }
		
		void ListBoxKeyUp(object sender, KeyEventArgs  e)
		{
			if (e.KeyCode == Keys.Delete)
		    {
				for (int i = responsesListBox.SelectedIndices.Count-1; i >= 0; i--)
					if (responsesListBox.SelectedIndices[i] >=0)
						responsesListBox.Items.RemoveAt(responsesListBox.SelectedIndices[i]);	
				responsesTextBox.Focus();
				e.Handled = true;
			}	
			if (e.KeyCode == Keys.Escape)
			{
				CancelButtonClick(sender, e);
				e.Handled = true;
			}
		}
		
		void TextBoxKeyUp(object sender, KeyEventArgs  e)
		{
			if (e.KeyCode == Keys.Enter)
		    {
				bool found = false;
				foreach (var i in responsesListBox.Items)
					if (responsesTextBox.Text == (string)i )
						found = true;
				if (!found)
				{
					responsesListBox.Items.Add(responsesTextBox.Text);
					synthesizer.SpeakAsync(responsesTextBox.Text);
					responsesTextBox.Text = "";
				}
			}
			if (e.KeyCode == Keys.Tab)
				FinishButtonClick(sender, e);
			e.Handled = true;
		}
		
		public void Clear()
		{
			this.responsesTextBox.Text = "";
			this.responsesListBox.Items.Clear();
			this.standardResponsesCheckBox.Checked = false;
			this.playBeforeExecutionCheckBox.Checked = false;
		}
		
		public void Fill(Command command)
		{
			this.responsesTextBox.Text = "";
			this.standardResponsesCheckBox.Checked = command.useStandardResponses;
			this.playBeforeExecutionCheckBox.Checked = !(command.responseInPost);
			foreach (var r in command.responses)
				this.responsesListBox.Items.Add(r);
		}
		
		public bool GetData(Command command)
		{
			command.responses.Clear();
			command.useStandardResponses = this.standardResponsesCheckBox.Checked;
			command.responseInPost = !(this.playBeforeExecutionCheckBox.Checked);
			foreach (var r in responsesListBox.Items)
				command.responses.Add((string)r);
			if (! string.IsNullOrEmpty(this.responsesTextBox.Text))
				command.responses.Add(this.responsesTextBox.Text);
			return true;
		}
		
		public List<string> GetResponses()
		{
			var result = new List<string>();
			foreach (var r in responsesListBox.Items)
				result.Add((string)r);
			if (! string.IsNullOrEmpty(this.responsesTextBox.Text))
				result.Add(this.responsesTextBox.Text);
			
			return result;
		}
		
		public void SetData( List<string> reponses)
		{
			Clear();
			foreach (var r in reponses)
				this.responsesListBox.Items.Add(r);
		}
		
		void FinishButtonClick(object sender, EventArgs e)
		{
			Workflow.EndWorkflow();
		}
		void CancelButtonClick(object sender, EventArgs e)
		{
			Workflow.AbortWorkflow();
		}
		void BackButtonClick(object sender, EventArgs e)
		{
			Workflow.PreviousWorkflowStep();
		}
		public void ShowBackButton()
		{
			this.backButton.Show();
		}
		public void HideBackButton()
		{
			this.backButton.Hide();
		}
		
		public void HideStandardResponses (bool enabled)
		{
			standardResponsesCheckBox.Enabled = enabled;
			playBeforeExecutionCheckBox.Enabled = enabled;
		}
		public void FocusOnShow()
		{
			responsesTextBox.Focus();
		}		
		
	}
}
