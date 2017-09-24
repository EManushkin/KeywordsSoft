using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeywordsSoft.Library.Entities
{
    public class MainTable : Keys
    {
        [Browsable(false)]
        public bool isChecked { get; set; }

        public string cluster { get; set; }

        public int urls { get; set; }

        public int texts { get; set; }

        public int spintexts { get; set; }

        public int images { get; set; }

        public int snippets { get; set; }

        public int suggests { get; set; }

        public int videos { get; set; }
    }

    public class DbNamePath
    {
        public string Name { get; set; }

        public string Path { get; set; }

        public string Class { get; set; }
    }
}
