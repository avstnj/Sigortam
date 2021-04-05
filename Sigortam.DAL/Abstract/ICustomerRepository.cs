using Sigortam.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sigortam.DAL.Abstract
{
    public interface ICustomerRepository: IRepository<Customer>
    {
        //Customer GetLastCustomer();
    }
}
