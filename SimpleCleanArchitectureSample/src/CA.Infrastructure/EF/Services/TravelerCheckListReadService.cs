using CA.Application.Services;
using CA.Infrastructure.EF.Contexts;
using CA.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Infrastructure.EF.Services
{
    internal sealed class TravelerCheckListReadService : ITravelerCheckListReadService
    {
        private readonly DbSet<TravelerCheckListReadModel> _travelerCheckList;

        public TravelerCheckListReadService(ReadDbContext context)
            => _travelerCheckList = context.TravelerCheckList;

        public Task<bool> ExistsByNameAsync(string name)
            => _travelerCheckList.AnyAsync(pl => pl.Name == name);
    }
}
