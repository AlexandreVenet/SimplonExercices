using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Exercices.Exercises
{
	internal class GetNumbersInText : BaseExercise
	{
		public GetNumbersInText() : base("Obtenir les signes numériques d'un texte y compris représentant des nombres négatifs.") { }

		protected override void App()
		{
			string str = String.Empty;

			int step = 0;

			while (step == 0)
			{
				Console.Write("Saisir un texte : ");
				str = Console.ReadLine();
				if (str != null && str.Length > 0)
				{
					step++;
					break;
				}
			}

            string pattern = @"-?\d+";
			MatchCollection matches = Regex.Matches(str, pattern);

			if(matches.Count == 0)
			{
				WriteAndWaitForEnter("Cette chaîne ne contient pas de nombres.");
				return;
			}

			StringBuilder sbAll = new StringBuilder();
			StringBuilder sbEach = new StringBuilder();

			foreach (Match m in matches)
			{
				sbAll.Append(m);
				sbEach.Append($"{m} ");
			}

			Console.WriteLine($"Les nombres sont : {sbAll}");
			Console.WriteLine($"Les nombres par groupe sont : {sbEach}");

			HasPressedEnter();
		}
	}
}
