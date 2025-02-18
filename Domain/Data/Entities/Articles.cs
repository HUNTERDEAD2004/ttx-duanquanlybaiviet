using Domain.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDomain.Object
{
    public class Articles
    {
        public int ArcticleID { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string EmailFe {  get; set; }

        public string Avatar {  get; set; }

        public decimal Royalty { get; set; }

        public string Download_path { get; set; }

        public string Preview_Image { get; set; }

        public string Description { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int CategoryID { get; set; }

        public int AuthorID { get; set; }

        public int WritingPhaseID { get; set; }

        //FK

        //  n - 1
        public virtual Categories Categories { get; set; } = new Categories();

        public virtual WritingPhases WritingPhases { get; set; } = new WritingPhases();

        // 1 - n
        public virtual ICollection<Articles_Hashtag> Articles_Hashtags { get; set; } = new List<Articles_Hashtag>();

        public virtual ICollection<ApprovalHistory> Approvals { get; set; } = new List<ApprovalHistory>();
    }
}
