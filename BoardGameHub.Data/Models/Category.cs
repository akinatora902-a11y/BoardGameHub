using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameHub.Data.Models
{
    public class Category
    {
        [Required]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        []
        public string Name { get; set; }
    }
}
