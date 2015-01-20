/*
 * Created by SharpDevelop.
 * User: Peter
 * Date: 24.12.2014
 * Time: 12:08
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
	/// Description of ParentForm.
	/// </summary>
	public partial class ParentForm : Form
	{
		public CommandList commandList;
		
		AINameForm aINameForm;
		CommandNameForm commandNameForm;
		KeyPhraseForm keyPhraseForm;
		ProfileNameForm profileNameForm;
		ResponsesForm responsesForm;
		KeyPressedForm keyPressedForm;
		JokesForm jokesForm;

		SpeechSynthesizer synthesizer;
		RecognitionWorker recognitionWorker;
		
		public	List<Form> commandWorkflow;
		public	List<Form> specialWorkflow;
		public	List<Form> jokesWorkflow;
		public	List<Form> aINameWorkflow;
		public	List<Form> profileNameWorkflow;
		public  List<Form> allForms;
		public  Workflow workflow;
		
		bool running;
		public bool error;
				
		public ParentForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			running = false;
			error = false;
			
			commandsListBox.KeyUp += ListBoxKeyUp;
			commandsListBox.MouseClick += ListBoxMouseClick;
			commandsListBox.MouseDoubleClick += ListBoxMouseDoubleClick;
			
		
			
			
			this.KeyUp += FormKeyUp;
			
			
			commandNameForm = new CommandNameForm();	
			commandNameForm.FormBorderStyle = FormBorderStyle.None;
			keyPressedForm = new KeyPressedForm();		
			keyPressedForm.FormBorderStyle = FormBorderStyle.None;
			keyPhraseForm = new KeyPhraseForm();	
			keyPhraseForm.FormBorderStyle = FormBorderStyle.None;
			responsesForm = new ResponsesForm();		
			responsesForm.FormBorderStyle = FormBorderStyle.None;
			profileNameForm = new ProfileNameForm();		
			profileNameForm.FormBorderStyle = FormBorderStyle.None;
			jokesForm = new JokesForm();			
			jokesForm.FormBorderStyle = FormBorderStyle.None;
			aINameForm = new AINameForm();
			aINameForm.FormBorderStyle = FormBorderStyle.None;
			
			commandWorkflow = new List<Form>();
			commandWorkflow.Add(commandNameForm);
			commandWorkflow.Add(keyPressedForm);
			commandWorkflow.Add(keyPhraseForm);
			commandWorkflow.Add(responsesForm);
			
			specialWorkflow = new List<Form>();
			specialWorkflow.Add(keyPhraseForm);
			specialWorkflow.Add(responsesForm);
			
			jokesWorkflow = new List<Form>();
			jokesWorkflow.Add(keyPhraseForm);
			jokesWorkflow.Add(jokesForm);
			
			aINameWorkflow = new List<Form>();
			aINameWorkflow.Add(aINameForm);
			
			profileNameWorkflow = new List<Form>();
			profileNameWorkflow.Add(profileNameForm);
			
			allForms = new List<Form>();
			allForms.Add(commandNameForm);
			allForms.Add(keyPressedForm);
			allForms.Add(keyPhraseForm);
			allForms.Add(responsesForm);
			allForms.Add(jokesForm);
			allForms.Add(aINameForm);
			allForms.Add(profileNameForm);
			
			this.GotFocus += StopWorkflow;
			
			recognitionWorker = new RecognitionWorker(this);
			synthesizer = new SpeechSynthesizer();
			synthesizer.Volume = 100; 
            synthesizer.Rate = -2;  
            
           
		}
		
		
		
		
		
		public void EnableStopButton (bool enable)
		{
			stopButton.Enabled = enable;
		}
		
		void ListBoxMouseClick(object sender, MouseEventArgs e)
	    {
		    int index = commandsListBox.SelectedIndex;
		    if (index != -1)
		    {
		    	Command command = null;
		    	command = commandList.GetCommand((string)commandsListBox.SelectedItems[0]);
		    	DisplayCommand(command);
		    }
	    }
		
		public void DisplayCommand(Command command)
		{
			if (command != null)
		    	{
		    		logTextBox.AppendText("\n");
		    		logTextBox.AppendText("NAME: "+command.name+"\n");
		    		logTextBox.AppendText("ASSIGNED KEY(S): ");
		    		string text = "";
		    		foreach (var s in command.sequence)
		    			text += (s + " | ");
		    		if (text.EndsWith(" | "))
		    		    text.Remove(text.Length-4);
		    		logTextBox.AppendText(text + "\n");
		    		
		    		logTextBox.AppendText("KEYPHRASES: \n");
		    		foreach (var k in command.keyPhrases)
		    			logTextBox.AppendText(k+"\n");
		    		logTextBox.AppendText("USING STANDARD PHRASES: ");
		    		if (command.useStandardResponses)
		    			logTextBox.AppendText("yes \n");
		    		else
		    			logTextBox.AppendText("no \n");
		    		logTextBox.AppendText("RESPONSES: \n");
		    		if (command.responses.Count >= 10)
		    			logTextBox.AppendText("(more than 10...not listed to avoid flood)");
		    		else
		    			foreach (var r in command.responses)
		    				logTextBox.AppendText(r+"\n");
		    	}
		
		}
		
		void ListBoxMouseDoubleClick(object sender, MouseEventArgs e)
	    {
		    int index = commandsListBox.SelectedIndex;
		    addCommandButton.Focus();
		    if (index != -1)
		    {
		    	Command command = null;
		    	command = commandList.GetCommand((string)commandsListBox.SelectedItems[0]);
		   
		    	if (command != null)
		    		((ICanEdit)MdiParent).EditCommand(command.name);
		    }
	    }
		
		void ListBoxKeyUp(object sender, KeyEventArgs  e)
		{
			if (running)
			{
				e.Handled = true;
				label1.Focus();
				return;
			}
			if (e.KeyCode == Keys.Delete)
		    {
				for (int i = commandsListBox.SelectedIndices.Count-1; i >= 0; i--)
				{
					if (commandsListBox.SelectedIndices[i] >=0)
					{
						string name = (string)commandsListBox.Items[commandsListBox.SelectedIndices[i]];
						// do not remove standard commands
						if (! (name == "AIName" 
						       || name == "Jokes" 
						       || name == "Pause Speech Recognition"
						       || name == "Reactivate Speech Recognition"
						       || name == "Stop Speech Output"
						       || name == "Teamspeak on"
						       || name == "Teamspeak off"))
						{
							commandList.RemoveCommand(name);
							commandsListBox.Items.RemoveAt(commandsListBox.SelectedIndices[i]);
						}
					}
				}
				e.Handled = true;
			}
			addCommandButton.Focus();
			
		}
		
		void FormKeyUp (object sender, KeyEventArgs  e)
		{
			if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
			{
				AddCommandButtonClick(sender, e);
			}
		}
			
		void StopWorkflow(object sender, EventArgs e)
		{

		}
		
		public void AddMessage(string message)
		{
			logTextBox.AppendText("\n");
			logTextBox.AppendText(message);
			addCommandButton.Focus();
		}
		
		public void AddCommand(Command command)
		{
				commandsListBox.Items.Remove(commandList.commandToBeErased);
				bool found = false;
				foreach (var i in commandsListBox.Items)
					if (command.name == (string)i )
						found = true;
				if (!found)
					commandsListBox.Items.Add(command.name);
				
				SortCommands();
				
		}
	
		public void ChangeEnabled( bool enabled ) 
		{ 
		    foreach ( Control c in this.Controls ) 
		    { 
		        c.Enabled = enabled;     
		    } 
		} 
		
		public void FillCommandsListBox(CommandList commandList)
		{
			commandsListBox.Items.Clear();
			foreach (var c in commandList.listOfCommands)
				commandsListBox.Items.Add(c.name);
			
			SortCommands();
		}
		
		public void Clear()
		{
			commandsListBox.Items.Clear();
			logTextBox.Clear();
		}
		
		public TextBox GetLogBox()
		{
			return logTextBox;
		}
		public void StartButtonClick(object sender, EventArgs e)
		{
			if (commandList.listOfCommands.Count == 0)
			{
				AddMessage("No commands defined. Recognition not started.");
				return;
			}
			running = true;
			addCommandButton.Enabled = false;
			
			startButton.Enabled = false;
			((ICanEdit)MdiParent).EnableMenuStrip (false);
			
			stopButton.Enabled = true;
			//startButton.Enabled = false;
			AddMessage("Voice recognition is running");
			label1.Focus();
			recognitionWorker.StartRecognition(commandList);
			
		}
		void StopButtonClick(object sender, EventArgs e)
		{
			running = false;
			foreach(var c in this.Controls)
				((Control)c).Enabled = true;
			((ICanEdit)MdiParent).EnableMenuStrip (true);
			stopButton.Enabled = false;
			recognitionWorker.stopRecognition();
			startButton.Enabled = true;
			AddMessage("Voice recognition stopped");
		}
		void AddCommandButtonClick(object sender, EventArgs e)
		{
			((ICanEdit)MdiParent).EditCommand("");
		}
		public void SetListToName(string name)
		{
			commandsListBox.SelectedIndices.Clear();
			for (int i = 0; i < commandsListBox.Items.Count; ++i)
			{
				if (((string) commandsListBox.Items[i]) == name)
				{
					commandsListBox.SelectedIndex = i;
					break;
				}
			}
		}
		public void FocusOnShow(object sender, EventArgs e)
		{
			addCommandButton.Focus();
		}
		
		void SortCommands()
		{
			var list = new List<string>();
			foreach (var i in commandsListBox.Items)
				list.Add((string)i);
			list.Sort();
			commandsListBox.Items.Clear();
			foreach (var l in list)
				commandsListBox.Items.Add(l);
				
		}
		public void ErrorOnStartup()
		{
			error = true;
		}
	}
}
