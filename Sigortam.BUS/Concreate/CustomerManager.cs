using Sigortam.BUS.Abstract;
using Sigortam.DAL.Abstract;
using Sigortam.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sigortam.BUS.Concreate
{
    public class CustomerManager : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomerManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public void Create(Customer entity)
        {
            //iş kuralları yazılacak..
            _unitOfWork.CustomerRepository.Create(entity);
            _unitOfWork.Save();
        }

        public void Delete(Customer entity)
        {
            //iş kuralları yazılacak..
            _unitOfWork.CustomerRepository.Delete(entity);
            _unitOfWork.Save();
        }

        public List<Customer> GetByAll()
        {
            //iş kuralları yazılacak..
            return _unitOfWork.CustomerRepository.GetByAll();
        }

        public Customer GetById(int id)
        {
            //iş kuralları yazılacak..
            return _unitOfWork.CustomerRepository.GetById(id);
        }

        public void Update(Customer entity)
        {
            //iş kuralları yazılacak..
            _unitOfWork.CustomerRepository.Update(entity);
            _unitOfWork.Save();
        }
    }
}
