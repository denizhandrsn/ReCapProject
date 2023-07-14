using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerService _customerService;
        public CustomerManager(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public List<Customer> getAll()
        {
            return _customerService.getAll();
        }
    }
}
