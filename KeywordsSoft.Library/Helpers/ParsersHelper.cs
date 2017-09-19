using KeywordsSoft.Library.Database;
using KeywordsSoft.Library.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeywordsSoft.Library.Helpers
{
    public class ParsersHelper
    {
        private string Path = Directory.GetCurrentDirectory() + "\\";

        private string CreateCommand = @"CREATE TABLE parsers(
                                            id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, 
                                            name TEXT,
                                            type TEXT);
                                         INSERT INTO parsers (name, type) VALUES
                                            ('google', 'snippets'),
                                            ('bing', 'images'),
                                            ('yandex', 'texts'),
                                            ('rambler', 'videos'),
                                            ('yahoo', 'suggests'),
                                            ('msn', 'images');";

        private DatabaseRepository Database { get; set; }

        public ParsersHelper()
        {
            Database = new DatabaseRepository();
        }

        public bool CreateDatabase()
        {
            return Database.Create(Path, "parsers", CreateCommand);
        }

        public void DeleteDatabase()
        {
            Database.Delete(Path + "parsers");
        }

        public List<Parsers> Select(string type = null)
        {
            string filter = null;
            if (type != null)
            {
                filter = $"type = {type}";
            }
            return Database.Select<Parsers>(Path, "parsers", filter);
        }

        public bool Parse(string dbName, string keyId, Parsers parser)
        {
            Random rnd = new Random((int)DateTime.Now.Ticks);
            List<string> values = new List<string>();
            int count = 0;
            bool result = false;
            switch (parser.type)
            {
                case Parsers.type_texts:
                    var textsHelper = new TextsHelper();
                    //TODO parse algorithm
                    count = rnd.Next(10, 20);
                    for (int i = 0; i < count; i++)
                    {
                        //(key_id, text, spin, parser_id, url)
                        if (rnd.Next(0, 2) == 0)
                        {
                            values.Add($"('{keyId}', 'parse_text_{DateTime.Now.Ticks + i}', '', '{parser.id}', 'parse_url_www_{DateTime.Now.Ticks + i}')");
                        }
                        else
                        {
                            values.Add($"('{keyId}', 'parse_text_{DateTime.Now.Ticks + i}', 'parse_spin_{DateTime.Now.Ticks + i}', '{parser.id}', 'parse_url_www_{DateTime.Now.Ticks + i}')");
                        }
                    }
                    result = textsHelper.AddParseData(dbName, keyId, values, parser);
                    break;
                case Parsers.type_images:
                    var imagesHelper = new ImagesHelper();
                    //TODO parse algorithm
                    count = rnd.Next(10, 50);
                    for (int i = 0; i < count; i++)
                    {
                        values.Add($"('{keyId}', 'parse_text_{DateTime.Now.Ticks + i}', '{parser.id}')");
                    }
                    result = imagesHelper.AddParseData(dbName, keyId, values, parser);
                    break;
                case Parsers.type_videos:
                    var videosHelper = new VideosHelper();
                    //TODO parse algorithm
                    count = rnd.Next(10, 50);
                    for (int i = 0; i < count; i++)
                    {
                        values.Add($"('{keyId}', 'parse_text_{DateTime.Now.Ticks + i}', '{parser.id}')");
                    }
                    result = videosHelper.AddParseData(dbName, keyId, values, parser);
                    break;
                case Parsers.type_snippets:
                    var snippetsHelper = new SnippetsHelper();
                    //TODO parse algorithm
                    count = rnd.Next(20, 30);
                    for (int i = 0; i < count; i++)
                    {
                        values.Add($"('{keyId}', 'parse_text_{DateTime.Now.Ticks + i}', '{parser.id}')");
                    }
                    result = snippetsHelper.AddParseData(dbName, keyId, values, parser);
                    break;
                case Parsers.type_suggests:
                    var suggestsHelper = new SuggestsHelper();
                    //TODO parse algorithm
                    count = rnd.Next(20, 30);
                    for (int i = 0; i < count; i++)
                    {
                        values.Add($"('{keyId}', 'parse_text_{DateTime.Now.Ticks + i}', '{parser.id}')");
                    }
                    result = suggestsHelper.AddParseData(dbName, keyId, values, parser);
                    break;
                default:
                    result = false;
                    break;
            }

            values.Clear();
            values = null;
            GC.Collect();
            return result;
        }
        public bool AddParseData(string dbName, List<string> keysIds, List<string> values, Parsers parser)
        {
            string ids = string.Join(",", keysIds);
            string value = string.Join(",", values);
            switch (parser.type)
            {
                case Parsers.type_texts:
                    var textsHelper = new TextsHelper();
                    textsHelper.DeleteParserRelationships(dbName, ids, parser);
                    return textsHelper.Add(dbName, value);
                case Parsers.type_images:
                    var imagesHelper = new ImagesHelper();
                    imagesHelper.DeleteParserRelationships(dbName, ids, parser);
                    return imagesHelper.Add(dbName, value);
                case Parsers.type_videos:
                    var videosHelper = new VideosHelper();
                    videosHelper.DeleteParserRelationships(dbName, ids, parser);
                    return videosHelper.Add(dbName, value);
                case Parsers.type_snippets:
                    var snippetsHelper = new SnippetsHelper();
                    snippetsHelper.DeleteParserRelationships(dbName, ids, parser);
                    return snippetsHelper.Add(dbName, value);
                case Parsers.type_suggests:
                    var suggestsHelper = new SuggestsHelper();
                    suggestsHelper.DeleteParserRelationships(dbName, ids, parser);
                    return suggestsHelper.Add(dbName, value);
                default:
                    return false;
            }
        }
    }
}
