/*
 * Created by SharpDevelop.
 * User: Peter
 * Date: 27.12.2014
 * Time: 03:09
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Speech2Keys
{
	/// <summary>
	/// Description of IWorkflow.
	/// </summary>
	public interface IWorkflow
	{
		Workflow Workflow{get;set;}
		void FocusOnShow();
	}
}
