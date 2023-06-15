using Microsoft.EntityFrameworkCore;
using crud_cqrs_pattern.Commands;
using crud_cqrs_pattern.Data;
using crud_cqrs_pattern.Interfaces;
using crud_cqrs_pattern.Models;

namespace crud_cqrs_pattern.Handlers;

public class CreateClienteCommandHandler : ICommandHandler<CreateClienteCommand, Cliente>
{
    Cliente ICommandHandler<CreateClienteCommand, Cliente>.Handle(CreateClienteCommand command)
    {
        using var context = new AppDbContextWrite();
        
        var cliente = new Cliente { Nome = command.Nome, Email = command.Email };

        context.Entry(cliente).State = EntityState.Added;
        context.SaveChanges();

        return cliente;
    }
}
