using System.Collections.Generic;

namespace CodeFirstEF6.Model
{
    public class Categorie
    {
        public Categorie()
        {
            Produits = new HashSet<Produit>();
        }

        public int Id { get; set; }
        public string Label { get; set; }

        public virtual ICollection<Produit> Produits { get; set; }
    }
}
