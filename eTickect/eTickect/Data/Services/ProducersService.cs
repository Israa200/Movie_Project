using eTickects.Data;
using eTickects.Models;
using eTickets.Data.Base;

namespace eTickect.Data.Services
{
    public class ProducersService :EntityBaseRepository<Producer>,IProducersService
    {
        public ProducersService(AppDbContext context) : base(context) { }
    }
}
