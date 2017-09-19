using KeywordsSoft.Library.Database;
using KeywordsSoft.Library.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
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

            //var KeysList = new KeysHelper().Select(dbName);
            //var TextsList = new TextsHelper().Select(dbName, (filter != null ? filter : "1") + " group by key_id", "id, key_id, CAST(COUNT(NULLIF(text, '' )) as TEXT) as text, CAST(COUNT(NULLIF(spin, '' )) as TEXT) as spin, parser_id, CAST(COUNT(NULLIF(url, '' )) as TEXT) as url");
            //var ImagesList = new ImagesHelper().Select(dbName, (filter != null ? filter : "1") + " group by key_id", "id, key_id, CAST(COUNT(NULLIF(text, '' )) as TEXT) as text, parser_id");
            //var SnippetsList = new SnippetsHelper().Select(dbName, (filter != null ? filter : "1") + " group by key_id", "id, key_id, CAST(COUNT(NULLIF(text, '' )) as TEXT) as text, parser_id");
            //var SuggestsList = new SuggestsHelper().Select(dbName, (filter != null ? filter : "1") + " group by key_id", "id, key_id, CAST(COUNT(NULLIF(text, '' )) as TEXT) as text, parser_id");
            //var VideosList = new VideosHelper().Select(dbName, (filter != null ? filter : "1") + " group by key_id", "id, key_id, CAST(COUNT(NULLIF(text, '' )) as TEXT) as text, parser_id");
            //var ClustersList = new ClustersHelper().Select(dbName);

            //MainTableList = (
            //    from k in KeysList
            //    join t in TextsList on k.id equals t.key_id into tmp_t
            //    from t in tmp_t.DefaultIfEmpty()
            //    join i in ImagesList on k.id equals i.key_id into tmp_i
            //    from i in tmp_i.DefaultIfEmpty()
            //    join sn in SnippetsList on k.id equals sn.key_id into tmp_sn
            //    from sn in tmp_sn.DefaultIfEmpty()
            //    join su in SuggestsList on k.id equals su.key_id into tmp_su
            //    from su in tmp_su.DefaultIfEmpty()
            //    join v in VideosList on k.id equals v.key_id into tmp_v
            //    from v in tmp_v.DefaultIfEmpty()
            //    select new MainTable()
            //    {
            //        isChecked = false,
            //        id = k.id,
            //        name = k.name,
            //        good = k.good,
            //        cluster = string.Join(", ", ClustersList.Where(x => x.key_id == k.id).Select(c => c.cluster_id.ToString()).OrderBy(c => c)),
            //        urls = t == null ? 0 : int.Parse(t.url),
            //        texts = t == null ? 0 : int.Parse(t.text),
            //        spintexts = t == null ? 0 : int.Parse(t.spin),
            //        images = i == null ? 0 : int.Parse(i.text),
            //        snippets = sn == null ? 0 : int.Parse(sn.text),
            //        suggests = su == null ? 0 : int.Parse(su.text),
            //        videos = v == null ? 0 : int.Parse(v.text),
            //    }).ToList();





            //string t1;
            //System.Diagnostics.Stopwatch sw = new Stopwatch();
            //sw.Start();

            List<Task> tasks = new List<Task>();


            var KeysList = Task.Run(() =>
            {
                return new KeysHelper().Select(dbName);
            });
            var TextsList = Task.Run(() =>
            {
                return new TextsHelper().Select(dbName, (filter != null ? filter : "1") + " group by key_id", "id, key_id, CAST(COUNT(NULLIF(text, '' )) as TEXT) as text, CAST(COUNT(NULLIF(spin, '' )) as TEXT) as spin, parser_id, CAST(COUNT(NULLIF(url, '' )) as TEXT) as url");
            });
            var ImagesList = Task.Run(() =>
            {
                return new ImagesHelper().Select(dbName, (filter != null ? filter : "1") + " group by key_id", "id, key_id, CAST(COUNT(NULLIF(text, '' )) as TEXT) as text, parser_id");
            });
            var SnippetsList = Task.Run(() =>
            {
                return new SnippetsHelper().Select(dbName, (filter != null ? filter : "1") + " group by key_id", "id, key_id, CAST(COUNT(NULLIF(text, '' )) as TEXT) as text, parser_id");
            });
            var SuggestsList = Task.Run(() =>
            {
                return new SuggestsHelper().Select(dbName, (filter != null ? filter : "1") + " group by key_id", "id, key_id, CAST(COUNT(NULLIF(text, '' )) as TEXT) as text, parser_id");
            });
            var VideosList = Task.Run(() =>
            {
                return new VideosHelper().Select(dbName, (filter != null ? filter : "1") + " group by key_id", "id, key_id, CAST(COUNT(NULLIF(text, '' )) as TEXT) as text, parser_id");
            });
            var ClustersList = Task.Run(() =>
            {
                return new ClustersHelper().Select(dbName);
            });

            Task.WaitAll(KeysList, TextsList, ImagesList, SnippetsList, SuggestsList, VideosList, ClustersList);

            MainTableList = (
                from k in KeysList.Result
                join t in TextsList.Result on k.id equals t.key_id into tmp_t
                from t in tmp_t.DefaultIfEmpty()
                join i in ImagesList.Result on k.id equals i.key_id into tmp_i
                from i in tmp_i.DefaultIfEmpty()
                join sn in SnippetsList.Result on k.id equals sn.key_id into tmp_sn
                from sn in tmp_sn.DefaultIfEmpty()
                join su in SuggestsList.Result on k.id equals su.key_id into tmp_su
                from su in tmp_su.DefaultIfEmpty()
                join v in VideosList.Result on k.id equals v.key_id into tmp_v
                from v in tmp_v.DefaultIfEmpty()
                select new MainTable()
                {
                    isChecked = false,
                    id = k.id,
                    name = k.name,
                    good = k.good,
                    cluster = string.Join(", ", ClustersList.Result.Where(x => x.key_id == k.id).Select(c => c.cluster_id.ToString()).OrderBy(c => c)),
                    urls = t == null ? 0 : int.Parse(t.url),
                    texts = t == null ? 0 : int.Parse(t.text),
                    spintexts = t == null ? 0 : int.Parse(t.spin),
                    images = i == null ? 0 : int.Parse(i.text),
                    snippets = sn == null ? 0 : int.Parse(sn.text),
                    suggests = su == null ? 0 : int.Parse(su.text),
                    videos = v == null ? 0 : int.Parse(v.text),
                }).ToList();

            //sw.Stop();
            //t1 = (sw.ElapsedMilliseconds / 100.0).ToString();

            return MainTableList;
        }
    }
}