
using CA.Application.DTO;
using CA.Domain.Repositories;
using CA.Infrastructure.EF.Contexts;
using CA.Infrastructure.EF.Models;
using CA.Infrastructure.EF.Queries;
using CA.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;

namespace CA.Application.Queries.Handlers
{
    internal sealed class GetTravelerCheckListHandler : IQueryHandler<GetTravelerCheckList, TravelerCheckListDto>
    {
        private readonly DbSet<TravelerCheckListReadModel> _TravelerCheckLists;

        public GetTravelerCheckListHandler(ReadDbContext context)
            => _TravelerCheckLists = context.TravelerCheckList;

        public Task<TravelerCheckListDto> HandleAsync(GetTravelerCheckList query)
            => _TravelerCheckLists
                .Include(pl => pl.Items)
                .Where(pl => pl.Id == query.Id)
                .Select(pl => pl.AsDto())
                .AsNoTracking()
                .SingleOrDefaultAsync();
    }
}
