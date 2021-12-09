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
                        SignIn();
                        break;
                    case '2':
                        SignUp();
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
                        //Gioca();
                        break;
                    case '2':
                        CreaEroe();
                        break;
                    case '3':
                        EliminaEroe();
                        break;
                    case '4':
                        //CreaMostro();
                        break;
                    case '5':
                        MostraClassifica();
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

        private static void SignIn()
        {
            string username;
            string password;
            bool checkOK;
            do
            {
                Console.WriteLine("Inserire Username");
                username = Console.ReadLine();
                Console.WriteLine("Inserire Password");
                password = Console.ReadLine();

                checkOK = bl.CheckCredentials(username, password);
                if (!checkOK)
                {
                    Console.WriteLine("Credenziali errate! ");
                }

            }
            while (!checkOK);

            if (bl.isUserAdmin(username))
            {
                AdminMenu();
            }
            else UserMenu();



        }



        private static void SignUp()
        {
            bool check = false;
            string username;
            do
            {
                Console.WriteLine("Inserire Nickname\n");
                username = Console.ReadLine();
                check = bl.CheckNickName(username);
                if (!check)
                {
                    Console.WriteLine("Nickname già in uso");
                }
            }
            while (!check);

            Console.WriteLine("Inserire password");
            string password = Console.ReadLine();

            int id = bl.GetAvailableId();

            User user = new User(username, password, id);
            if (!bl.AddUser(user))
            {
                Console.WriteLine("Qualcosa è andato storto!");
            }

        }

        private static void MostraClassifica()
        {
            Console.WriteLine("---- CLASSIFICA ----");
            List<Hero> heroes = bl.FetchClassica();
            List<User> users = bl.FetchUtenti(heroes);
            int i = 1;
            foreach (var e in heroes)
            {
                User u = users.Where(u => u.IdUser == e.IdUser).FirstOrDefault();
                Console.WriteLine($"{i}) {e.Name} - LVL: {e.Level} - Punti: {e.Exp} - Giocatore: {u.NickName}");
                i++;
            }
        }
        private static void EliminaEroe()
        {
            List<Hero> eroi = bl.GetAllHeroes();
            if (eroi.Count != 0)
            {
                foreach (var e in eroi)
                {
                    Console.WriteLine(e.ToString());
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
            bool isNameUsed;
            char choice;
            CatEnum cat;
            Console.WriteLine("Inserisci il nome dell'eroe");
            do
            {
                heroName = Console.ReadLine();
                isNameUsed = IsNameUsed(heroName);
                if(isNameUsed == true)
                    Console.WriteLine("E' già presente un eroe con questo nome");

            } while (isNameUsed == true);


            Console.WriteLine("Inserisci la categoria dell'eroe");
            do
            {
                Console.WriteLine("1 per scegliere un Guerriero\n" +
                    "2 per scegliere un Mago ");
                choice = Console.ReadKey().KeyChar;
                Console.WriteLine();
                
                switch (choice)
                {
                    case '1':
                         cat = CatEnum.Warrior;
                        
                        break;
                    case '2':
                        cat = CatEnum.Magician;
                        break;
                    default:
                        Console.WriteLine("Scelta non valida");
                        break;
                }
            } while (choice != '1' || choice != '2');

            Console.WriteLine("Inserisci l'arma dell'eroe");

            //PrintWeaponsByCategory(cat);

            Console.WriteLine("Eroe inserito");
        }




        private static bool IsNameUsed(string heroName)
        {
            bool isNameUsed = false;

            if (bl.GetHeroByName(heroName) == null)
                return false;
            else
                return true;
        }


        private static void PrintWeaponsByCategory(CatEnum cat)
        {
            List<Weapon> weapons = bl.GetWeaponsByCategory(cat);
            foreach (Weapon weapon in weapons)
                Console.WriteLine(weapon);
        }


        #endregion
        
        
    }
}



