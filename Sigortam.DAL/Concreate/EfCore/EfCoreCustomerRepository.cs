using Sigortam.DAL.Abstract;
using Sigortam.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sigortam.DAL.Concreate.EfCore
{
    public class EfCoreCustomerRepository : EfCoreGenericRepository<Customer>, ICustomerRepository
    {
        public EfCoreCustomerRepository(SigortamContext context) : base(context)
        {

        }
        private SigortamContext SigortamContext
        {
            get { return context as SigortamContext; }
        }

        //public Customer GetLastCustomer()
        //{
        //    var res = SigortamContext.Customers.LastOrDefault();
        //    return res;
        //}
    }
}
