using crud_cqrs_pattern.Data;
using crud_cqrs_pattern.Interfaces;
using crud_cqrs_pattern.Models;
using crud_cqrs_pattern.Queries;

namespace crud_cqrs_pattern.Handlers;

public class GetClienteByIdQueryHandler : IQueryHandler<GetClienteByIdQuery, Cliente>
{
    public Cliente Handle(GetClienteByIdQuery query)
    {
        using var context = new AppDbContextRead();

        return context.Clientes.Find(query.Id) ?? throw new InvalidOperationException("Cliente não encontrado!");
    }
}
