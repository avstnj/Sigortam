using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Sigortam.Api.ApiHelpers
{
    public class ApiProcess
    {
        public static async Task<ResponseModel> PostMetod<ReguestModel, ResponseModel>(string URL, ReguestModel requestModel, string token = null) where ReguestModel : class where ResponseModel : class
        {
            //string UserName = username;
            //string token = null;
            //Helper.GlobalVariables.TryGetValue("accessToken", out token);
            ResponseModel reservationList;
            using (var httpClient = new HttpClient())
            {
                try
                {
                    if (!string.IsNullOrEmpty(token))
                        httpClient.DefaultRequestHeaders.Add("Authorization", token);

                    StringContent content = new StringContent(JsonConvert.SerializeObject(requestModel), Encoding.UTF8, "application/json");

                    using (var responsenew = Task.Run(async () => await httpClient.PostAsync(URL, content)).Result)
                    {
                        string apiResponse = await responsenew.Content.ReadAsStringAsync();
                        reservationList = JsonConvert.DeserializeObject<ResponseModel>(apiResponse);
                    }
                }
                catch (Exception ex)
                {
                    reservationList = null;
                    string error = ex.StackTrace;
                }
            }
            return reservationList;
        }
        public static async Task<ResponseModel> GetMetod<ResponseModel>(string URL, string token = null) where ResponseModel : class
        {
            //string token = null;
            //Helper.GlobalVariables.TryGetValue("accessToken", out token);
            ResponseModel reservationList;
            using (var httpClient = new HttpClient())
            {
                try
                {
                    if (!string.IsNullOrEmpty(token))
                        httpClient.DefaultRequestHeaders.Add("Authorization", token);
                    //httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                    using (var responsenew = Task.Run(async () => await httpClient.GetAsync(URL)).Result)
                    {
                        string apiResponse = await responsenew.Content.ReadAsStringAsync();
                        reservationList = JsonConvert.DeserializeObject<ResponseModel>(apiResponse);
                    }
                }
                catch (Exception ex)
                {
                    reservationList = null;
                    string error = ex.StackTrace;
                }
            }
            return reservationList;
        }
    }
}
