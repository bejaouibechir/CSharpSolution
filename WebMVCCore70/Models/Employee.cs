using System;
using System.Collections.Generic;

namespace WebMVCCore70.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string? Nom { get; set; }

    public decimal? Salaire { get; set; }

    public DateTime? Recrutement { get; set; }

    public virtual ICollection<Produit> Produits { get; } = new List<Produit>();
}
