using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, ReCapContext>, IUserDal
    {
        public List<UserDetailsDto> GetUserDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from u in context.Users
                             join r in context.Rentals
                             on u.Id equals r.UserId
                             join car in context.Cars
                             on r.CarId equals car.Id
                             join col in context.Colors
                             on car.ColorId equals col.Id
                             join b in context.Brands
                             on car.BrandId equals b.Id
                             select new UserDetailsDto
                             {
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Email = u.Email,
                                 BrandName = b.BrandName,
                                 ColorName = col.ColorName,
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description,
                                 ModelYear = car.ModelYear,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                return result.ToList();

            }
        }
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new ReCapContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }
    }
}
