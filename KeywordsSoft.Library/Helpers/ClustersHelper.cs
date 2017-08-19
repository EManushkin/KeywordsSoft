using KeywordsSoft.Library.Database;
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
        private string Path = $@"{ConfigurationManager.AppSettings["DatabasePath"]}\clusters\";

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

        public bool CreateDatabase(string name)
        {
            return Database.Create(Path, name + "_clusters", CreateCommand);
        }

        public void DeleteDatabase(string name)
        {
            Database.Delete(Path + name + "_clusters");
        }
    }
}
