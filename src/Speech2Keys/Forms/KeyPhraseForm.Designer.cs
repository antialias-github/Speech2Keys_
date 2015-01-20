/*
 * Created by SharpDevelop.
 * User: Peter
 * Date: 24.12.2014
 * Time: 17:14
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Speech2Keys
{
	partial class KeyPhraseForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button backButton;
		private System.Windows.Forms.ListBox keyPhraseListBox;
		private System.Windows.Forms.Button nextButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.TextBox keyPhraseTextBox;
		
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
			this.keyPhraseListBox = new System.Windows.Forms.ListBox();
			this.nextButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.keyPhraseTextBox = new System.Windows.Forms.TextBox();
			this.cancelButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// backButton
			// 
			this.backButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.backButton.Location = new System.Drawing.Point(35, 228);
			this.backButton.Name = "backButton";
			this.backButton.Size = new System.Drawing.Size(75, 23);
			this.backButton.TabIndex = 18;
			this.backButton.Text = "<< Back";
			this.backButton.UseVisualStyleBackColor = true;
			this.backButton.Click += new System.EventHandler(this.BackButtonClick);
			// 
			// keyPhraseListBox
			// 
			this.keyPhraseListBox.FormattingEnabled = true;
			this.keyPhraseListBox.Location = new System.Drawing.Point(12, 88);
			this.keyPhraseListBox.Name = "keyPhraseListBox";
			this.keyPhraseListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.keyPhraseListBox.Size = new System.Drawing.Size(260, 134);
			this.keyPhraseListBox.TabIndex = 17;
			// 
			// nextButton
			// 
			this.nextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.nextButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.nextButton.Location = new System.Drawing.Point(197, 228);
			this.nextButton.Name = "nextButton";
			this.nextButton.Size = new System.Drawing.Size(75, 23);
			this.nextButton.TabIndex = 16;
			this.nextButton.Text = "Next >>";
			this.nextButton.UseVisualStyleBackColor = true;
			this.nextButton.Click += new System.EventHandler(this.NextButtonClick);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(260, 39);
			this.label1.TabIndex = 15;
			this.label1.Text = "Enter Keyphrase(s). \r\nThese are the phrases that will trigger the command.\r\nHit \'" +
	"del\' key to delete selected phrases.";
			// 
			// keyPhraseTextBox
			// 
			this.keyPhraseTextBox.Location = new System.Drawing.Point(12, 62);
			this.keyPhraseTextBox.Name = "keyPhraseTextBox";
			this.keyPhraseTextBox.Size = new System.Drawing.Size(259, 20);
			this.keyPhraseTextBox.TabIndex = 14;
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelButton.Location = new System.Drawing.Point(116, 228);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 19;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.CancelButtonClick);
			// 
			// KeyPhraseForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.ClientSize = new System.Drawing.Size(284, 262);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.backButton);
			this.Controls.Add(this.keyPhraseListBox);
			this.Controls.Add(this.nextButton);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.keyPhraseTextBox);
			this.Name = "KeyPhraseForm";
			this.Text = "KeyPhraseForm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
