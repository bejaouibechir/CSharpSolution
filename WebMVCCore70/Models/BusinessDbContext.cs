using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebMVCCore70.Models;

public partial class BusinessDbContext : DbContext
{
    public BusinessDbContext()
    {
    }

    public BusinessDbContext(DbContextOptions<BusinessDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<Client> Clients { get; set; }
    public virtual DbSet<Employee> Employees { get; set; }
    public virtual DbSet<Produit> Produits { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlServer("Data Source=PC2023\\PC2023;Initial Catalog=BusinessDB;Integrated Security=True;" +
            "TrustServerCertificate=True"); 
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();//Clé primaire
            entity.Property(e => e.Label).HasMaxLength(50);
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Nom).HasMaxLength(50);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC079FA03943");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Nom).HasMaxLength(50);
            entity.Property(e => e.Recrutement).HasColumnType("date");
            entity.Property(e => e.Salaire).HasColumnType("money");
        });

        modelBuilder.Entity<Produit>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Label).HasMaxLength(50);
            entity.Property(e => e.Prix).HasColumnType("money");

            entity.HasOne(d => d.Categorie).WithMany(p => p.Produits)
                .HasForeignKey(d => d.CategorieId)
                .HasConstraintName("FK_Produits_Categories");

            entity.HasOne(d => d.Client).WithMany(p => p.Produits)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Produits_Clients");

            entity.HasOne(d => d.Employee).WithMany(p => p.Produits)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Produits_Employees");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
