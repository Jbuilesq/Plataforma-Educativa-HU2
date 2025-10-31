using platform.Domain.Interfaces;
using webEscuela.Domain.Entities;
using webEscuela.Infrastructure.Data;

namespace platform.Infrastructure.Repositories;

public class ProfesorRepository : Repository<Profesor>, IProfesorRepository
{
    public ProfesorRepository(EscuelaDbContext context) : base(context)
    {
        
    }
}