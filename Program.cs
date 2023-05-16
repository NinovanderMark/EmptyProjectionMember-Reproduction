using EmptyProjectionMember_Reproduction.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmptyProjectionMember_Reproduction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var options = new DbContextOptionsBuilder<DbContext>().UseInMemoryDatabase("InMemoryUnitTestDatabase").Options;
            var dbContext = new DbContext(options);

            // Current models
            var car1 = new Car { Id = 1, Brand = "Volvo", DriverName = "Peter" };
            var car2 = new Car { Id = 2, Brand = "Ford", DriverName = "John" };
            dbContext.Add<Car>(car1);
            dbContext.Add<Car>(car2);

            // Older models
            var driver = new Person { Name = "Abraham" };
            var car3 = new OldCar { Id = 3, CarBrand = "2CV", Driver = driver };
            dbContext.Add<Person>(driver);
            dbContext.Add<OldCar>(car3);

            dbContext.SaveChanges();

            // Running queries on the data
            var carList = dbContext.Set<Car>().AsQueryable();
            var oldCarList = from car in dbContext.Set<OldCar>()
                             .Include(c => c.Driver)
                             select new Car
                             {
                                 Id = car.Id,
                                 Brand = car.CarBrand,
                                 DriverName = car.Driver.Name
                             };

            var combinedList = carList.Concat(oldCarList);
            var result = combinedList.ToList();
        }
    }
}