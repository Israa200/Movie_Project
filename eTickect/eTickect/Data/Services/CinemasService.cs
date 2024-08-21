using eTickets.Data.Base;
using eTickects.Models;
using eTickets.Data.Base;
using Microsoft.EntityFrameworkCore;
using eTickect.Data.Services;

namespace eTickects.Data.Services
{
	public class CinemasService : EntityBaseRepository<Cinema>, ICinemasService
	{
		public CinemasService(AppDbContext context) : base(context) { }

	}
}
