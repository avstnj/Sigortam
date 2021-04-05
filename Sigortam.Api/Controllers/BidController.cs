using Microsoft.AspNetCore.Mvc;
using Sigortam.Api.ApiHelpers;
using Sigortam.Api.ServiceHelper.Bid;
using Sigortam.DAL.Abstract;
using Sigortam.Entity;
using Sigortam.ViewModel.Bid;
using Sigortam.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sigortam.Api.Controllers
{
    [Route("api/[controller]")]
    public class BidController : Controller
    {
        private IUnitOfWork unitOfWork;
        public BidController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        [HttpPost]
        [Route("GetBidByCompany")]
        public async Task<ApiResult<List<BidResponseModel>>> GetBidByCompany([FromBody] BidRequestModel model)
        {

            List<BidResponseModel> bidResponseModels = new List<BidResponseModel>();
            BidService bidServiceLocal = new BidService();
            string[] sirketURLListesi = Startup.SirketURLListesi.Split(',');
            foreach (string item in sirketURLListesi)
            {
                CommonResultModel<BidResponseModel> commonResultModel = await bidServiceLocal.GetBidByCompany(model, item);
                if (commonResultModel.State)
                    bidResponseModels.Add(commonResultModel.DataResult);
            }

            Customer customer = new Customer
            {
                InsertDate = DateTime.Now,
                isActive = true,
                Plaka = model.Plaka,
                RuhsatSeriKodu = model.RuhsatSeriKodu,
                RuhsatSeriNo = model.RuhsatSeriNo,
                TCKN = model.TCKN,
                UpdateDate = null
            };

            unitOfWork.CustomerRepository.Create(customer);
            unitOfWork.Save();

            //int customerId = unitOfWork.CustomerRepository.GetByAll().LastOrDefault().Id;
            int customerId = unitOfWork.CustomerRepository.GetByAll().LastOrDefault().Id;

            if (bidResponseModels.Count > 0)
            {
                foreach (BidResponseModel item in bidResponseModels)
                {
                    Entity.Bid bid = new Entity.Bid
                    {
                        BidAmount = item.TeklifTutari,
                        BidDescription = item.TeklifAciklama,
                        CompanyLogo = item.FirmaLogo,
                        CompanyName = item.FirmaAdi,
                        CustomerId = customerId,
                        InsertDate = DateTime.Now,
                        isActive = true,
                        UpdateDate = null,
                    };
                    unitOfWork.BidRepository.Create(bid);
                    unitOfWork.Save();
                }
            }
            ApiResult<List<BidResponseModel>> apiResult = new ApiResult<List<BidResponseModel>>
            {
                Data = bidResponseModels,
                Message = "",
                StatusCode = 200
            };
            return apiResult;
        }

        [HttpPost]
        [Route("GetRuhsatInfo")]
        public ApiResult<RuhsatInfoResponseModel> GetRuhsatInfo([FromBody] RuhsatInfoRequestModel model)
        {
            ApiResult<RuhsatInfoResponseModel> apiResult = new ApiResult<RuhsatInfoResponseModel>
            {
                Data = null,
                Message = "Başarısız",
                StatusCode = 404
            };
            Customer customer = unitOfWork.CustomerRepository.GetByAll().Where(x => x.Plaka == model.Plaka && x.TCKN == model.TCKN).FirstOrDefault();
            if (customer != null)
            {
                RuhsatInfoResponseModel ruhsatInfoResponseModel = new RuhsatInfoResponseModel
                {
                    RuhsatSeriKodu = customer.RuhsatSeriKodu,
                    RuhsatSeriNo = customer.RuhsatSeriNo
                };

                apiResult = new ApiResult<RuhsatInfoResponseModel>
                {
                    Data = ruhsatInfoResponseModel,
                    Message = "Başarılı",
                    StatusCode = 200
                };
            }

            return apiResult;
        }
    }
}
