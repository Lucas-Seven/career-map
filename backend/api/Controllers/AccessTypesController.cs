﻿using dll.DAL;
using dll.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/accessTypes")]
    [ApiController]
    public class AccessTypesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly AccessTypesDAO _accessTypesDAO;
        public string ConnectionString { get; set; }
        public AccessTypesController(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = _configuration.GetConnectionString("AprovAtosConnection");
            _accessTypesDAO = new AccessTypesDAO(ConnectionString);
        }

        [HttpPost]
        public IActionResult PostAccessType(MAccessType accessType)
        {
            _accessTypesDAO.InsertAccessType(accessType);
            return Ok(new { message = "The access type was successfully registered." });
        }
    }
}
