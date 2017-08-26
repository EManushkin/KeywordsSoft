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
    public class ParsersHelper
    {
        private string Path = ""; //$@"{ConfigurationManager.AppSettings["DatabasePath"]}\parsers\";

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

        //public bool Add(string dbName, List<string> entity)
        //{
        //    return Database.Add<Keys>(Path, dbName, entity);
        //}

        public List<Parsers> Select()
        {
            return Database.Select<Parsers>(Path, "parsers");
        }

        public bool Parse(List<string> keysIds, Parsers parser, string dbName)
        {
            Random rnd = new Random((int)DateTime.Now.Ticks);
            List<string> values = new List<string>();
            switch (parser.type)
            {
                case Parsers.type_texts:
                    //TODO parse algorithm
                    foreach (var id in keysIds)
                    {
                        for (int i = 0; i < rnd.Next(10, 30); i++)
                        {
                            //(key_id, text, spin, parser_id, url)
                            values.Add($"('{id}', 'parse_text_{i}', 'parse_spin_{i}', '{parser.id}', 'parse_url_www{i}')");
                        }
                    }
                    return new TextsHelper().Add(dbName, values);
                default:
                    return false;
            }
        }

        //public List<Parsers> ParseTexts()
        //{
        //    return Database.Select<Parsers>(Path, "parsers");
        //}
    }
}
