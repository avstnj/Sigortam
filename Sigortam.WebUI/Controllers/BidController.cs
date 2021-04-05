using Microsoft.AspNetCore.Mvc;
using Sigortam.ViewModel.Bid;
using Sigortam.ViewModel.Common;
using Sigortam.WebUI.ServiceHelper.Bid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sigortam.WebUI.Controllers
{
    public class BidController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<CommonResultModel<List<BidResponseModel>>> GetBidByCompany(BidRequestModel model)
        {
            BidService bidService = new BidService();
            return await bidService.GetBidByCompany(model);
        }
        [HttpPost]
        public CommonResultModel<RuhsatInfoResponseModel> GetRuhsatInfo(RuhsatInfoRequestModel model)
        {
            BidService bidService = new BidService();
            return bidService.GetRuhsatInfo(model);
        }
    }
}
