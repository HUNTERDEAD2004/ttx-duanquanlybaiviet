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
        public virtual Categories Categories { get; set; }

        public virtual Users Users { get; set; }

        public virtual WritingPhases WritingPhases { get; set; }

        // 1 - n
        public virtual Articles_Hashtag Articles_Hashtag { get; set; }

        public virtual ApprovalHistory ApprovalHistory { get; set; }
    }
}
