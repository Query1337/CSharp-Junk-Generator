using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace C_Sharp_Junk_Generator
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

		}
		private void Generatebutton_Click(object sender, EventArgs e)
		{
			string app = this.textBox1.Text;
			if (app.Contains(".cs"))
			{
				FIleInput(app);
			}
			else
			{
				app += ".cs";
				FIleInput(app);
			}

		}
		static void FIleInput(string app)
		{
			string threads = "100";
			string fileinterior = File.ReadAllText(app);
			Gen(fileinterior, threads);
		}

		private static Random random1 = new Random();
		private static Random random2 = new Random();

		static string GenerateRandomStrings()
		{
			var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
			int chance = random1.Next(20, 100);
			var stringChars = new char[chance];
			for (int i = 0; i < stringChars.Length; i++)
			{
				stringChars[i] = chars[random2.Next(chars.Length)];
			}
			var finalString = new String(stringChars);
			return finalString;
		}
		static void Gen(string interior, string threads)
		{
			int threadsINT = Int32.Parse(threads);
			using (StreamWriter WriteAndGen = new StreamWriter("Generated.cs"))
			{
				WriteAndGen.WriteLine(interior);
				for (int i = 0; i < threadsINT; i++)
				{
					
					WriteAndGen.Write("public class " + GenerateRandomStrings() + "{\n " + "void " + GenerateRandomStrings() + "()" + "{ ");

					string string1 = GenerateRandomStrings();
					string string2 = GenerateRandomStrings();
					WriteAndGen.Write("string " + string1 + " = \"" + GenerateRandomStrings() + "\";");
					WriteAndGen.Write("string " + string2 + " = \"" + GenerateRandomStrings() + "\";");
					WriteAndGen.Write(string1 + " = \"" + GenerateRandomStrings() + "\";");
					WriteAndGen.Write(string1 + " = " + string2 + ";");

					WriteAndGen.Write("}}");
					WriteAndGen.WriteLine("\n");					
				}
			}
		}

        private void Helpbutton_Click(object sender, EventArgs e)
        {
			MessageBox.Show("Write You're .CS File Name, (Make Sure The Generator And .cs File is in The Same Directory)");
        }
    }
}



