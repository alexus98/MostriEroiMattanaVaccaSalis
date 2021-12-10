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
                Console.Write("Digita 1 per accedere, 2 per registarti, Q per uscire: ");
                
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

        

        internal static void AdminMenu(User u)
        {
            char choice;
            do
            {
                Console.WriteLine("\nScegli 1 per Giocare\n" +
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
                        Gioca(u);
                        break;
                    case '2':
                        CreaEroe(u);
                        break;
                    case '3':
                        EliminaEroe(u);
                        break;
                    case '4':
                        CreaMostro();
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

        internal static void UserMenu(User u)
        {
            char choice;
            do
            {
                Console.WriteLine("\nScegli 1 per Giocare\n" +
                "Scegli 2 per Creare un nuovo eroe\n" +
                "Scegli 3 per Eliminare un eroe\n" +
                "Scegli Q per Uscire");

                choice = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (choice)
                {
                    case '1':
                        Gioca(u);
                        break;
                    case '2':
                        CreaEroe(u);
                        break;
                    case '3':
                        EliminaEroe(u);
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
        private static void Gioca(User u)
        {
            Hero hero = new Hero();
            bool exit;
            bool sceltaeroe = true;
            do
            {
                if(sceltaeroe)
                    hero = SceltaHero(u);

                if (hero == null)
                {
                    hero = CreaEroe(u);
                }

                Partita(u, hero);

                Console.WriteLine("\nVuoi continuare a giocare? Schiaccia [S] per continuare o qualsiasi tasto per uscire");
                char risp = Console.ReadKey().KeyChar;
                if (risp == 'S')
                {
                    exit = true;
                    Console.WriteLine("\nVuoi continuare con lo stesso eroe? Schiaccia [S] per continuare o qualsiasi tasto per scegliere un nuovo eroe");
                    char risp2 = Console.ReadKey().KeyChar;

                    if (risp2 != 'S')
                    {
                        sceltaeroe = true;
                    }
                    else
                        sceltaeroe = false;
                }
                else
                    exit = false;
            } while (exit);
        }

        private static void Partita(User u, Hero? hero)
        {

            Monster monster = bl.GetRandomMonster(hero.Level);
            Weapon heroWeapon = bl.GetWeaponsById(hero.IdWeapon);
            Weapon monsterWeapon = bl.GetWeaponsById(monster.IdWeapon);

            Turno t = Turno.Player;
            char choice;
            bool escape = false;
            bool win = false;
            Console.WriteLine("----LET'S BATTLE BEGIN!----");
            Console.WriteLine($"{hero.Name} VS {monster.Name}");
            do
            {
                switch (t)
                {
                    case Turno.Player:
                        do
                        {
                            Console.Write("\nPremi 1 per attaccare\n" +
                                "Premi 2 per fuggire: ");
                            choice = Console.ReadKey().KeyChar;

                            if (choice == '1')
                            {
                                Console.WriteLine($"\nE' il turno di {hero.Name}");
                                hero.Attack(monster, heroWeapon);
                            }
                            else if (choice == '2')
                                escape = hero.Escape();
                            
                        } while (choice != '1' && choice != '2');
                        if (monster.LifePoints <= 0)
                            win = true;
                        t = Turno.Monster;
                        break;

                    case Turno.Monster:
                        Console.WriteLine($"E' il turno di {monster.Name}");
                        monster.Attack(hero, monsterWeapon);
                        t = Turno.Player;
                        break;
                }


            } while (hero.LifePoints > 0 && monster.LifePoints > 0 && escape == false);

            if (escape)
            {
                hero.Exp -= monster.Level * 5;
                Console.WriteLine("Fiu, l'hai scampata bella!");
            }
            else if (win)
            {
                hero.Exp += monster.Level * 10;
                Console.WriteLine($"YOU WIN!! Hai guadagnato {hero.Exp += monster.Level * 10} Exp");
            }

            hero.SetLevelByExp();
            hero.SetLifePointsByLevel();

            if(hero.Level >= 3)
                u.IsAdmin = true;

            UpdateHero(hero);
            UpdateUser(u);
             
        }

        public enum Turno
        {
            Player = 1,
            Monster = 2
            
        }

        private static Hero SceltaHero(User u)
        {
            List<Hero> heroes = bl.GetAllHeroes(u);
            if (heroes.Count != 0)
            {
                foreach (var e in heroes)
                {
                    Console.WriteLine(e.ToString());  
                }
                int id;
                Console.Write("\nQuale eroe vuoi scegliere? Inserisci l'Id: ");
                while (!(int.TryParse(Console.ReadLine(), out id) && id > 0))
                {
                    Console.WriteLine("Valore errato. Riprova:");
                }

                Hero eroe = bl.GetHeroById(id);
                return eroe;
            }
            else
            {
                return null;
                Console.WriteLine("Non hai nessun eroe nell'account. Creane uno.");   
            }
        }

        private static void SignIn()
        {
            string username;
            string password;
            bool checkOK;
            do
            {
                Console.WriteLine("\nInserire Username");
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

            User user= new User();
            if (bl.isUserAdmin(username))
            {
                user = bl.GetUser(username);
                AdminMenu(user);
            }
            else UserMenu(user);



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
                if (check)
                {
                    Console.WriteLine("Nickname già in uso");
                }
            }
            while (check);

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

        private static void EliminaEroe(User u)
        {
            List<Hero> eroi = bl.GetAllHeroes(u);
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

        private static Hero CreaEroe(User u)
        {
            string heroName;
            bool isNameUsed, flagWeapon;
            char choice;
            int idWeapon;
            Hero hero = new Hero();
            Hero newHero;
            Console.WriteLine("Inserisci il nome dell'eroe");
            do
            {
                heroName = Console.ReadLine();
                isNameUsed = IsNameUsed(heroName);
                if(isNameUsed == true)
                    Console.WriteLine("E' già presente un eroe con questo nome");
            } while (isNameUsed == true);
            hero.Name = heroName;


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
                        hero.Category = CatEnum.Warrior;
                        break;
                    case '2':
                        hero.Category = CatEnum.Magician;
                        break;
                    default:
                        Console.WriteLine("Scelta non valida");
                        break;
                }
            } while (choice != '1' && choice != '2');

            Console.WriteLine("Inserisci l'arma dell'eroe");

            do
            {
                PrintWeaponsByCategory(hero.Category);
                idWeapon = int.Parse(Console.ReadLine());
                flagWeapon = IsWeaponsForThisCategory(idWeapon, (int)hero.Category);
                if (flagWeapon == false)
                    Console.WriteLine("Inserisci un id dell'arma valido");
            } while (flagWeapon == false);
            
            hero.IdWeapon = idWeapon;
            hero.IdUser = u.IdUser;
            
            newHero = bl.InsertHero(hero);
            
            Console.WriteLine("Eroe inserito");
            return newHero;
        }

        private static void CreaMostro()
        {
            string monsterName;
            bool isNameUsed, flagWeapon, success;
            char choice;
            CatEnum cat;
            int idWeapon, level;
            Monster monster = new Monster();
            Console.WriteLine("Inserisci il nome del mostro");
            do
            {
                monsterName = Console.ReadLine();
                isNameUsed = IsMonsterNameUsed(monsterName);
                if (isNameUsed == true)
                    Console.WriteLine("E' già presente un mostro con questo nome");
            } while (isNameUsed == true);
            monster.Name = monsterName;


            Console.WriteLine("Inserisci la categoria del mostro");
            do
            {
                Console.WriteLine("1 per scegliere un Cultista\n" +
                    "2 per scegliere un Orco\n" +
                    "3 per scegliere un Signore del male");
                choice = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (choice)
                {
                    case '1':
                        monster.Category = CatEnum.Cultist;
                        break;
                    case '2':
                        monster.Category = CatEnum.Orc;
                        break;
                    case '3':
                        monster.Category = CatEnum.Saruman;
                        break;
                    default:
                        Console.WriteLine("Scelta non valida");
                        break;
                }
            } while (choice != '1' && choice != '2' && choice != '3');

            Console.WriteLine("Inserisci l'arma del mostro");

            do
            {
                PrintWeaponsByCategory(monster.Category);
                idWeapon = int.Parse(Console.ReadLine());
                flagWeapon = IsWeaponsForThisCategory(idWeapon, (int)monster.Category);
                if (flagWeapon == false)
                    Console.WriteLine("Inserisci un id dell'arma valido");
            } while (flagWeapon == false);

            Console.WriteLine("Inserisci il livello del mostro");
            do
            {
                level = int.Parse(Console.ReadLine());  
                if (level < 1 || level > 5)
                    Console.WriteLine("Inserisci un livello da 1 a 5");
                else
                    monster.Level = level;
            } while (level < 1 || level > 5);

            monster.SetLifePointsByLevel();

            monster.IdWeapon = idWeapon;
            success = bl.InsertMonster(monster);

            Console.WriteLine("Mostro inserito");
        }

        private static bool IsNameUsed(string heroName)
        {
            if (bl.GetHeroByName(heroName) == null)
                return false;
            else
                return true;
        }

        private static bool IsMonsterNameUsed(string monsterName)
        {
            bool isNameUsed = false;

            if (bl.GetMonsterByName(monsterName) == null)
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

        private static bool IsWeaponsForThisCategory(int id, int cat)
        {
            return bl.GetWeaponsById(id).IdCategory == cat;
        }

        private static void UpdateHero(Hero h)
        {
            bl.UpdateHero(h);
        }

        private static void UpdateUser(User u)
        {
            bl.UpdateUser(u);
        }
        #endregion


    }
}



