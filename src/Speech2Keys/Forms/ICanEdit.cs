/*
 * Created by SharpDevelop.
 * User: Peter
 * Date: 27.12.2014
 * Time: 23:08
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Speech2Keys
{
	/// <summary>
	/// Description of ICanEditCommands.
	/// </summary>
	public interface ICanEdit
	{
		void EditCommand(string name);
		void UpdateTitleBar(string text);
		void LoadAndLaunch();
		void CreateProfileNew();
		void LoadWithoutLaunch();
		void EnableMenuStrip (bool enable);
		void ErrorOnStartup();
	}
}
