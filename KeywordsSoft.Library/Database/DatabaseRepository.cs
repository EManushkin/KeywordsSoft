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
        private const string limit = "2000000";

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
                GC.Collect();
                GC.WaitForPendingFinalizers();
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

        public List<T> Select<T>(string path, string dbName, string filter = null, string selectExpression = "*") where T : class, new()
        {
            List<T> list = new List<T>();

            if (File.Exists(path + dbName + ".db"))
            {
                try
                {
                    using (var connection = new SQLiteConnection(GetConnectionString(path + dbName)))
                    {
                        
                        T obj = default(T);

                        connection.Open();

                        using (SQLiteCommand sqLiteCommand = new SQLiteCommand())
                        {
                            sqLiteCommand.CommandType = CommandType.Text;
                            sqLiteCommand.CommandTimeout = 10;
                            sqLiteCommand.Connection = connection;

                            string command = filter == null
                                ? $"SELECT {selectExpression} FROM {typeof(T).Name} LIMIT {limit}"
                                : $"SELECT {selectExpression} FROM {typeof(T).Name} WHERE {filter} LIMIT {limit}";

                            sqLiteCommand.CommandText = command;

                            SQLiteDataReader reader = sqLiteCommand.ExecuteReader();
                            while (reader.Read())
                            {
                                obj = Activator.CreateInstance<T>();
                                foreach (PropertyInfo prop in obj.GetType().GetProperties())
                                {
                                    try
                                    {
                                        if (!object.Equals(reader[prop.Name], DBNull.Value))
                                        {
                                            if (prop.PropertyType.Equals(typeof(bool?)))
                                            {
                                                prop.SetValue(obj, object.Equals(reader[prop.Name], string.Empty) ? (Nullable<bool>)null : Convert.ToBoolean(reader[prop.Name]), null);
                                            }
                                            else
                                            {
                                                prop.SetValue(obj, reader[prop.Name] == DBNull.Value ? null : reader[prop.Name], null);
                                            }
                                        }
                                    }
                                    catch (Exception ex) { }
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

        public bool Add<T>(string path, string dbName, List<string> values) where T : class, new()
        {
            if (File.Exists(path + dbName + ".db"))
            {
                try
                {
                    using (var connection = new SQLiteConnection(GetConnectionString(path + dbName)))
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
                            val.Append(string.Join(",", values));

                            //foreach (var itemVal in values)
                            //{
                            //    val.Append(string.Join(",", itemVal));
                            //}

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

        public bool Delete<T>(string path, string dbName, string filter = null) where T : class
        {
            if (File.Exists(path + dbName + ".db"))
            {
                try
                {
                    using (var connection = new SQLiteConnection(GetConnectionString(path + dbName)))
                    {
                        connection.Open();

                        using (SQLiteCommand sqLiteCommand = new SQLiteCommand())
                        {
                            sqLiteCommand.CommandType = CommandType.Text;
                            sqLiteCommand.CommandTimeout = 10;
                            sqLiteCommand.Connection = connection;

                            string command = filter == null
                                ? $"DELETE FROM {typeof(T).Name};"
                                : $"DELETE FROM {typeof(T).Name} WHERE {filter};";

                            sqLiteCommand.CommandText = command;
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

        public bool MoveToAnotherDatabase<T>(string path, string dbNameFrom, string dbNameTo, string filter) where T : class
        {
            DataTable result = null;

            if (File.Exists(path + dbNameFrom + ".db") && File.Exists(path + dbNameTo + ".db"))
            {
                try
                {
                    result = new DataTable();

                    using (var connectionFrom = new SQLiteConnection(GetConnectionString(path + dbNameFrom)))
                    {
                        connectionFrom.Open();

                        using (SQLiteCommand sqLiteCommand = new SQLiteCommand())
                        {
                            sqLiteCommand.CommandType = CommandType.Text;
                            sqLiteCommand.CommandTimeout = 10;
                            sqLiteCommand.Connection = connectionFrom;

                            string command = $"SELECT * FROM {typeof(T).Name} WHERE {filter} LIMIT {limit}";

                            sqLiteCommand.CommandText = command;
                            result.Load(sqLiteCommand.ExecuteReader());

                            command = $"DELETE FROM {typeof(T).Name} WHERE {filter};";
                            sqLiteCommand.CommandText = command;
                            sqLiteCommand.ExecuteNonQuery();
                        }

                        connectionFrom.Close();
                    }

                    using (var connectionTo = new SQLiteConnection(GetConnectionString(path + dbNameTo)))
                    {
                        connectionTo.Open();

                        T obj = default(T);

                        using (SQLiteTransaction transaction = connectionTo.BeginTransaction())
                        {
                            using (SQLiteCommand sqLiteCommand = new SQLiteCommand())
                            {
                                sqLiteCommand.CommandType = CommandType.Text;
                                sqLiteCommand.CommandTimeout = 10;
                                sqLiteCommand.Connection = connectionTo;

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
                                foreach (DataRow row in result.Rows)
                                {
                                    val.Append("(");
                                    var length = row.ItemArray.Count();
                                    for (int i = 1; i < row.ItemArray.Count(); i++)
                                    {
                                        val.Append($"'{row[i]}'" + ", ");
                                    }
                                    val.Remove(val.Length - 2, 2).Append("), ");

                                }
                                val.Remove(val.Length - 2, 2);

                                foreach (DataRow row in result.Rows)
                                {
                                    var test = row.ItemArray;
                                }

                                string command = $"INSERT INTO {typeof(T).Name} ({types}) VALUES {val};";
                                sqLiteCommand.CommandText = command;

                                sqLiteCommand.ExecuteNonQuery();
                            }

                            transaction.Commit();
                        }
                        connectionTo.Close();
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
