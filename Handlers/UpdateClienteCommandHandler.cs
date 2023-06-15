using Microsoft.EntityFrameworkCore;
using crud_cqrs_pattern.Commands;
using crud_cqrs_pattern.Data;
using crud_cqrs_pattern.Interfaces;
using crud_cqrs_pattern.Models;

namespace crud_cqrs_pattern.Handlers;

public class UpdateClienteCommandHandler : ICommandHandler<UpdateClienteCommand, Cliente>
{
    Cliente ICommandHandler<UpdateClienteCommand, Cliente>.Handle(UpdateClienteCommand command)
    {
        using var context = new AppDbContextWrite();

        var cliente = context.Clientes.Find(command.Id) ?? throw new InvalidOperationException("Cliente não encontrado!");
        
        cliente.Nome = command.Nome;
        cliente.Email = command.Email;

        context.Entry(cliente).State = EntityState.Modified;
        context.SaveChanges();

        return cliente;
    }
}
