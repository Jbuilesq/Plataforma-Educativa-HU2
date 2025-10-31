using platform.Domain.Interfaces;
using webEscuela.Domain.Entities;
using webEscuela.Infrastructure.Data;

namespace platform.Infrastructure.Repositories;

public class SeccionRepository : Repository<Seccion>, ISeccionRepository
{
    public SeccionRepository(EscuelaDbContext context) : base(context)
    {
        
    }
}