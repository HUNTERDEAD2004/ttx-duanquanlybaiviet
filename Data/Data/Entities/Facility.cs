using Domain.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDomain.Object
{
    public class Facility
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FacilityId { get; set; }

        public string Name { get; set; }

        //FK

        // 1 - n 
        public virtual ICollection<Users> Users { get; set; } = new List<Users>();

        public virtual ICollection<RegistrationPeriods> Regions { get; set; } = new List<RegistrationPeriods>();
    }
}
