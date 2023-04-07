﻿using System;
using System.Collections.Generic;

namespace WebMVCCore7_1.Models;

public partial class Category
{
    public int Id { get; set; }

    public string Label { get; set; } = null!;

    public virtual ICollection<Produit> Produits { get; } = new List<Produit>();
}
