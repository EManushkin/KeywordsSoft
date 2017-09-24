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
    public class ClustersHelper
    {
        public static string Path = $@"{ConfigurationManager.AppSettings["DatabasePath"]}\clusters\";

        private string CreateCommand = @"CREATE TABLE keys_clusters(
                                            id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, 
                                            key_id INTEGER,
                                            cluster_id INTEGER);
                                         CREATE TABLE Clusters(
                                            id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, 
                                            name TEXT);";

        private DatabaseRepository Database { get; set; }

        public ClustersHelper()
        {
            Database = new DatabaseRepository();
        }

        public bool CreateDatabase(string dbName)
        {
            return Database.Create(Path, dbName + "_clusters", CreateCommand);
        }

        public void DeleteDatabase(string dbName)
        {
            Database.Delete(Path + dbName + "_clusters");
        }

        public List<Keys_Clusters> Select(string dbName, string filter = null)
        {
            return Database.Select<Keys_Clusters>(Path, dbName + "_clusters", filter);
        }

        public bool DeleteKeysRelationships(string dbName, string keysIds)
        {
            //string ids = string.Join(",", keysIds);
            return Database.Delete<Keys_Clusters>(Path, dbName + "_clusters", $"key_id in ({keysIds})");
        }

        public bool MoveToAnotherDatabase(string dbNameFrom, string dbNameTo, List<string> keysIds)
        {
            string ids = string.Join(",", keysIds);
            return Database.MoveToAnotherDatabase<Keys_Clusters>(Path, dbNameFrom + "_clusters", dbNameTo + "_clusters", $"key_id in ({ids})", null);
        }
    }
}
