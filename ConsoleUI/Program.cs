using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("GetAll-----------------------");

            CarManager carManager = new CarManager(new InMemoryCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(" Id:{0} Marka Id:{1} Renk Id:{2} Model Yılı:{3} Günlük Ücret:{4} Açıklama:{5} ",car.Id,car.BrandId,car.ColorId,car.ModelYear,car.DailyPrice,car.Description);
            }

            Console.WriteLine("GetById-----------------------");

            CarManager getById = new CarManager(new InMemoryCarDal());
            var result = getById.GetById(5);
            foreach (var id in result)
            {
                Console.WriteLine("Marka Id:{0} Renk Id:{1} Model Yılı:{2} Günlük Ücret:{3} Açıklama:{4} ", id.BrandId, id.ColorId, id.ModelYear, id.DailyPrice, id.Description);
            }

            Console.WriteLine("Add-----------------------------");

            Car addCar = new Car { Id = 6, BrandId = 5, ColorId = 4, ModelYear = 1995, DailyPrice = 2000, Description = "Citroen" };
            carManager.Add(addCar);
            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine("Id:{0} Marka Id:{1} Renk Id:{2} Model Yılı:{3} Günlük Ücret:{4} Açıklama:{5} ", item.Id, item.BrandId, item.ColorId, item.ModelYear, item.DailyPrice, item.Description);
            }

            Console.WriteLine("Update--------------------------");

            Car updateCar=new Car { Id = 2, BrandId = 5, ColorId = 4, ModelYear = 2015, DailyPrice = 7000, Description = "Volvo" };
            carManager.Update(updateCar);
            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine("Id:{0} Marka Id:{1} Renk Id:{2} Model Yılı:{3} Günlük Ücret:{4} Açıklama:{5} ", item.Id, item.BrandId, item.ColorId, item.ModelYear, item.DailyPrice, item.Description);
            }

            Console.WriteLine("Delete---------------------------");

            carManager.Delete(addCar);
            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine("Id:{0} Marka Id:{1} Renk Id:{2} Model Yılı:{3} Günlük Ücret:{4} Açıklama:{5} ", item.Id, item.BrandId, item.ColorId, item.ModelYear, item.DailyPrice, item.Description);
            }
        }
    }
}
