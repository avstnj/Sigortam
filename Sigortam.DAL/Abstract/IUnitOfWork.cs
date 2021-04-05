using System;
using System.Collections.Generic;
using System.Text;

namespace Sigortam.DAL.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository CustomerRepository { get; }
        IBidRepository BidRepository { get;}
        void Save();
    }
}
