using KeywordsSoft.Library.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeywordsSoft.Library.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(SQLiteConnection sqLiteConnection)
         : base(sqLiteConnection, false)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var initializer =  new SQLite.CodeFirst.SqliteCreateDatabaseIfNotExists<DatabaseContext>(modelBuilder);
            //var initializer = new SQLite.CodeFirst.SqliteDropCreateDatabaseAlways<DatabaseContext>(modelBuilder);
            System.Data.Entity.Database.SetInitializer(initializer);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Keys> Keys { get; set; }
    }
}
