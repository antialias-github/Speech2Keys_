/*
 * Created by SharpDevelop.
 * User: Peter
 * Date: 25.12.2014
 * Time: 23:41
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;

namespace Speech2Keys
{
	/// <summary>
	/// Description of IWorkflowItem.
	/// </summary>
	public interface IWorkflowItem
	{
		bool FillCommandWithData(Command command);
		void InitializeForm(Command command);
	}
}
