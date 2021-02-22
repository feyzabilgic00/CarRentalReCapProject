using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //---Car'a ait CRUD işlemleri
            //AddedCar();
            //DeletedCar();
            //UpdatedCar();
            //GetAllCar();
            //GetByIdCar();
            //--Joinleme işlemi sonucu
            //GetCarDetails();
            //---Brand'a ait CRUD işlemleri
            //AddedBrand();
            //UpdatedBrand();
            //DeletedBrand();
            //GetAllBrand();
            //GetByIdBrand();
            //--Color'a ait CRUD işlemleri
            //AddedColor();
            //UpdatedColor();
            //DeletedColor();
            //GetAllColor();
            //GetByIdColor();
            //AddedUser();
            //AddedCustomer();
            //UpdatedCustomer();
            AddedRental();
            GetRentalDetails();
        }

        private static void GetRentalDetails()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            foreach (var rental in rentalManager.GetRentalDetails().Data)
            {
                Console.WriteLine("Car Name: {0} Customer Name: {1} User Name: {2} Rent Date: {3} Return Date: {4}", rental.CarName, rental.CustomerName, rental.UserName, rental.RentDate, rental.ReturnDate);
            }
        }

        private static void AddedRental()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            rentalManager.Add(new Rental
            {
                CarId = 3,
                CustomerId = 3,
                RentDate = DateTime.Parse("02-15-2021"),
                ReturnDate = DateTime.Parse("02-22-2021")
            });
            foreach (var rental in rentalManager.GetAll().Data)
            {
                Console.WriteLine("Car Id:{0} Customer Id:{1} Rent Date:{2} Return Date:{3}", rental.CarId, rental.CustomerId, rental.RentDate, rental.ReturnDate);
            }
        }

        private static void UpdatedCustomer()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Update(
                new Customer { Id = 2, UserId = 2, CustomerName = "Hayriye" }
                );
            foreach (var customer in customerManager.GetAll().Data)
            {
                Console.WriteLine(customer.CustomerName);
            }
        }

        private static void AddedCustomer()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Add(
                new Customer { UserId = 1, CustomerName = "Feyza" }
                );
            foreach (var customer in customerManager.GetAll().Data)
            {
                Console.WriteLine(customer.CustomerName);
            }
        }

        private static void AddedUser()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            userManager.Add(
               new User { FirstName = "Fahriye", LastName = "Kuzu", Email = "fahriyee@hotmail.com", Password = "12345678" }
            );
            foreach (var user in userManager.GetAll().Data)
            {
                Console.WriteLine("{0} {1}", user.FirstName, user.LastName);
            }
        }

        private static void GetByIdColor()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Console.WriteLine(colorManager.GetById(4).Data);
        }

        private static void GetAllColor()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.Name);
            }
        }

        private static void GetAllBrand()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.Name);
            }
        }

        private static void GetByIdBrand()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Console.WriteLine(brandManager.GetById(3).Data);
        }

        private static void GetByIdCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine(carManager.GetById(1).Data);
        }

        private static void DeletedColor()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Delete(new Color { Id = 5 });
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.Name);
            }
        }

        private static void UpdatedColor()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Update(new Color { Id = 5, Name = "Kırmızı" });
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.Name);
            }
        }

        private static void AddedColor()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color { Name = "Mor" });
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.Name);
            }
        }

        private static void DeletedBrand()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Delete(new Brand { Id = 4 });
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.Name);
            }
        }

        private static void UpdatedBrand()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Update(new Brand { Id = 2, Name = "JEEP" });
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.Name);
            }
        }

        private static void AddedBrand()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand { Name = "BMW" });
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.Name);
            }
        }

        private static void GetCarDetails()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine("Car Name:{0} - Brand Name:{1} - Color Name: {2} - Daily Price:{3} ", car.CarName, car.BrandName, car.ColorName, car.DailyPrice);
            }
        }

        private static void GetAllCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine("Car Id:{0} - Brand Id:{1} - Color Id: {2} - Daily Price:{3} - Model Year:{4} - Description:{5}", car.Id, car.BrandId, car.ColorId, car.DailyPrice, car.ModelYear, car.Description_);
            }
        }

        private static void UpdatedCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Update(new Car
            {
                Id = 6,
                Description_ = "LAND-ROVER",
                BrandId = 3,
                ColorId = 2,
                DailyPrice = 5000,
                ModelYear = 2020
            });
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine("Car Id:{0} - Brand Id:{1} - Color Id: {2} - Daily Price:{3} - Model Year:{4} - Description:{5}", car.Id, car.BrandId, car.ColorId, car.DailyPrice, car.ModelYear, car.Description_);
            }
        }

        private static void DeletedCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Delete(new Car
            {
                Id = 1002
            });
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.Description_);
            }
        }

        private static void AddedCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car
            {
                BrandId = 3,
                ColorId = 3,
                ModelYear = 2020,
                DailyPrice = 10000,
                Description_ = "Lamborghini"
            });
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.Description_);
            }
        }
    }
}
