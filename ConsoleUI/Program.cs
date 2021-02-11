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
            Console.WriteLine("GetCarsByBrandId ------------------------ ");

            CarManager carManager1 = new CarManager(new EfCarDal());
            foreach (var car in carManager1.GetCarsByBrandId(3))
            {
                Console.WriteLine("Brand ID:{0} Color ID:{1} Model Year:{2} Daily Price:{3} Description:{4}",car.BrandId,car.ColorId,car.ModelYear,car.DailyPrice,car.Description_);
            }

            Console.WriteLine("GetCarsByColorId -------------------------");

            CarManager carManager2 = new CarManager(new EfCarDal());
            foreach (var car in carManager2.GetCarsByColorId(2))
            {
                Console.WriteLine("Brand ID:{0} Color ID:{1} Model Year:{2} Daily Price:{3} Description:{4}", car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Description_);
            }

            Console.WriteLine("Ekleme işlemi esnasında çalıştırılacak kurallar");

            CarManager carManager3 = new CarManager(new EfCarDal());
            carManager3.Add(new Car
            { 
                BrandId=4,
                ColorId=3,
                ModelYear=2010,
                DailyPrice=0,
                Description_="D"
            });
            foreach (var car in carManager3.GetAll())
            {
                Console.WriteLine("Brand ID:{0} Color ID:{1} Model Year:{2} Daily Price:{3} Description:{4}", car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Description_);
            }
        }
    }
}
