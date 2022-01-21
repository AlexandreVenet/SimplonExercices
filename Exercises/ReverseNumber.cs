using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercices.Exercises
{
	internal class ReverseNumber : BaseExercise
	{
		public ReverseNumber() : base("Inverser l'ordre des chiffres d'un nombre.") { }
		protected override void App()
		{
			int step = 0;
			string str = String.Empty;
			int userNumber = 0;

			while (step == 0)
			{
				Console.Write("Entrer un nombre entier : ");
				str = Console.ReadLine();
				if (int.TryParse(str, out userNumber))
				{
					step++;
					break;
				}
			}

			int tester = userNumber; // ex : 123
			int currentDigit = 0;
			StringBuilder sb = new StringBuilder();

			while (tester > 0)
			{
				currentDigit = tester % 10; // récupérer le digit de fin
				sb.Append(currentDigit);
				tester = tester / 10; // récupérer les digits précédant celui utilisé (avec int, on a une troncature des décimales)
			}

			WriteAndWaitForEnter($"{str} inversé est {sb}.");
		}
	}
}
