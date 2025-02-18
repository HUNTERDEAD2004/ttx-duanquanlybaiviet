using Domain.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDomain.Object
{
    public class User_RegistrationPeriods
    {
        public int ID {  get; set; }

        public int UserID { get; set; }

        public int CategoryID { get; set; }

        public int WritingPhaseID { get; set; }

        public int RegistrationPeriods { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        //FK

        // n - 1 
        public virtual Users Users { get; set; } = new Users();

        public virtual Categories Categories { get; set; } = new Categories();

        public virtual WritingPhases WritingPhases { get; set; } = new WritingPhases();
    }
}
