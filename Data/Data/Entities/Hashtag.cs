using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDomain.Object
{
    public class Hashtag
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HashtagID { get; set; }

        public string Title { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        //FK

        // 1 - n
        public virtual ICollection<Articles_Hashtag> Articles_Hashtags { get; set; } = new List<Articles_Hashtag>();
    }
}
