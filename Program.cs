using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Exercices.Exercises;

namespace Exercices
{
	internal class Program
	{
		#region Fields

		private static bool _isRunning = true;
		private static bool _hasPressedEnter;
		private static int _dashNumber = 110;
		protected static string _dashLine;
		//private static BaseExercise _app;

		private enum CurrentScreen
		{
			Home,
			App,
			End,
		}
		private static CurrentScreen _currentScreen = CurrentScreen.Home;

		private static string _path;
		private static int _currentOption = 0;
		private static string[] _filesPaths;
		private static int _totalFiles;

		#endregion



		#region Main

		static void Main(string[] args)
		{
			CreateDashLine();
			GetFiles();

			// Design pattern : StateMachine (minimale)
			while (_isRunning)
			{
				switch (_currentScreen)
				{
					case CurrentScreen.Home:
						Console.Clear();
						HeaderFooter("Programme en boucle. Naviguer [Haut/Bas]. Valider [Entrée].");
						DisplayFiles();
						SelectOption();
						break;
					case CurrentScreen.App:
						Console.Clear();
						//_app = new DateAndTime();// Lancer le sous-programme désiré en instanciant sa classe
						HeaderFooter("Sous-programme lancé. Valider [Entrée].");
						InstanciateMyClass(Path.GetFileNameWithoutExtension(_filesPaths[_currentOption]));
						_currentScreen = CurrentScreen.End;
						break;
					case CurrentScreen.End:
						HeaderFooter("Fin de boucle de progamme.");
						HasPressedEnter();
						_currentScreen = CurrentScreen.Home;
						break;
					default:
						break;
				}

			}
		}

		#endregion



		#region Display and simple controls

		/// <summary>
		/// Protected. Attendre que l'utilisateur ait appuyé sur Entrée.
		/// </summary>
		protected static void HasPressedEnter()
		{
			_hasPressedEnter = false;
			while (!_hasPressedEnter)
			{
				if (Console.ReadKey().Key == ConsoleKey.Enter)
				{
					_hasPressedEnter = true;
				}
			}
		}

		/// <summary>
		/// Protected. Ecrire une ligne et attendre que l'utilisateur ait appuyé sur Entrée.
		/// </summary>
		/// <param name="str">Chaîne à afficher</param>
		protected static void WriteAndWaitForEnter(string str)
		{
			Console.WriteLine(str);
			HasPressedEnter();
		}

		/// <summary>
		/// Créer une ligne de tirets de type string et conserver cette ligne.
		/// </summary>
		private static void CreateDashLine()
		{
			StringBuilder sb = new StringBuilder("", _dashNumber);
			for (int i = 0; i < _dashNumber; i++)
			{
				sb.Append("_");
			}
			sb.Append("\n");
			_dashLine = sb.ToString();
		}

		/// <summary>
		/// Ecrire un header ou un footer pour l'écran principal.
		/// </summary>
		/// <param name="str">Chaîne de titre</param>
		private static void HeaderFooter(string str)
		{
			Console.ForegroundColor = ConsoleColor.DarkBlue;
			Console.WriteLine(_dashLine);
			Console.WriteLine(str);
			Console.WriteLine(_dashLine);
			Console.ResetColor();
			//HasPressedEnter();
		}

		#endregion



		#region Files, main menu and instanciation

		/// <summary>
		/// Lister les fichiers du sous-dossier Exercises.
		/// </summary>
		private static void GetFiles()
		{
			// WORKING directory
			//Console.WriteLine(Directory.GetCurrentDirectory());
			//Console.WriteLine(Environment.CurrentDirectory);

			// PROJECT BIN directory
			//Console.WriteLine(Directory.GetParent(Environment.CurrentDirectory).FullName);

			// PROJECT directory
			//Console.WriteLine(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName);

			// Sous-dossier des classes
			_path = $"{Directory.GetParent(Environment.CurrentDirectory).Parent.FullName}{Path.DirectorySeparatorChar}Exercises";

			// Obtenir les chemins des fichiers (array)
			_filesPaths = Directory.GetFiles(_path);

			// Conserver le nombre total de fichiers pour les contrôles au clavier
			_totalFiles = _filesPaths.Length;
		}

		/// <summary>
		/// Afficher la liste des fichiers du dossier Exercises.
		/// </summary>
		private static void DisplayFiles()
		{
			string space = string.Empty;

			for (int i = 0; i < _filesPaths.Length; i++)
			{
				if (_currentOption == i)
				{
					Console.BackgroundColor = ConsoleColor.DarkCyan;
					Console.ForegroundColor = ConsoleColor.Black;
				}

				if(i<10)
				{
					space = " ";
				}
				else
				{
					space = string.Empty;
				}

				Console.WriteLine($" {space}{i} : {Path.GetFileNameWithoutExtension(_filesPaths[i])} ");

				if (_currentOption == i)
				{
					Console.ResetColor();
				}
			}
		}

		/// <summary>
		/// Contrôle du menu et sélection d'une option au clavier.
		/// </summary>
		private static void SelectOption()
		{
			bool hasEntered = false;
			ConsoleKeyInfo keyPressed = Console.ReadKey();

			if(keyPressed.Key == ConsoleKey.UpArrow)
			{
				_currentOption--;
				if (_currentOption < 0) _currentOption = _totalFiles - 1;
			}
			else if(keyPressed.Key == ConsoleKey.DownArrow)
			{
				_currentOption++;
				if (_currentOption > _totalFiles -1) _currentOption = 0;
			}
			else if(keyPressed.Key == ConsoleKey.Enter)
			{
				hasEntered = true;
			}
			
			if(hasEntered)
			{
				_currentScreen = CurrentScreen.App;
			}
			// Si !hasEntered, retour automatique au même état
	  
		}

		/// <summary>
		/// Instancier dynamiquement une classe concrète à partir de son nom.
		/// </summary>
		/// <param name="myClass">Nom de la classe</param>
		private static void InstanciateMyClass(string myClass)
		{
			//Type t = typeof(Add2Ints);
			//Assembly assem = Assembly.GetAssembly(t); 
			//Console.WriteLine(assem.FullName); // Exercices, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
			//Console.WriteLine(t); // Exercises.Exercises.Add2Ints
			//Type tt = typeof(Add2Ints);
			//Console.WriteLine(tt.FullName);

			// Instancier à partir d'une chaîne de caractère et de l'assembly actuelle 
			// https://stackoverflow.com/questions/9854900/instantiate-a-class-from-its-textual-name
			
			try
			{
				Assembly assembly = Assembly.GetExecutingAssembly(); // Obtenir l'assembly actuelle
				Type type = assembly.GetTypes().First(t => t.Name == myClass); // Chercher le type correspondant à la chaîne
				Activator.CreateInstance(type); // Instancier (le sous-programme se lance)
			}
			catch (System.InvalidOperationException e)
			{
				if(e.GetHashCode() == 21083178)
				{
					Console.WriteLine("Une erreur est survenue.");
					Console.WriteLine("Aucune classe d'exercice n'existe avec ce nom.");
					HasPressedEnter();
				}
			}

		}

		#endregion
	}
}
