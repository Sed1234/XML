using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2408.Nodes
{
    public class News
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public DateTime pubDate { get; set; }

        public override string ToString ()
        {
            string str = string.Format(">>{0}\n{1}\n[Description]{2}\n{3}\n\n", Title, Link, Description, pubDate);
            return str;
        }

    }
}
