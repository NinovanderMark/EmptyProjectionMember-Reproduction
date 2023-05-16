using EmptyProjectionMember_Reproduction.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmptyProjectionMember_Reproduction
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<OldCar> OldCars { get; set; }

        public DbContext(DbContextOptions options) : base(options) 
        { 
        }
    }
}
