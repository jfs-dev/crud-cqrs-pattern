namespace crud_cqrs_pattern.Interfaces;

public interface IQueryHandler<TQuery, TResult>
{
    TResult Handle(TQuery query);
}
