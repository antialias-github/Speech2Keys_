/*
 * Created by SharpDevelop.
 * User: Peter
 * Date: 29.12.2014
 * Time: 15:49
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
	/// Description of KeyTranslator.
	/// </summary>
	public class KeyTranslator
	{
		public KeyTranslator()
		{
			
		}
		public static string TranslateKeyToString(Keys key)
		{
			if (key == Keys.None)
				return "none";
				
			if (key == Keys.ShiftKey)
	 			return "shift";
			if (key == Keys.ControlKey)
	 			return "control";
			
			if (key == Keys.Space)
	 			return "space";
			
			
			if (key == Keys.A)
	 			return "a";
			if (key == Keys.B)
				return "b";
			if (key == Keys.C)			
				return "c";
			if (key == Keys.D)
				return "d";
			if (key == Keys.E)
				return "e";
			if (key == Keys.F)
				return "f";
			if (key == Keys.G)
				return "g";
			if (key == Keys.H)
				return "h";
			if (key == Keys.I)
				return "i";
			if (key == Keys.J)	
				return "j";
			if (key == Keys.K)
				return "k";
			if (key == Keys.L)
				return "l";
			if (key == Keys.M)
				return "m";
			if (key == Keys.N)		
				return "n";
			if (key == Keys.O)	
				return "o";
			if (key == Keys.P)
				return "p";
			if (key == Keys.Q)
				return "q";
			if (key == Keys.R)
				return "r";
			if (key == Keys.S)
				return "s";
			if (key == Keys.T)
				return "t";
			if (key == Keys.U)
				return "u";
			if (key == Keys.V)
				return "v";
			if (key == Keys.W)
				return "w";
			if (key == Keys.X)
				return "x";
			if (key == Keys.Y)
				return "y";
			if (key == Keys.Z)	
				return "z";

			if (key == Keys.D0)	
				return "0";
			if (key == Keys.D1)
				return "1";
			if (key == Keys.D2)
				return "2";
			if (key == Keys.D3)
				return "3";
			if (key == Keys.D4)
				return "4";
			if (key == Keys.D5)
				return "5";
			if (key == Keys.D6)
				return "6";
			if (key == Keys.D7)
				return "7";
			if (key == Keys.D8)
				return "8";
			if (key == Keys.D9)
				return "9";

			if (key == Keys.Left)
				return "left";
			if (key == Keys.Right)
				return "right";
			if (key == Keys.Up)
				return "up";
			if (key == Keys.Down)
				return "down";

			if (key == Keys.Escape)
				return "escape";

			if (key == Keys.PageUp)
				return "page up";
			if (key == Keys.PageDown)
				return "page down";
			if (key == Keys.Home)
				return "home";
			if (key == Keys.End)
				return "end";
			if (key == Keys.Insert)
				return "insert";
			if (key == Keys.Delete)
				return "delete";

			if (key == Keys.Enter)			
				return "enter";
			if (key == Keys.Back)
				return "backspace";
			if (key == Keys.Tab)
				return "tab";

			if (key == Keys.NumPad1)			
				return "Num1";
			if (key == Keys.NumPad2)
				return "Num2";
			if (key == Keys.NumPad3)
				return "Num3";
			if (key == Keys.NumPad4)
				return "Num4";
			if (key == Keys.NumPad5)
				return "Num5";
			if (key == Keys.NumPad6)
				return "Num6";
			if (key == Keys.NumPad7)
				return "Num7";
			if (key == Keys.NumPad8)
				return "Num8";
			if (key == Keys.NumPad9)
				return "Num9";
			if (key == Keys.NumPad0)
				return "Num0";

			if (key == Keys.Add)
				return "+";
			if (key == Keys.Subtract)
				return "-";
			if (key == Keys.Multiply)
				return "*";
			if (key == Keys.Divide)
				return "/";
			if (key == Keys.Execute)
				return "Execute";

			if (key == Keys.F1)
				return "F1";
			if (key == Keys.F2)
				return "F2";
			if (key == Keys.F3)
				return "F3";
			if (key == Keys.F4)
				return "F4";
			if (key == Keys.F5)
				return "F5";
			if (key == Keys.F6)
				return "F6";
			if (key == Keys.F7)
				return "F7";
			if (key == Keys.F8)
				return "F8";
			if (key == Keys.F9)
				return "F9";
			if (key == Keys.F10)
				return "F10";
			if (key == Keys.F11)
				return "F11";
			if (key == Keys.F12)
				return "F12";
			
			 
			return "none";

		}
		public static Keys TranslateStringToKey(string key)
		{
			if (key == "none")
				return Keys.None;
			
			if (key == "shift")
	 			return Keys.ShiftKey;
			if (key == "control")
	 			return Keys.ControlKey;
			
			if (key == "space")
	 			return Keys.Space;
		
	 		if (key == "a")
				return Keys.A;
			if (key == "b")
				return Keys.B;
			if (key == "c")
				return Keys.C;
			if (key == "d")
				return Keys.D;
			if (key == "e")
				return Keys.E;
			if (key == "f")
				return Keys.F;
			if (key == "g")
				return Keys.G;
			if (key == "h")
				return Keys.H;
			if (key == "i")
				return Keys.I;
			if (key == "j")
				return Keys.J;
			if (key == "k")
				return Keys.K;
			if (key == "l")
				return Keys.L;
			if (key == "m")
				return Keys.M;
			if (key == "n")
				return Keys.N;
			if (key == "o")
				return Keys.O;
			if (key == "p")
				return Keys.P;
			if (key == "q")
				return Keys.Q;
			if (key == "r")
				return Keys.R;
			if (key == "s")
				return Keys.S;
			if (key == "t")
				return Keys.T;
			if (key == "u")
				return Keys.U;
			if (key == "v")
				return Keys.V;
			if (key == "w")
				return Keys.W;
			if (key == "x")
				return Keys.X;
			if (key == "y")
				return Keys.Y;
			if (key == "z")
				return Keys.Z;	
			
			if (key == "0")
				return Keys.D0;	
			if (key == "1")
				return Keys.D1;
			if (key == "2")
				return Keys.D2;
			if (key == "3")
				return Keys.D3;
			if (key == "4")
				return Keys.D4;
			if (key == "5")
				return Keys.D5;
			if (key == "6")
				return Keys.D6;
			if (key == "7")
				return Keys.D7;
			if (key == "8")
				return Keys.D8;
			if (key == "9")
				return Keys.D9;
			
			if (key == "left")
				return Keys.Left;
			if (key == "right")
				return Keys.Right;
			if (key == "up")
				return Keys.Up;
			if (key == "down")
				return Keys.Down;
			
			if (key == "escape")
				return Keys.Escape;
			
			if (key == "page up")
				return Keys.PageUp;
			if (key == "page down")
				return Keys.PageDown;
			if (key == "home")
				return Keys.Home;
			if (key == "end")
				return Keys.End;
			if (key == "insert")
				return Keys.Insert;
			if (key == "delete")
				return Keys.Delete;
			
			if (key == "enter")
				return Keys.Enter;
			if (key == "backspace")
				return Keys.Back;
			if (key == "tab")
				return Keys.Tab;
			
			if (key == "Num1")
				return Keys.NumPad1;
			if (key == "Num2")
				return Keys.NumPad2;
			if (key == "Num3")
				return Keys.NumPad3;
			if (key == "Num4")
				return Keys.NumPad4;
			if (key == "Num5")
				return Keys.NumPad5;
			if (key == "Num6")
				return Keys.NumPad6;
			if (key == "Num7")
				return Keys.NumPad7;
			if (key == "Num8")
				return Keys.NumPad8;
			if (key == "Num9")
				return Keys.NumPad9;
			if (key == "Num0")
				return Keys.NumPad0;
		
			if (key == "+")
				return Keys.Add;
			if (key == "-")
				return Keys.Subtract;
			if (key == "*")
				return Keys.Multiply;
			if (key == "/")
				return Keys.Divide;
			if (key == "Execute")
				return Keys.Execute;
			
			if (key == "F1")
				return Keys.F1;
			if (key == "F2")
				return Keys.F2;
			if (key == "F3")
				return Keys.F3;
			if (key == "F4")
				return Keys.F4;
			if (key == "F5")
				return Keys.F5;
			if (key == "F6")
				return Keys.F6;
			if (key == "F7")
				return Keys.F7;
			if (key == "F8")
				return Keys.F8;
			if (key == "F9")
				return Keys.F9;
			if (key == "F10")
				return Keys.F10;
			if (key == "F11")
				return Keys.F11;
			if (key == "F12")
				return Keys.F12;

			return Keys.None;			
		}
	}
}
