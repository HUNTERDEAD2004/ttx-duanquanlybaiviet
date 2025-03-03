using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO.Articles_Hashtag
{
    public class CreateArticles_HashtagRespository
    {
        public int HashtagID { get; set; }

        public int ArcticleID { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
