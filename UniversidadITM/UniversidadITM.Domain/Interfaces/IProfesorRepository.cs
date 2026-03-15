using System.Collections.Generic;
using System.Threading.Tasks;
using UniversidadITM.Domain.Entities;

namespace UniversidadITM.Domain.Interfaces
{
    public interface IProfesorRepository
    {
        Task<IEnumerable<Profesor>> ObtenerTodosAsync();
        Task AgregarAsync(Profesor profesor);
        Task<bool> ExisteEmailAsync(string email); // Bonus Nivel 5
    }
}
