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
        List<Contact> Contacts;

        public IHM()
        {
            RefreshContactList()
        }

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
            Console.Clear();
            Console.WriteLine("------------------------- Ajouter Contact ? -------------------------\n");

            Contact c = null;

            try
            {
                string name, prenom, age, genre, phone, email;

                Console.Write("Veuillez saisir le nom du contact : ");
                name = Console.ReadLine();

                Console.Write("Veuillez saisir le prénom du contact : ");
                prenom = Console.ReadLine();

                Console.Write("Veuillez saisir l'âge du contact : ");
                age = Console.ReadLine();

                Console.Write("Veuillez saisir le genre du contact : ");
                genre = Console.ReadLine();

                Console.Write("Veuillez saisir le numéro de téléphone du contact : ");
                phone = Console.ReadLine();

                Console.Write("Veuillez saisir l'email du contact : ");
                email = Console.ReadLine();


                c = new(name, prenom, age, genre, phone, email);
               c.Id = c.Add();
                
                if (c.Id > 0)
                    Console.WriteLine("\nNouveau contact ajouté avec succès!\n");

                else
                    Console.WriteLine("\nErreur de l'ajout d'un nouveau contact!");

            }
                
        }
        private void EditContact ()
           { 
            Console.Clear();

            Console.WriteLine(Console.WriteLine("------------------------- Modifier Contact ? -------------------------\n"););

            Contact c = null;

            int index = -1;

            Console.Write("Veuillez saisir l'Id du contact à modifier");

            while(!int.TryParse(Console.ReadLine(), out index) && index >0)
                Console.WriteLine("Veuillez saisir un entier positif");


            (bool found, Contact tmp) = GetContact(index);

            if (found)
            {
                c = tmp;
            }

            else
            {
                Console.WriteLine("\nAucun contact avec cet ID !\n");
                return;
            }

            try
            {
                 string name, prenom, age, genre, phone, email;

                 Console.Write($"Veuillez saisir le nom du contact (Actual Value = {c.Name} => PRESS ENTER pour conserver) : ");
                string stringTmp = Console.ReadLine();
                name = stringTmp == "" ? c.Name : stringTmp;

                Console.Write($"Veuillez saisir le prénom du contact (Actual Value = {c.Prenom} => PRESS ENTER pour conserver) : ");
                stringTmp = Console.ReadLine();
                prenom = stringTmp == "" ? c.Prenom : stringTmp;

                
                Console.Write($"Veuillez saisir le genre du contact (Actual Value = {c.Genre} => PRESS ENTER pour conserver) : ");
                stringTmp = Console.ReadLine();
                genre = stringTmp == "" ? c.Genre : stringTmp;

                
                Console.Write($"Veuillez saisir le numéro de téléphone du contact (Actual Value = {c.Phone} => PRESS ENTER pour conserver) : ");
                stringTmp = Console.ReadLine();
                phone = stringTmp == "" ? c.Phone : stringTmp;

                
                Console.Write($"Veuillez saisir l'adresse mail du contact (Actual Value = {c.Email} => PRESS ENTER pour conserver) : ");
                stringTmp = Console.ReadLine();
                email = stringTmp == "" ? c.Email : stringTmp;


                Contact tmp = new Contact()
                { 
                Name = name,
                Prenom = prenom,
                Genre = genre,
                Phone = phone,
                Email = email              
                
                };

                if (!tmp.Update())
                    Console.WriteLine("\nErreur de la modification du contact.\n");
                else
                    Console.WriteLine("\nContact modifié avec succès...");

            }

        }

        private void DeleteContact ()
        {Console.Clear();

            Console.WriteLine("------------------------- Supprimer Contact -------------------------\n");

;
            int index = -1;
          
            Console.Write("Veuillez saisir l'id du contact à supprimer : ");
            while (!int.TryParse(Console.ReadLine(), out index) && index >= 0)
                OnRed("Veuillez saisir un entier");


            (bool found, Contact c) = GetContact(index);
            
            if (!found)
               
                OnRed("\nAucun contact avec cet ID!\n");

            if (c != null)
            {
                ( bool result, string message) = c.Delete();
                
                if (result)
                    OnGreen("\nContact supprimé avec succès!\n");
                else
                    OnRed("\nErreur lors de la suppression du contact!\n");
            }
        }

        public (bool, Contact) GetContact(int id)
        {
            Contact contact = new();
            (bool found, Contact c) = GetContact(id);

            if (found)
                contact = c;

            return (found, c)
        }

    }
}
