using Backend.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Context
{
    public class EYDbContext : DbContext
    {
        public EYDbContext() { }
        public EYDbContext(DbContextOptions<EYDbContext> options) : base(options) { }

        public DbSet<User> User { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        // public DbSet<Profile> Profile { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
                optionsBuilder.UseMySql("server=roundhouse.proxy.rlwy.net;port=13761;user=root;password=hJhdkhkiVNkepIJczmEIdVRmatkyETuE;Database=railway", serverVersion);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            /*
                public int Id { get; set; }
                public string Username { get; set; }
                public string Password { get; set; }*/
            modelBuilder.Entity<User>().ToTable("user");
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<User>().Property(u => u.username).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.password).IsRequired();

            
            modelBuilder.Entity<Supplier>().ToTable("supplier");
            modelBuilder.Entity<Supplier>().HasKey(s => s.Id);
            modelBuilder.Entity<Supplier>().Property(s => s.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Supplier>().Property(s => s.razonSocial).IsRequired();
            modelBuilder.Entity<Supplier>().Property(s => s.nombreComercial).IsRequired();
            modelBuilder.Entity<Supplier>().Property(s => s.identificacionTributaria).IsRequired();
            modelBuilder.Entity<Supplier>().Property(s => s.numeroTelefonico).IsRequired();
            modelBuilder.Entity<Supplier>().Property(s => s.email).IsRequired();
            modelBuilder.Entity<Supplier>().Property(s => s.sitioWeb).IsRequired();
            modelBuilder.Entity<Supplier>().Property(s => s.direccionFisica).IsRequired();
            modelBuilder.Entity<Supplier>().Property(s => s.pais).IsRequired();
            modelBuilder.Entity<Supplier>().Property(s => s.facturacionAnual).IsRequired();
            modelBuilder.Entity<Supplier>().Property(s => s.ultimaModificacion).IsRequired().HasDefaultValue(DateTime.UtcNow);

        }
    }
}
