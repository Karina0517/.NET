using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UniversidadITM.Domain.Entities;
using UniversidadITM.Domain.Interfaces;

namespace UniversidadITM.Infrastructure.Repositories
{
    public class ProfesorRepository : IProfesorRepository
    {
        private readonly ApplicationDbContext _context;

        public ProfesorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Profesor>> ObtenerTodosAsync()
        {
            return await _context.Profesores.ToListAsync();
        }

        public async Task AgregarAsync(Profesor profesor)
        {
            await _context.Profesores.AddAsync(profesor);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExisteEmailAsync(string email)
        {
            return await _context.Profesores.AnyAsync(p => p.Email == email);
        }
    }
}
