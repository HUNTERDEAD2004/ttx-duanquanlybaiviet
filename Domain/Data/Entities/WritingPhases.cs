using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDomain.Object
{
    public class WritingPhases
    {
        public int WritingPhaseID { get; set; }

        public string Name { get; set; }

        public int AmountArticles { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime ModifiedAt { get; set; }

        public bool Is_Opening_registration { get; set; }

        public int RegistrationPeriodID { get; set; }

        //FK

        // n - 1
        public virtual RegistrationPeriods RegistrationPeriods { get; set; } = new RegistrationPeriods();

        // 1 - n
        public virtual ICollection<Articles> Articles { get; set; } = new List<Articles>(); 

        public virtual ICollection<User_RegistrationPeriods> UserRegistrationPeriods { get; set; } = new List<User_RegistrationPeriods>();
    }
}
