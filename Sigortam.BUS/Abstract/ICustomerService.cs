using Sigortam.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sigortam.BUS.Abstract
{
    public interface ICustomerService
    {
        Customer GetById(int id);
        List<Customer> GetByAll();
        void Create(Customer entity);
        void Update(Customer entity);
        void Delete(Customer entity);
    }
}
