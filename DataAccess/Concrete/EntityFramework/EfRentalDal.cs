using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentalCarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (RentalCarContext context=new RentalCarContext())
            {
                var result = from r in context.Rentals
                             join car in context.Cars on r.CarId equals car.Id
                             join b in context.Brands on car.BrandId equals b.Id
                             join c in context.Customers on r.CustomerId equals c.Id
                             join u in context.Users on c.UserId equals u.Id
                             select new RentalDetailDto
                             {
                                 CarName = car.Description_,
                                 UserName = u.FirstName+" "+u.LastName,
                                 CustomerName = c.CustomerName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate?? DateTime.Now
                             };
                return result.ToList();
            }
        }
    }
}
