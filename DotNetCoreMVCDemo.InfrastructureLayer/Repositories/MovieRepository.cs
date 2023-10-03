using DotNetCoreMVCDemo.DomainLayer.Entity;
using DotNetCoreMVCDemo.InfrastructureLayer.Data;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreMVCDemo.Data.Repository
{
    public class MovieRepository : Repository<Movie>
    {
        private readonly DotNetCoreMVCDemoContext _dbContext;

        public MovieRepository(DotNetCoreMVCDemoContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<Movie> GetMoviesIncludeTickets()
        {
            return _dbContext.Movies.Include(x => x.Tickets).ToList();
        }
    }
}
