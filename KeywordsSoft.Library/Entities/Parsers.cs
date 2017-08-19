using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeywordsSoft.Library.Entities
{
    public class Parsers
    {
        public const string type_texts = "texts";
        public const string type_videos = "videos";
        public const string type_images = "images";
        public const string type_suggests = "suggests";
        public const string type_snippets = "snippets";
        public static readonly string[] types = { type_texts, type_videos, type_images, type_suggests, type_snippets };

        public long id { get; set; }

        public string name { get; set; }

        public string type { get; set; }
    }
}
