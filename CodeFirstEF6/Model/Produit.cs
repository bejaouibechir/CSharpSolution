using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstEF6.Model
{
    public class Produit
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public decimal? Prix { get; set; }

        //Clé étrangère categorie
        public int CategorieId { get; set; }

        //Propriété de naviguation categorie
        public Categorie Categorie { get; set; }

        //Clé étrangère client
        public int ClientId { get; set; }

        //Propriété de naviguation client
        public Client Client { get; set; }

        //Clé étrangère client
        public int EmployeeId { get; set; }

        //Propriété de naviguation client
        public Employee Employee { get; set; }

    }
}
