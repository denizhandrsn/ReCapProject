using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utilities
{
    public class UserBusinessRules
    {
        IUserDal _userDal;
        public UserBusinessRules(IUserDal userDal)
        {
            _userDal = userDal;
        }


        public IResult CheckIfUserAlreadyExists(User user)
        {
            var result = _userDal.GetAll().Contains(user);
            if (!result)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
        public IResult CheckIfEmailIsUsed(User user)
        {
            var result = _userDal.Get(p => p.Email.Equals(user.Email));
            if (result != null)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
