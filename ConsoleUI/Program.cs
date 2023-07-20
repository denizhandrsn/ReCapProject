using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.DTOs;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserTest();
            
        }


        private static void UserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());

            foreach (var user in userManager.GetUserDetails().Data)
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10}", 
                    user.FirstName,user.LastName,user.Email,user.CompanyName,user.BrandName,user.ColorName,
                    user.ModelYear,user.DailyPrice,user.RentDate,user.ReturnDate,user.Description);
            }
            
        }
        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5}",car.BrandName,car.Description,car.ModelYear,car.ColorName,car.DailyPrice,car.CarId);
            }
            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine("{0} {1} {2} {3}", car.Description, car.ModelYear, car.CarId, car.DailyPrice);
            //}
        }
    }
}