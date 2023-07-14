using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Customer:IEntites
    {
        public int CustomerId { get; set; }
        public string CustomerFirsName { get; set; }
        public string CustomerLastName { get; set; }
        public string NationalityNumber { get; set; }
    }
}
