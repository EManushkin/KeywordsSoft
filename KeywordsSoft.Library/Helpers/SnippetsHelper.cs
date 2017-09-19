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
    public class SnippetsHelper
    {
        private string Path = $@"{ConfigurationManager.AppSettings["DatabasePath"]}\snippets\";

        private string CreateCommand = @"CREATE TABLE snippets(
                                            id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, 
                                            key_id INTEGER,
                                            text TEXT,
                                            parser_id INTEGER);";

        private DatabaseRepository Database { get; set; }

        public SnippetsHelper()
        {
            Database = new DatabaseRepository();
        }

        public bool CreateDatabase(string dbName)
        {
            return Database.Create(Path, dbName + "_snippets", CreateCommand);
        }

        public void DeleteDatabase(string dbName)
        {
            Database.Delete(Path + dbName + "_snippets");
        }

        public List<Snippets> Select(string dbName, string filter = null, string selectExpression = "*")
        {
            return Database.Select<Snippets>(Path, dbName + "_snippets", filter, selectExpression);
        }

        public bool Add(string dbName, string values)
        {
            return Database.Add<Snippets>(Path, dbName + "_snippets", values);
        }

        public bool AddParseData(string dbName, string keyId, List<string> values, Parsers parser)
        {
            return Database.AddWithClean<Snippets>(Path, dbName + "_snippets", values, $"parser_id = {parser.id} and key_id = {keyId}");
        }

        public bool DeleteParserRelationships(string dbName, string keysIds, Parsers parser)
        {
            //string ids = string.Join(",", keysIds);
            return Database.Delete<Snippets>(Path, dbName + "_snippets", $"parser_id = {parser.id} and key_id in ({keysIds})");
        }

        public bool DeleteKeysRelationships(string dbName, string keysIds)
        {
            //string ids = string.Join(",", keysIds);
            return Database.Delete<Snippets>(Path, dbName + "_snippets", $"key_id in ({keysIds})");
        }

        public bool MoveToAnotherDatabase(string dbNameFrom, string dbNameTo, string keysIds, string maxId)
        {
            //string ids = string.Join(",", keysIds);
            return Database.MoveToAnotherDatabase<Snippets>(Path, dbNameFrom + "_snippets", dbNameTo + "_snippets", $"key_id in ({keysIds})", maxId);
        }
    }
}
