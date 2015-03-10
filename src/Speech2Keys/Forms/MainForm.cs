/*
 * Created by SharpDevelop.
 * User: Peter
 * Date: 24.12.2014
 * Time: 10:13
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace Speech2Keys
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form, ICanEdit
	{
		ParentForm parentForm;
		AINameForm aINameForm;
		CommandNameForm commandNameForm;
		KeyPhraseForm keyPhraseForm;
		ProfileNameForm profileNameForm;
		ResponsesForm responsesForm;
		KeyPressedForm keyPressedForm;
		JokesForm jokesForm;
		QuickLaunch quickLaunch;
		ErrorOnStartup errorOnStartup;
		
		
		public	Workflow commandWorkflow;
		public	Workflow reactivateWorkflow;
		public	Workflow pauseWorkflow;
		public	Workflow stopSpeechWorkflow;
		public	Workflow jokesWorkflow;
		public	Workflow aINameWorkflow;
		public	Workflow profileNameWorkflow;
		public  Workflow standardResponsesWorkflow;
		
		
		Command command;
		CommandList commandList;
		Workflow currentWorkflow;
		Serializer serializer;
		
		bool error;
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			error = false;
			InitializeComponent();
				
			serializer = new Serializer();
			
			parentForm = new ParentForm();
			FormatForm(parentForm, DockStyle.Fill);	
			if (parentForm.error)
				error = true;
			errorOnStartup = new ErrorOnStartup();
			FormatForm(errorOnStartup, DockStyle.Fill);	
			aINameForm = new AINameForm();
			FormatForm(aINameForm, DockStyle.None);	
			commandNameForm = new CommandNameForm();
			FormatForm(commandNameForm, DockStyle.None);		
			keyPhraseForm = new KeyPhraseForm();
			FormatForm(keyPhraseForm, DockStyle.None);	
			profileNameForm = new ProfileNameForm();
			FormatForm(profileNameForm, DockStyle.None);	
			responsesForm = new ResponsesForm();
			FormatForm(responsesForm, DockStyle.None);	
			keyPressedForm = new KeyPressedForm();
			FormatForm(keyPressedForm, DockStyle.None);	
			jokesForm = new JokesForm();
			FormatForm(jokesForm, DockStyle.None);	
			quickLaunch = new QuickLaunch();
			FormatForm(quickLaunch, DockStyle.Fill);
			quickLaunch.SecureStrip();
		
			
			command = new Command();
			commandList = new CommandList();	
			parentForm.commandList = commandList;
			quickLaunch.commandList = commandList;
			quickLaunch.parentForm = parentForm;
			
			// Setup a number of workflows
			aINameWorkflow = new Workflow();
			aINameWorkflow.AddItem(new AINameWorkflowItem(aINameForm));
			
			jokesWorkflow = new Workflow();
			jokesWorkflow.AddItem(new KeyPhraseWorkflowItem(keyPhraseForm));
			jokesWorkflow.AddItem(new JokesWorkflowItem(jokesForm));
			
			reactivateWorkflow = new Workflow();
			reactivateWorkflow.AddItem(new KeyPhraseWorkflowItem(keyPhraseForm));
			reactivateWorkflow.AddItem(new ResponsesWorkflowItem(responsesForm));
			
			pauseWorkflow = new Workflow();
			pauseWorkflow.AddItem(new KeyPhraseWorkflowItem(keyPhraseForm));
			pauseWorkflow.AddItem(new ResponsesWorkflowItem(responsesForm));
			
			stopSpeechWorkflow = new Workflow();
			stopSpeechWorkflow.AddItem(new KeyPhraseWorkflowItem(keyPhraseForm));
			stopSpeechWorkflow.AddItem(new ResponsesWorkflowItem(responsesForm));
		
			profileNameWorkflow = new Workflow();
			profileNameWorkflow.AddItem(new ProfileNameWorkflowItem(profileNameForm));
		
			commandWorkflow = new Workflow();
			commandWorkflow.AddItem(new CommandNameWorkflowItem(commandNameForm));
			commandWorkflow.AddItem(new KeyPressWorkflowItem(keyPressedForm));
			commandWorkflow.AddItem(new KeyPhraseWorkflowItem(keyPhraseForm));
			commandWorkflow.AddItem(new ResponsesWorkflowItem(responsesForm));
			
			standardResponsesWorkflow = new Workflow();
			standardResponsesWorkflow.AddItem(new ResponsesWorkflowItem(responsesForm));
			
			parentForm.EnableStopButton(false);
		}
		
		void FormatForm(Form form, DockStyle style)
		{
			form.MdiParent = this;
			form.FormBorderStyle = FormBorderStyle.None;
			form.Dock = style;
		}
	
		void MainFormLoad(object sender, EventArgs e)
		{
			
			if (!error)
			{
				parentForm.Show();
				quickLaunch.Show();
				quickLaunch.BringToFront();
				quickLaunch.Activate();
			}
			else
			{
				errorOnStartup.Show();
			}
		}
			
		void NewProfileToolStripMenuItemClick(object sender, EventArgs e)
		{
			currentWorkflow = profileNameWorkflow;
			SetupWorkflow(null, false);	
		}
		void AINameToolStripMenuItemClick(object sender, EventArgs e)
		{
			currentWorkflow = aINameWorkflow;
			SetupWorkflow("AIName", true);	
		}	

		void JokesToolStripMenuItem1Click(object sender, EventArgs e)
		{
			currentWorkflow = jokesWorkflow;
			SetupWorkflow("Jokes", true);
		}
		void PauseRecognitenToolStripMenuItemClick(object sender, EventArgs e)
		{
			currentWorkflow = pauseWorkflow;
			SetupWorkflow("Pause Speech Recognition", true);
		}
		void ReactivateRecognitionToolStripMenuItemClick(object sender, EventArgs e)
		{
			currentWorkflow = reactivateWorkflow;
			SetupWorkflow("Reactivate Speech Recognition", true);
		}
		void StopSpeechOutputToolStripMenuItemClick(object sender, EventArgs e)
		{
			currentWorkflow = stopSpeechWorkflow;
			SetupWorkflow("Stop Speech Output", true);
		}
		void AddCommandToolStripMenuItemClick(object sender, EventArgs e)
		{
			currentWorkflow = commandWorkflow;
			SetupWorkflow(null, true);
		}
		
		public void EditCommand(string name)
		{
			currentWorkflow = commandWorkflow;
			if (name == "AIName")
				currentWorkflow = aINameWorkflow;
			if (name == "Jokes")
				currentWorkflow = jokesWorkflow;
			if (name == "Pause Speech Recognition")
				currentWorkflow = pauseWorkflow;
			if (name == "Reactivate Speech Recognition")
				currentWorkflow = reactivateWorkflow;
			if (name == "Stop Speech Output")
				currentWorkflow = stopSpeechWorkflow;
			SetupWorkflow(name, true);
		}
		
		void StandardResponsesToolStripMenuItemClick(object sender, EventArgs e)
		{
			currentWorkflow = standardResponsesWorkflow;
			SetupWorkflow(null, false);
		}
		
		void SetupWorkflow(string commandName, bool createCommand)
		{
			currentWorkflow.parentForm = parentForm;
			
			if (commandName != null && commandList.CommandIsAlreadyDefined(commandName))
			{
				currentWorkflow.alreadyExistingCommand = commandList.GetCommand(commandName);
				commandList.commandToBeErased = commandName;
			}
			else
				currentWorkflow.alreadyExistingCommand = null;
			
			if (createCommand)
				currentWorkflow.command = new Command();
			else
				currentWorkflow.command = null;
				
			if (!string.IsNullOrEmpty(commandName) && currentWorkflow.command != null)
				currentWorkflow.command.name = commandName;
			
			currentWorkflow.commandList = commandList;
			currentWorkflow.StartWorkflow();
		}
		
		void LoadProfileToolStripMenuItemClick(object sender, EventArgs e)
		{
			DialogResult result = openFileDialog1.ShowDialog();
			if(result==DialogResult.OK)
			{
				try
				{
					commandList.Reset();
					serializer.Deserialize(ref commandList, openFileDialog1.FileName);
					commandList.CreateStandardCommands();
					parentForm.commandList = commandList;
					parentForm.FillCommandsListBox(commandList);
					this.Text = commandList.ProfileName;
				}
				catch (IOException)
				{
				}
			}
		}
		public void LoadAndLaunch()
		{
			LoadProfileToolStripMenuItemClick(this, null);
			parentForm.StartButtonClick(parentForm,null);
		}
		public void CreateProfileNew()
		{
			NewProfileToolStripMenuItemClick(this, null);
		}
		public void LoadWithoutLaunch()
		{
			LoadProfileToolStripMenuItemClick(this, null);
		}
		void SaveProfileToolStripMenuItemClick(object sender, EventArgs e)
		{
			saveFileDialog1.FileName = parentForm.commandList.ProfileName;
			if(saveFileDialog1.ShowDialog() ==DialogResult.OK)
			{
				try
				{
					serializer.Serialize(commandList, saveFileDialog1.FileName);
				}
				catch (IOException)
				{}
			}
		}
		
		public void UpdateTitleBar(string text)
		{
			this.Text = text;
			commandList.ProfileName = text;
		}
		
		public void EnableMenuStrip (bool enable)
		{
			this.mainMenuStrip.Enabled = enable;
		}
		
		public void ErrorOnStartup()
		{
			error = true;
		}
	}
}
