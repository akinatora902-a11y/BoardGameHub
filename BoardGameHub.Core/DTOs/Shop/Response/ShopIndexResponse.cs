using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameHub.Core.DTOs.Shop.Response
{
    public class ShopIndexResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool ApprovalStatus { get; set; }
        public string Owner { get; set; } = null!;
    }
}
