using DotNetCoreMVCDemo.DomainLayer.Entity;
using DotNetCoreMVCDemo.InfrastructureLayer.Data;

namespace DotNetCoreMVCDemo.Data.Repository
{
    public class MovieRepository : Repository<Movie>
    {
        public MovieRepository(DotNetCoreMVCDemoContext dbContext) : base(dbContext)
        {

        }
    }
}
