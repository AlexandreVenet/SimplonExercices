using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercices.Exercises
{
	internal class TypeSize : BaseExercise
	{
		public TypeSize() : base("Afficher la taille des types .NET en bytes et en bits."){ }

		protected override void App()
		{

			// source : https://www.geeksforgeeks.org/sizeof-operator-in-c-sharp/

			WriteAndWaitForEnter("Toutes les tests s'effectuent sur des variables dont la valeur est par défaut 0.");

			Console.WriteLine($"sizeof(bool)    :  {sizeof(bool)} byte    {sizeof(bool) * 8} bits");
			Console.WriteLine($"sizeof(byte)    :  {sizeof(byte)} byte    {sizeof(byte) * 8} bits");
			Console.WriteLine($"sizeof(sbyte)   :  {sizeof(sbyte)} byte    {sizeof(sbyte) * 8} bits");
			Console.WriteLine($"sizeof(char)    :  {sizeof(char)} bytes  {sizeof(char) * 8} bits");
			Console.WriteLine($"sizeof(short)   :  {sizeof(short)} bytes  {sizeof(short) * 8} bits");
			Console.WriteLine($"sizeof(ushort)  :  {sizeof(ushort)} bytes  {sizeof(ushort) * 8} bits");
			Console.WriteLine($"sizeof(float)   :  {sizeof(float)} bytes  {sizeof(float) * 8} bits");
			Console.WriteLine($"sizeof(int)     :  {sizeof(int)} bytes  {sizeof(int) * 8} bits");
			Console.WriteLine($"sizeof(ulong)   :  {sizeof(ulong)} bytes  {sizeof(ulong) * 8} bits");
			Console.WriteLine($"sizeof(double)  :  {sizeof(double)} bytes  {sizeof(double) * 8} bits");
			Console.WriteLine($"sizeof(decimal) : {sizeof(decimal)} bytes {sizeof(decimal) * 8} bits");

			Console.WriteLine("Autres types : pas de taille prédéfinie (elle dépend du contenu).");

			HasPressedEnter();
		}

	}
}
