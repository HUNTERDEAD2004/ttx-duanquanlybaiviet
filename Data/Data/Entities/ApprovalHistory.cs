using Domain.Data.Entities;
using Domain.Data.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDomain.Object
{
    public class ApprovalHistory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ApprovalID { get; set; }

        public int ArticleID { get; set; }

        public int UserID { get; set; }

        public string Type { get; set; }

        public string Note { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime ModifiledDate { get; set; }

        public HistoryApprovalStatus Status { get; set; }

        //FK

        // n - 1
        public virtual Articles Articles { get; set; } = new Articles();

        public virtual Users Users { get; set; } = new Users();

        //
    }
}
