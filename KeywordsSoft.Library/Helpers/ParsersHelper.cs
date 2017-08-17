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
        private string Path = $@"{ConfigurationManager.AppSettings["DatabasePath"]}\parsers\";

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

        public void CreateDatabase()
        {
            Database.Create(Path, "parsers", CreateCommand);
        }

        public void DeleteDatabase()
        {
            Database.Delete(Path + "parsers");
        }

        public List<Parsers> Select()
        {
            return Database.Select<Parsers>(Path, "parsers");
        }
    }
}
