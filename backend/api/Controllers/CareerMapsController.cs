﻿using dll.DAL;
using dll.Data;
using dll.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CareerMapsController : ControllerBase
    {
        private readonly CareerMapsDao _careerMapsDao;

        public CareerMapsController(AprovAtosContext context)
        {
            _careerMapsDao = new CareerMapsDao(context);
        }

        [HttpGet]
        public IEnumerable<CareerMap> GetAllCareerMaps()
        {
            return _careerMapsDao.List();
        }

        [HttpPost]
        public CareerMap PostCareerMap(CareerMap careerMap)
        {
            _careerMapsDao.Execute(careerMap, EntityState.Added);
            return careerMap;
        }

        [HttpPut]
        public CareerMap PutCareerMap(CareerMap careerMap)
        {
            _careerMapsDao.Execute(careerMap, EntityState.Modified);
            return careerMap;
        }

        [HttpDelete]
        public IActionResult DeleteCareerMap(CareerMap careerMap)
        {
            try
            {
                _careerMapsDao.Execute(careerMap, EntityState.Deleted);
                return Ok("The career map was successfully deleted.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
