using CRUD_API.DTO;
using CRUD_API.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_API.IRepository
{
    public interface IStudent
    {
        public Task<MessageHelper> CreateStudent(StudentDTO create);
        public Task<MessageHelper> EditStudent(StudentDTO edit);
        public Task<StudentDTO> GetStudentById(long studentId);
        public Task<List<StudentDTO>> GetStudentList();
    }
}

