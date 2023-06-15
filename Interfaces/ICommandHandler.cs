namespace crud_cqrs_pattern.Interfaces;

public interface ICommandHandler<TCommand, TResult>
{
    TResult Handle(TCommand command);
}
