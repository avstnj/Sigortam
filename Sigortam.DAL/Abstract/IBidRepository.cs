using Sigortam.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sigortam.DAL.Abstract
{
    public interface IBidRepository : IRepository<Bid>
    {
        List<Bid> GetPopularBids();
    }
}
