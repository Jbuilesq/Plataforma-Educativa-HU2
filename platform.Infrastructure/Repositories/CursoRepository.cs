using platform.Domain.Interfaces;
using webEscuela.Domain.Entities;
using webEscuela.Infrastructure.Data;

namespace platform.Infrastructure.Repositories;

public class CursoRepository : Repository<Curso>, ICursoRepository
{
    public CursoRepository(EscuelaDbContext context) : base(context)
    {
        
    }
}