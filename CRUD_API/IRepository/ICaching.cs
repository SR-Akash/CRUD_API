using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_API.IRepository
{
    public interface ICaching
    {
        public Task<object> GetAllItemList();

    }
}
