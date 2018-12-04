using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wrapsql.Factories;
using Wrapsql.Models;

namespace Wrapsql
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = SqlFactory.GetDbContext();
            var lpRepo = SqlFactory.GetLichtpunktRepository();

            var lps = Enumerable.Range(0, 10).Select(i => new Lichtpunkt { Id = i, Ort = "Ort" + i });

            lpRepo.CreateRepository();

            using (var connection = context.GetConnection())
            using (var transaction = connection.BeginTransaction())
            {
                foreach (var lp in lps)
                {
                    lpRepo.Add(lp);
                }
                transaction.Commit();
            }
        }
    }
}
