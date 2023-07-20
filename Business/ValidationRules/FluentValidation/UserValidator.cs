using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    //Validation: Nesnenin yapısının kontrol edilmesidir. Business codesla aynı değildir
    public class UserValidator:AbstractValidator<Users>
    {
        public UserValidator()
        {
            RuleFor(p => p.Password).MinimumLength(4);
            RuleFor(p => p.Password).MaximumLength(12);
            RuleFor(p => p.Email).EmailAddress();
            RuleFor(p => p.FirstName).NotEmpty();
            RuleFor(p => p.LastName).NotEmpty();


        }


    }
}
