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
        public static string Path = $@"{ConfigurationManager.AppSettings["DatabasePath"]}\texts\";

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

        public List<Texts> Select(string dbName, string filter = null, string selectExpression = "*")
        {
            return Database.Select<Texts>(Path, dbName + "_texts", filter, selectExpression);
        }

        public bool Add(string dbName, string values)
        {
            return Database.Add<Texts>(Path, dbName + "_texts", values);
        }

        public bool AddParseData(string dbName, string keyId, List<string> values, Parsers parser)
        {
            return Database.AddWithClean<Texts>(Path, dbName + "_texts", values, $"parser_id = {parser.id} and key_id = {keyId}");
        }

        public bool DeleteParserRelationships(string dbName, string keysIds, Parsers parser)
        {
            //string ids = string.Join(",", keysIds);
            return Database.Delete<Texts>(Path, dbName + "_texts", $"parser_id = {parser.id} and key_id in ({keysIds})");
        }

        public bool DeleteKeysRelationships(string dbName, string keysIds)
        {
            //string ids = string.Join(",", keysIds);
            return Database.Delete<Texts>(Path, dbName + "_texts", $"key_id in ({keysIds})");
        }

        public bool MoveToAnotherDatabase(string dbNameFrom, string dbNameTo, string keysIds, string maxId)
        {
            //string ids = string.Join(",", keysIds);
            return Database.MoveToAnotherDatabase<Texts>(Path, dbNameFrom + "_texts", dbNameTo + "_texts", $"key_id in ({keysIds})", maxId);
        }

        public bool Vacuum(string dbName)
        {
            return Database.Vacuum<Texts>(Path, dbName + "_texts");
        }
    }
}
