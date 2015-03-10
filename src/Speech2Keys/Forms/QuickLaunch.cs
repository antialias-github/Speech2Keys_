/*
 * Created by SharpDevelop.
 * User: Peter
 * Date: 28.12.2014
 * Time: 02:01
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
	/// Description of QuickLaunch.
	/// </summary>
	public partial class QuickLaunch : Form
	{
		public CommandList commandList;
		public ParentForm parentForm;
		
		public QuickLaunch()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		public void SecureStrip()
		{
			((ICanEdit)MdiParent).EnableMenuStrip(false);
		}
		void LoadAndLaunchButtonClick(object sender, EventArgs e)
		{
			((ICanEdit)MdiParent).EnableMenuStrip(true);
			((ICanEdit)this.MdiParent).LoadAndLaunch();
			this.Visible = false;
			parentForm.FocusOnShow(sender, e);
			
		}
		void CreateAndEditButtonClick(object sender, EventArgs e)
		{
			((ICanEdit)MdiParent).EnableMenuStrip(true);
			
			commandList.Reset();
			commandList.CreateStandardCommands();
			commandList.AddDefaultStandardResponses();
			parentForm.Clear();
			foreach (var c in commandList.listOfCommands)
				parentForm.AddCommand(c);
				
			commandList.ProfileName = "New Profile";
			((ICanEdit)(parentForm.MdiParent)).UpdateTitleBar("New Profile");
			((ICanEdit)this.MdiParent).CreateProfileNew();
			this.Visible = false;
			parentForm.FocusOnShow(sender, e);
			
		}
		void EditExistingProfileButonClick(object sender, EventArgs e)
		{ 
			((ICanEdit)MdiParent).EnableMenuStrip(true);
			((ICanEdit)this.MdiParent).LoadWithoutLaunch();
			this.Visible = false;
			
		}
	}
}
