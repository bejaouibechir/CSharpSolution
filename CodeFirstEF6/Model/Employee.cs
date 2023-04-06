using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstEF6.Model
{
    public class Employee
    {
        public Employee()
        {
            Produits = new HashSet<Produit>();
        }
        public int Id { get; set; }
        public string Nom { get; set; }

        public decimal? Salaire { get; set; }
        public DateTime? Recrutement { get; set; }

        public ICollection<Produit> Produits { get; set; }
    }
}
