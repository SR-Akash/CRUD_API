using ClosedXML.Excel;
using CRUD_API.DbContexts;
using CRUD_API.DTO;
using CRUD_API.Helper;
using CRUD_API.IRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
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

        //public async Task<MessageHelper> CreateStudent(StudentDTO create)
        //{
        //    try
        //    {
        //        var check = _dbContext.TblStudents.Where(x => x.StrPhoneNo == create.PhoneNo && x.IsActive == true).FirstOrDefault();

        //        if (check != null)
        //            throw new Exception("Student with Phone No [ " + create.PhoneNo + " ] is Already Exist");

        //        var entity = new Models.TblStudent
        //        {
        //            StrStudentName = create.StudentName,
        //            StrPhoneNo = create.PhoneNo,
        //            StrAddress = create.Address,
        //            StrBloodGroup = create.BloodGroup,
        //            DteInsertDateTime = DateTime.Now,
        //            IsActive = true
        //        };

        //        await _dbContext.TblStudents.AddAsync(entity);
        //        await _dbContext.SaveChangesAsync();

        //        return new MessageHelper
        //        {
        //            statuscode = 200,
        //            Message = "Create Successfully"
        //        };
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }

        //}

        //public async Task<MessageHelper> EditStudent(StudentDTO edit)
        //{
        //    try
        //    {
        //        var update = _dbContext.TblStudents.Where(x => x.IntStudentId == edit.StudentId && x.IsActive == true).FirstOrDefault();

        //        if (update == null)
        //            throw new Exception("Student Update Data Not Found");

        //        update.StrStudentName = edit.StudentName;
        //        update.StrAddress = edit.Address;
        //        update.StrPhoneNo = edit.PhoneNo;
        //        update.StrBloodGroup = edit.BloodGroup;

        //        _dbContext.TblStudents.Update(update);
        //        await _dbContext.SaveChangesAsync();

        //        return new MessageHelper
        //        {
        //            Message = "Edited Successfully",
        //            statuscode = 200
        //        };
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }

        //}

        //public async Task<StudentDTO> GetStudentById(long studentId)
        //{
        //    try
        //    {
        //        var data = await Task.FromResult((from a in _dbContext.TblStudents
        //                                          where a.IsActive == true
        //                                          && a.IntStudentId == studentId
        //                                          select new StudentDTO
        //                                          {
        //                                              StudentId = a.IntStudentId,
        //                                              StudentName = a.StrStudentName,
        //                                              PhoneNo = a.StrPhoneNo,
        //                                              Address = a.StrAddress,
        //                                              BloodGroup = a.StrBloodGroup,
        //                                              InsertDateTime = a.DteInsertDateTime.Date
        //                                          }).FirstOrDefault());

        //        if (data == null)
        //            throw new Exception("Student Data Not Found");

        //        return data;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public async Task<List<StudentDTO>> GetStudentList()
        //{
        //    try
        //    {
        //        var data = await Task.FromResult((from a in _dbContext.TblStudents
        //                                          where a.IsActive == true
        //                                          select new StudentDTO
        //                                          {
        //                                              StudentId = a.IntStudentId,
        //                                              StudentName = a.StrStudentName,
        //                                              Address = a.StrAddress,
        //                                              BloodGroup = a.StrBloodGroup,
        //                                              PhoneNo = a.StrPhoneNo,
        //                                              ImagePath = a.ImageString
        //                                          }).ToList());

        //        return data;
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}

        //public static async Task<IActionResult> GetExcelDownload(List<StudentDTO> dt)
        //{
        //    int TotalRowCount = dt.Count;

        //    XLWorkbook xLWorkbook = new XLWorkbook();

        //    var worksheet = xLWorkbook.Worksheets.Add("Student List");
        //    //Sub Title
        //    var subTitle = worksheet.Range(2, 1, 2, 6).SetValue("Student List");
        //    subTitle.Merge().Style.Font.SetBold().Font.FontSize = 16;
        //    subTitle.Style.Font.SetFontColor(XLColor.CoolBlack);
        //    subTitle.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
        //    subTitle.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

        //    ////Table Header
        //    var header = worksheet.Range(4, 1, 4, 7);
        //    header.Style.Font.SetBold();
        //    header.Style.Fill.SetBackgroundColor(XLColor.CoolBlack);
        //    header.Style.Font.SetFontColor(XLColor.White);
        //    header.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
        //    header.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
        //    header.Style.Border.TopBorder = XLBorderStyleValues.Thin;
        //    header.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
        //    header.Style.Border.RightBorder = XLBorderStyleValues.Thin;

        //    int hSl = 1;

        //    header.Cell(1, hSl++).SetValue("Student Id");
        //    header.Cell(1, hSl++).SetValue("Student Name");
        //    header.Cell(1, hSl++).SetValue("Phone No");
        //    header.Cell(1, hSl++).SetValue("Address");
        //    header.Cell(1, hSl++).SetValue("Blood Group");
        //    header.Cell(1, hSl++).SetValue("Date");


        //    ////Table Data
        //    var dataArray = worksheet.Range(5, 1, TotalRowCount + 4, 6);
        //    dataArray.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
        //    dataArray.Style.Border.TopBorder = XLBorderStyleValues.Thin;
        //    dataArray.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
        //    dataArray.Style.Border.RightBorder = XLBorderStyleValues.Thin;

        //    var rowIndex = 1;
        //    foreach (var row in dt)
        //    {
        //        int dSl = 1;
        //        //dataArray.Cell(rowIndex, dSl++).SetValue(rowIndex.ToString());
        //        dataArray.Cell(rowIndex, dSl++).SetValue(row.StudentId.ToString());
        //        dataArray.Cell(rowIndex, dSl++).SetValue(row.StudentName.ToString());
        //        dataArray.Cell(rowIndex, dSl++).SetValue(row.PhoneNo.ToString());
        //        dataArray.Cell(rowIndex, dSl++).SetValue(row.Address.ToString());
        //        dataArray.Cell(rowIndex, dSl++).SetValue(row.BloodGroup.ToString());
        //        dataArray.Cell(rowIndex, dSl++).SetValue(row.InsertDateTime.ToString());

        //        rowIndex++;
        //    }
        //    worksheet.Columns().AdjustToContents();

        //    MemoryStream MS = new MemoryStream();
        //    xLWorkbook.SaveAs(MS);
        //    MS.Position = 0;

        //    return new FileStreamResult(MS, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
        //    {
        //        FileDownloadName = "StudentList.xlsx"
        //    };
        //}

        //public async Task<Dictionary<long, string>> GetDictornaryData()
        //{
        //    Dictionary<long, string> getData = new Dictionary<long, string>();

        //    var data = await Task.FromResult((from a in _dbContext.TblStudents
        //                                      where a.IsActive == true
        //                                      select new GetCommonDTO
        //                                      {
        //                                          Value = a.IntStudentId,
        //                                          Label = a.StrStudentName
        //                                      }).ToList());

        //    foreach (var itm in data)
        //    {
        //        getData.Add(itm.Value, itm.Label);
        //    }
        //    return getData;

        //}
        
        
        
        private readonly string _smtpServer = "smtp-relay.sendinblue.com";
        private readonly int _smtpPort = 587;
        private readonly string _smtpUsername = "akashtah25@gmail.com";
        private readonly string _smtpPassword = "hxNXnJM6jAW0G3Sp";
        public async Task<string> SendEmailAsync(string toEmail, string subject, string message)
        {
            using (var smtpClient = new SmtpClient(_smtpServer)
            {
                Port = _smtpPort,
                Credentials = new NetworkCredential(_smtpUsername, _smtpPassword),
                EnableSsl = true,
            })
            {
                using (var mailMessage = new MailMessage(_smtpUsername, toEmail)
                {
                    Subject = subject,
                    Body = message,
                    IsBodyHtml = true,
                })
                {
                    await smtpClient.SendMailAsync(mailMessage);
                }
            }
            return "OK";
        }
    }
}
