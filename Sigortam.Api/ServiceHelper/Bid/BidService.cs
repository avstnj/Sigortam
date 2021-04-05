using Sigortam.Api.ApiHelpers;
using Sigortam.ViewModel.Bid;
using Sigortam.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sigortam.Entity;

namespace Sigortam.Api.ServiceHelper.Bid
{
    public class BidService
    {
        public async Task<CommonResultModel<BidResponseModel>> GetBidByCompany(BidRequestModel model,string companyUrl)
        {
            CommonResultModel<BidResponseModel> result = new CommonResultModel<BidResponseModel> { };
            CommonResultModel commonResultModel = new CommonResultModel { DataResult = false, Description = "Başarısız", State = true };

            string URL = companyUrl;
            URL += "Bid/TeklifHesapla";
            var datalist = await ApiProcess.PostMetod<BidRequestModel, CommonResultModel<BidResponseModel>>(URL, model);

            if (datalist.State)
            {
                result = new CommonResultModel<BidResponseModel>    
                {
                    DataResult = datalist.DataResult,
                    Description = datalist.Description,
                    State = true
                };
            }
            else
            {
                result = new CommonResultModel<BidResponseModel>
                {
                    DataResult = null,
                    Description = datalist.Description,
                    State = false,
                };
            }
            return result;
        }
    }
}
