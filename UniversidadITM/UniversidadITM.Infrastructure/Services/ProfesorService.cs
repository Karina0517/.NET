using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using UniversidadITM.Domain.Dtos;
using UniversidadITM.Domain.Entities;
using UniversidadITM.Domain.Interfaces;

namespace UniversidadITM.Infrastructure.Services
{
    public class ProfesorService : IProfesorService
    {
        private readonly IProfesorRepository _repository;
        private readonly IMapper _mapper;

        public ProfesorService(IProfesorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProfesorDto>> ObtenerTodosAsync()
        {
            var profesores = await _repository.ObtenerTodosAsync();
            return _mapper.Map<IEnumerable<ProfesorDto>>(profesores);
        }

        public async Task<bool> RegistrarProfesorAsync(ProfesorCreateDto profesorDto)
        {
            // Reto de Robustez: Provocar error a propósito si el nombre es Error
            if (profesorDto.Nombre.Equals("Error", StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception("Error de prueba");
            }

            // Regla de Negocio Crítica: Validar Especialidad no vacía
            if (string.IsNullOrWhiteSpace(profesorDto.Especialidad))
            {
                throw new ArgumentException("La especialidad del profesor no puede estar vacía.");
            }

            // Regla de Negocio Crítica: Perfil Senior
            if (profesorDto.Especialidad.Equals("Arquitectura", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Perfil Senior Detectado");
            }

            // Bonus Nivel 5: Email único
            if (await _repository.ExisteEmailAsync(profesorDto.Email))
            {
                throw new ArgumentException($"El email {profesorDto.Email} ya está registrado.");
            }

            // AutoMapper para evitar asignaciones manuales en el servicio
            var profesor = _mapper.Map<Profesor>(profesorDto);
            profesor.FechaContratacion = DateTime.UtcNow;

            await _repository.AgregarAsync(profesor);
            return true;
        }
    }
}
