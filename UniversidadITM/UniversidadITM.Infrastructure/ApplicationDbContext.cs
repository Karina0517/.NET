using Microsoft.EntityFrameworkCore;
using UniversidadITM.Domain.Entities;

namespace UniversidadITM.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Profesor> Profesores { get; set; }
    }
}
