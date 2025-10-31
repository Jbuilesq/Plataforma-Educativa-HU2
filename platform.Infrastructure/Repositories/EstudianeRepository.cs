using platform.Domain.Interfaces;
using webEscuela.Domain.Entities;
using webEscuela.Infrastructure.Data;

namespace platform.Infrastructure.Repositories;

public class EstudianeRepository : Repository<Estudiante>, IEstudienteRepository
{
    public EstudianeRepository(EscuelaDbContext context) : base(context)
    {
        
    }
}