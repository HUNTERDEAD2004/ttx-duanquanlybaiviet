using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDomain.Object
{
    public class Articles_Hashtag
    {
        public int Id { get; set; }

        public int HashtagID { get; set; }

        public int ArcticleID { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        //FK

        // n - 1 
        public virtual Articles Articles { get; set; } = new Articles();

        public virtual Hashtag Hashtag { get; set; } = new Hashtag();
    }
}
