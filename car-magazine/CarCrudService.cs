using System;
using System.Collections.Generic;
using System.Linq;

namespace car_magazine
{
    public class CarCrudService
    {
        private readonly AppDbContext dbContext;

        public CarCrudService(AppDbContext context)
        {
            dbContext = context;
        }

        public List<Car> GetCars()
        {
            return dbContext.Cars.ToList();
        }

        public List<Car> GetUserCars(int userId)
        {
            return dbContext.Cars.Where(car => car.UserId == userId).ToList();
        }

        public void CreateCar(string model, decimal price, int mileage, string vinCode, int year, string categoryName, int userId)
        {
            ValidateCarFields(model, price, mileage, vinCode, year, categoryName);

            using (var dbContextTransaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    // Check if VIN code is unique
                  /*  if (IsVinCodeUnique(vinCode))
                    {
                        throw new InvalidOperationException("VIN code must be unique. Another car with the same VIN code already exists.");
                    }*/

                    var category = dbContext.Categories.FirstOrDefault(c => c.Name == categoryName);

                    if (category == null)
                    {
                        throw new InvalidOperationException("Please select a valid category.");
                    }

                    var newCar = new Car
                    {
                        Model = model,
                        Price = price,
                        Mileage = mileage,
                        VinCode = vinCode,
                        Year = year,
                        CategoryId = (int)category.Id,
                        UserId = userId
                    };

                    dbContext.Cars.Add(newCar);
                    dbContext.SaveChanges();

                    dbContextTransaction.Commit();
                }
                catch (Exception)
                {
                    
                    dbContextTransaction.Rollback();
                    throw;
                }
            }
        }


        public void UpdateCar(int carId, string model, decimal price, int mileage, string vinCode, int year, string categoryName)
        {
            ValidateCarFields(model, price, mileage, vinCode, year, categoryName);

            var car = dbContext.Cars.Find(carId);

            if (car == null)
            {
                throw new InvalidOperationException("Car not found.");
            }

            // Check if VIN code is unique among other cars (excluding the current car being updated)
            if (IsVinCodeUnique(vinCode, carId))
            {
                throw new InvalidOperationException("VIN code must be unique. Another car with the same VIN code already exists.");
            }

            var category = dbContext.Categories.FirstOrDefault(c => c.Name == categoryName);

            if (category == null)
            {
                throw new InvalidOperationException("Please select a valid category.");
            }

            car.Model = model;
            car.Price = price;
            car.Mileage = mileage;
            car.VinCode = vinCode;
            car.Year = year;
            car.CategoryId = (int)category.Id;

            dbContext.SaveChanges();
        }

        public void DeleteCar(int carId)
        {
            var car = dbContext.Cars.Find(carId);

            if (car == null)
            {
                throw new InvalidOperationException("Car not found.");
            }

            dbContext.Cars.Remove(car);
            dbContext.SaveChanges();
        }

        private void ValidateCarFields(string model, decimal price, int mileage, string vinCode, int year, string categoryName)
        {
            if (string.IsNullOrEmpty(model) || price <= 0 || mileage < 0 || string.IsNullOrEmpty(vinCode) || year <= 0 || string.IsNullOrEmpty(categoryName))
            {
                throw new InvalidOperationException("All fields are required.");
            }
        }

        private bool IsVinCodeUnique(string vinCode, int? carId = null)
        {
            if (carId.HasValue)
            {
                bool isUnique = !dbContext.Cars.Any(c => c.VinCode == vinCode && c.Id != carId.Value);
                Console.WriteLine($"Checking VIN code uniqueness for car with ID {carId}: {isUnique}");
                return isUnique;
            }
            else
            {
                bool isUnique = !dbContext.Cars.Any(c => c.VinCode == vinCode);
                Console.WriteLine($"Checking VIN code uniqueness for new car: {isUnique}");
                return isUnique;
            }
        }


    }
}
