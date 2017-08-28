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
    public class TextsHelper
    {
        private string Path = $@"{ConfigurationManager.AppSettings["DatabasePath"]}\texts\";

        private string CreateCommand = @"CREATE TABLE Texts(
                                            id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, 
                                            key_id INTEGER,
                                            text TEXT,
                                            spin TEXT,
                                            parser_id INTEGER,
                                            url TEXT);";

        private DatabaseRepository Database { get; set; }

        public TextsHelper()
        {
            Database = new DatabaseRepository();
        }

        public bool CreateDatabase(string dbName)
        {
            return Database.Create(Path, dbName + "_texts", CreateCommand);
        }

        public void DeleteDatabase(string dbName)
        {
            Database.Delete(Path + dbName + "_texts");
        }

        public List<Texts> Select(string dbName, string filter = null)
        {
            return Database.Select<Texts>(Path, dbName + "_texts", filter);
        }

        public bool Add(string dbName, List<string> values)
        {
            return Database.Add<Texts>(Path, dbName + "_texts", values);
        }

        public bool DeleteParserRelationships(string dbName, List<string> keysIds, Parsers parser)
        {
            string ids = string.Empty;
            keysIds.ForEach(k => ids += $"{k},");
            ids = ids.Remove(ids.LastIndexOf(','), 1);
            return Database.Delete<Texts>(Path, dbName + "_texts", $"parser_id = {parser.id} and key_id in ({ids})");
        }

        public bool DeleteKeysRelationships(string dbName, List<string> keysIds)
        {
            string ids = string.Empty;
            keysIds.ForEach(k => ids += $"{k},");
            ids = ids.Remove(ids.LastIndexOf(','), 1);
            return Database.Delete<Texts>(Path, dbName + "_texts", $"key_id in ({ids})");
        }

        public bool MoveToAnotherDatabase(string dbNameFrom, string dbNameTo, List<string> keysIds)
        {
            string ids = string.Empty;
            keysIds.ForEach(k => ids += $"{k},");
            ids = ids.Remove(ids.LastIndexOf(','), 1);
            return Database.MoveToAnotherDatabase<Texts>(Path, dbNameFrom + "_texts", dbNameTo + "_texts", $"key_id in ({ids})");
        }
    }
}
