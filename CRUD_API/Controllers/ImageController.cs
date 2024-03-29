﻿using DocumentFormat.OpenXml.InkML;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Net;


namespace SME.Controllers.FTP
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly FTPHelper ftpHelper;
        public ImageController()
        {
            // Initialize the FtpHelper with FTP server details
            ftpHelper = new FTPHelper("ftp://192.168.2.1102/", "Akash", "akash@123");
        }
        public class FileResponse
        {
            public string id { get; set; }
            public string fileName { get; set; }
        }
        [HttpPost("UploadImage")]
        public IActionResult UploadImage(IFormFile image)
        {
            try
            {
                if (image == null || image.Length == 0)
                    return BadRequest("Invalid image.");

                // Get the image stream
                using (var stream = image.OpenReadStream())
                {
                    // Upload the image to the FTP server
                    ftpHelper.UploadImage(stream, image.FileName);
                }
                FileResponse response = new FileResponse
                {
                    id = image.Name,
                    fileName = image.FileName
                };


                return Ok(response);
                //return Ok(image.FileName);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("DownloadImage")]
        public IActionResult DownloadImage(string fileName)
        {
            try
            {
                // Download the image from the FTP server
                var imageStream = ftpHelper.DownloadImage(fileName);

                // If the image was found, return it
                if (imageStream != null)
                {
                    return File(imageStream, "image/jpeg"); // Assuming the image is JPEG format
                }
                else
                {
                    return NotFound("Image not found.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
