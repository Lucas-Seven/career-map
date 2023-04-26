using admin.Api.Model;
using admin.Api.Model.Response;
using admin.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.Net.Http;

namespace admin.Api.Service
{
    public class QuestionService : BaseService
    {
        //private AlternativeListResponse DataList { get; set; }

        public QuestionService()
        {
            endpoint = $"question";
            //DataList = new AlternativeListResponse();
            //DataList = new List<CompanyPosition>();
        }


        public async Task<QuestionsAlternative> GetQuestionById(int questionId)
        {
            QuestionsAlternative dados = new QuestionsAlternative();

            try
            {
                string url = $"{baseUrl}{endpoint}?questionId={questionId}";
                httpClient.BaseAddress = new Uri(url);
                var json = await httpClient.GetStringAsync("");

                dados = JsonConvert.DeserializeObject<QuestionsAlternative>(json);

                //DataList = dados;
                //DataList.AddRange(dados.Alternatives);
            }
            catch (Exception)
            {
                //throw;
            }

            return dados;
        }



        //public async Task<bool> Insert(QuestionsAlternative question)
        public async Task<bool> Insert(MQuestion question)
        {
            endpoint = "questions/insert";

            try
            {
                string url = baseUrl + endpoint;
                httpClient.BaseAddress = new Uri(url);

                var content = new StringContent(JsonConvert.SerializeObject(question),
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

        //public async Task<List<AlternativeInfo>> GetAllAlternatives()
        //{
        //    List<AlternativeInfo> dados = new List<AlternativeInfo>();

        //    try
        //    {
        //        string url = baseUrl + endpoint;
        //        httpClient.BaseAddress = new Uri(url);
        //        var json = await httpClient.GetStringAsync("");

        //        dados = JsonConvert.DeserializeObject<List<AlternativeInfo>>(json);

        //        //DataList = dados;
        //        //DataList.AddRange(dados.Alternatives);
        //    }
        //    catch (Exception)
        //    {
        //        //throw;
        //    }

        //    return dados;
        //}

        //public async Task<bool> AddAlternative(AlternativeInfo Alternative)
        //{
        //    try
        //    {
        //        string url = baseUrl + endpoint;
        //        httpClient.BaseAddress = new Uri(url);

        //        var dados = JsonConvert.SerializeObject(Alternative);

        //        var AlternativeContent = new HttpContent();


        //        var json = await httpClient.PostAsync("", AlternativeContent);


        //        //DataList = dados;
        //        //DataList.AddRange(dados.Alternatives);
        //    }
        //    catch (Exception)
        //    {
        //        //throw;
        //    }

        //    return dados;
        //}

        ////public async Task<bool> AddAlternative(AlternativeInfo Alternative)
        ////{
        ////    try
        ////    {
        ////        string url = baseUrl + endpoint;
        ////        httpClient.BaseAddress = new Uri(url);

        ////        var content = new StringContent(JsonConvert.SerializeObject(Alternative),
        ////                                         System.Text.Encoding.UTF8,
        ////                                         "application/json");

        ////        var response = await httpClient.PostAsync("", content);

        ////        var responseContent = await response.Content.ReadAsStringAsync();

        ////        Console.WriteLine(responseContent);
        ////        return true;
        ////    }
        ////    catch (Exception)
        ////    {
        ////        //throw;
        ////    }

        ////    return false;
        ////}


        ////public Dictionary<int, AlternativeInfo> LoadDataMemory()
        ////{
        ////    var careers = new Dictionary<int, AlternativeInfo>();

        ////    for (int i = 1; i <= 5; i++)
        ////    {
        ////        careers.Add(i, new AlternativeInfo()
        ////        {
        ////            AlternativeId = i,
        ////            AlternativeName = $"Req {i}"
        ////        });
        ////    };
        ////    return careers;
        ////}

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
