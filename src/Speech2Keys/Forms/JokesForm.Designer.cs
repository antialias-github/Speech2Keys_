/*
 * Created by SharpDevelop.
 * User: Peter
 * Date: 24.12.2014
 * Time: 15:45
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Speech2Keys
{
	partial class JokesForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button finishButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button selectJokesbutton;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Button clearJokesButton;
		private System.Windows.Forms.Label numberOfJokesLabel;
		private System.Windows.Forms.ListBox jokeFileNamesListBox;
		private System.Windows.Forms.Button backButton;
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
			this.selectJokesbutton = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.cancelButton = new System.Windows.Forms.Button();
			this.clearJokesButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.numberOfJokesLabel = new System.Windows.Forms.Label();
			this.jokeFileNamesListBox = new System.Windows.Forms.ListBox();
			this.backButton = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// finishButton
			// 
			this.finishButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.finishButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.finishButton.Location = new System.Drawing.Point(197, 227);
			this.finishButton.Name = "finishButton";
			this.finishButton.Size = new System.Drawing.Size(75, 23);
			this.finishButton.TabIndex = 8;
			this.finishButton.Text = "Finish";
			this.finishButton.UseVisualStyleBackColor = true;
			this.finishButton.Click += new System.EventHandler(this.FinishButtonClick);
			// 
			// selectJokesbutton
			// 
			this.selectJokesbutton.Location = new System.Drawing.Point(13, 42);
			this.selectJokesbutton.Name = "selectJokesbutton";
			this.selectJokesbutton.Size = new System.Drawing.Size(103, 23);
			this.selectJokesbutton.TabIndex = 9;
			this.selectJokesbutton.Text = "Add Joke File";
			this.selectJokesbutton.UseVisualStyleBackColor = true;
			this.selectJokesbutton.Click += new System.EventHandler(this.SelectJokesbuttonClick);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.Filter = "\"Textfiles (*.txt)|*.txt|All files (*.*)|*.*\"";
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelButton.Location = new System.Drawing.Point(116, 227);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 11;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.CancelButtonClick);
			// 
			// clearJokesButton
			// 
			this.clearJokesButton.Location = new System.Drawing.Point(14, 71);
			this.clearJokesButton.Name = "clearJokesButton";
			this.clearJokesButton.Size = new System.Drawing.Size(102, 23);
			this.clearJokesButton.TabIndex = 12;
			this.clearJokesButton.Text = "Clear Jokes";
			this.clearJokesButton.UseVisualStyleBackColor = true;
			this.clearJokesButton.Click += new System.EventHandler(this.ClearJokesButtonClick);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(13, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 13;
			this.label1.Text = "Number of Jokes:";
			// 
			// numberOfJokesLabel
			// 
			this.numberOfJokesLabel.Location = new System.Drawing.Point(119, 13);
			this.numberOfJokesLabel.Name = "numberOfJokesLabel";
			this.numberOfJokesLabel.Size = new System.Drawing.Size(100, 23);
			this.numberOfJokesLabel.TabIndex = 14;
			this.numberOfJokesLabel.Text = "0";
			// 
			// jokeFileNamesListBox
			// 
			this.jokeFileNamesListBox.FormattingEnabled = true;
			this.jokeFileNamesListBox.Location = new System.Drawing.Point(13, 112);
			this.jokeFileNamesListBox.Name = "jokeFileNamesListBox";
			this.jokeFileNamesListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.jokeFileNamesListBox.Size = new System.Drawing.Size(259, 95);
			this.jokeFileNamesListBox.TabIndex = 15;
			// 
			// backButton
			// 
			this.backButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.backButton.Location = new System.Drawing.Point(35, 227);
			this.backButton.Name = "backButton";
			this.backButton.Size = new System.Drawing.Size(75, 23);
			this.backButton.TabIndex = 16;
			this.backButton.Text = "<< Back";
			this.backButton.UseVisualStyleBackColor = true;
			this.backButton.Click += new System.EventHandler(this.BackButtonClick);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(140, 42);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(132, 67);
			this.label2.TabIndex = 17;
			this.label2.Text = "Jokefiles must be plain text files with empty lines to delimit jokes. \r\nTo delete" +
	" files select them and hit the \'del\' key.";
			// 
			// JokesForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.ClientSize = new System.Drawing.Size(284, 262);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.backButton);
			this.Controls.Add(this.jokeFileNamesListBox);
			this.Controls.Add(this.numberOfJokesLabel);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.clearJokesButton);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.selectJokesbutton);
			this.Controls.Add(this.finishButton);
			this.Name = "JokesForm";
			this.Text = "JokesForm";
			this.ResumeLayout(false);

		}
	}
}
