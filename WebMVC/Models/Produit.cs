//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Produit
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public Nullable<decimal> Prix { get; set; }
        public Nullable<int> ClientId { get; set; }
        public Nullable<int> EmployeeId { get; set; }
        public Nullable<int> CategorieId { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual Client Client { get; set; }
        public virtual Employee Employee { get; set; }
    }
}