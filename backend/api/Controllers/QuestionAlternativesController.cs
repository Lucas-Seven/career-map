﻿using dll.DAL;
using dll.Models;
using dll.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/alternatives")]
    [ApiController]
    public class QuestionAlternativesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly QuestionAlternativesDAO _questionAlternativesDAO;
        public string ConnectionString { get; set; }
        public QuestionAlternativesController(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = _configuration.GetConnectionString("AprovAtosConnection");
            _questionAlternativesDAO = new QuestionAlternativesDAO(ConnectionString);
        }
    }
}
