using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListeContactEFCORE.Classes
{
    internal class Contact
    {
        // L'annotation Key sert à définir quelle est la clé primaire de notre modèle
        [Key] 
      
        // L'annotation StringLength(x) sert à définir la taille maximale de notre texte une fois en SQL
        [StringLength(80)]

        // L'annotation Required sert à s'assurer que la propriété est alimentée en cas d'ajout
         [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [StringLength(80)]
        [Required]
        public string Prenom { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Email { get; set; }






        public override string ToString()
        {
            return $"Id : {ID} - Nom : {Name}  - Prénom : {Prenom}) - Âge : {Age} ans - Genre : {Genre} - Téléphone {Phone} - Email : {Email}";
        }


    }
}
