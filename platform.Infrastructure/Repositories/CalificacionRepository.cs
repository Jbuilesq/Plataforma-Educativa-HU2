using platform.Domain.Interfaces;
using webEscuela.Domain.Entities;
using webEscuela.Infrastructure.Data;

namespace platform.Infrastructure.Repositories;

public class CalificacionRepository : Repository<Calificacion>, ICalificacionRepository
{
    public CalificacionRepository(EscuelaDbContext context) : base(context)
    {
        
    }
    
}