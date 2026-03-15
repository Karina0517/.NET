using System.Collections.Generic;
using System.Threading.Tasks;
using UniversidadITM.Domain.Dtos;

namespace UniversidadITM.Domain.Interfaces
{
    public interface IProfesorService
    {
        Task<IEnumerable<ProfesorDto>> ObtenerTodosAsync();
        Task<bool> RegistrarProfesorAsync(ProfesorCreateDto profesorDto);
    }
}
