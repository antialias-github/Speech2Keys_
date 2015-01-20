/*
 * Created by SharpDevelop.
 * User: Peter
 * Date: 24.12.2014
 * Time: 14:34
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Speech2Keys
{
	partial class KeyPressedForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button backButton;
		private System.Windows.Forms.Button nextButton;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Button pauseTenthSecondButton;
		private System.Windows.Forms.Button pauseHalfSecondButton;
		private System.Windows.Forms.Button pauseFullSecondButton;
		private System.Windows.Forms.ListBox sequenceListBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button clearButton;
		private System.Windows.Forms.Button pauseTwoSecondsButton;
		private System.Windows.Forms.Button deleteSelectedButton;
		private System.Windows.Forms.Label label1;
		
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
			this.backButton = new System.Windows.Forms.Button();
			this.nextButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.pauseTenthSecondButton = new System.Windows.Forms.Button();
			this.pauseHalfSecondButton = new System.Windows.Forms.Button();
			this.pauseFullSecondButton = new System.Windows.Forms.Button();
			this.sequenceListBox = new System.Windows.Forms.ListBox();
			this.label2 = new System.Windows.Forms.Label();
			this.clearButton = new System.Windows.Forms.Button();
			this.pauseTwoSecondsButton = new System.Windows.Forms.Button();
			this.deleteSelectedButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// backButton
			// 
			this.backButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.backButton.Location = new System.Drawing.Point(35, 411);
			this.backButton.Name = "backButton";
			this.backButton.Size = new System.Drawing.Size(75, 23);
			this.backButton.TabIndex = 14;
			this.backButton.Text = "<< Back";
			this.backButton.UseVisualStyleBackColor = true;
			this.backButton.Click += new System.EventHandler(this.BackButtonClick);
			// 
			// nextButton
			// 
			this.nextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.nextButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.nextButton.Location = new System.Drawing.Point(197, 411);
			this.nextButton.Name = "nextButton";
			this.nextButton.Size = new System.Drawing.Size(75, 23);
			this.nextButton.TabIndex = 13;
			this.nextButton.Text = "Next >>";
			this.nextButton.UseVisualStyleBackColor = true;
			this.nextButton.Click += new System.EventHandler(this.NextButtonClick);
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelButton.Location = new System.Drawing.Point(116, 411);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 15;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.CancelButtonClick);
			// 
			// pauseTenthSecondButton
			// 
			this.pauseTenthSecondButton.Location = new System.Drawing.Point(15, 142);
			this.pauseTenthSecondButton.Name = "pauseTenthSecondButton";
			this.pauseTenthSecondButton.Size = new System.Drawing.Size(95, 23);
			this.pauseTenthSecondButton.TabIndex = 17;
			this.pauseTenthSecondButton.Text = "Pause 0.1s";
			this.pauseTenthSecondButton.UseVisualStyleBackColor = true;
			this.pauseTenthSecondButton.Click += new System.EventHandler(this.PauseTenthSecondButtonClick);
			// 
			// pauseHalfSecondButton
			// 
			this.pauseHalfSecondButton.Location = new System.Drawing.Point(15, 171);
			this.pauseHalfSecondButton.Name = "pauseHalfSecondButton";
			this.pauseHalfSecondButton.Size = new System.Drawing.Size(96, 23);
			this.pauseHalfSecondButton.TabIndex = 18;
			this.pauseHalfSecondButton.Text = "Pause 0.5s";
			this.pauseHalfSecondButton.UseVisualStyleBackColor = true;
			this.pauseHalfSecondButton.Click += new System.EventHandler(this.PauseHalfSecondButtonClick);
			// 
			// pauseFullSecondButton
			// 
			this.pauseFullSecondButton.Location = new System.Drawing.Point(14, 200);
			this.pauseFullSecondButton.Name = "pauseFullSecondButton";
			this.pauseFullSecondButton.Size = new System.Drawing.Size(96, 23);
			this.pauseFullSecondButton.TabIndex = 19;
			this.pauseFullSecondButton.Text = "Pause 1.0s";
			this.pauseFullSecondButton.UseVisualStyleBackColor = true;
			this.pauseFullSecondButton.Click += new System.EventHandler(this.PauseFullSecondButtonClick);
			// 
			// sequenceListBox
			// 
			this.sequenceListBox.FormattingEnabled = true;
			this.sequenceListBox.Location = new System.Drawing.Point(159, 25);
			this.sequenceListBox.Name = "sequenceListBox";
			this.sequenceListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.sequenceListBox.Size = new System.Drawing.Size(113, 368);
			this.sequenceListBox.TabIndex = 20;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(14, 25);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 118);
			this.label2.TabIndex = 21;
			this.label2.Text = "Type key(s) you want to assign.\r\nPause buttons will insert pauses after selected " +
	"item(s). \r\nFor long intervals add mutiple pauses.";
			// 
			// clearButton
			// 
			this.clearButton.Location = new System.Drawing.Point(14, 370);
			this.clearButton.Name = "clearButton";
			this.clearButton.Size = new System.Drawing.Size(96, 23);
			this.clearButton.TabIndex = 22;
			this.clearButton.Text = "Clear All";
			this.clearButton.UseVisualStyleBackColor = true;
			this.clearButton.Click += new System.EventHandler(this.ClearButtonClick);
			// 
			// pauseTwoSecondsButton
			// 
			this.pauseTwoSecondsButton.Location = new System.Drawing.Point(14, 229);
			this.pauseTwoSecondsButton.Name = "pauseTwoSecondsButton";
			this.pauseTwoSecondsButton.Size = new System.Drawing.Size(97, 23);
			this.pauseTwoSecondsButton.TabIndex = 24;
			this.pauseTwoSecondsButton.Text = "Pause 2.0s";
			this.pauseTwoSecondsButton.UseVisualStyleBackColor = true;
			this.pauseTwoSecondsButton.Click += new System.EventHandler(this.PauseTwoSecondsButtonClick);
			// 
			// deleteSelectedButton
			// 
			this.deleteSelectedButton.Location = new System.Drawing.Point(14, 326);
			this.deleteSelectedButton.Name = "deleteSelectedButton";
			this.deleteSelectedButton.Size = new System.Drawing.Size(96, 23);
			this.deleteSelectedButton.TabIndex = 25;
			this.deleteSelectedButton.Text = "Delete Selected";
			this.deleteSelectedButton.UseVisualStyleBackColor = true;
			this.deleteSelectedButton.Click += new System.EventHandler(this.DeleteSelectedButtonClick);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(14, 265);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 58);
			this.label1.TabIndex = 26;
			this.label1.Text = "Deleter multiple entries with drag select or ctrl select (no shift select)";
			// 
			// KeyPressedForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.ClientSize = new System.Drawing.Size(284, 446);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.deleteSelectedButton);
			this.Controls.Add(this.pauseTwoSecondsButton);
			this.Controls.Add(this.clearButton);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.sequenceListBox);
			this.Controls.Add(this.pauseFullSecondButton);
			this.Controls.Add(this.pauseHalfSecondButton);
			this.Controls.Add(this.pauseTenthSecondButton);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.backButton);
			this.Controls.Add(this.nextButton);
			this.Name = "KeyPressedForm";
			this.Text = "KeyPressedForm";
			this.ResumeLayout(false);

		}
	}
}
