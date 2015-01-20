/*
 * Created by SharpDevelop.
 * User: Peter
 * Date: 24.12.2014
 * Time: 10:13
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Speech2Keys
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.MenuStrip mainMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newProfileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem loadProfileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveProfileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem commandsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aINameToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem standardResponsesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addCommandToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem specialCommandsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem pauseRecognitenToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem reactivateRecognitionToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem stopSpeechOutputToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem jokesToolStripMenuItem1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		 private void InitializeComponent()
		{
			this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loadProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.commandsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.addCommandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.specialCommandsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pauseRecognitenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.reactivateRecognitionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stopSpeechOutputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aINameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.jokesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.standardResponsesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.mainMenuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainMenuStrip
			// 
			this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.fileToolStripMenuItem,
			this.commandsToolStripMenuItem,
			this.configurationToolStripMenuItem});
			this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
			this.mainMenuStrip.Name = "mainMenuStrip";
			this.mainMenuStrip.Size = new System.Drawing.Size(852, 24);
			this.mainMenuStrip.TabIndex = 1;
			this.mainMenuStrip.Text = "Menu";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.newProfileToolStripMenuItem,
			this.loadProfileToolStripMenuItem,
			this.saveProfileToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// newProfileToolStripMenuItem
			// 
			this.newProfileToolStripMenuItem.Name = "newProfileToolStripMenuItem";
			this.newProfileToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
			this.newProfileToolStripMenuItem.Text = "New Profile";
			this.newProfileToolStripMenuItem.Click += new System.EventHandler(this.NewProfileToolStripMenuItemClick);
			// 
			// loadProfileToolStripMenuItem
			// 
			this.loadProfileToolStripMenuItem.Name = "loadProfileToolStripMenuItem";
			this.loadProfileToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
			this.loadProfileToolStripMenuItem.Text = "Load Profile";
			this.loadProfileToolStripMenuItem.Click += new System.EventHandler(this.LoadProfileToolStripMenuItemClick);
			// 
			// saveProfileToolStripMenuItem
			// 
			this.saveProfileToolStripMenuItem.Name = "saveProfileToolStripMenuItem";
			this.saveProfileToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
			this.saveProfileToolStripMenuItem.Text = "Save Profile";
			this.saveProfileToolStripMenuItem.Click += new System.EventHandler(this.SaveProfileToolStripMenuItemClick);
			// 
			// commandsToolStripMenuItem
			// 
			this.commandsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.addCommandToolStripMenuItem,
			this.specialCommandsToolStripMenuItem});
			this.commandsToolStripMenuItem.Name = "commandsToolStripMenuItem";
			this.commandsToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
			this.commandsToolStripMenuItem.Text = "Commands";
			// 
			// addCommandToolStripMenuItem
			// 
			this.addCommandToolStripMenuItem.Name = "addCommandToolStripMenuItem";
			this.addCommandToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
			this.addCommandToolStripMenuItem.Text = "Add New Command";
			this.addCommandToolStripMenuItem.Click += new System.EventHandler(this.AddCommandToolStripMenuItemClick);
			// 
			// specialCommandsToolStripMenuItem
			// 
			this.specialCommandsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.pauseRecognitenToolStripMenuItem,
			this.reactivateRecognitionToolStripMenuItem,
			this.stopSpeechOutputToolStripMenuItem,
			this.aINameToolStripMenuItem,
			this.jokesToolStripMenuItem1});
			this.specialCommandsToolStripMenuItem.Name = "specialCommandsToolStripMenuItem";
			this.specialCommandsToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
			this.specialCommandsToolStripMenuItem.Text = "Special Commands";
			// 
			// pauseRecognitenToolStripMenuItem
			// 
			this.pauseRecognitenToolStripMenuItem.Name = "pauseRecognitenToolStripMenuItem";
			this.pauseRecognitenToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
			this.pauseRecognitenToolStripMenuItem.Text = "Pause Recognition";
			this.pauseRecognitenToolStripMenuItem.Click += new System.EventHandler(this.PauseRecognitenToolStripMenuItemClick);
			// 
			// reactivateRecognitionToolStripMenuItem
			// 
			this.reactivateRecognitionToolStripMenuItem.Name = "reactivateRecognitionToolStripMenuItem";
			this.reactivateRecognitionToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
			this.reactivateRecognitionToolStripMenuItem.Text = "Reactivate Recognition";
			this.reactivateRecognitionToolStripMenuItem.Click += new System.EventHandler(this.ReactivateRecognitionToolStripMenuItemClick);
			// 
			// stopSpeechOutputToolStripMenuItem
			// 
			this.stopSpeechOutputToolStripMenuItem.Name = "stopSpeechOutputToolStripMenuItem";
			this.stopSpeechOutputToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
			this.stopSpeechOutputToolStripMenuItem.Text = "Stop Speech Output";
			this.stopSpeechOutputToolStripMenuItem.Click += new System.EventHandler(this.StopSpeechOutputToolStripMenuItemClick);
			// 
			// aINameToolStripMenuItem
			// 
			this.aINameToolStripMenuItem.Name = "aINameToolStripMenuItem";
			this.aINameToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
			this.aINameToolStripMenuItem.Text = "AI Name";
			this.aINameToolStripMenuItem.Click += new System.EventHandler(this.AINameToolStripMenuItemClick);
			// 
			// jokesToolStripMenuItem1
			// 
			this.jokesToolStripMenuItem1.Name = "jokesToolStripMenuItem1";
			this.jokesToolStripMenuItem1.Size = new System.Drawing.Size(195, 22);
			this.jokesToolStripMenuItem1.Text = "Jokes";
			this.jokesToolStripMenuItem1.Click += new System.EventHandler(this.JokesToolStripMenuItem1Click);
			// 
			// configurationToolStripMenuItem
			// 
			this.configurationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.standardResponsesToolStripMenuItem});
			this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
			this.configurationToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
			this.configurationToolStripMenuItem.Text = "Configuration";
			// 
			// standardResponsesToolStripMenuItem
			// 
			this.standardResponsesToolStripMenuItem.Name = "standardResponsesToolStripMenuItem";
			this.standardResponsesToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
			this.standardResponsesToolStripMenuItem.Text = "Standard Responses";
			this.standardResponsesToolStripMenuItem.Click += new System.EventHandler(this.StandardResponsesToolStripMenuItemClick);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.Filter = " \"Profiles (*.s2k)|*.s2k|All files (*.*)|*.*\"";
			// 
			// saveFileDialog1
			// 
			this.saveFileDialog1.Filter = " \"Profiles (*.s2k)|*.s2k|All files (*.*)|*.*\"";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(852, 591);
			this.Controls.Add(this.mainMenuStrip);
			this.IsMdiContainer = true;
			this.MainMenuStrip = this.mainMenuStrip;
			this.Name = "MainForm";
			this.Text = "Speech2Keys";
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.mainMenuStrip.ResumeLayout(false);
			this.mainMenuStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
