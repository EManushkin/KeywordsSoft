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

        public bool DeleteKeysWithRelationships(string dbName, List<string> keysIds)
        {
            return
                new KeysHelper().Delete(dbName, keysIds) &&
                new TextsHelper().DeleteKeysRelationships(dbName, keysIds) &&
                new ImagesHelper().DeleteKeysRelationships(dbName, keysIds) &&
                new SnippetsHelper().DeleteKeysRelationships(dbName, keysIds) &&
                new SuggestsHelper().DeleteKeysRelationships(dbName, keysIds) &&
                new VideosHelper().DeleteKeysRelationships(dbName, keysIds) &&
                new ClustersHelper().DeleteKeysRelationships(dbName, keysIds);
        }

        public bool MoveKeysToAnotherDatabase(string dbNameFrom, string dbNameTo, List<string> keysIds)
        {
            return
                new KeysHelper().MoveToAnotherDatabase(dbNameFrom, dbNameTo, keysIds) &&
                new TextsHelper().MoveToAnotherDatabase(dbNameFrom, dbNameTo, keysIds) &&
                new ImagesHelper().MoveToAnotherDatabase(dbNameFrom, dbNameTo, keysIds) &&
                new SnippetsHelper().MoveToAnotherDatabase(dbNameFrom, dbNameTo, keysIds) &&
                new SuggestsHelper().MoveToAnotherDatabase(dbNameFrom, dbNameTo, keysIds) &&
                new VideosHelper().MoveToAnotherDatabase(dbNameFrom, dbNameTo, keysIds) &&
                new ClustersHelper().DeleteKeysRelationships(dbNameFrom, keysIds);
        }


        public List<MainTable> Select(string dbName, string parserId = null)
        {
            List<MainTable> MainTableList = new List<MainTable>();

            string filter = null;
            if (parserId != null)
            {
                filter = $"parser_id = {parserId}";
            }

            var KeysList = new KeysHelper().Select(dbName);
            var TextsList = new TextsHelper().Select(dbName, filter);
            var ImagesList = new  ImagesHelper().Select(dbName, filter);
            var SnippetsList = new SnippetsHelper().Select(dbName, filter);
            var SuggestsList = new SuggestsHelper().Select(dbName, filter);
            var VideosList = new VideosHelper().Select(dbName, filter);
            var ClustersList = new ClustersHelper().Select(dbName);

            MainTableList.AddRange(KeysList.Select(k => new MainTable()
            {
                isChecked = false,
                id = k.id,
                name = k.name,
                good = k.good,
                cluster = string.Join(", ", ClustersList.Where(x => x.key_id == k.id).Select(c => c.cluster_id.ToString()).OrderBy(c => c)),
                urls = TextsList.Count(x => x.key_id == k.id && !string.IsNullOrEmpty(x.url)),
                texts = TextsList.Count(x => x.key_id == k.id),
                spintexts = TextsList.Count(x => x.key_id == k.id && !string.IsNullOrEmpty(x.spin)),
                images = ImagesList.Count(x => x.key_id == k.id),
                snippets = SnippetsList.Count(x => x.key_id == k.id),
                suggests = SuggestsList.Count(x => x.key_id == k.id),
                videos = VideosList.Count(x => x.key_id == k.id)
            }));

            return MainTableList;
        }
    }
}
