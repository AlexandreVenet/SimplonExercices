using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercices.Exercises
{
	internal class LeapYear : BaseExercise
	{
		public LeapYear() : base("Année bissextile.") { }

		protected override void App()
		{
			string str = String.Empty;

			int step = 0;
			int result = 0;

			while (step == 0)
			{
				Console.Write("Saisir une année : ");
				str = Console.ReadLine();
				if (int.TryParse(str, out result))
				{
					step++;
					break;
				}
			}

			if(DateTime.IsLeapYear(result))
            {
				WriteAndWaitForEnter($"L'année {result} est bissextile.");
            }
            else
            {
				WriteAndWaitForEnter($"L'année {result} n'est pas bissextile.");
            }

		}
	}
}
