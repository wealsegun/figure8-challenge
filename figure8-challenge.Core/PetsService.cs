using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace PetsAlone.Core
{
    public class PetsService
    {
        public List<My_Pet_Class> GetAll(Figure8ChallengeContext petsDbContext)
        {
            var connection = new SqliteConnection(petsDbContext.Database.GetConnectionString());
            connection.Open();
            var x = new SqliteCommand("SELECT COUNT(*) FROM Pets", connection).ExecuteScalar();

            var y = new List<My_Pet_Class>();
            for (var i = 0; i < (long)x; i++)
            {
                var z = petsDbContext.Pets.FindAsync(i + 1).Result;
                y.Add(z);
            }

            // seems to be the best way to order by newest first
            var yy = new List<My_Pet_Class>();
            foreach (var xy in y)
            {
                if (yy.Count == 0)
                {
                    yy.Add(xy);
                }
                else if (yy[0].MissingSince < xy.MissingSince)
                {
                    var temp = yy;
                    yy = new List<My_Pet_Class> { xy };
                    foreach (var tempitem in temp)
                    {
                        yy.Add(tempitem);
                    }
                }
                else
                {
                    yy.Add(xy);
                }
            }

            return yy;
        }

        public List<My_Pet_Class> GetPetListBySearchField(Figure8ChallengeContext petsDbContext, PetSearchField search)
        {
            //var connection = new SqliteConnection(petsDbContext.Database.GetConnectionString());
            //connection.Open();

            //var databaseResponse = new SqliteCommand("SELECT COUNT(*) FROM Pets", connection).ExecuteScalar();

            var outPutResult = new List<My_Pet_Class>();
            if (search != null)
            {
                // A = PetType  if A is true
                if (search.PetType > 0 )
                {
                    var record = petsDbContext.Pets.Where(c=>c.PetType == search.PetType).OrderByDescending(c=>c.MissingSince).ToList();
                    return record;
                }
                // A = PetType  if A is false
                else
                {
                    var record = petsDbContext.Pets.OrderByDescending(c => c.MissingSince).ToList();
                    return record;
                }
            }
            else
            {
                return outPutResult;
            }

        }

        public int CreatePets(Figure8ChallengeContext petsDbContext, My_Pet_Class model)
        {
            int count = 0;

            if (model != null)
            {
                var response = petsDbContext.Pets.Add(model);
                petsDbContext.SaveChanges();
                count = model.Id;
                return count;
            }
            else
            {
                return 0;
            }
        }
    }
}