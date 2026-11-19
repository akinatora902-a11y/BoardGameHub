using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameHub.Core.DTOs.Shop.Request
{
    public class EditShopRequest
    {
        public Guid Id {  get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Owner { get; set; } = null!;
    }
}
