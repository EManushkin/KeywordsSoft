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
    public class SuggestsHelper
    {
        public static string Path = $@"{ConfigurationManager.AppSettings["DatabasePath"]}\suggests\";

        private string CreateCommand = @"CREATE TABLE suggests(
                                            id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, 
                                            key_id INTEGER,
                                            text TEXT,
                                            parser_id INTEGER);";

        private DatabaseRepository Database { get; set; }

        public SuggestsHelper()
        {
            Database = new DatabaseRepository();
        }

        public bool CreateDatabase(string dbName)
        {
            return Database.Create(Path, dbName + "_suggests", CreateCommand);
        }

        public void DeleteDatabase(string dbName)
        {
            Database.Delete(Path + dbName + "_suggests");
        }

        public List<Suggests> Select(string dbName, string filter = null, string selectExpression = "*")
        {
            return Database.Select<Suggests>(Path, dbName + "_suggests", filter, selectExpression);
        }

        public bool Add(string dbName, string values)
        {
            return Database.Add<Suggests>(Path, dbName + "_suggests", values);
        }

        public bool AddParseData(string dbName, string keyId, List<string> values, Parsers parser)
        {
            return Database.AddWithClean<Suggests>(Path, dbName + "_suggests", values, $"parser_id = {parser.id} and key_id = {keyId}");
        }

        public bool DeleteParserRelationships(string dbName, string keysIds, Parsers parser)
        {
            //string ids = string.Join(",", keysIds);
            return Database.Delete<Suggests>(Path, dbName + "_suggests", $"parser_id = {parser.id} and key_id in ({keysIds})");
        }

        public bool DeleteKeysRelationships(string dbName, string keysIds)
        {
            //string ids = string.Join(",", keysIds);
            return Database.Delete<Suggests>(Path, dbName + "_suggests", $"key_id in ({keysIds})");
        }

        public bool MoveToAnotherDatabase(string dbNameFrom, string dbNameTo, string keysIds, string maxId)
        {
            //string ids = string.Join(",", keysIds);
            return Database.MoveToAnotherDatabase<Suggests>(Path, dbNameFrom + "_suggests", dbNameTo + "_suggests", $"key_id in ({keysIds})", maxId);
        }

        public bool Vacuum(string dbName)
        {
            return Database.Vacuum<Suggests>(Path, dbName + "_suggests");
        }
    }
}
