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
    public class SuggestsHelper
    {
        private string Path = $@"{ConfigurationManager.AppSettings["DatabasePath"]}\suggests\";

        private string CreateCommand = @"CREATE TABLE suggests(
                                            id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, 
                                            key_id INTEGER,
                                            text TEXT,
                                            parser_id INTEGER);";

        private DatabaseRepository Database { get; set; }

        public SuggestsHelper()
        {
            Database = new DatabaseRepository();
        }

        public bool CreateDatabase(string dbName)
        {
            return Database.Create(Path, dbName + "_suggests", CreateCommand);
        }

        public void DeleteDatabase(string dbName)
        {
            Database.Delete(Path + dbName + "_suggests");
        }

        public bool Add(string dbName, List<string> values)
        {
            return Database.Add<Suggests>(Path, dbName + "_suggests", values);
        }
    }
}
