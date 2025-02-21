using Domain.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO.ApprovalHistory
{
    public class ApprovalHistoryDTO
    {
        public int ApprovalID { get; set; }

        public int ArticleID { get; set; }

        public int UserID { get; set; }

        public string Type { get; set; }

        public string Note { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime ModifiledDate { get; set; }

        public HistoryApprovalStatus Status { get; set; }
    }
}
