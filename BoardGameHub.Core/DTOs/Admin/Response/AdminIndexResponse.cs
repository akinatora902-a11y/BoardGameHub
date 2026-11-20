namespace BoardGameHub.Core.DTOs.Admin.Response
{
    public class AdminIndexResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public bool ApprovalStatus { get; set; } 
    }
}
