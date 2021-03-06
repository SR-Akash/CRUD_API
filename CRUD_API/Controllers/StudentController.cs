using CRUD_API.DTO;
using CRUD_API.Helper;
using CRUD_API.IRepository;
using CRUD_API.Repository;
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

        [HttpPut]
        [Route("EditStudent")]
        public async Task<MessageHelper> EditStudent(StudentDTO edit)
        {
            var msg = await _IRepository.EditStudent(edit);
            return msg;

        }

        [HttpGet]
        [Route("GetStudentById")]
        public async Task<IActionResult> GetStudentById(long studentId)
        {

            var dt = await _IRepository.GetStudentById(studentId);
            if (dt == null)
            {
                return NotFound();
            }
            return Ok(dt);

        }

        [HttpGet]
        [Route("GetStudentList")]
        public async Task<IActionResult> GetStudentList()
        {

            var dt = await _IRepository.GetStudentList();
            if (dt == null)
            {
                return NotFound();
            }
            return Ok(dt);

        }

        [HttpGet]
        [Route("GetExcelDownload")]
        public async Task<IActionResult> GetExcelDownload()
        {

            var dt = await _IRepository.GetStudentList();

            return await Student.GetExcelDownload(dt);

        }

        [HttpGet]
        [Route("GetDictornaryData")]
        public async Task<IActionResult> GetDictornaryData()
        {

            var dt = await _IRepository.GetDictornaryData();
            if (dt == null)
            {
                return NotFound();
            }
            return Ok(dt);

        }
    }
}