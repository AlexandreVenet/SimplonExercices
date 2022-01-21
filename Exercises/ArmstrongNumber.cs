using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercices.Exercises
{
	internal class ArmstrongNumber : BaseExercise
	{
		// Règle pour déterminer si un nombre est un nombre Armstrong :
		// nombre = somme des cubes de chaque chiffre

		public ArmstrongNumber() : base("Déterminer si un nombre est Armstrong.") { }

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

			int tester = userNumber; // ex : 123
			int currentDigit = 0;
			double result = 0; // double pour utiliser Math.Pow
			StringBuilder sb = new StringBuilder();

			while (tester > 0)
			{
				currentDigit = tester % 10; // récupérer le digit de fin
				result = result + Math.Pow(currentDigit,3); // Ajouter au résultat le digit au cube 
				tester = tester / 10; // récupérer les digits précédant celui utilisé (avec int, on a une troncature des décimales)

				sb.Append($"({currentDigit} x {currentDigit} x {currentDigit}) + "); // derniers caractères : "+ "
			}

			// Supprimer les derniers caractères 
			sb.Remove(sb.Length - 3, 3);

			WriteAndWaitForEnter($"{userNumber} >> {sb} >> {result}");

			// Evaluer
			if(userNumber == result)
            {
				WriteAndWaitForEnter($"{userNumber} est Armstrong.");
            }
			else
            {
				WriteAndWaitForEnter($"{userNumber} n'est pas Armstrong.");
            }


		}
	}
}
