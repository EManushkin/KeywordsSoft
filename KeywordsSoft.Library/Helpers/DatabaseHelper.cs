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

        public bool CreateCategoryDatabases(string dbName)
        {
            if (new KeysHelper().CreateDatabase(dbName))
            {
                return new TextsHelper().CreateDatabase(dbName) &&
                new ImagesHelper().CreateDatabase(dbName) &&
                new SnippetsHelper().CreateDatabase(dbName) &&
                new SuggestsHelper().CreateDatabase(dbName) &&
                new VideosHelper().CreateDatabase(dbName) &&
                new ClustersHelper().CreateDatabase(dbName);
            }

            return false;
        }

        public void DeleteCategoryDatabases(string dbName)
        {
            new KeysHelper().DeleteDatabase(dbName);
            new TextsHelper().DeleteDatabase(dbName);
            new ImagesHelper().DeleteDatabase(dbName);
            new SnippetsHelper().DeleteDatabase(dbName);
            new SuggestsHelper().DeleteDatabase(dbName);
            new VideosHelper().DeleteDatabase(dbName);
            new ClustersHelper().DeleteDatabase(dbName);
        }

        public List<MainTable> Select(string dbName)
        {
            List<MainTable> MainTableList = new List<MainTable>();

            var KeysList = new KeysHelper().Select(dbName);
            //new TextsHelper().DeleteDatabase(dbName);
            var ImagesList = new  ImagesHelper().Select(dbName);
            //new SnippetsHelper().DeleteDatabase(dbName);
            //new SuggestsHelper().DeleteDatabase(dbName);
            //new VideosHelper().DeleteDatabase(dbName);
            //new ClustersHelper().DeleteDatabase(dbName);

            MainTableList.AddRange(KeysList.Select(k => new MainTable()
            {
                id = k.id,
                name = k.name,
                good = k.good,
                isChecked = false,
                images = ImagesList.Count(i => i.key_id == k.id)
            }));

            return MainTableList;
        }
    }
}
