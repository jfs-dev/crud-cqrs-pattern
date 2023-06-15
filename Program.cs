using crud_cqrs_pattern.Commands;
using crud_cqrs_pattern.Data;
using crud_cqrs_pattern.Dispatchers;
using crud_cqrs_pattern.Models;
using crud_cqrs_pattern.Queries;
using crud_cqrs_pattern.Services;

Console.WriteLine("Incluir cliente");
Console.WriteLine("---------------");

var createClientePeterParkerCommand = new CreateClienteCommand {Nome = "Peter Parker", Email = "peter.parker@marvel.com"};
var createClienteBenParkerCommand = new CreateClienteCommand {Nome = "Ben Parker", Email = "ben.parker@marvel.com"};
var createClienteMaryJaneCommand = new CreateClienteCommand {Nome = "Mary Jane", Email = "mary.jane@marvel.com"};
var peterParker = CommandDispatcher.Dispatch<CreateClienteCommand, Cliente>(createClientePeterParkerCommand);
var benParker = CommandDispatcher.Dispatch<CreateClienteCommand, Cliente>(createClienteBenParkerCommand);
var maryJane = CommandDispatcher.Dispatch<CreateClienteCommand, Cliente>(createClienteMaryJaneCommand);

Console.WriteLine($"Cliente incluído - {peterParker.Id} - {peterParker.Nome}");
Console.WriteLine($"Cliente incluído - {benParker.Id} - {benParker.Nome}");
Console.WriteLine($"Cliente incluído - {maryJane.Id} - {maryJane.Nome}");
Console.WriteLine("");

Console.WriteLine("Atualizar cliente");
Console.WriteLine("-----------------");

var updateClienteCommand = new UpdateClienteCommand {Id = 3, Nome = "Mary Jane Watson", Email = "mary.jane@marvel.com"};
var maryJaneUpdate = CommandDispatcher.Dispatch<UpdateClienteCommand, Cliente>(updateClienteCommand);

Console.WriteLine($"Cliente atualizado - {maryJaneUpdate.Id} - {maryJaneUpdate.Nome}");
Console.WriteLine("");

Console.WriteLine("Excluir cliente");
Console.WriteLine("---------------");

var deleteClienteCommand = new DeleteClienteCommand {Id = 2};
var benParkerDelete = CommandDispatcher.Dispatch<DeleteClienteCommand, Cliente>(deleteClienteCommand);

Console.WriteLine($"Cliente excluído - {benParkerDelete.Id} - {benParkerDelete.Nome}");
Console.WriteLine("");

DbMirrorService.Sync(new AppDbContextWrite(), new AppDbContextRead());

Console.WriteLine("Obter cliente");
Console.WriteLine("-------------");

var getClienteByIdQuery = new GetClienteByIdQuery {Id = 1};
var returnClienteQuery = QueryDispatcher.Dispatch<GetClienteByIdQuery, Cliente>(getClienteByIdQuery);

Console.WriteLine($"Cliente obtido - {returnClienteQuery.Id} - {returnClienteQuery.Nome}");
Console.WriteLine("");

Console.WriteLine("Obter todos os clientes");
Console.WriteLine("-----------------------");

var getAllClientesQuery = new GetAllClientesQuery();
var returnAllClientesQuery = QueryDispatcher.Dispatch<GetAllClientesQuery, IEnumerable<Cliente>>(getAllClientesQuery);

foreach (var currentCliente in returnAllClientesQuery)
{
    Console.WriteLine($"{currentCliente.Id} - {currentCliente.Nome}");
}
