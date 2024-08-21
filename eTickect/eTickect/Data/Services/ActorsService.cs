using eTickets.Data.Base;
using eTickects.Models;
using eTickets.Data.Base;
using Microsoft.EntityFrameworkCore;

namespace eTickects.Data.Services
{
    public class ActorsService : EntityBaseRepository<Actor>, IActorsServices 
    {
       public ActorsService(AppDbContext context):base(context) { }
    }
}
