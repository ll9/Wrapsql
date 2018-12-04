using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wrapsql.Repositories;
using Wrapsql.Utils;

namespace Wrapsql.Factories
{
    public static class SqlFactory
    {
        private static readonly string dataSource = "test.db";
        private static DbContext _dbContext = null;
        private static LichtpunktRepository _lichtpunktRepository;

        public static DbContext GetDbContext()
        {
            if (_dbContext == null)
            {
                _dbContext = new DbContext(dataSource);
            }
            return _dbContext;
        }

        public static LichtpunktRepository GetLichtpunktRepository()
        {
            if (_lichtpunktRepository == null)
            {
                _lichtpunktRepository = new LichtpunktRepository(GetDbContext());
            }
            return _lichtpunktRepository;
        }
    }
}
