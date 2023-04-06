using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirstEF6
{
    internal class Program
    {
        static BusinessDBEntities _context;
        static void Main(string[] args)
        {
            _context = new BusinessDBEntities();
            List<Produit> produitlist = _context.Produits.ToList();
        }
    }
}


/*
 //Test d'ajout avec EF6 

  _context = new BusinessDBEntities();

            Client client = new Client
            {
                Id = 2,
                Nom = "Anouar",
                Adresse = "22 Rue des roses",
                Status = false,
                Contact = "anuar@xyz.com"
            };
            _context.Clients.Add(client);
            _context.SaveChanges();
 
 
 */

/*
  //Test de mise a jour 

  _context = new BusinessDBEntities();

            try
            {
                Client client = new Client
                {
                    Id = 2,
                    Nom = "Anouar",
                    Adresse = "56 Rue des Jasmins",
                    Status = false,
                    Contact = "anuar@xyz.com"
                };
                _context.Clients.AddOrUpdate(client);
                _context.SaveChanges();
            }
            catch (SqlException ex)
            {
                 Debug.WriteLine(ex.Message);
            }
 
 
 */

/*
 //Test de recupération d'une seule ligne à partir de la base de données
 _context = new BusinessDBEntities();
            //Ramène l'occurence unique comme celle qui se base sur l'identifiant
            //Note: Sa lève une exception dans le cas où il y a une duplication de valeur
            Client client1 = _context.Clients.SingleOrDefault(c=>c.Id==1);
            //Ramène la première occurence qui corréspond au critère
            Client client2 = _context.Clients.FirstOrDefault(c => c.Id == 1);
 
 */