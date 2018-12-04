using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wrapsql.Models;
using Wrapsql.Utils;

namespace Wrapsql.Repositories
{
    public class LichtpunktRepository
    {
        private readonly DbContext _context;

        public LichtpunktRepository(DbContext context)
        {
            _context = context;
        }

        public void CreateRepository()
        {
            var query = $"CREATE TABLE IF NOT EXISTS Lichtpunkt(id integer primary key, ort TEXT)";

            using (var conneciton = _context.GetConnection())
            using (var command = new SQLiteCommand(query, conneciton))
            {
                command.ExecuteNonQuery();
            }
        }

        public void Add(Lichtpunkt lichtpunkt)
        {
            var query = $"INSERT INTO Lichtpunkt(id, ort) VALUES(@id, @ort)";

            using (var connection = _context.GetConnection())
            using (var command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@id", lichtpunkt.Id);
                command.Parameters.AddWithValue("@ort", lichtpunkt.Ort);

                command.ExecuteNonQuery();
            }
        }
    }
}
