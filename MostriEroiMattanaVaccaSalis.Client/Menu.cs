using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriEroiMattanaVaccaSalis.Client
{
    internal class Menu
    {

        internal static void MainMenu()
        {
            do {
                Console.WriteLine("Digita 1 per accedere, 2 per registarti, 3 per uscire");
                int choice;
                choice = Console.ReadKey().KeyChar;


                switch (choice)
                {
                    case '1':
                        break;
                    case '2':
                        break;
                    default: Console.WriteLine("Scelta non disponibile");
                        break;
                }


            } while (choice != );
            

        }


        internal static void AdminMenu()
        {

        }

        internal static void UserMenu()
        {

        }
    }
}
