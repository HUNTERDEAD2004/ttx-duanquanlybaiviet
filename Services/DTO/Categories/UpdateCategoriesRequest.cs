using Domain.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO.Categories
{
    public class UpdateCategoriesRequest
    {
        public int CategoryID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Royalty { get; set; }

        public EntityStatus Status { get; set; }
    }
}
