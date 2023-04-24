using admin.Api.Model.Response;
using admin.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.Net.Http;

namespace admin.Api.Service
{
    public class RequirementService : BaseService
    {
        private RequirementListResponse DataList { get; set; }

        public RequirementService()
        {
            endpoint = $"requirements";
            DataList = new RequirementListResponse();
            //DataList = new List<CompanyPosition>();
        }


        public async Task<List<RequirementInfo>> GetAllRequirements()
        {
            List<RequirementInfo> dados = new List<RequirementInfo>();

            try
            {
                string url = baseUrl + endpoint;
                httpClient.BaseAddress = new Uri(url);
                var json = await httpClient.GetStringAsync("");

                dados = JsonConvert.DeserializeObject<List<RequirementInfo>>(json);

                //DataList = dados;
                //DataList.AddRange(dados.Requirements);
            }
            catch (Exception)
            {
                //throw;
            }

            return dados;
        }

        //public async Task<bool> AddRequirement(RequirementInfo requirement)
        //{
        //    try
        //    {
        //        string url = baseUrl + endpoint;
        //        httpClient.BaseAddress = new Uri(url);

        //        var dados = JsonConvert.SerializeObject(requirement);

        //        var requirementContent = new HttpContent();


        //        var json = await httpClient.PostAsync("", requirementContent);


        //        //DataList = dados;
        //        //DataList.AddRange(dados.Requirements);
        //    }
        //    catch (Exception)
        //    {
        //        //throw;
        //    }

        //    return dados;
        //}

        public async Task<bool> AddRequirement(RequirementInfo requirement)
        {
            try
            {
                string url = baseUrl + endpoint;
                httpClient.BaseAddress = new Uri(url);

                var content = new StringContent(JsonConvert.SerializeObject(requirement),
                                                 System.Text.Encoding.UTF8,
                                                 "application/json");

                var response = await httpClient.PostAsync("", content);

                var responseContent = await response.Content.ReadAsStringAsync();

                Console.WriteLine(responseContent);
                return true;
            }
            catch (Exception)
            {
                //throw;
            }

            return false;
        }


        public Dictionary<int, RequirementInfo> LoadDataMemory()
        {
            var careers = new Dictionary<int, RequirementInfo>();

            for (int i = 1; i <= 5; i++)
            {
                careers.Add(i, new RequirementInfo()
                {
                    RequirementId = i,
                    RequirementName = $"Req {i}"
                });
            };
            return careers;
        }

        //public api.CompanyPositionService _apiService { get; set; }

        //public CareerMapVM careerMap { get; set; }

        //public CompanyPositionService()
        //{
        //    //if (career != null)
        //    //{
        //        //this.careerMap = career;
        //        _apiService = new api.CompanyPositionService();
        //    //}
        //}

        //public async Task<List<CompanyPositionInfo>> GetAllCompanyPositions()
        //{
        //    var data = await _apiService.GetAllPositions();

        //    List<CompanyPositionVM> ret = new List<CompanyPositionVM>();

        //    foreach (var item in data)
        //    {
        //        CompanyPositionVM cp = new CompanyPositionVM()
        //        {
        //            CompanyPositionId = item.CompanyPositionId,
        //            CompanyPositionName = item.CompanyPositionName,
        //        };

        //        ret.Add(cp);
        //    }

        //    return data;
        //}

        ////public async Task<CompanyPositionListVM> GetCompanyPositionsList()
        ////{
        ////    var data = await _apiService.GetPositionsByCareer();

        ////    var careerMap = new CareerMapVM()
        ////    {
        ////        CareerMapId = data.CareerMapResponse.CareerMapId,
        ////        CareerMapName = data.CareerMapResponse.CareerMapName
        ////    };

        ////    CompanyPositionListVM ret = new CompanyPositionListVM();
        ////    ret.CareerMapVm = careerMap;

        ////    foreach (var item in data.CompanyPositionResponseList)
        ////    {
        ////        CompanyPositionVM cp = new CompanyPositionVM()
        ////        {
        ////            ParentCareerMapVm = careerMap,
        ////            CompanyPositionId = item.CompanyPositionInfo.CompanyPositionId,
        ////            CompanyPositionName = item.CompanyPositionInfo.CompanyPositionName,
        ////            HierarchyNumber = item.HierarchyNumber
        ////        };

        ////        ret.CompanyPositionVmList.Add(cp);
        ////    }

        ////    return ret;
        ////}
    }
}
