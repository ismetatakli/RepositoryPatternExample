using RepositoryPatternExample.API.Models;
using RepositoryPatternExample.API.Repository;

namespace RepositoryPatternExample.API.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        Task CompleteAsync();
    }
}
