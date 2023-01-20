using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PetsAlone.Core;
using System;
using System.Data.Common;
using System.Data.Entity;

namespace PetAlone.Core.UnitTest
{
    [TestClass]
    public class Figure8ChallengeUnitTest
    {
        public PetsService ps { get; private set; }
        public ContactService cs { get; private set; }
        public ServiceCollection Services { get; private set; }
        public ServiceProvider ServiceProvider { get; protected set; }
        Figure8ChallengeContext _context;

        private DbContextOptions<Figure8ChallengeContext> context;
        
        [TestInitialize]
        public void Initialize()
        {

            

            
            
            //context = new PetsDbContext(options);
            ps = new PetsService();
            cs = new ContactService();
            Services = new ServiceCollection();

            Services.AddDbContext<Figure8ChallengeContext>(options => options.UseInMemoryDatabase("PetsAlone"), ServiceLifetime.Transient);
            Services.AddTransient<Figure8ChallengeContext>(sp => sp.GetService<Figure8ChallengeContext>());

            Services.AddDbContext<Figure8ChallengeContext>(opts =>
            {
                static DbConnection CreateInMemoryDatabase()
                {
                    var connection = new SqliteConnection("Filename=PetsAlone.db");
                    connection.Open();
                    return connection;
                }

                opts.UseSqlite(CreateInMemoryDatabase());
            });
            //Services.AddDefaultIdentity<ApplicationUser>()
              // .AddEntityFrameworkStores<PetsDbContext>();

            var dbContextOptionBuilder = new DbContextOptionsBuilder<Figure8ChallengeContext>();
            dbContextOptionBuilder.UseInMemoryDatabase(databaseName: "PetsAlone");

            _context = new Figure8ChallengeContext(dbContextOptionBuilder.Options);
            ps = new PetsService();

            ServiceProvider = Services.BuildServiceProvider();

            var scope = ServiceProvider.CreateScope();
            var _serviceProf = scope.ServiceProvider;
           

        }
        [TestMethod]
        public void CheckTest()
        {
            var actual = "wale";
            var expected = "wale";
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetPets()
        {
            
            PetSearchField search = new PetSearchField { PetType = 0 };
            List<My_Pet_Class> pets = new List<My_Pet_Class>()
            {
                new My_Pet_Class
                {
                    Id = 1,
                    Name = "Max",
                    PetType = 2,
                    MissingSince = DateTime.Now.Subtract(TimeSpan.FromDays(6))
                },
                new My_Pet_Class {
                     Id = 2,
                    Name = "Fluffy",
                    PetType = 1,
                    MissingSince = DateTime.Now.Subtract(TimeSpan.FromDays(10))

                },
                new My_Pet_Class{
                    Id = 3,
                    Name = "Snowball",
                    PetType = 4,
                    MissingSince = DateTime.Now.Subtract(TimeSpan.FromDays(2))
                }
            };

            var actual = pets.OrderByDescending(c=>c.MissingSince);
            var expected = ps.GetPetListBySearchField(_context, search);

            Assert.AreEqual(expected.FirstOrDefault()?.Name, actual.FirstOrDefault()?.Name);
        }

        [TestMethod]
        public void CreatePet()
        {
            
            My_Pet_Class pet = new My_Pet_Class()
            {
                Id = 4,
                MissingSince = DateTime.Now.Subtract(TimeSpan.FromDays(6)),
                Name = "Nath's Cat",
                PetType = 1,
            };
            var pets = new List<My_Pet_Class>();
            pets.Add(pet);
            var actual = 4;
            var expected = ps.CreatePets(_context, pet);
            Assert.AreEqual(expected, actual); ;
           
        }

        [TestMethod]
        public void GetContactDetails()
        {
            var contacts = new List<ContactDetails>() {

                new ContactDetails {
                    Id = 1,
                    Name = "John Mx",
                    PhoneNumber = "+23453245533",
                    DateCreated=new DateTime(2023,01, 20),
                    UpdatedAt = null

                }

            };

            var actual = contacts.ToList();
            var expected = cs.GetAllContact(_context);
            Assert.AreEqual(expected.FirstOrDefault().Name, actual.FirstOrDefault().Name);
        }

        [TestMethod]
        public void CreateContact()
        {
            int id = 3;
            id = id + 1;
            var contact = new ContactDetails
            {
                Name = "Olawale Lawrence Ogunleye",
                PhoneNumber = "+234 7060 578 240"
            };
            var actual = id;
            var expected = cs.CreateContact(_context, contact);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void UpdateContactDetails()
        {
            long id = 4;
            var contact = new ContactDetails
            {
                Name = "Olawale Lawrence",
                PhoneNumber = "+234 7060 578 240"
            };
            var actual = false;
            var expected = cs.UpdateContact(_context, contact, id);
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void DeleteContact()
        {
            long id = 3;
            var actual = false;
            var expected = cs.DeleteContact(_context, id);
            Assert.AreEqual(expected, actual);
        }
    }
}