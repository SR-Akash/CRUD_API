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
        private readonly IStudent _emailService;

        public StudentController(IStudent IRepository, IStudent emailService)
        {
            _IRepository = IRepository;
            _emailService = emailService;
        }

        //[HttpPost]
        //[Route("CreateStudent")]
        //public async Task<MessageHelper> CreateStudent(StudentDTO Create)
        //{
        //    var msg = await _IRepository.CreateStudent(Create);
        //    return msg;

        //}

        //[HttpPut]
        //[Route("EditStudent")]
        //public async Task<MessageHelper> EditStudent(StudentDTO edit)
        //{
        //    var msg = await _IRepository.EditStudent(edit);
        //    return msg;

        //}

        //[HttpGet]
        //[Route("GetStudentById")]
        //public async Task<IActionResult> GetStudentById(long studentId)
        //{

        //    var dt = await _IRepository.GetStudentById(studentId);
        //    if (dt == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(dt);

        //}

        //[HttpGet]
        //[Route("GetStudentList")]
        //public async Task<IActionResult> GetStudentList()
        //{

        //    var dt = await _IRepository.GetStudentList();
        //    if (dt == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(dt);

        //}

        //[HttpGet]
        //[Route("GetExcelDownload")]
        //public async Task<IActionResult> GetExcelDownload()
        //{

        //    var dt = await _IRepository.GetStudentList();

        //    return await Student.GetExcelDownload(dt);

        //}

        //[HttpGet]
        //[Route("GetDictornaryData")]
        //public async Task<IActionResult> GetDictornaryData()
        //{

        //    var dt = await _IRepository.GetDictornaryData();
        //    if (dt == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(dt);

        //}





        [HttpPost("send")]
        public async Task<IActionResult> SendEmail(string toEmail, string subject, string message)
        {
            try
            {
                await _emailService.SendEmailAsync(toEmail, subject, message);
                return Ok("Email sent successfully.");
            }
            catch (Exception ex)
            {
                // Handle exceptions, log errors, etc.
                return BadRequest("An error occurred while sending the email.");
            }
        }
    }
}