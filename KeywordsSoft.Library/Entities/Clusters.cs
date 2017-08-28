using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeywordsSoft.Library.Entities
{
    public class Clusters
    {
        public long id { get; set; }

        public string name { get; set; }
    }

    public class Keys_Clusters
    {
        public long id { get; set; }

        public long key_id { get; set; }

        public long cluster_id { get; set; }
    }
}
