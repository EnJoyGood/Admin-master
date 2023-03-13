using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Models
{
    internal class Prod
    {
        public int ProductId { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public int Count { get; set; }

        [Column(TypeName = "image")]
        public byte[] Photo { get; set; }

        public virtual List<Order> Orders { get; set; } = new();
    }
}
