

using System;
using System.Collections.Generic;
using DataAdoProject.CRUD;

namespace DataAdoProject
{
    internal class Program
    {
        static DataContext _context;
      
        static void Main(string[] args)
        {
            _context = new DataContext();
            List<Categorie> categorie = _context.GetCategorieList();
            Console.Read();
        }
    }
}



/*
 // Test d'ajout de categorie

 _context = new DataContext();

            Categorie categorie1 = new Categorie { Id = 1, Label = "Voitures" };
            Categorie categorie2 = new Categorie { Id = 2, Label = "Motos" };
            Categorie categorie3 = new Categorie { Id = 3, Label = "Camions" };

            _context.AddCategorie(categorie1);
            _context.AddCategorie(categorie2);
            _context.AddCategorie(categorie3);

            Console.WriteLine("Les trois catégories sont ajoutées");
            Console.Read();
 
 
 
 */

/*
 //Test de mise à jour de catégorie
 _context = new DataContext();
            _context.UpdateCategorie(2, "Motocycles");
            Console.WriteLine("Une mise à jour a été effectuée");
            Console.Read();
 */

/*
 //Test de supression de catégorie

 _context = new DataContext();
            _context.DeleteCategorie(3);
            Console.WriteLine("Une supression a été effectuée");
            Console.Read();
 
 */

/*
 //Test de recuperation de categorie

_context = new DataContext();
            Categorie categorie = _context.GetCategorie(1);
            Console.Read();
 
 
 */