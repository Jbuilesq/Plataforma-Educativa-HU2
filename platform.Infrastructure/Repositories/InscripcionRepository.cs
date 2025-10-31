using platform.Domain.Interfaces;
using webEscuela.Domain.Entities;
using webEscuela.Infrastructure.Data;

namespace platform.Infrastructure.Repositories;

public class InscripcionRepository : Repository<Inscripcion>, IInscripcionRepository
{
    public InscripcionRepository(EscuelaDbContext context) : base(context)
    {
        
    }
}