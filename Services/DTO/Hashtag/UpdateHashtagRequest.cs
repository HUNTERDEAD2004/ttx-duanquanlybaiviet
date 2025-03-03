using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO.Hashtag
{
    public class UpdateHashtagRequest
    {
        public int HashtagID { get; set; }

        public string Title { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
