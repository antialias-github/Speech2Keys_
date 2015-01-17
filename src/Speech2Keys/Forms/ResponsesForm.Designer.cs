/*
 * Created by SharpDevelop.
 * User: Peter
 * Date: 24.12.2014
 * Time: 10:48
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Speech2Keys
{
	partial class ResponsesForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button backButton;
		private System.Windows.Forms.ListBox responsesListBox;
		private System.Windows.Forms.Button finishButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox responsesTextBox;
		private System.Windows.Forms.CheckBox standardResponsesCheckBox;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.CheckBox playBeforeExecutionCheckBox;
		
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
			this.responsesListBox = new System.Windows.Forms.ListBox();
			this.finishButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.responsesTextBox = new System.Windows.Forms.TextBox();
			this.standardResponsesCheckBox = new System.Windows.Forms.CheckBox();
			this.cancelButton = new System.Windows.Forms.Button();
			this.playBeforeExecutionCheckBox = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// backButton
			// 
			this.backButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.backButton.Location = new System.Drawing.Point(35, 228);
			this.backButton.Name = "backButton";
			this.backButton.Size = new System.Drawing.Size(75, 23);
			this.backButton.TabIndex = 12;
			this.backButton.Text = "<< Back";
			this.backButton.UseVisualStyleBackColor = true;
			this.backButton.Click += new System.EventHandler(this.BackButtonClick);
			// 
			// responsesListBox
			// 
			this.responsesListBox.FormattingEnabled = true;
			this.responsesListBox.Location = new System.Drawing.Point(12, 88);
			this.responsesListBox.Name = "responsesListBox";
			this.responsesListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.responsesListBox.Size = new System.Drawing.Size(260, 134);
			this.responsesListBox.TabIndex = 11;
			// 
			// finishButton
			// 
			this.finishButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.finishButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.finishButton.Location = new System.Drawing.Point(197, 228);
			this.finishButton.Name = "finishButton";
			this.finishButton.Size = new System.Drawing.Size(75, 23);
			this.finishButton.TabIndex = 10;
			this.finishButton.Text = "Finish";
			this.finishButton.UseVisualStyleBackColor = true;
			this.finishButton.Click += new System.EventHandler(this.FinishButtonClick);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(98, 41);
			this.label1.TabIndex = 9;
			this.label1.Text = "Enter Response(s).\r\nHit \'del\' key to delete selected responses.";
			// 
			// responsesTextBox
			// 
			this.responsesTextBox.Location = new System.Drawing.Point(13, 62);
			this.responsesTextBox.Name = "responsesTextBox";
			this.responsesTextBox.Size = new System.Drawing.Size(260, 20);
			this.responsesTextBox.TabIndex = 8;
			// 
			// standardResponsesCheckBox
			// 
			this.standardResponsesCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.standardResponsesCheckBox.Location = new System.Drawing.Point(116, 7);
			this.standardResponsesCheckBox.Name = "standardResponsesCheckBox";
			this.standardResponsesCheckBox.Size = new System.Drawing.Size(156, 27);
			this.standardResponsesCheckBox.TabIndex = 13;
			this.standardResponsesCheckBox.Text = "Add Standard Responses";
			this.standardResponsesCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.standardResponsesCheckBox.UseVisualStyleBackColor = true;
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelButton.Location = new System.Drawing.Point(116, 228);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 14;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.CancelButtonClick);
			// 
			// playBeforeExecutionCheckBox
			// 
			this.playBeforeExecutionCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.playBeforeExecutionCheckBox.Location = new System.Drawing.Point(116, 30);
			this.playBeforeExecutionCheckBox.Name = "playBeforeExecutionCheckBox";
			this.playBeforeExecutionCheckBox.Size = new System.Drawing.Size(156, 29);
			this.playBeforeExecutionCheckBox.TabIndex = 15;
			this.playBeforeExecutionCheckBox.Text = "Play During Execution";
			this.playBeforeExecutionCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.playBeforeExecutionCheckBox.UseVisualStyleBackColor = true;
			// 
			// ResponsesForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.ClientSize = new System.Drawing.Size(284, 262);
			this.Controls.Add(this.playBeforeExecutionCheckBox);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.standardResponsesCheckBox);
			this.Controls.Add(this.backButton);
			this.Controls.Add(this.responsesListBox);
			this.Controls.Add(this.finishButton);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.responsesTextBox);
			this.Name = "ResponsesForm";
			this.Text = "ResponsesForm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
