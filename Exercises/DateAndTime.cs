using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercices.Exercises
{
	internal class DateAndTime : BaseExercise
	{
		// Traduction de l'enum DayOfWeek avec correspondance des valeurs
		// https://docs.microsoft.com/fr-fr/dotnet/api/system.dayofweek?view=net-6.0
		private enum FrenchDay
        {
			lundi = 1,
			mardi = 2,
			mercredi = 3,
			jeudi = 4,
			vendredi = 5,
			samedi = 6,
			dimanche = 0
        }

		public DateAndTime() : base("Jouer avec la date et le type enum.") { }

		protected override void App()
		{
			// Aujourd'hui
			DateTime date = DateTime.Now;

			WriteAndWaitForEnter($"Nous sommes le {date.ToLongDateString()}. Il est : {date.ToLongTimeString()}.");

			// Ajouter un jour
			DateTime dateNext = date.AddDays(1);

			// Récupérer le jour en question, le transformer en int et en obtenir la constante nommée équivalente de l'enum perso
			// Vérifier si la date est exacte avec les outils de la classe DateTime.

			int dayInt = (int)dateNext.DayOfWeek;

			WriteAndWaitForEnter($"Demain, nous serons {(FrenchDay) dayInt} {dateNext.Day} ({dateNext.ToLongDateString()}).");
		}
	}
}
