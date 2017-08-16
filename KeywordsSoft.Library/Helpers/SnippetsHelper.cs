﻿using KeywordsSoft.Library.Database;
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

        public void CreateDatabase(string name)
        {
            Database.Create(Path, name + "_snippets", CreateCommand);
        }

        public void DeleteDatabase(string name)
        {
            Database.Delete(Path + name + "_snippets");
        }
    }
}