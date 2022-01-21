using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercices.Exercises
{
	internal abstract class BaseExercise : Program
	{
		protected string _name, _description;

		public BaseExercise(string description)
        {
			_name = this.GetType().Name ; // le nom à l'instanciation
			if(_description == null && Char.IsLower(description[0]))
            {
				_description = description;
            }
			else
            {
				_description = Char.ToLower(description[0]) + description.Substring(1);
            }

			Console.ForegroundColor = ConsoleColor.DarkCyan;
			Console.WriteLine($"{_name} : {_description}");
			WriteAndWaitForEnter(_dashLine);
			Console.ResetColor();
			
			App();

			Console.ForegroundColor = ConsoleColor.DarkCyan;
			Console.WriteLine(_dashLine);
			Console.WriteLine($"Fin de {_name}.");
			Console.ResetColor();
		}

		abstract protected void App();

	}
}
