using KeywordsSoft.Library.Database;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeywordsSoft.Library.Helpers
{
    public class VideosHelper
    {
        private string Path = $@"{ConfigurationManager.AppSettings["DatabasePath"]}\videos\";

        private string CreateCommand = @"CREATE TABLE snippets(
                                            id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, 
                                            key_id INTEGER,
                                            text TEXT,
                                            parser_id INTEGER);";

        private DatabaseRepository Database { get; set; }

        public VideosHelper()
        {
            Database = new DatabaseRepository();
        }

        public bool CreateDatabase(string name)
        {
            return Database.Create(Path, name + "_videos", CreateCommand);
        }

        public void DeleteDatabase(string name)
        {
            Database.Delete(Path + name + "_videos");
        }
    }
}
