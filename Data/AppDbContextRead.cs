using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using crud_cqrs_pattern.Models;

namespace crud_cqrs_pattern.Data;

public class AppDbContextRead : DbContext
{
    public DbSet<Cliente> Clientes { get; set; } = null!;

    public override int SaveChanges()
    {
        var stackTrace = new StackTrace();
        var callingMethod = stackTrace.GetFrame(1)?.GetMethod()?.Name;

        if (callingMethod != null && callingMethod == "Sync") return base.SaveChanges();

        throw new InvalidOperationException("Este banco de dados é somente para leitura!");
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("crud-cqrs-pattern-read");
    }
}
