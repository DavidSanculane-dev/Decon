using Decon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Monitor = Decon.Domain.Entities.Monitor;

namespace Decon.Infrastructure.Data
{
    public class DeconDbContext : DbContext
    {

        public DeconDbContext(DbContextOptions<DeconDbContext> options) : base(options) { }

        // Tabelas de domínio
        public DbSet<PC> PCs => Set<PC>();
        public DbSet<Monitor> Monitors => Set<Monitor>();
        public DbSet<Printer> Printers => Set<Printer>();

        // Auxiliares
        public DbSet<User> Users => Set<User>();
        public DbSet<Department> Departments => Set<Department>();
        public DbSet<Location> Locations => Set<Location>();
        public DbSet<AssetAssignment> AssetAssignments => Set<AssetAssignment>();
        public DbSet<AssetHistory> AssetHistories => Set<AssetHistory>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Schema default para organizar as tabelas
            modelBuilder.HasDefaultSchema("decon");

            // Aplica todas as configurações Fluent de forma automática
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DeconDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

    }
}
