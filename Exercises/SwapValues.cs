using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercices.Exercises
{
    internal class SwapValues : BaseExercise
    {
        public SwapValues() : base("Intervertir les valeurs de deux variables de type string.") { }

        protected override void App()
        {
            int step = 0;
            string str = String.Empty;

            string a = String.Empty;
            string b = String.Empty;

            while (step == 0)
            {
                Console.Write("Variable A : ");
                str = Console.ReadLine();
                if (str != null && str.Length > 0)
                {
                    step++;
                    break;
                }
            }

            a = str;

            while (step == 1)
            {
                Console.Write("Variable B : ");
                str = Console.ReadLine();
                if (str != null && str.Length > 0 && str != a)
                {
                    step++;
                    break;
                }
            }

            b = str;

            string save = a;
            a = b;
            b = save;

            WriteAndWaitForEnter($"Les variables sont interverties. A = \"{a}\", B = \"{b}\".");
        }
    }
}
