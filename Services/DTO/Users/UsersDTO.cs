using Domain.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO.Users
{
    public class UsersDTO
    {
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
    }
}
