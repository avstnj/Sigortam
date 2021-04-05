using Sigortam.DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sigortam.DAL.Concreate.EfCore
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SigortamContext _context;
        public UnitOfWork(SigortamContext context)
        {
            _context = context;
        }
        private EfCoreCustomerRepository _customerRepository;
        private EfCoreBidRepository _bidRepository;

        public ICustomerRepository CustomerRepository => _customerRepository = _customerRepository ?? new EfCoreCustomerRepository(_context);
        public IBidRepository BidRepository => _bidRepository = _bidRepository ?? new EfCoreBidRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
