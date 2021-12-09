using MostriEroiMattanaVaccaSalis.Core.BusinessLayer;
using MostriEroiMattanaVaccaSalis.Core.Entities;
using MostriEroiMattanaVaccaSalis.Mock.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriEroiMattanaVaccaSalis.Client
{
    internal class Menu
    {
        private static readonly BusinessLayer bl = new BusinessLayer(new UserRepository(), new HeroRepository(), new MonsterRepository(),new WeaponRepository());
        internal static void MainMenu()
        {  
            char choice;
            do {
                Console.WriteLine("Digita 1 per accedere, 2 per registarti, Q per uscire");
                
                choice = Console.ReadKey().KeyChar;


                switch (choice)
                {
                    case '1':
                        break;
                    case '2':
                        break;
                    case 'Q':
                        Console.WriteLine("Alla prossima partita");
                        break;
                    default: Console.WriteLine("Scelta non disponibile");
                        break;
                }


            } while (choice != 'Q');
            

        }


        internal static void AdminMenu()
        {
            char choice;
            do
            {
                Console.WriteLine("Scegli 1 per Giocare\n+" +
                "Scegli 2 per Creare un nuovo eroe\n" +
                "Scegli 3 per Eliminare un eroe\n" +
                "Scegli 4 per Creare un nuovo mostro\n" +
                "Scegli 5 per Mostrare la classifica globale\n" +
                "Scegli Q per Uscire");

                choice = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (choice)
                {
                    case '1':
                        break;
                    case '2':
                        break;
                    case '3':
                        break;
                    case '4':
                        break;
                    case '5':
                        break;
                    case 'Q':
                        Console.WriteLine("Alla prossima partita");
                        break;
                    default:
                        Console.WriteLine("Scelta non valida");
                        break;
                }
            } while (choice != 'Q');
        }

        internal static void UserMenu()
        {
            char choice;
            do
            {
                Console.WriteLine("Scegli 1 per Giocare\n+" +
                "Scegli 2 per Creare un nuovo eroe\n" +
                "Scegli 3 per Eliminare un eroe\n" +
                "Scegli Q per Uscire");

                choice = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (choice)
                {
                    case '1':
                        //Gioca();
                        break;
                    case '2':
                        CreaEroe();
                        break;
                    case '3':
                        EliminaEroe();
                        break;
                    case 'Q':
                        Console.WriteLine("Alla prossima partita");
                        break;
                    default:
                        Console.WriteLine("Scelta non valida");
                        break;
                }
            } while (choice != 'Q');
        }

        #region Metodi Menu
        private static void EliminaEroe()
        {
            
                List<Hero> eroi = bl.GetAllHeroes();
                if (eroi.Count != 0)
                {
                    
                    foreach (var e in eroi)
                    {
                    Console.WriteLine(e.ToString()); ;
                    
                    }
                int id;
                    
                   Console.Write("Quale eroe vuoi eliminare? Inserisci l'Id: ");
                while (!(int.TryParse(Console.ReadLine(), out id) && id > 0))
                {
                    Console.WriteLine("Valore errato. Riprova:");
                }
                Hero eroe = bl.GetHeroById(id);
                bool esito = bl.DeleteHero(eroe);
                if (esito)
                {
                    Console.WriteLine("Eroe eliminato correttamente!");
                }
                else
                {
                    Console.WriteLine("Ops, qualcosa è andato storto.");
                }
                    
                }
                else
                {
                    Console.WriteLine("Non hai nessun eroe nell'account. Creane uno.");
                }
            
            
        }
        private static void CreaEroe()
        {
            string heroName;
            bool flagNome = false;
            Console.WriteLine("Inserisci il nome dell'eroe");
            do
            {

            } while (flagNome == false);
            heroName = Console.ReadLine();
            Console.WriteLine("Inserisci la categoria dell'eroe");
            Console.WriteLine("Inserisci l'arma dell'eroe");
            Console.WriteLine("Eroe inserito");
        }




        private static void isNameUsed(string heroName)
        {
            bl.GetHeroByName(heroName);
        }



        #endregion
        
        
    }
}



