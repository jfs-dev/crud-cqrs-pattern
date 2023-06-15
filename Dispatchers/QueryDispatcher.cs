using crud_cqrs_pattern.Interfaces;

namespace crud_cqrs_pattern.Dispatchers;

public class QueryDispatcher
{
    public static TResult Dispatch<TQuery, TResult>(TQuery query)
    {
        var handlerType = typeof(IQueryHandler<,>).MakeGenericType(typeof(TQuery), typeof(TResult));
        var handlers = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(assembly => assembly.GetTypes())
            .Where(type => handlerType.IsAssignableFrom(type) && !type.IsInterface)
            .ToList();

        if (handlers.Count == 0) throw new InvalidOperationException($"Nenhum manipulador encontrado para o tipo de consulta '{typeof(TQuery).Name}'.");
        if (handlers.Count > 1) throw new InvalidOperationException($"Múltiplos manipuladores encontrados para o tipo de consulta '{typeof(TQuery).Name}'.");

        var handlerInstance = Activator.CreateInstance(handlers[0]) ?? throw new InvalidOperationException($"Não foi possível criar uma instância do manipulador de consulta para o tipo '{typeof(TQuery).Name}'.");
        var handler = (IQueryHandler<TQuery, TResult>)handlerInstance;

        return handler.Handle(query);
    }
}
