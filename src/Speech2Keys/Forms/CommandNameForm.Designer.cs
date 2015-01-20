/*
 * Created by SharpDevelop.
 * User: Peter
 * Date: 24.12.2014
 * Time: 10:47
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Speech2Keys
{
	partial class CommandNameForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button nextButton;
		private System.Windows.Forms.Button cancelButton;
		public System.Windows.Forms.TextBox CommandNameTextBox;
		private System.Windows.Forms.Label label2;
		
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
			this.CommandNameTextBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.nextButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// CommandNameTextBox
			// 
			this.CommandNameTextBox.Location = new System.Drawing.Point(13, 57);
			this.CommandNameTextBox.Name = "CommandNameTextBox";
			this.CommandNameTextBox.Size = new System.Drawing.Size(259, 20);
			this.CommandNameTextBox.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(11, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(260, 21);
			this.label1.TabIndex = 1;
			this.label1.Text = "Enter Name of Command";
			// 
			// nextButton
			// 
			this.nextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.nextButton.Location = new System.Drawing.Point(196, 227);
			this.nextButton.Name = "nextButton";
			this.nextButton.Size = new System.Drawing.Size(75, 23);
			this.nextButton.TabIndex = 2;
			this.nextButton.Text = "Next >>";
			this.nextButton.UseVisualStyleBackColor = true;
			this.nextButton.Click += new System.EventHandler(this.NextButtonClick);
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelButton.Location = new System.Drawing.Point(115, 227);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 7;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.CancelButtonClick);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(13, 92);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(259, 61);
			this.label2.TabIndex = 8;
			this.label2.Text = "Name of the command. This is ONLY a label. Speaking the name will have no effect," +
	" unless you define the label name as a keyphrase in the keyphrase step.";
			// 
			// CommandNameForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.ClientSize = new System.Drawing.Size(284, 262);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.nextButton);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.CommandNameTextBox);
			this.Name = "CommandNameForm";
			this.Text = "CommandNameForm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
