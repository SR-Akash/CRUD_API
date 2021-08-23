using CRUD_API.DbContexts;
using CRUD_API.DTO;
using CRUD_API.Helper;
using CRUD_API.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_API.Repository
{
    public class Student : IStudent
    {
        private readonly DbContextCom _dbContext;

        public Student(DbContextCom dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<MessageHelper> CreateStudent(StudentDTO create)
        {
            try
            {
                var check = _dbContext.TblStudents.Where(x => x.StrPhoneNo == create.PhoneNo && x.IsActive == true).FirstOrDefault();

                if (check != null)
                    throw new Exception("Student with Phone No [ "+create.PhoneNo+" ] is Already Exist");

                var entity = new Models.TblStudent
                {
                    StrStudentName = create.StudentName,
                    StrPhoneNo = create.PhoneNo,
                    StrAddress = create.Address,
                    StrBloodGroup = create.BloodGroup,
                    DteInsertDateTime = DateTime.Now,
                    IsActive = true
                };

                await _dbContext.TblStudents.AddAsync(entity);
                await _dbContext.SaveChangesAsync();

                return new MessageHelper
                {
                    statuscode = 200,
                    Message = "Create Successfully"
                };
            }
            catch( Exception )
            {
                throw;
            }
           
        }
    }
}
