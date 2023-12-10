using CRUD_API.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_API.IRepository
{
    public interface ISymmetricEncryptionExample
    {
        public Task<string> SymmetricExample(string inputMessage);
        public Task<string> SymmetricExampleDecrypt(string inputMessage, string key);
    }
}
