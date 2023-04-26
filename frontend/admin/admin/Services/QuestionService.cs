using admin.Api.Model;
using admin.Api.Model.Response;
using admin.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using api = admin.Api.Service;

namespace admin.Services
{
    public class QuestionService
    {
        public api.QuestionService _api;

        public QuestionService()
        {
            _api = new api.QuestionService();
        }

        public QuestionsAlternative GetQuestionById(int questionId)
        {
            return _api.GetQuestionById(questionId).Result;
        }

        //public bool Insert(QuestionsAlternative question)
        public bool Insert(MQuestion question)
        {
            return _api.Insert(question).Result;
        }

        //public List<AlternativeVM> GetAllAlternatives()
        //{
        //    var data = _api.GetAllAlternatives().Result;
        //    var ret = new List<AlternativeVM>();

        //    foreach (var item in data)
        //    {
        //        AlternativeVM career = new AlternativeVM()
        //        {
        //            AlternativeId = item.AlternativeId,
        //            AlternativeName = item.AlternativeName
        //        };

        //        ret.Add(career);
        //    }

        //    return ret;
        //}

        //public bool AddAlternative(AlternativeInfo Alternative) 
        //{
        //    return _api.AddAlternative(Alternative).Result;
        //}



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
