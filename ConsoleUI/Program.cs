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
            GetCarDetails();
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
        }

        private static void GetByIdColor()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Console.WriteLine(colorManager.GetById(4).Name);
        }

        private static void GetAllColor()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.Name);
            }
        }

        private static void GetAllBrand()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.Name);
            }
        }

        private static void GetByIdBrand()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Console.WriteLine(brandManager.GetById(3).Name);
        }

        private static void GetByIdCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine(carManager.GetById(1).Description_);
        }

        private static void DeletedColor()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Delete(new Color { Id = 5 });
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.Name);
            }
        }

        private static void UpdatedColor()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Update(new Color { Id = 5, Name = "Kırmızı" });
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.Name);
            }
        }

        private static void AddedColor()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color { Name = "Mor" });
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.Name);
            }
        }

        private static void DeletedBrand()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Delete(new Brand { Id = 4 });
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.Name);
            }
        }

        private static void UpdatedBrand()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Update(new Brand { Id = 2, Name = "JEEP" });
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.Name);
            }
        }

        private static void AddedBrand()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand { Name = "BMW" });
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.Name);
            }
        }

        private static void GetCarDetails()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine("Car Name:{0} - Brand Name:{1} - Color Name: {2} - Daily Price:{3} ", car.CarName, car.BrandName, car.ColorName, car.DailyPrice);
            }
        }

        private static void GetAllCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll())
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
            foreach (var car in carManager.GetAll())
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
            foreach (var car in carManager.GetAll())
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
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description_);
            }
        }
    }
}
