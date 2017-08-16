using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite.EF6;
using System.Configuration;
using System.IO;
using System.Data;
using System.Data.Common;

namespace KeywordsSoft.Library.Database
{
    public class DatabaseRepository
    {
        private string KeysPath = $@"{ConfigurationManager.AppSettings["DatabasePath"]}\keys\";
        private string TextsPath = $@"{ConfigurationManager.AppSettings["DatabasePath"]}\texts\";

        private SQLiteCommand sqLiteCommand;

        public DatabaseRepository()
        {
            sqLiteCommand = new SQLiteCommand();
            sqLiteCommand.CommandType = CommandType.Text;
            sqLiteCommand.CommandTimeout = 10;
        }

        private string GetConnectionString(string path)
        {
            return $@"Data Source={path}.db;Version=3;"; //Password={ConfigurationManager.AppSettings["DatabasePassword"]};
        }

        public void CreateDatabases(string name)
        {
            CreateKeysDatabase(name);
            CreateTextsDatabase(name);
        }


        public void CreateKeysDatabase(string name)
        {
            try
            {
                if (!Directory.Exists(KeysPath))
                {
                    Directory.CreateDirectory(KeysPath);
                }

                using (var connection = new SQLiteConnection(GetConnectionString(KeysPath + name)))
                {
                    connection.Open();
                    sqLiteCommand.Connection = connection;
                    sqLiteCommand.CommandText = @"CREATE TABLE Keys(
                                                    id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, 
                                                    name  TEXT);
                                                  CREATE TABLE variations(
                                                    id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, 
                                                    name TEXT);";

                    sqLiteCommand.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                //TODO _log.Error(ex);
            }
        }

        public void CreateTextsDatabase(string name)
        {
            try
            {
                if (!Directory.Exists(TextsPath))
                {
                    Directory.CreateDirectory(TextsPath);
                }

                using (var connection = new SQLiteConnection(GetConnectionString(TextsPath + name + "_texts")))
                {
                    connection.Open();
                    sqLiteCommand.Connection = connection;
                    sqLiteCommand.CommandText = @"CREATE TABLE Texts(
                                                    id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, 
                                                    key_id INTEGER,
                                                    text TEXT,
                                                    spin TEXT,
                                                    parser_id INTEGER,
                                                    url TEXT);";

                    sqLiteCommand.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                //TODO _log.Error(ex);
            }
        }
    }
}
