using System;
using System.Collections.Generic;

namespace WebMVCCore70.Models;

public partial class Client
{
    public int Id { get; set; }

    public string? Nom { get; set; }

    public bool? Status { get; set; }

    public string? Adresse { get; set; }

    public string? Contact { get; set; }

    public virtual ICollection<Produit> Produits { get; } = new List<Produit>();
}
