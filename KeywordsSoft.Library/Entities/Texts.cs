using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeywordsSoft.Library.Entities
{
    public class Texts
    {
        public long id { get; set; }

        public long key_id { get; set; }

        public string text { get; set; }

        public string spin { get; set; }

        public long parser_id { get; set; }

        public string url { get; set; }
    }
}
