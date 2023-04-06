using System;

namespace DataAdoProject.CRUD
{
    public class Employee
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public decimal? Salaire { get; set; } // C'est un type décimal nullable
        public DateTime? Recrutement { get; set; } //C'est un type datetime nullable
    }
}