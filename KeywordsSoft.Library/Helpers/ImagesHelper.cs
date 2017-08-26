using KeywordsSoft.Library.Database;
using KeywordsSoft.Library.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeywordsSoft.Library.Helpers
{
    public class ImagesHelper
    {
        private string Path = $@"{ConfigurationManager.AppSettings["DatabasePath"]}\images\";

        private string CreateCommand = @"CREATE TABLE images(
                                            id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, 
                                            key_id INTEGER,
                                            text TEXT,
                                            parser_id INTEGER);";

        private DatabaseRepository Database { get; set; }

        public ImagesHelper()
        {
            Database = new DatabaseRepository();
        }

        public bool CreateDatabase(string dbName)
        {
            return Database.Create(Path, dbName + "_images", CreateCommand);
        }

        public void DeleteDatabase(string dbName)
        {
            Database.Delete(Path + dbName + "_images");
        }

        public List<Images> Select(string dbName)
        {
            return Database.Select<Images>(Path, dbName);
        }

        public bool Add(string dbName, List<string> values)
        {
            return Database.Add<Images>(Path, dbName + "_images", values);
        }

    }
}
