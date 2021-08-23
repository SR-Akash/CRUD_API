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
    public class ExcelDownloadController : ControllerBase
    {
        private readonly IStudent _IRepository;

        public ExcelDownloadController(IStudent IRepository)
        {
            _IRepository = IRepository;
        }

        

    }
}
