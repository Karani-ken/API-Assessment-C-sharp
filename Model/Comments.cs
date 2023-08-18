using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3Assessment.Model
{
    public class Comments
    {
        public string id { get; set; }
        public int postId { get; set; }
        public string name { get; set; }
        public string email { get; set; }

        public string body { get; set; }
    }
}
