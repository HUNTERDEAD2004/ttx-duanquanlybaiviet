using AppDomain.Object;
using Domain.Data.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data.Entities
{
    public class Users
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string Email { get; set; }

        public string EmailFE { get; set; }

        public string Avatar { get; set; }

        public string Bio { get; set; }

        public RoleSetUp Role { get; set; }

        public DateTime Createdate { get; set; }

        public DateTime Modifiedate { get; set; }

        public EntityStatus UStatus { get; set; }

        public int User_Training_Facility_Code { get; set; }

        // FK

        // N - 1
        public virtual Facility Facility { get; set; } = new Facility();

        // 1 - N
        public virtual ICollection<Articles> Articles { get; set; } = new List<Articles>();

        public virtual ICollection<ApprovalHistory> ApprovalHistory { get; set; } = new List<ApprovalHistory>();

        public virtual ICollection<User_RegistrationPeriods> User_RegistrationPeriods { get; set; } = new List<User_RegistrationPeriods>();
    }
}
