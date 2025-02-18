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
        public string Is_Opening_registration { get; set; }
        //public enum Status { }
        public int RegistrationPeriodID { get; set; }
    }
}
