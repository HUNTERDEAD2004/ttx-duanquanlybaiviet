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
    }
}
