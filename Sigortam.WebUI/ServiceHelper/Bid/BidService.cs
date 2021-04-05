using Sigortam.ViewModel.Bid;
using Sigortam.ViewModel.Common;
using Sigortam.WebUI.ApiHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sigortam.WebUI.ServiceHelper.Bid
{
    public class BidService
    {
        public async Task<CommonResultModel<List<BidResponseModel>>> GetBidByCompany(BidRequestModel model)
        {
            CommonResultModel<List<BidResponseModel>> result = new CommonResultModel<List<BidResponseModel>> { };

            string URL = Startup.ApiURL;
            URL += "Bid/GetBidByCompany";
            var datalist = await ApiProcess.PostMetod<BidRequestModel, ApiResult<List<BidResponseModel>>>(URL, model);

            if (datalist.StatusCode == 200)
            {
                result = new CommonResultModel<List<BidResponseModel>>
                {
                    DataResult = datalist.Data,
                    Description = datalist.Message,
                    State = true
                };
            }
            return result;
        }
        public CommonResultModel<RuhsatInfoResponseModel> GetRuhsatInfo(RuhsatInfoRequestModel model)
        {
            CommonResultModel<RuhsatInfoResponseModel> result = new CommonResultModel<RuhsatInfoResponseModel> { };

            string URL = Startup.ApiURL;
            URL += "Bid/GetRuhsatInfo";
            var datalist = ApiProcess.PostMetod<RuhsatInfoRequestModel, ApiResult<RuhsatInfoResponseModel>>(URL, model);

            if (datalist.Result.StatusCode == 200)
            {
                result = new CommonResultModel<RuhsatInfoResponseModel>
                {
                    DataResult = datalist.Result.Data,
                    Description = datalist.Result.Message,
                    State = true
                };
            }
            return result;
        }
    }
}
