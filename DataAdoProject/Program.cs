

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DataAdoProject.CRUD;

namespace DataAdoProject
{
    internal class Program
    {
        static DataContext _context;

        static void Main(string[] args)
        {
            _context = new DataContext();
            DataSet employeeData = _context.GetEmployeeList_DisconnetedMode();

            Console.Read();
        }

        /*
         //Test du mode déconnecté
            _context = new DataContext();
            DataSet dataSet = _context.GetEmployeeList_DisconnetedMode();
            DataTable employees = dataSet.Tables[0];
            List<Employee> employeeList = DataTableToList<Employee>(employees);
         
         */

        //Cette methode convertie une datatable en une liste générique 
        public static List<T> DataTableToList<T>(DataTable table) where T : new()
        {
            List<T> list = new List<T>();
            var typeProperties = typeof(T).GetProperties().Select(propertyInfo => new
            {
                PropertyInfo = propertyInfo,
                Type = Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType
            }).ToList();

            foreach (var row in table.Rows.Cast<DataRow>())
            {
                T obj = new T();
                foreach (var typeProperty in typeProperties)
                {
                    object value = row[typeProperty.PropertyInfo.Name];
                    object safeValue = value == null || DBNull.Value.Equals(value)
                        ? null
                        : Convert.ChangeType(value, typeProperty.Type);

                    typeProperty.PropertyInfo.SetValue(obj, safeValue, null);
                }
                list.Add(obj);
            }
            return list;
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

/*
 //Test d'ajout d'employee

 _context = new DataContext();
            Employee employee = new Employee { Id = 1, Nom="Bechir", 
                Recrutement=new DateTime(2015,2,8), Salaire=55000 };
            _context.AddEmployee(employee);
            Console.Read();
 
 */