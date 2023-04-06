using System.Collections.Generic;
using System.Security.Cryptography;

namespace CodeFirstEF6.Model
{
    public class Client
    {
        public Client()
        {
            Produits= new HashSet<Produit>();
        }

        public int Id { get; set; }
        public string Nom { get; set; }
        public bool Status { get; set; }
        public string Adresse { get; set; }

        public string Contact { get; set; }

        public virtual ICollection<Produit> Produits { get; set; }
    }
}
