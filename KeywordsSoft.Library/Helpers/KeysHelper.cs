using KeywordsSoft.Library.Database;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeywordsSoft.Library.Helpers
{
    public class KeysHelper
    {
        private string Path = $@"{ConfigurationManager.AppSettings["DatabasePath"]}\keys\";

        private const string CreateCommand = @"CREATE TABLE Keys(
                                                  id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, 
                                                  name  TEXT,
                                                  good INTEGER);
                                               CREATE TABLE variations(
                                                  id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, 
                                                  name TEXT);";

        private DatabaseRepository Database { get; set; }

        public KeysHelper()
        {
            Database = new DatabaseRepository();
        }

        public bool CreateDatabase(string name)
        {
            return Database.Create(Path, name, CreateCommand);
        }

        public void DeleteDatabase(string name)
        {
            Database.Delete(Path + name);
        }
    }
}
