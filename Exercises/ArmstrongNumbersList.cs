using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercices.Exercises
{
	internal class ArmstrongNumbersList : BaseExercise
	{
		public ArmstrongNumbersList() : base("Donner les nombres Armstrong entre 0 et le nombre saisi.") { }

		protected override void App()
		{
			int step = 0;
			string str = String.Empty;

			int userNumber = 0;

			// Récupérer le nombre
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

			// Travailler en valeur absolue
			userNumber = Math.Abs(userNumber);

			WriteAndWaitForEnter($"Je vais travailler en valeur absolue, soit avec le nombre : {userNumber}");

			WriteAndWaitForEnter("Si le nombre égale la somme des cubes de chacun de ses chiffres, alors c'est un nombre Armstrong.");

			// Obtenir la liste des nombres ok
			List<int> armstrongNumbers = new List<int>();

            for (int i = 0; i <= userNumber; i++)
            {
				if(CheckNumber(i))
                {
					armstrongNumbers.Add(i);
                }
            }

            // Afficher

			StringBuilder sb = new StringBuilder();
			sb.Append("Nombres Armstrong : \n");

			for (int i = 0; i < armstrongNumbers.Count; i++)
            {
				sb.Append(armstrongNumbers[i]);
				
				if(i < armstrongNumbers.Count -1)
                {
					sb.Append("\n");
                }
            }

			WriteAndWaitForEnter(sb.ToString());
		}

		private bool CheckNumber(int userNumber)
        {
			int tester = userNumber; // ex : 123
			int currentDigit = 0; // Le digit évalué
			double result = 0; // double pour utiliser Math.Pow

			while (tester > 0)
			{
				currentDigit = tester % 10; // récupérer le digit de fin
				result = result + Math.Pow(currentDigit, 3); // Ajouter au résultat le digit au cube 
				tester = tester / 10; // récupérer les digits précédents celui utilisé (avec int, on a une troncature des décimales)
			}

			// Evaluer
			bool returnValue = false;

			if (userNumber == result) returnValue = true;

			return returnValue;
			
		}
	}
}
