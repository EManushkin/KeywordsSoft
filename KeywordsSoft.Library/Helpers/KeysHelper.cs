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
    public class KeysHelper
    {
        private string Path = $@"{ConfigurationManager.AppSettings["DatabasePath"]}\keys\";

        private const string CreateCommand = @"CREATE TABLE Keys(
                                                  id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, 
                                                  name  TEXT,
                                                  good TEXT);
                                               CREATE TABLE variations(
                                                  id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, 
                                                  name TEXT);";

        private DatabaseRepository Database { get; set; }

        public KeysHelper()
        {
            Database = new DatabaseRepository();
        }

        public bool CreateDatabase(string dbName)
        {
            return Database.Create(Path, dbName, CreateCommand);
        }

        public void DeleteDatabase(string dbName)
        {
            Database.Delete(Path + dbName);
        }

        public bool Add(string dbName, List<string> entity)
        {
            return Database.Add<Keys>(Path, dbName, entity);
        }

        public List<Keys> Select(string dbName, string filter = null)
        {
            return Database.Select<Keys>(Path, dbName, filter);
        }

        public bool Delete(string dbName, List<string> keysIds)
        {
            string ids = string.Join(",", keysIds);
            return Database.Delete<Keys>(Path, dbName, $"id in ({ids})");
        }

        public bool MoveToAnotherDatabase(string dbNameFrom, string dbNameTo, List<string> keysIds)
        {
            string ids = string.Join(",", keysIds);
            return Database.MoveToAnotherDatabase<Keys>(Path, dbNameFrom, dbNameTo, $"id in ({ids})");
        }
    }
}
