using crud_cqrs_pattern.Interfaces;

namespace crud_cqrs_pattern.Dispatchers;

public class CommandDispatcher
{
    public static TResult Dispatch<TCommand, TResult>(TCommand command)
    {
        var handlerType = typeof(ICommandHandler<,>).MakeGenericType(typeof(TCommand), typeof(TResult));
        var handlers = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(assembly => assembly.GetTypes())
            .Where(type => handlerType.IsAssignableFrom(type) && !type.IsInterface)
            .ToList();

        if (handlers.Count == 0) throw new InvalidOperationException($"Nenhum manipulador encontrado para o tipo de comando '{typeof(TCommand).Name}'.");
        if (handlers.Count > 1) throw new InvalidOperationException($"Múltiplos manipuladores encontrados para o tipo de comando '{typeof(TCommand).Name}'.");

        var handlerInstance = Activator.CreateInstance(handlers[0]) ?? throw new InvalidOperationException($"Não foi possível criar uma instância do manipulador de comando para o tipo de comando '{typeof(TCommand).Name}'.");
        var handler = (ICommandHandler<TCommand, TResult>)handlerInstance;

        return handler.Handle(command);
    }
}
