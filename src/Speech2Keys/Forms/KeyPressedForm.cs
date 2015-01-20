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
		int lastKeyInsertIndex;
		int numberOfSelectedItems;
		bool LastActionWasHighlight;
		bool mouseJustUp;
			
		
		public KeyPressedForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
		
			
//			sequenceTextBox.KeyDown += SequenceKeyDown;
//			sequenceTextBox.KeyUp += SequenceKeyUp;
			//sequenceListBox.KeyUp += SequenceListKeyUp;
			
			sequenceListBox.KeyUp += SequenceListKeyUp;
			sequenceListBox.KeyDown += SequenceListKeyDown;
			sequenceListBox.MouseDown += SequenceListMouseDown;
			sequenceListBox.MouseUp += SequenceListMouseUp;
			
			
			lastPressedKey = "none";
			numberOfSelectedItems = 0;
			LastActionWasHighlight = false;
			lastKeyInsertIndex = -1;
			mouseJustUp = false;
			
			
			
		
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void SequenceListMouseDown(object sender, MouseEventArgs  e)
		{
			int count = sequenceListBox.Items.Count;
			
			
			if (count > 0 )
				if (lastKeyInsertIndex != -1 
				    && lastKeyInsertIndex < sequenceListBox.Items.Count 
				    &&(((string)sequenceListBox.Items[lastKeyInsertIndex]) == "shift down" || ((string)sequenceListBox.Items[lastKeyInsertIndex]) == "control down"))
				{
					sequenceListBox.Items.RemoveAt(lastKeyInsertIndex);
					lastKeyInsertIndex = -1;
				}
		}
		void SequenceListMouseUp(object sender, MouseEventArgs  e)
		{
			mouseJustUp = true;
		}
		
		void SequenceKeyUp(object sender, KeyEventArgs  e)
		{
		/*	if (LastActionWasHighlight && e.KeyCode == Keys.Delete)
			{
				LastActionWasHighlight  = false;
				return;
			}
			
			numberOfSelectedItems = sequenceListBox.SelectedIndices.Count;
			LastActionWasHighlight = false;
			string pressedKey = KeyTranslator.TranslateKeyToString(e.KeyCode) + " up";	
			if (lastPressedKey != pressedKey)
			{
				lastPressedKey = pressedKey;
				AddAfterSelection(pressedKey);
				//sequenceListBox.Items.Add(pressedKey);		
			}
			e.Handled = true;*/
		}
		
		void SequenceKeyDown(object sender, KeyEventArgs  e)
		{
		/*	if (LastActionWasHighlight && e.KeyCode == Keys.Delete)
			{
				for (int i = sequenceListBox.SelectedIndices.Count-1; i >= 0; i--)
					if (sequenceListBox.SelectedIndices[i] >=0)
						sequenceListBox.Items.RemoveAt(sequenceListBox.SelectedIndices[i]);
					//iller.Focus();
				sequenceListBox.ClearSelected();
				numberOfSelectedItems = 0;
				return;
			}
			
			numberOfSelectedItems = sequenceListBox.SelectedIndices.Count;
			LastActionWasHighlight = false;
			string pressedKey = KeyTranslator.TranslateKeyToString(e.KeyCode) + " down";
			if (lastPressedKey != pressedKey)
			{
				lastPressedKey = pressedKey;
				AddAfterSelection(pressedKey);
				//sequenceListBox.Items.Add(pressedKey);		
			}
			e.Handled = true;*/
		}

		void SequenceListKeyUp(object sender, KeyEventArgs  e)
		{
			/*if (e.KeyCode == Keys.Delete)
		    {
				
					LastActionWasHighlight = false;
					for (int i = sequenceListBox.SelectedIndices.Count-1; i >= 0; i--)
						if (sequenceListBox.SelectedIndices[i] >=0)
							sequenceListBox.Items.RemoveAt(sequenceListBox.SelectedIndices[i]);
					//iller.Focus();
					sequenceListBox.ClearSelected();
					numberOfSelectedItems = 0;
					
			}
			if (numberOfSelectedItems !=  sequenceListBox.SelectedIndices.Count)
			{
				numberOfSelectedItems = sequenceListBox.SelectedIndices.Count;
				LastActionWasHighlight = true;;
			}
		
			sequenceTextBox.Focus();
						
			e.Handled = true;
			*/

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
		}
		
		public void Clear()
		{
			numberOfSelectedItems = 0;	
			LastActionWasHighlight = false;
			lastPressedKey = "none";
			lastKeyInsertIndex = -1;
			sequenceListBox.Items.Clear();
			sequenceListBox.Focus();
			
		
		}
		
		public void Fill(Command command)
		{
			
			
			sequenceListBox.Items.Clear();
			foreach (var s in command.sequence)
				sequenceListBox.Items.Add(s);
			sequenceListBox.Focus();
			lastKeyInsertIndex = -1;
			lastPressedKey = "none";
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
			lastKeyInsertIndex = -1;
		}
		void SequenceTextBoxTextChanged(object sender, EventArgs e)
		{
		//	sequenceTextBox.Clear();
		}
		List<string> GetSequence()
		{
			var result = new List<string>();
			foreach (var i in sequenceListBox.Items)
				result.Add((string)i);
			return result;
		}
		void SetSequence(List<string> sequence)
		{
			sequenceListBox.Items.Clear();
			foreach (var s in sequence)
				sequenceListBox.Items.Add(s);
			sequenceListBox.Focus();
		}
		void ClearButtonClick(object sender, EventArgs e)
		{
			numberOfSelectedItems = 0;
			LastActionWasHighlight = false;
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
		
		void AddKey(string key)
		{
			var newItems = new List<string>();
			var newSelectedIndices = new List<int>();
			if (sequenceListBox.SelectedIndices.Count == 0)
			{
				sequenceListBox.Items.Add(key);
			}
			else
			{
				for (int i = 0; i < sequenceListBox.Items.Count; ++i)
				{
					newItems.Add((string)(sequenceListBox.Items[i]));
					if (sequenceListBox.SelectedIndices.Contains(i))
					{
						newItems.Add(key);
						newSelectedIndices.Add(i);
					}
				}
				sequenceListBox.Items.Clear();
				foreach (var n in newItems)
					sequenceListBox.Items.Add(n);
			}
			foreach (var s in newSelectedIndices)
				sequenceListBox.SetSelected(s, true);
			sequenceListBox.Focus();
		}
		
		void AddAfterSelection(string key)
		{
			
			if (sequenceListBox.SelectedIndices.Count == 1 && sequenceListBox.SelectedIndices[0] >= 0)
			{
				int index = sequenceListBox.SelectedIndices[0];
				var newItems = new List<string>();
				lastKeyInsertIndex = index+1;
				for (int i = 0; i < sequenceListBox.Items.Count; ++i)
				{
					newItems.Add((string)(sequenceListBox.Items[i]));
					if (i == index)
						newItems.Add(key);
				}
				sequenceListBox.Items.Clear();
				foreach (var n in newItems)
						sequenceListBox.Items.Add(n);
				sequenceListBox.SelectedIndex = index+1;
			}
			else
			{
				lastKeyInsertIndex = sequenceListBox.SelectedIndices.Count;
				sequenceListBox.Items.Add(key);					
			}
		}
		void DeleteSelectedButtonClick(object sender, EventArgs e)
		{
			for (int i = sequenceListBox.SelectedIndices.Count-1; i >= 0; i--)
				if (sequenceListBox.SelectedIndices[i] >=0)
					sequenceListBox.Items.RemoveAt(sequenceListBox.SelectedIndices[i]);
			sequenceListBox.ClearSelected();
			numberOfSelectedItems = 0;
			sequenceListBox.Focus();
		}
		
		
			
		
	}
}
