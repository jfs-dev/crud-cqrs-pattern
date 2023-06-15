using crud_cqrs_pattern.Data;
using crud_cqrs_pattern.Interfaces;
using crud_cqrs_pattern.Models;
using crud_cqrs_pattern.Queries;

namespace crud_cqrs_pattern.Handlers;

public class GetAllClientesQueryHandler : IQueryHandler<GetAllClientesQuery, IEnumerable<Cliente>>
{
    IEnumerable<Cliente> IQueryHandler<GetAllClientesQuery, IEnumerable<Cliente>>.Handle(GetAllClientesQuery query)
    {
        using var context = new AppDbContextRead();
        
        return context.Clientes.ToList();
    }
}
