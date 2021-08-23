using System;
using System.Collections.Generic;

#nullable disable

namespace CRUD_API.Models
{
    public partial class TblStudent
    {
        public long IntStudentId { get; set; }
        public string StrStudentName { get; set; }
        public string StrPhoneNo { get; set; }
        public string StrAddress { get; set; }
        public string StrBloodGroup { get; set; }
        public DateTime DteInsertDateTime { get; set; }
        public bool IsActive { get; set; }
    }
}
