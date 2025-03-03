using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO.WritingPhases
{
     public class CreateWritingPhasesRequest
    {
        public string Name { get; set; }

        public int AmountArticles { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime ModifiedAt { get; set; }

        public bool Is_Opening_registration { get; set; }

        public int RegistrationPeriodID { get; set; }
    }
}
