using System;
using System.Collections.Generic;

namespace WebMVCCore7_1.Models;

public partial class Produit
{
    public int Id { get; set; }

    public string Label { get; set; } = null!;

    public decimal? Prix { get; set; }

    public int? ClientId { get; set; }

    public int? EmployeeId { get; set; }

    public int? CategorieId { get; set; }

    public virtual Category? Categorie { get; set; }

    public virtual Client? Client { get; set; }

    public virtual Employee? Employee { get; set; }
}
