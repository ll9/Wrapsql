using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wrapsql.Utils
{
    public class DbContext
    {
        public DbContext(string dataSource)
        {
            DataSource = dataSource;
        }

        public string DataSource { get; set; }

        public SQLiteConnection GetConnection()
        {
            var connection = new SQLiteConnection("Data Source=" + DataSource);
            connection.Open();
            return connection;
        }
    }
}
