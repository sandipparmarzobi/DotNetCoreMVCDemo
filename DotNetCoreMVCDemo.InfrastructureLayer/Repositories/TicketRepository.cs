using DotNetCoreMVCDemo.DomainLayer.Entity;
using DotNetCoreMVCDemo.InfrastructureLayer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreMVCDemo.InfrastructureLayer.Repositories
{
    public class TicketRepository : Repository<Tickets>
    {
        private readonly DotNetCoreMVCDemoContext _dbContext;

        public TicketRepository(DotNetCoreMVCDemoContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<Tickets> GetTicketsIncludeMovie()
        {
            return _dbContext.Tickets.Include(x => x.Movie).ToList();
        }

        public List<Tickets>? SearchTicketByName(string Name)
        {
            var ticket= _dbContext.Tickets.Where(s => s.CustomerName!.Contains(Name)).ToList();
            return ticket;
        }
    }
}
