using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercices.Exercises
{
    internal class Add2Ints : BaseExercise
    {	
        public Add2Ints() : base("Ajouter deux entiers."){ }

		protected override void App()
		{
			int step = 0;
			string str = String.Empty;

			int i = 0;
			int j = 0;

			while (step == 0)
			{
				Console.Write("Premier nombre : ");
				str = Console.ReadLine();
				if (int.TryParse(str, out i))
				{
					step++;
					break;
				}
			}

			while (step == 1)
			{
				Console.Write("Second nombre : ");
				str = Console.ReadLine();
				if (int.TryParse(str, out j))
				{
					step++;
					break;
				}
			}

			WriteAndWaitForEnter($"{i} + {j} = {i + j}");
		}
	}
}
