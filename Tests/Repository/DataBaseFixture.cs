using Entities;
using Microsoft.EntityFrameworkCore;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Repository
{
    public class DatabaseFixture : IDisposable
    {
        public MyStoreContext Context { get; private set; }

        public DatabaseFixture()
        {
            // Set up the test database connection and initialize the context
            var options = new DbContextOptionsBuilder<MyStoreContext>()
                .UseSqlServer("Server=srv2\\pupils;Database=Tests;Trusted_Connection=True;")
                .Options;
            Context = new MyStoreContext(options, null);
            Context.Database.EnsureCreated();// create the data base
        }

        public void Dispose()
        {
            // Clean up the test database after all tests are completed
            Context.Database.EnsureDeleted();
            Context.Dispose();
        }
    }
}
