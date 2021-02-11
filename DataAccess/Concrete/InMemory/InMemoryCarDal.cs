using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id=1,BrandId=1,ColorId=1,ModelYear=2000,DailyPrice=1000,Description="Opel"},
                new Car{Id=2,BrandId=1,ColorId=2,ModelYear=2001,DailyPrice=2000,Description="BMW" },
                new Car{Id=3,BrandId=2,ColorId=2,ModelYear=2005,DailyPrice=3000,Description="Fiat" },
                new Car{Id=4,BrandId=2,ColorId=3,ModelYear=2010,DailyPrice=4000,Description="Hyundai" },
                new Car{Id=5,BrandId=2,ColorId=3,ModelYear=2015,DailyPrice=5000,Description="Leon" }
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete =_cars.SingleOrDefault(c=>c.Id==car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int carId)
        {
            return _cars.Where(c=>c.Id==carId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
