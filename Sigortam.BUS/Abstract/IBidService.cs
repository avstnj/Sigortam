using Sigortam.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sigortam.BUS.Abstract
{
    public interface IBidService
    {
        Bid GetById(int id);
        List<Bid> GetByAll();
        void Create(Bid entity);
        void Update(Bid entity);
        void Delete(Bid entity);
    }
}
