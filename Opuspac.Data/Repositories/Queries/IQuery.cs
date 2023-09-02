namespace Opuspac.Data.Repositories.Queries;

public interface IQuery<TOut>
{
    IQueryable<TOut> Run(DatabaseContext dbContext);
}