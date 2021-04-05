using Sigortam.DAL.Abstract;
using Sigortam.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sigortam.DAL.Concreate.EfCore
{
    public class EfCoreBidRepository : EfCoreGenericRepository<Bid>, IBidRepository
    {
        public EfCoreBidRepository(SigortamContext context) : base(context)
        {

        }
        private SigortamContext SigortamContext
        {
            get { return context as SigortamContext; }
        }
        public List<Bid> GetPopularBids()
        {
            return SigortamContext.Bids.ToList();
        }
    }
}
