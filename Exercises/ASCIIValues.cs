using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercices.Exercises
{
	internal class ASCIIValues : BaseExercise
	{
		public ASCIIValues() : base("Afficher les valeurs ASCII.") { }

		protected override void App()
		{
			string str = String.Empty;

			Console.Write("Entrer du texte : ");
			str = Console.ReadLine();

			byte[] asciiBytes = Encoding.ASCII.GetBytes(str);

			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < asciiBytes.Length; i++)
			{
				sb.Append($"{asciiBytes[i]} ");
			}

			WriteAndWaitForEnter(sb.ToString());
		}
	}
}
