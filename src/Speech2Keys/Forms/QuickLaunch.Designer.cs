/*
 * Created by SharpDevelop.
 * User: Peter
 * Date: 28.12.2014
 * Time: 02:01
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Speech2Keys
{
	partial class QuickLaunch
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Button createNewProfileButton;
		private System.Windows.Forms.Button loadAndLaunchButton;
		private System.Windows.Forms.Button editExistingProfileButon;
		
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
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.createNewProfileButton = new System.Windows.Forms.Button();
			this.loadAndLaunchButton = new System.Windows.Forms.Button();
			this.editExistingProfileButon = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.Filter = " \"Profiles (*.prf)|*.prf|All files (*.*)|*.*\"";
			// 
			// createNewProfileButton
			// 
			this.createNewProfileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.createNewProfileButton.Location = new System.Drawing.Point(42, 271);
			this.createNewProfileButton.Name = "createNewProfileButton";
			this.createNewProfileButton.Size = new System.Drawing.Size(494, 63);
			this.createNewProfileButton.TabIndex = 0;
			this.createNewProfileButton.Text = "Create a New Profile";
			this.createNewProfileButton.UseVisualStyleBackColor = true;
			this.createNewProfileButton.Click += new System.EventHandler(this.CreateAndEditButtonClick);
			// 
			// loadAndLaunchButton
			// 
			this.loadAndLaunchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.loadAndLaunchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.loadAndLaunchButton.Location = new System.Drawing.Point(42, 69);
			this.loadAndLaunchButton.Name = "loadAndLaunchButton";
			this.loadAndLaunchButton.Size = new System.Drawing.Size(494, 67);
			this.loadAndLaunchButton.TabIndex = 1;
			this.loadAndLaunchButton.Text = "Load and Launch a Profile";
			this.loadAndLaunchButton.UseVisualStyleBackColor = true;
			this.loadAndLaunchButton.Click += new System.EventHandler(this.LoadAndLaunchButtonClick);
			// 
			// editExistingProfileButon
			// 
			this.editExistingProfileButon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.editExistingProfileButon.Location = new System.Drawing.Point(42, 166);
			this.editExistingProfileButon.Name = "editExistingProfileButon";
			this.editExistingProfileButon.Size = new System.Drawing.Size(494, 67);
			this.editExistingProfileButon.TabIndex = 2;
			this.editExistingProfileButon.Text = "Edit an Existing Profile";
			this.editExistingProfileButon.UseVisualStyleBackColor = true;
			this.editExistingProfileButon.Click += new System.EventHandler(this.EditExistingProfileButonClick);
			// 
			// QuickLaunch
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.ClientSize = new System.Drawing.Size(573, 378);
			this.Controls.Add(this.editExistingProfileButon);
			this.Controls.Add(this.loadAndLaunchButton);
			this.Controls.Add(this.createNewProfileButton);
			this.Name = "QuickLaunch";
			this.Text = "QuickLaunch";
			this.ResumeLayout(false);

		}
	}
}
