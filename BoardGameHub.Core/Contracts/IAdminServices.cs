using BoardGameHub.Core.DTOs.Admin.Response;

namespace BoardGameHub.Core.Contracts
{
    public interface IAdminServices
    {
        Task<IEnumerable<AdminIndexResponse>> Index();
    }
}
