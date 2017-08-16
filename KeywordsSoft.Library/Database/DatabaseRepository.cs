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
        public DatabaseRepository()
        {
        }

        private string GetConnectionString(string fullPath)
        {
            return $@"Data Source={fullPath}.db;Version=3;"; //Password={ConfigurationManager.AppSettings["DatabasePassword"]};
        }


        public void Create(string path, string name, string command)
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                using (var connection = new SQLiteConnection(GetConnectionString(path + name)))
                {
                    connection.Open();

                    using (SQLiteCommand sqLiteCommand = new SQLiteCommand())
                    {
                        sqLiteCommand.CommandType = CommandType.Text;
                        sqLiteCommand.CommandTimeout = 10;
                        sqLiteCommand.Connection = connection;
                        sqLiteCommand.CommandText = command;
                        sqLiteCommand.ExecuteNonQuery();
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                //TODO _log.Error(ex);
            }
        }

        public void Delete(string fullPath)
        {
            if (File.Exists(fullPath + ".db"))
            {
                File.Delete(fullPath + ".db");
            }
        }

        public string [] GetСategories(string path)
        {
            if (Directory.Exists(path))
            {
                return Directory.GetFiles(path, "*.db").Select(file => Path.GetFileNameWithoutExtension(file)).OrderBy(file => file).ToArray();
            }

            return null;
        }
    }
}
