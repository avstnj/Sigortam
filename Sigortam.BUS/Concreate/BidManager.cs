using Sigortam.BUS.Abstract;
using Sigortam.DAL.Abstract;
using Sigortam.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sigortam.BUS.Concreate
{
    public class BidManager : IBidService
    {
        private IBidRepository bidRepository;
        private readonly IUnitOfWork _unitOfWork;

        public BidManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Create(Bid entity)
        {
            //iş kuralları yazılacak..
            _unitOfWork.BidRepository.Create(entity);
            _unitOfWork.Save();
        }

        public void Delete(Bid entity)
        {
            _unitOfWork.BidRepository.Delete(entity);
            _unitOfWork.Save();
        }

        public List<Bid> GetByAll()
        {
            return _unitOfWork.BidRepository.GetByAll();
        }

        public Bid GetById(int id)
        {
            return _unitOfWork.BidRepository.GetById(id);
        }

        public void Update(Bid entity)
        {
            _unitOfWork.BidRepository.Update(entity);
            _unitOfWork.Save();
        }
    }
}
