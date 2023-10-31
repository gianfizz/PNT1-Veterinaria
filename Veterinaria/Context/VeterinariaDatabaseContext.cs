using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Veterinaria.Models;

namespace Veterinaria.Context
{
    public class VeterinariaDatabaseContext : DbContext
    {
        public VeterinariaDatabaseContext(DbContextOptions<VeterinariaDatabaseContext> options) : base(options)
        {
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Doctor> Doctores { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Veterinarias> Veterinarias { get; set; }

    }
}
