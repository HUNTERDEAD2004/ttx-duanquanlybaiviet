using Domain.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDomain.Object
{
    public class Categories
    {
        public int CategoryID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Royalty { get; set; }

        public EntityStatus Status { get; set; }

        //FK

        // 1 - n
        public virtual ICollection<User_RegistrationPeriods> User_Registrations { get; set; } = new List<User_RegistrationPeriods>();

        public virtual ICollection<Articles> Articles { get; set; } = new List<Articles>();
    }
}
