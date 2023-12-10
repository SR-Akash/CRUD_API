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
    public class SymmetricEncryptionExampleController : ControllerBase
    {
        private readonly ISymmetricEncryptionExample _IRepository;


        public SymmetricEncryptionExampleController(ISymmetricEncryptionExample IRepository)
        {
            _IRepository = IRepository;
        }

        [HttpPost]
        [Route("SymmetricExample")]
        public async Task<string> SymmetricExample(string inputMessage)
        {
            var msg = await _IRepository.SymmetricExample(inputMessage);
            return msg;

        }

        [HttpPost]
        [Route("SymmetricExampleDecrypt")]
        public async Task<string> SymmetricExampleDecrypt(string inputMessage, string key)
        {
            var msg = await _IRepository.SymmetricExampleDecrypt(inputMessage, key);
            return msg;

        }

    }
}
