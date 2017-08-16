using KeywordsSoft.Library.Database;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeywordsSoft.Library.Helpers
{
    public class DatabaseHelper
    {
        private string СategoriesPath = $@"{ConfigurationManager.AppSettings["DatabasePath"]}\keys\";

        private DatabaseRepository Database { get; set; }

        public DatabaseHelper()
        {
            Database = new DatabaseRepository();
        }

        public string[] GetСategories()
        {
            return Database.GetСategories(СategoriesPath);
        }

        public void CreateCategoryDatabases(string name)
        {
            new KeysHelper().CreateDatabase(name);
            new TextsHelper().CreateDatabase(name);
            new ImagesHelper().CreateDatabase(name);
            new SnippetsHelper().CreateDatabase(name);
            new SuggestsHelper().CreateDatabase(name);
            new VideosHelper().CreateDatabase(name);
            new ClustersHelper().CreateDatabase(name);
        }

        public void DeleteCategoryDatabases(string name)
        {
            new KeysHelper().DeleteDatabase(name);
            new TextsHelper().DeleteDatabase(name);
            new ImagesHelper().DeleteDatabase(name);
            new SnippetsHelper().DeleteDatabase(name);
            new SuggestsHelper().DeleteDatabase(name);
            new VideosHelper().DeleteDatabase(name);
            new ClustersHelper().DeleteDatabase(name);
        }
    }
}
