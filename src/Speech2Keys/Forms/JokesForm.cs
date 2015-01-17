/*
 * Created by SharpDevelop.
 * User: Peter
 * Date: 24.12.2014
 * Time: 15:45
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
	/// Description of JokesForm.
	/// </summary>
	public partial class JokesForm : Form, IWorkflow
	{
		public Workflow Workflow{get;set;}
		
		public bool clearJokes;
		
		public JokesForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			jokeFileNamesListBox.KeyUp += ListBoxKeyUp;
			clearJokes = false;
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void ListBoxKeyUp(object sender, KeyEventArgs  e)
		{
			if (e.KeyCode == Keys.Delete)
		    {
				for (int i = jokeFileNamesListBox.SelectedIndices.Count-1; i >= 0; i--)
					if (jokeFileNamesListBox.SelectedIndices[i] >=0)
						jokeFileNamesListBox.Items.RemoveAt(jokeFileNamesListBox.SelectedIndices[i]);
		        e.Handled = true;
		    }
			selectJokesbutton.Focus();
		}
		
		public void SetLabel(string text)
		{
			this.numberOfJokesLabel.Text = text;
		}
		
		public void Clear()
		{
			this.numberOfJokesLabel.Text = "0";
			jokeFileNamesListBox.Items.Clear();
		}
		
		public List<string> GetJokeFileNames()
		{
			var result = new List<string>();
			foreach (var i in jokeFileNamesListBox.Items)
				result.Add((string)i);
			return result;
		}
		
		public void ClearJokesButtonClick(object sender, EventArgs e)
		{
			clearJokes = true;
			Clear();
		}
		void CancelButtonClick(object sender, EventArgs e)
		{
			Workflow.AbortWorkflow();
		}
		void SelectJokesbuttonClick(object sender, EventArgs e)
		{
			DialogResult result = openFileDialog1.ShowDialog();
			if(result==DialogResult.OK)
			{
				if (!jokeFileNamesListBox.Items.Contains(openFileDialog1.FileName))
					jokeFileNamesListBox.Items.Add(openFileDialog1.FileName);
			}
		}
		void FinishButtonClick(object sender, EventArgs e)
		{
			Workflow.EndWorkflow();
		}
		void BackButtonClick(object sender, EventArgs e)
		{
			Workflow.PreviousWorkflowStep();
		}
		
		public void FocusOnShow()
		{
			selectJokesbutton.Focus();
		}
	}
}
