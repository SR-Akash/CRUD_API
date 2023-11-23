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
    public class CachingController : ControllerBase
    {
        private readonly ICaching _cache;

        public CachingController(ICaching cache)
        {
            _cache = cache;
        }

        [HttpGet]
        [Route("GetAllItemList")]
        public async Task<IActionResult> GetAllItemList()
        {
            return Ok(await _cache.GetAllItemList());
        }

    }
}
