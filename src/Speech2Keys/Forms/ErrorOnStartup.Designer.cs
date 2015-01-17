/*
 * Created by SharpDevelop.
 * User: Peter
 * Date: 03.01.2015
 * Time: 16:31
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Speech2Keys
{
	partial class ErrorOnStartup
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
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
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(284, 262);
			this.label1.TabIndex = 0;
			this.label1.Text = "Could not find the default input device. \r\nPlease make sure you have a microphone" +
	" connected and active.\r\nThen restart the application.";
			// 
			// ErrorOnStartup
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 262);
			this.Controls.Add(this.label1);
			this.Name = "ErrorOnStartup";
			this.Text = "ErrorOnStartup";
			this.ResumeLayout(false);

		}
	}
}
