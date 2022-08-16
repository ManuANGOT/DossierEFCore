using ListeContactEFCORE.Classes;
using ListeContactEFCORE.Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListeContactEFCORE.Classes
{
    internal class IHM
    {
        private ApplicationDbContext _context = new();

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("\n=== MENU PRINCIPAL ===\n");

                Console.WriteLine("1. Voir les contacts");
                Console.WriteLine("2. Ajouter un contact");
                Console.WriteLine("3. Modifier un contact");
                Console.WriteLine("4. Supprimer un contact");
                Console.WriteLine("0. Quitter le programme");

                Console.Write("Faites votre choix : ");
                int mainChoice = int.Parse(Console.ReadLine());

                switch (mainChoice)
                {
                    case 0:
                        Environment.Exit(0);
                        break;

                    case 1:
                        ListContacts();
                        break;

                    case 2:
                        AddContact();
                        break;

                    case 3:
                        EditContact();
                        break;

                    case 4:
                        DeleteContact();
                        break;

                    default:
                        Console.WriteLine("Votre choix est incorrect !");
                        break;
                }
            }
        }

        private void ListContacts()
        {
            List<Contact> contactList = _context.Contacts.ToList();
          

            Console.WriteLine("\n--- Liste des contacts ---");

            if (contactList.Count > 0)
            {
                foreach (var contact in contactList) Console.WriteLine(contact);
            }
            else
            {
                Console.WriteLine("Ce contact n'existe pas dans la base de données !");
            }
        }

        private void AddContact()
        {

        }
        private void EditContact ()
        {

        }

        private void DeleteContact ()
        {

        }
    }
}
