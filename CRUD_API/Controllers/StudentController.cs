using CRUD_API.DTO;
using CRUD_API.Helper;
using CRUD_API.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudent _IRepository;

        public StudentController(IStudent IRepository)
        {
            _IRepository = IRepository;
        }

        [HttpPost]
        [Route("CreateStudent")]

        public async Task<MessageHelper> CreateStudent(StudentDTO Create)
        {
            var msg = await _IRepository.CreateStudent(Create);
            return msg;

        }
    }
}