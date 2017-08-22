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
using System.Reflection;

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


        public bool Create(string path, string name, string command)
        {
            try
            {
                if (File.Exists(path + name + ".db"))
                {
                    return false;
                }

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

                return true;
            }
            catch (Exception ex)
            {
                //TODO _log.Error(ex);
                return false;
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

        public List<T> Select<T>(string path, string name) where T : class, new()
        {
            List<T> list = new List<T>();

            if (File.Exists(path + name + ".db"))
            {
                try
                {
                    using (var connection = new SQLiteConnection(GetConnectionString(path + name)))
                    {
                        
                        T obj = default(T);

                        connection.Open();

                        using (SQLiteCommand sqLiteCommand = new SQLiteCommand())
                        {
                            sqLiteCommand.CommandType = CommandType.Text;
                            sqLiteCommand.CommandTimeout = 10;
                            sqLiteCommand.Connection = connection;
                            sqLiteCommand.CommandText = $"SELECT * FROM {typeof(T).Name}";

                            SQLiteDataReader reader = sqLiteCommand.ExecuteReader();
                            while (reader.Read())
                            {
                                obj = Activator.CreateInstance<T>();
                                foreach (PropertyInfo prop in obj.GetType().GetProperties())
                                {
                                    if (!object.Equals(reader[prop.Name], DBNull.Value))
                                    {
                                        prop.SetValue(obj, reader[prop.Name], null);
                                    }
                                }
                                list.Add(obj);
                            }
                        }

                        connection.Close();
                    }
                }
                catch (Exception ex)
                {
                }
            }
            return list;
        }

        public bool Add<T>(string path, string name, List<string> values) where T : class, new()
        {
            if (File.Exists(path + name + ".db"))
            {
                try
                {
                    using (var connection = new SQLiteConnection(GetConnectionString(path + name)))
                    {
                        T obj = default(T);

                        connection.Open();

                        using (SQLiteCommand sqLiteCommand = new SQLiteCommand())
                        {
                            sqLiteCommand.CommandType = CommandType.Text;
                            sqLiteCommand.CommandTimeout = 10;
                            sqLiteCommand.Connection = connection;

                            string types = "";
                            List<PropertyInfo> properties = new List<PropertyInfo>(); 
                            obj = Activator.CreateInstance<T>();
                            foreach (PropertyInfo prop in obj.GetType().GetProperties())
                            {
                                types = string.IsNullOrEmpty(types) ? "" : types + ", ";
                                if (prop.Name != "id")
                                {
                                    properties.Add(prop);
                                    types += prop.Name;
                                }
                            }

                            StringBuilder val = new StringBuilder();
                            foreach (var itemVal in values)
                            {
                                val.Append(itemVal + ", ");
                            }

                            val.Remove(val.Length - 2, 2);

                            sqLiteCommand.CommandText = $"INSERT INTO {typeof(T).Name} ({types}) VALUES {val};";
                            sqLiteCommand.ExecuteNonQuery();
                        }

                        connection.Close();
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
