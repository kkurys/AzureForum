using System.Threading.Tasks;
using AzureForum.Data.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AzureForum.Data.Services
{
    public class DataService : IDataService
    {
        private readonly AzureForumDbContext _dbContext;

        public DataService(AzureForumDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DbSet<T> GetSet<T>() where T : class
        {
            return _dbContext.Set<T>();
        }

        public async Task SaveDbAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
