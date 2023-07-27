using Core.Entities.Concrete;
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
        IDataResult<List<User>> GetAll();
        IDataResult<List<User>> GetUsersByName(string firstName);
        IDataResult<User> GetUserByEmail(string email);
        IDataResult<User> GetById(int id);
        IDataResult<List<UserDetailsDto>> GetUserDetails();
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
        List<OperationClaim> GetClaims(User user);
        User GetByMail(string email);
    }
}
