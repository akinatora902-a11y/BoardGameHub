using AutoMapper;
using AutoMapper.QueryableExtensions;
using BoardGameHub.Core.Contracts;
using BoardGameHub.Core.DTOs.Admin.Response;
using BoardGameHub.Data;
using Microsoft.EntityFrameworkCore;

namespace BoardGameHub.Core.Services
{
    public class AdminServices(BoardGameHubDbContext dbContext, IMapper mapper) : IAdminServices
    {
        public async Task<IEnumerable<AdminIndexResponse>> Index()
        {
            var list = await dbContext.Shop
                .Where(s => s.ApprovalStatus == false)
                .OrderBy(s => s.Name)
                .ProjectTo<AdminIndexResponse>(mapper.ConfigurationProvider)
                .ToArrayAsync();

            return list;
        }
    }
}
