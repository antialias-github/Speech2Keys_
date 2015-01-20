/*
 * Created by SharpDevelop.
 * User: Peter
 * Date: 24.12.2014
 * Time: 14:34
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
	/// Description of KeyPressedForm.
	/// </summary>
	public partial class KeyPressedForm : Form, IWorkflow
	{
		public Workflow Workflow{get;set;}
		string lastPressedKey;
		int mouseSelectedIndex;
		bool mouseJustUp;
		
		
			
		
		public KeyPressedForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
	
			sequenceListBox.KeyUp += SequenceListKeyUp;
			sequenceListBox.KeyDown += SequenceListKeyDown;
			sequenceListBox.MouseDown += SequenceListMouseDown;
			sequenceListBox.MouseUp += SequenceListMouseUp;
			mouseSelectedIndex = -1;
			
			lastPressedKey = "none";

			
			mouseJustUp = false;
			
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void SequenceListMouseDown(object sender, MouseEventArgs  e)
		{
			int count = sequenceListBox.Items.Count;
			if (count > 0 ) // there is a selected item
				if (mouseSelectedIndex != -1 // there is one item selected by mouse
				    && mouseSelectedIndex < sequenceListBox.Items.Count 
				    &&(((string)sequenceListBox.Items[mouseSelectedIndex]) == "control down")) //and it was control
						sequenceListBox.Items.RemoveAt(mouseSelectedIndex); // then remove it because that control was supposed to be used to mark multiple entries and not a valid entry in the sequence
				
			mouseJustUp = false;
		}
		void SequenceListMouseUp(object sender, MouseEventArgs  e)
		{
			mouseJustUp = true;
			if (sequenceListBox.SelectedIndices.Count == 1)
				mouseSelectedIndex = sequenceListBox.SelectedIndices[0];
			else
			{
				mouseSelectedIndex = -1;
			}
		}
		
		void SequenceListKeyUp(object sender, KeyEventArgs  e)
		{
			string pressedKey = KeyTranslator.TranslateKeyToString(e.KeyCode) + " up";	
			
			if (mouseJustUp && (pressedKey == "control up" || pressedKey == "shift up" ))
				lastPressedKey = "none";
			
			else 
				if (lastPressedKey != pressedKey)
				{
					lastPressedKey = pressedKey;
					AddAfterSelection(pressedKey);	
					mouseJustUp = false;
				}
			e.Handled = true;
		}
		
		void SequenceListKeyDown(object sender, KeyEventArgs  e)
		{
			string pressedKey = KeyTranslator.TranslateKeyToString(e.KeyCode)+ " down";	
			if (lastPressedKey != pressedKey)
			{
				lastPressedKey = pressedKey;
				AddAfterSelection(pressedKey);	
				mouseJustUp = false;
			}
			e.Handled = true;
		}
		
		public void Clear()
		{
			lastPressedKey = "none";
			sequenceListBox.Items.Clear();
			sequenceListBox.Focus();
			mouseSelectedIndex = -1;
		}
		
		public void Fill(Command command)
		{
			sequenceListBox.Items.Clear();
			foreach (var s in command.sequence)
				sequenceListBox.Items.Add(s);
			sequenceListBox.Focus();
			lastPressedKey = "none";
			mouseSelectedIndex = sequenceListBox.Items.Count -1;
			sequenceListBox.SelectedIndex = mouseSelectedIndex;
		}
		
		public bool GetData(Command command)
		{
			int upCount = 0;
			int downCount = 0;
			foreach (var i in sequenceListBox.Items)
			{
				if (((string)i).EndsWith(" up"))
					upCount++;
				if (((string)i).EndsWith(" down"))
					downCount++;
			}
			if (upCount != downCount && (command.name != "Teamspeak on"  && command.name != "Teamspeak off"))
			{
				Workflow.parentForm.AddMessage("number of key-up actions does not match number of key-down actions.\n Keys not added");
				return false;
			}
			command.sequence.Clear();
			foreach (var i in sequenceListBox.Items)
				command.sequence.Add((string)i);
			
			if (command.sequence.Count == 0)
				command.sequence.Add("none");
			
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
		void BackButtonClick(object sender, EventArgs e)
		{
			Workflow.PreviousWorkflowStep();
		}
		
		
	
		
		
		
		public void FocusOnShow()
		{
			sequenceListBox.Focus();
			lastPressedKey = "none";
		}
		void SequenceTextBoxTextChanged(object sender, EventArgs e)
		{
		//	sequenceTextBox.Clear();
		}
		
		void ClearButtonClick(object sender, EventArgs e)
		{
			sequenceListBox.Items.Clear();
			sequenceListBox.Focus();
		}
		void PauseTenthSecondButtonClick(object sender, EventArgs e)
		{
			AddPause("Pause: 0.1 seconds");
		}
		void PauseHalfSecondButtonClick(object sender, EventArgs e)
		{
			AddPause("Pause: 0.5 seconds");
		}
		void PauseFullSecondButtonClick(object sender, EventArgs e)
		{
			AddPause("Pause: 1 second");
		}
		void PauseTwoSecondsButtonClick(object sender, EventArgs e)
		{
			AddPause("Pause: 2 seconds");
		}
		void AddPause(string pause)
		{
			var newItems = new List<string>();
			if (sequenceListBox.SelectedIndices.Count == 0)
			{
				sequenceListBox.Items.Add(pause);
			}
			else
			{
				for (int i = 0; i < sequenceListBox.Items.Count; ++i)
				{
					newItems.Add((string)(sequenceListBox.Items[i]));
					if (sequenceListBox.SelectedIndices.Contains(i))
						newItems.Add(pause);
				}
				sequenceListBox.Items.Clear();
				foreach (var n in newItems)
					sequenceListBox.Items.Add(n);
			}
			sequenceListBox.ClearSelected();
			sequenceListBox.Focus();
		}
		
	
		void AddAfterSelection(string key)
		{
			if (key == "none")
				return;
			sequenceListBox.ClearSelected();
			
			if (mouseSelectedIndex != -1 && mouseSelectedIndex < sequenceListBox.Items.Count)
			{
				var newItems = new List<string>();
				for (int i = 0; i < sequenceListBox.Items.Count; ++i)
				{
					newItems.Add((string)(sequenceListBox.Items[i]));
					if (i == mouseSelectedIndex)
						newItems.Add(key);
				}
				mouseSelectedIndex++;
				sequenceListBox.Items.Clear();
				foreach (var n in newItems)
						sequenceListBox.Items.Add(n);
				sequenceListBox.SelectedIndex = mouseSelectedIndex;
			}
			else
			{
				sequenceListBox.Items.Add(key);	
				mouseSelectedIndex = sequenceListBox.Items.Count -1;
				sequenceListBox.SelectedIndex = mouseSelectedIndex;
			}
		}
		void DeleteSelectedButtonClick(object sender, EventArgs e)
		{
			
			for (int i = sequenceListBox.SelectedIndices.Count-1; i >= 0; i--)
				if (sequenceListBox.SelectedIndices[i] >=0)
					sequenceListBox.Items.RemoveAt(sequenceListBox.SelectedIndices[i]);
			
			
			var newItems = new List<string>();
			for (int i = 0; i < sequenceListBox.Items.Count; ++i)
				newItems.Add((string)(sequenceListBox.Items[i]));
			sequenceListBox.Items.Clear();
			foreach (var n in newItems)
					sequenceListBox.Items.Add(n);

			if (sequenceListBox.Items.Count > 0)
			{
				mouseSelectedIndex = sequenceListBox.Items.Count -1;
				sequenceListBox.SelectedIndex = mouseSelectedIndex;
			}
			else
				mouseSelectedIndex = -1;
			
			sequenceListBox.Focus();
		}
		
		
			
		
	}
}
