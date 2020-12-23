namespace AutoShow.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using AutoShow.Models;

    public partial class AutoShowContext : DbContext
    {
        public AutoShowContext()
            : base("name=AutoShowContext")
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<BodyType> BodyTypes { get; set; }
        public virtual DbSet<CarBrand> CarBrands { get; set; }
        public virtual DbSet<CarModel> CarModels { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Colour> Colours { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<EngineLocation> EngineLocations { get; set; }
        public virtual DbSet<EngineType> EngineTypes { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }
        public virtual DbSet<PaintedModel> PaintedModels { get; set; }
        public virtual DbSet<PaymentType> PaymentTypes { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Provider> Providers { get; set; }
        public virtual DbSet<Purchase> Purchases { get; set; }
        public virtual DbSet<Supply> Supplies { get; set; }
        public virtual DbSet<TechnicalInformation> TechnicalInformations { get; set; }
        public virtual DbSet<Warehouse> Warehouses { get; set; }//The quantity of products is stored here

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<BodyType>()
                .Property(e => e.BodyTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<BodyType>()
                .HasMany(e => e.TechnicalInformation)
                .WithRequired(e => e.BodyType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CarBrand>()
                .Property(e => e.CarBrandName)
                .IsUnicode(false);

            modelBuilder.Entity<CarBrand>()
                .HasMany(e => e.CarModel)
                .WithRequired(e => e.CarBrand)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CarModel>()
                .Property(e => e.CarModelName)
                .IsUnicode(false);

            modelBuilder.Entity<CarModel>()
                .HasMany(e => e.PaintedModel)
                .WithRequired(e => e.CarModel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Purchase)
                .WithRequired(e => e.Client)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Colour>()
                .Property(e => e.ColourName)
                .IsUnicode(false);

            modelBuilder.Entity<Colour>()
                .HasMany(e => e.PaintedModel)
                .WithRequired(e => e.Colour)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Country>()
                .Property(e => e.CountryName)
                .IsUnicode(false);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.CarModel)
                .WithRequired(e => e.Country)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EngineLocation>()
                .Property(e => e.EngineLocationName)
                .IsUnicode(false);

            modelBuilder.Entity<EngineLocation>()
                .HasMany(e => e.TechnicalInformation)
                .WithRequired(e => e.EngineLocation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EngineType>()
                .Property(e => e.EngineTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<EngineType>()
                .HasMany(e => e.TechnicalInformation)
                .WithRequired(e => e.EngineType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Manager>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Manager>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Manager>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Manager>()
                .HasMany(e => e.Purchase)
                .WithRequired(e => e.Manager)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PaintedModel>()
                .HasMany(e => e.Product)
                .WithRequired(e => e.PaintedModel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PaymentType>()
                .Property(e => e.PaymentTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<PaymentType>()
                .HasMany(e => e.Purchase)
                .WithRequired(e => e.PaymentType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Markup)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Supply)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasOptional(e => e.Warehouse)
                .WithRequired(e => e.Product);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Purchase)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Provider>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Provider>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Provider>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Provider>()
                .HasMany(e => e.Supply)
                .WithRequired(e => e.Provider)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Purchase>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Supply>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<TechnicalInformation>()
                .HasMany(e => e.CarModel)
                .WithRequired(e => e.TechnicalInformation)
                .WillCascadeOnDelete(false);
        }
    }
}