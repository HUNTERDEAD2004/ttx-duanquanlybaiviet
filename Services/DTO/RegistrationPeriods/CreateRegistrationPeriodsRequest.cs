using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO.RegistrationPeriods
{
    public class CreateRegistrationPeriodsRequest
    {
        public string Name { get; set; }

        public DateTime RegistrationStart { get; set; }

        public DateTime RegistrationEnd { get; set; }

        public int User_Training_Facility_Code { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime ModifiedAt { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool Is_Opening_registration { get; set; }
    }
}
