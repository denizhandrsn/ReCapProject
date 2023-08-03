using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {
        public List<CarDetailsDto> GetCarDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from p in context.Cars
                             join b in context.Brands
                             on p.BrandId equals b.Id
                             join c in context.Colors
                             on p.ColorId equals c.Id
                             join ci in context.CarImages
                             on p.Id equals ci.CarId
                             select new CarDetailsDto
                             {
                                 CarId = p.Id,
                                 BrandName = b.BrandName,
                                 Description = p.Description,
                                 ColorName = c.ColorName,
                                 ModelYear = p.ModelYear,
                                 DailyPrice = p.DailyPrice.ToString(),
                                 ImagePath = ci.ImagePath
                             };
                return result.ToList();


            }



        }
    }
}
