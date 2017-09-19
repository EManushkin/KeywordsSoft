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
    public class VideosHelper
    {
        private string Path = $@"{ConfigurationManager.AppSettings["DatabasePath"]}\videos\";

        private string CreateCommand = @"CREATE TABLE Videos(
                                            id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, 
                                            key_id INTEGER,
                                            text TEXT,
                                            parser_id INTEGER);";

        private DatabaseRepository Database { get; set; }

        public VideosHelper()
        {
            Database = new DatabaseRepository();
        }

        public bool CreateDatabase(string dbName)
        {
            return Database.Create(Path, dbName + "_videos", CreateCommand);
        }

        public void DeleteDatabase(string dbName)
        {
            Database.Delete(Path + dbName + "_videos");
        }

        public List<Videos> Select(string dbName, string filter = null, string selectExpression = "*")
        {
            return Database.Select<Videos>(Path, dbName + "_videos", filter, selectExpression);
        }

        public bool Add(string dbName, List<string> values)
        {
            return Database.Add<Videos>(Path, dbName + "_videos", values);
        }

        public bool AddParseData(string dbName, string keyId, List<string> values, Parsers parser)
        {
            return Database.AddWithClean<Videos>(Path, dbName + "_videos", values, $"parser_id = {parser.id} and key_id = {keyId}");
        }

        public bool DeleteParserRelationships(string dbName, List<string> keysIds, Parsers parser)
        {
            string ids = string.Join(",", keysIds);
            return Database.Delete<Videos>(Path, dbName + "_videos", $"parser_id = {parser.id} and key_id in ({ids})");
        }

        public bool DeleteKeysRelationships(string dbName, List<string> keysIds)
        {
            string ids = string.Join(",", keysIds);
            return Database.Delete<Videos>(Path, dbName + "_videos", $"key_id in ({ids})");
        }

        public bool MoveToAnotherDatabase(string dbNameFrom, string dbNameTo, List<string> keysIds)
        {
            string ids = string.Join(",", keysIds);
            return Database.MoveToAnotherDatabase<Videos>(Path, dbNameFrom + "_videos", dbNameTo + "_videos", $"key_id in ({ids})");
        }
    }
}
