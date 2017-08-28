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
    public class ImagesHelper
    {
        private string Path = $@"{ConfigurationManager.AppSettings["DatabasePath"]}\images\";

        private string CreateCommand = @"CREATE TABLE images(
                                            id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, 
                                            key_id INTEGER,
                                            text TEXT,
                                            parser_id INTEGER);";

        private DatabaseRepository Database { get; set; }

        public ImagesHelper()
        {
            Database = new DatabaseRepository();
        }

        public bool CreateDatabase(string dbName)
        {
            return Database.Create(Path, dbName + "_images", CreateCommand);
        }

        public void DeleteDatabase(string dbName)
        {
            Database.Delete(Path + dbName + "_images");
        }

        public List<Images> Select(string dbName, string filter = null)
        {
            return Database.Select<Images>(Path, dbName + "_images", filter);
        }

        public bool Add(string dbName, List<string> values)
        {
            return Database.Add<Images>(Path, dbName + "_images", values);
        }

        public bool DeleteParserRelationships(string dbName, List<string> keysIds, Parsers parser)
        {
            string ids = string.Empty;
            keysIds.ForEach(k => ids += $"{k},");
            ids = ids.Remove(ids.LastIndexOf(','), 1);
            return Database.Delete<Images>(Path, dbName + "_images", $"parser_id = {parser.id} and key_id in ({ids})");
        }

        public bool DeleteKeysRelationships(string dbName, List<string> keysIds)
        {
            string ids = string.Empty;
            keysIds.ForEach(k => ids += $"{k},");
            ids = ids.Remove(ids.LastIndexOf(','), 1);
            return Database.Delete<Images>(Path, dbName + "_images", $"key_id in ({ids})");
        }

        public bool MoveToAnotherDatabase(string dbNameFrom, string dbNameTo, List<string> keysIds)
        {
            string ids = string.Empty;
            keysIds.ForEach(k => ids += $"{k},");
            ids = ids.Remove(ids.LastIndexOf(','), 1);
            return Database.MoveToAnotherDatabase<Images>(Path, dbNameFrom + "_images", dbNameTo + "_images", $"key_id in ({ids})");
        }
    }
}
