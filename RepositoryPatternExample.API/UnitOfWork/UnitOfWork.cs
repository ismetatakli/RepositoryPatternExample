using RepositoryPatternExample.API.Models;
using RepositoryPatternExample.API.Repository;

namespace RepositoryPatternExample.API.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
                _context = context;
        }

        public async Task CompleteAsync()
        {
            try
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        await _context.SaveChangesAsync();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            catch (Exception e)
            {
                //Hata durumu
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
