using Microsoft.EntityFrameworkCore;
using crud_cqrs_pattern.Commands;
using crud_cqrs_pattern.Data;
using crud_cqrs_pattern.Interfaces;
using crud_cqrs_pattern.Models;

namespace crud_cqrs_pattern.Handlers;

public class DeleteClienteCommandHandler : ICommandHandler<DeleteClienteCommand, Cliente>
{
    Cliente ICommandHandler<DeleteClienteCommand, Cliente>.Handle(DeleteClienteCommand command)
    {
        using var context = new AppDbContextWrite();

        var cliente = context.Clientes.Find(command.Id) ?? throw new InvalidOperationException("Cliente não encontrado!");

        context.Entry(cliente).State = EntityState.Deleted;
        context.SaveChanges();

        return cliente;
    }
}
