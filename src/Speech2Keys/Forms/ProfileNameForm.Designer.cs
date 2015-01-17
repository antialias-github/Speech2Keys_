/*
 * Created by SharpDevelop.
 * User: Peter
 * Date: 24.12.2014
 * Time: 11:10
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Speech2Keys
{
	partial class ProfileNameForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button finishButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox profileNameTextBox;
		private System.Windows.Forms.Button cancelButton;
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
			this.finishButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.profileNameTextBox = new System.Windows.Forms.TextBox();
			this.cancelButton = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// finishButton
			// 
			this.finishButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.finishButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.finishButton.Location = new System.Drawing.Point(197, 221);
			this.finishButton.Name = "finishButton";
			this.finishButton.Size = new System.Drawing.Size(75, 23);
			this.finishButton.TabIndex = 5;
			this.finishButton.Text = "Finish";
			this.finishButton.UseVisualStyleBackColor = true;
			this.finishButton.Click += new System.EventHandler(this.FinishButtonClick);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(260, 21);
			this.label1.TabIndex = 4;
			this.label1.Text = "Enter Name of Profile";
			// 
			// profileNameTextBox
			// 
			this.profileNameTextBox.Location = new System.Drawing.Point(12, 42);
			this.profileNameTextBox.Name = "profileNameTextBox";
			this.profileNameTextBox.Size = new System.Drawing.Size(259, 20);
			this.profileNameTextBox.TabIndex = 3;
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelButton.Location = new System.Drawing.Point(116, 221);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 7;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.CancelButtonClick);
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(12, 79);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(258, 69);
			this.label2.TabIndex = 8;
			this.label2.Text = "Warning: \r\nThis will delete all unsaved commands! \r\nAbort with \'Cancel\' button (o" +
	"r hit \'esc\').";
			// 
			// ProfileNameForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.ClientSize = new System.Drawing.Size(284, 262);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.finishButton);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.profileNameTextBox);
			this.Name = "ProfileNameForm";
			this.Text = "ProfileNameForm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
