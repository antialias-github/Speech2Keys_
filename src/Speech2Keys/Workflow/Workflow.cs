/*
 * Created by SharpDevelop.
 * User: Peter
 * Date: 24.12.2014
 * Time: 16:47
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
	/// Description of Workflow.
	/// </summary>
	public class Workflow
	{
		public List<WorkflowItem> workflowItems;
		WorkflowItem currentItem;
		public ParentForm parentForm;
		
	
		// if a command of the name already exists then this command will be used to prefill form contents 
		public Command alreadyExistingCommand;
		
		// this is the command all the information will be wrtitten to
		public Command command;
		public CommandList commandList;
		
		public Workflow()
		{
			workflowItems = new List<WorkflowItem>();
			currentItem = null;
		}
		
		public void AddItem(WorkflowItem workflowItem)
		{
			workflowItems.Add(workflowItem);
		}
			
		public void NextWorkflowStep()
		{
			if(currentItem.FillCommandWithData(command))
			{		
				currentItem.form.Dock = DockStyle.None;
				HideForm(currentItem.form);
				if(workflowItems.IndexOf(currentItem) < workflowItems.Count - 1)
				{
					currentItem = workflowItems[ workflowItems.IndexOf(currentItem) + 1];
					if (currentItem.form is KeyPhraseForm)
							((KeyPhraseForm)(currentItem.form)).ShowBackButton();
						if (currentItem.form is ResponsesForm)
						{
							((ResponsesForm)(currentItem.form)).ShowBackButton();
							((ResponsesForm)(currentItem.form)).HideStandardResponses(true);
						}
					currentItem.InitializeForm(alreadyExistingCommand);
					currentItem.form.Dock = DockStyle.Left;
					ShowForm(currentItem.form);
					((IWorkflow)currentItem.form).FocusOnShow();
				}
			}	
		}
		
		public void PreviousWorkflowStep()
		{
			HideForm(currentItem.form);
			currentItem.form.Dock = DockStyle.None;
			if(workflowItems.IndexOf(currentItem) == 0)
				EndWorkflow();
			else
			{
				currentItem = workflowItems[workflowItems.IndexOf(currentItem) - 1];
				
				if (workflowItems.IndexOf(currentItem) == 0)
					{	
						if (currentItem.form is KeyPhraseForm)
							((KeyPhraseForm)(currentItem.form)).HideBackButton();
						if (currentItem.form is ResponsesForm)
						{
							((ResponsesForm)(currentItem.form)).HideBackButton();
							((ResponsesForm)(currentItem.form)).HideStandardResponses(true);
						}
					}
				currentItem.form.Dock = DockStyle.Left;
				currentItem.InitializeForm(command);
				ShowForm(currentItem.form);
				((IWorkflow)currentItem.form).FocusOnShow();
			}
		}
		
		public void StartWorkflow()
		{	
			((ICanEdit)parentForm.MdiParent).EnableMenuStrip (false);
			parentForm.Enabled = false;
			foreach (var w in workflowItems)
				((IWorkflow)(w.form)).Workflow = this;
			
			currentItem = workflowItems[0];
			currentItem.form.Dock = DockStyle.Left;
			
			if (command != null)
			{
				if (workflowItems.Count > 0)
				{
					if (currentItem.form is KeyPhraseForm)
						((KeyPhraseForm)(currentItem.form)).HideBackButton();
					if (currentItem.form is ResponsesForm)
					{
						((ResponsesForm)(currentItem.form)).HideBackButton();
						((ResponsesForm)(currentItem.form)).HideStandardResponses(true);
					}
					currentItem.InitializeForm(alreadyExistingCommand);
					ShowForm(currentItem.form);
					((IWorkflow)currentItem.form).FocusOnShow();
				}
			}
			else
			{
				if (currentItem.form is ProfileNameForm)
					((ProfileNameForm)(currentItem.form)).SetData(commandList.ProfileName);
				if (currentItem.form is ResponsesForm)
				{
					((ResponsesForm)(currentItem.form)).SetData(commandList.standardResponses);
					((ResponsesForm)(currentItem.form)).HideStandardResponses(false);
				}
				ShowForm(currentItem.form);
				((IWorkflow)currentItem.form).FocusOnShow();
			}
		}
		
		public void EndWorkflow()
		{	
			if(command != null)
			{
				if (currentItem.FillCommandWithData(command))
				{
					string result;
					if (commandList.Add(command, out result))
					{
						parentForm.AddCommand(command);
						commandList.commandToBeErased = "";
						currentItem.form.Dock = DockStyle.None;
						HideForm(currentItem.form);
						parentForm.Enabled = true;
						parentForm.DisplayCommand(command);
						parentForm.FocusOnShow(null, null);
						((ICanEdit)parentForm.MdiParent).EnableMenuStrip (true);
					}
				}		
			}
			else
			{
				if (currentItem.form is ProfileNameForm)
				{
					string name;
					if (((ProfileNameForm)(currentItem.form)).GetData(out name))
					{
						
						commandList.Reset();
						commandList.CreateStandardCommands();
						commandList.AddDefaultStandardResponses();
						parentForm.Clear();
						foreach (var c in commandList.listOfCommands)
							parentForm.AddCommand(c);
							
						commandList.ProfileName = name;
						((ICanEdit)(parentForm.MdiParent)).UpdateTitleBar(name);
						currentItem.form.Dock = DockStyle.None;
						HideForm(currentItem.form);
						parentForm.Enabled = true;
						parentForm.FocusOnShow(null, null);
						((ICanEdit)parentForm.MdiParent).EnableMenuStrip (true);
					}
				}
				if (currentItem.form is ResponsesForm)
				{
					List<string> responses;
					responses = ((ResponsesForm)(currentItem.form)).GetResponses();
					commandList.standardResponses.Clear();
					foreach (var r in responses)
						commandList.standardResponses.Add(r);
					currentItem.form.Dock = DockStyle.None;
					HideForm(currentItem.form);
					parentForm.Enabled = true;
					parentForm.FocusOnShow(null, null);
					((ICanEdit)parentForm.MdiParent).EnableMenuStrip (true);
				}
			}
		}
		
		public void AbortWorkflow()
		{
			currentItem.form.Dock = DockStyle.None;
			((ICanEdit)parentForm.MdiParent).EnableMenuStrip (true);
			commandList.commandToBeErased = "";
			if (command != null)
				command.Clear();
			HideAllForms();
			parentForm.Enabled = true;
		}
		
		public static void ShowForm (Form form)
		{
			form.Show();
			form.Dock = DockStyle.Left;
			form.BringToFront();
			form.Enabled = true;
			form.Activate();
		}
		
		public static void HideForm (Form form)
		{
			form.SendToBack();
			form.Enabled = false;
		}
		
		public void HideAllForms()
		{
				foreach (var w in workflowItems)
					HideForm(w.form);
		}
		
		public bool CheckConflictingKeyPhrases(Command command)
		{
			foreach (var c in parentForm.commandList.listOfCommands)
				foreach (var k in c.keyPhrases)
					foreach (var ck in command.keyPhrases)
						if (k.ToLower() == ck.ToLower() && command.name != c.name && c.name != commandList.commandToBeErased)
							{
								parentForm.AddMessage("Phrase " + ck + " already used in command " + c.name);
								return false;		
							}
			return true;
		}
		
		public bool CommandNameIsDuplicate (Command command)
		{
			foreach (var c in parentForm.commandList.listOfCommands)
				if (c.name.ToLower() == command.name.ToLower() )
				{
						parentForm.AddMessage("Command name " + c.name + " already in use");
						return true;
				}
			return false;
		}
		
	}
}
