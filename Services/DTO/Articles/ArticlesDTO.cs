using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO.Articles
{
    public class ArticlesDTO
    {
        public int ArcticleID { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string EmailFe { get; set; }

        public decimal Royalty { get; set; }

        public string Download_path { get; set; }

        public string Preview_Image { get; set; }

        public string Description { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int CategoryID { get; set; }

        public int AuthorID { get; set; }

        public int WritingPhaseID { get; set; }

        public object? Articles_Hashtags { get; set; }

        public object? Approvals { get; set; }
    }
}
