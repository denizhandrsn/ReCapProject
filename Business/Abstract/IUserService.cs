using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<Users>> GetAll();
        IDataResult<List<Users>> GetUsersByName(string firstName);
        IDataResult<Users> GetUserByEmail(string email);
        IDataResult<Users> GetById(int id);
        IDataResult<List<UserDetailsDto>> GetUserDetails();
        IResult Add(Users user);
        IResult Update(Users user);
        IResult Delete(Users user);
    }
}
