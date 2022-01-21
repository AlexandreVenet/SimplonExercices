using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercices.Exercises
{
	internal class OddEven : BaseExercise
	{
		public OddEven() : base("Nombre pair ou impair.") { }

		protected override void App()
		{
			string str = String.Empty;

			int step = 0;
			int result = 0;

			while (step == 0)
			{
				Console.Write("Saisir un nombre entier : ");
				str = Console.ReadLine();
				if (int.TryParse(str, out result))
                {
					step++;
					break;
                }
			}

			int test = result % 2;

			if(test == 0)
            {
				WriteAndWaitForEnter($"{result} est pair.");
            }
            else
            {
				WriteAndWaitForEnter($"{result} est impair.");
			}
		}
	}
}
