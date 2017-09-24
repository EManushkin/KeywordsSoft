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
using KeywordsSoft.Library.Entities;

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

        public string[] GetСategories(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            return Directory.GetFiles(path, "*.db").Select(file => Path.GetFileNameWithoutExtension(file)).OrderBy(file => file).ToArray();
        }

        public bool Vacuum<T>(string path, string dbName) where T : class, new()
        {
            if (Directory.Exists(path) && File.Exists(path + dbName + ".db"))
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

                            sqLiteCommand.CommandText = $"VACUUM;";
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

        public List<T> Select<T>(string path, string dbName, string filter = null, string selectExpression = "*") where T : class, new()
        {
            List<T> list = new List<T>();

            if (Directory.Exists(path) && File.Exists(path + dbName + ".db"))
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

        public List<MainTable> SelectMainTable(List<DbNamePath> Path_and_dbName, string filter = null)
        {
            List<MainTable> result = new List<MainTable>();

            bool isExists = true;

            foreach (var db in Path_and_dbName)
            {
                isExists &= Directory.Exists(db.Path) && File.Exists(db.Path + db.Name + ".db");
            }

            if (isExists)
            {
                try
                {
                    using (var connection = new SQLiteConnection(GetConnectionString(Path_and_dbName[0].Path + Path_and_dbName[0].Name)))
                    {
                        connection.Open();

                        using (SQLiteCommand sqLiteCommand = new SQLiteCommand())
                        {
                            sqLiteCommand.CommandType = CommandType.Text;
                            sqLiteCommand.CommandTimeout = 10;
                            sqLiteCommand.Connection = connection;
                            string command = string.Empty;
                            
                            for (int i = 1; i < Path_and_dbName.Count; i++)
                            {
                                command = $"ATTACH '{Path_and_dbName[i].Path + Path_and_dbName[i].Name + ".db"}' AS db{Path_and_dbName[i].Class};";
                                sqLiteCommand.CommandText = command;
                                sqLiteCommand.ExecuteNonQuery();
                            }

                            command = $@"SELECT id, name, good, text, spin, url, image, snippet, suggest, video, cluster
                                         FROM Keys as k
                                         LEFT JOIN
                                            (SELECT key_id, CAST(COUNT(NULLIF(text, '' )) as TEXT) as text, CAST(COUNT(NULLIF(spin, '')) as TEXT) as spin, CAST(COUNT(NULLIF(url, '')) as TEXT) as url
                                            FROM 'Texts' { (filter == null ? "group by key_id" : $"WHERE {filter} group by key_id") }) as t
                                         ON k.id = t.key_id
                                         LEFT JOIN
                                            (SELECT key_id, CAST(COUNT(NULLIF(text, '' )) as TEXT) as image
                                            FROM 'Images' { (filter == null ? "group by key_id" : $"WHERE {filter} group by key_id") }) as i
                                         ON k.id = i.key_id
                                         LEFT JOIN
                                            (SELECT key_id, CAST(COUNT(NULLIF(text, '' )) as TEXT) as snippet
                                            FROM 'Snippets' { (filter == null ? "group by key_id" : $"WHERE {filter} group by key_id") }) as sn
                                         ON k.id = sn.key_id
                                         LEFT JOIN
                                            (SELECT key_id, CAST(COUNT(NULLIF(text, '' )) as TEXT) as suggest
                                            FROM 'Suggests' { (filter == null ? "group by key_id" : $"WHERE {filter} group by key_id") }) as sg
                                         ON k.id = sg.key_id
                                         LEFT JOIN
                                            (SELECT key_id, CAST(COUNT(NULLIF(text, '' )) as TEXT) as video
                                            FROM 'Videos' { (filter == null ? "group by key_id" : $"WHERE {filter} group by key_id") }) as v
                                         ON k.id = v.key_id
                                         LEFT JOIN
                                            (SELECT key_id, GROUP_CONCAT(cluster_id) as cluster
                                            FROM (SELECT key_id, cluster_id FROM 'keys_clusters' ORDER BY key_id, cluster_id) group by key_id) as c
                                         ON k.id = c.key_id";

                            sqLiteCommand.CommandText = command;

                            SQLiteDataReader reader = sqLiteCommand.ExecuteReader();

                            while (reader.Read())
                            {
                                try
                                {
                                    result.Add(new MainTable()
                                    {
                                        id = (long)reader[0],
                                        name = !object.Equals(reader[1], DBNull.Value) ? (string)reader[1] : string.Empty,
                                        good = !object.Equals(reader[2], DBNull.Value) ? Convert.ToBoolean(reader[2]) : Convert.ToBoolean("null"),
                                        isChecked = false,
                                        texts = !object.Equals(reader[3], DBNull.Value) ? Convert.ToInt32(reader[3]) : 0,
                                        spintexts = !object.Equals(reader[4], DBNull.Value) ? Convert.ToInt32(reader[4]) : 0,
                                        urls = !object.Equals(reader[5], DBNull.Value) ? Convert.ToInt32(reader[5]) : 0,

                                        images = !object.Equals(reader[6], DBNull.Value) ? Convert.ToInt32(reader[6]) : 0,
                                        snippets = !object.Equals(reader[7], DBNull.Value) ? Convert.ToInt32(reader[7]) : 0,
                                        suggests = !object.Equals(reader[8], DBNull.Value) ? Convert.ToInt32(reader[8]) : 0,
                                        videos = !object.Equals(reader[9], DBNull.Value) ? Convert.ToInt32(reader[9]) : 0,
                                        cluster = !object.Equals(reader[10], DBNull.Value) ? (string)reader[10] : string.Empty,
                                    });
                                }
                                catch (Exception ex) { }
                            }
                        }
                        connection.Close();
                    }
                }
                catch (Exception ex)
                {
                }
            }
            return result;
        }

        public bool Add<T>(string path, string dbName, string values) where T : class, new()
        {
            if (Directory.Exists(path) && File.Exists(path + dbName + ".db"))
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

                            obj = Activator.CreateInstance<T>();

                            string types = string.Join(",", obj.GetType().GetProperties().Where(x => x.Name != "id").Select(x => x.Name));

                            //string val = string.Join(",", values);

                            sqLiteCommand.CommandText = $"INSERT INTO {typeof(T).Name} ({types}) VALUES {values};";
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

        public bool AddWithClean<T>(string path, string dbName, List<string> values, string cleanFilter) where T : class, new()
        {
            if (Directory.Exists(path) && File.Exists(path + dbName + ".db"))
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

                            obj = Activator.CreateInstance<T>();

                            string types = string.Join(",", obj.GetType().GetProperties().Where(x => x.Name != "id").Select(x => x.Name));

                            string val = string.Join(",", values);

                            sqLiteCommand.CommandText = $"DELETE FROM {typeof(T).Name} WHERE {cleanFilter};" +
                                                        $"INSERT INTO {typeof(T).Name} ({types}) VALUES {val};";
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
            if (Directory.Exists(path) && File.Exists(path + dbName + ".db"))
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

                            sqLiteCommand.CommandText = command + "VACUUM;";
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

        public bool MoveToAnotherDatabase<T>(string path, string dbNameFrom, string dbNameTo, string filter, string maxId) where T : class
        {
            if (Directory.Exists(path) && File.Exists(path + dbNameFrom + ".db") && File.Exists(path + dbNameTo + ".db"))
            {
                try
                {
                    using (var connectionFrom = new SQLiteConnection(GetConnectionString(path + dbNameFrom)))
                    {
                        connectionFrom.Open();

                        using (SQLiteCommand sqLiteCommand = new SQLiteCommand())
                        {
                            sqLiteCommand.CommandType = CommandType.Text;
                            sqLiteCommand.CommandTimeout = 10;
                            sqLiteCommand.Connection = connectionFrom;

                            string command = $"ATTACH '{path + dbNameTo + ".db"}' AS dbTo";
                            sqLiteCommand.CommandText = command;
                            sqLiteCommand.ExecuteNonQuery();

                            T obj = default(T);
                            obj = Activator.CreateInstance<T>();

                            string selectColumns = string.Empty;
                            string insertColumns = string.Empty;

                            if (typeof(T).Equals(typeof(Keys)))
                            {
                                insertColumns = string.Join(",", obj.GetType().GetProperties().Select(x => x.Name));
                                selectColumns = insertColumns.Replace("id", $"id+{maxId} as id");
                            }
                            else
                            {
                                insertColumns = string.Join(",", obj.GetType().GetProperties().Where(x => x.Name != "id").Select(x => x.Name));
                                selectColumns = insertColumns.Replace("key_id", $"key_id+{maxId} as key_id");
                            }

                            command = $"INSERT INTO dbTo.{typeof(T).Name} ({insertColumns}) SELECT {selectColumns} FROM {typeof(T).Name} WHERE {filter}";
                            sqLiteCommand.CommandText = command;
                            sqLiteCommand.ExecuteNonQuery();

                            command = $"DELETE FROM {typeof(T).Name} WHERE {filter};";
                            sqLiteCommand.CommandText = command + "VACUUM;";
                            sqLiteCommand.ExecuteNonQuery();
                        }

                        connectionFrom.Close();
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

            return true;
        }

        public bool MoveToAnotherDatabaseOld<T>(string path, string dbNameFrom, string dbNameTo, string filter) where T : class
        {
            DataTable result = null;

            if (Directory.Exists(path) && File.Exists(path + dbNameFrom + ".db") && File.Exists(path + dbNameTo + ".db"))
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
                            sqLiteCommand.CommandText = command + "VACUUM;";
                            sqLiteCommand.ExecuteNonQuery();
                        }

                        connectionFrom.Close();
                    }

                    if (result.Rows.Count > 0)
                    {
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

                                    obj = Activator.CreateInstance<T>();

                                    string types = string.Join(",", obj.GetType().GetProperties().Where(x => x.Name != "id").Select(x => x.Name));

                                    string val = string.Join(",", result.Rows.OfType<DataRow>()
                                        .Select(r => $"({string.Join(",", r.ItemArray.Skip(1).Select(x => $"'{x.ToString()}'").ToArray())})"));

                                    string command = $"INSERT INTO {typeof(T).Name} ({types}) VALUES {val};";
                                    sqLiteCommand.CommandText = command;

                                    sqLiteCommand.ExecuteNonQuery();
                                }

                                transaction.Commit();
                            }
                            connectionTo.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

            return true;
        }

        public string MaxId<T>(string path, string dbName) where T : class, new()
        {
            long count = 0;

            if (Directory.Exists(path) && File.Exists(path + dbName + ".db"))
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

                            sqLiteCommand.CommandText = $"SELECT MAX(id) FROM {typeof(T).Name};";
                            count = (long)sqLiteCommand.ExecuteScalar();
                        }
                        connection.Close();
                    }
                }
                catch (Exception ex)
                {
                }
            }
            return count.ToString();
        }
    }
}
