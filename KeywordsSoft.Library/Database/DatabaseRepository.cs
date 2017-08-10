using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite.EF6;

namespace KeywordsSoft.Library.Database
{
    public class DatabaseRepository
    {
        public void CreateDatabaseFile(string path)
        {
            try
            {
                SQLiteConnection.CreateFile(path);

                //using (SQLiteConnection sqLiteConnection = CreateConnection(path))
                //using (DatabaseContext context = new DatabaseContext(sqLiteConnection))
                //{
                //    DropCreateDatabaseAlways<DatabaseContext> initializator = new DropCreateDatabaseAlways<DatabaseContext>();
                //    System.Data.Entity.Database.SetInitializer(initializator);

                //    context.SaveChanges();
                //    // do not delete this log trace. we need some DB touch
                //    var count = context.Keys.Count();
                //}
            }
            catch (Exception ex)
            {
                //TODO _log.Error(ex);
            }
        }

        private static SQLiteConnection CreateConnection(string path)
        {
            SQLiteConnectionStringBuilder builder = (SQLiteConnectionStringBuilder)SQLiteProviderFactory.Instance.CreateConnectionStringBuilder();
            builder.DataSource = path;
            builder.FailIfMissing = false;

            return new SQLiteConnection(builder.ToString());
        }
    }
}
