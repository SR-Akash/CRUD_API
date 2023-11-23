using CRUD_API.DTO;
using CRUD_API.Helper;
using CRUD_API.IRepository;
using CRUD_API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.WindowsAzure.Storage.Blob;
using System.ComponentModel;
using Microsoft.WindowsAzure.Storage;
using Windows.Storage;

namespace CRUD_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileProcessController : ControllerBase
    {
        private const string inputData = "a";
        private readonly IStudent _IRepository;
        CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse("BlobEndpoint=https://ibosblobdata.blob.core.windows.net?sp=rw&st=2021-11-16T05:46:17Z&se=2023-11-16T13:46:17Z&spr=https&sv=2020-08-04&sr=c&sig=nvI%2Fa0NvK0FuTuwz8vLP%2FaSeipCwJhbGKvmIVj9%2BoJ4%3D");

        public FileProcessController(IStudent IRepository)
        {
            _IRepository = IRepository;
        }

        //[AllowAnonymous]
        //[HttpPost]
        //[Route("GetDownloadMultiple")]
        //public async Task<IActionResult> GetDownloadMultiple()
        //{
        //    var inputData = await _IRepository.GetStudentList();
        //    CloudBlobClient blobClient = cloudStorageAccount.CreateCloudBlobClient();
        //    CloudBlobContainer container = blobClient.GetContainerReference("erpdata");
        //    using (var outStream = new MemoryStream())
        //    {
        //        foreach (var i in inputData)
        //        {
        //            CloudBlockBlob blockBlob = container.GetBlockBlobReference(i.ImagePath);
        //            StorageFile file = await ApplicationData.Current.LocalFolder.CreateFileAsync(blockBlob.Name, CreationCollisionOption.ReplaceExisting);
        //            await blockBlob.DownloadToFileAsync(file.Path, FileMode.Create);
        //            using (var archive = new ZipArchive(outStream, ZipArchiveMode.Update, true))
        //            {
        //                foreach (var ii in inputData)
        //                {
        //                    var fileInArchive = archive.CreateEntry(Path.GetFileName(ii.ImagePath), CompressionLevel.Optimal);
        //                    using (var entryStream = fileInArchive.Open())
        //                    {
        //                        using (var fileCompressionStream = new MemoryStream(System.IO.File.ReadAllBytes(ii.ImagePath)))
        //                        {
        //                            await fileCompressionStream.CopyToAsync(entryStream);
        //                        }
        //                    }
        //                }
        //            }

        //        }

        //        outStream.Position = 0;
        //        return File(outStream.ToArray(), "application/zip", "CheckZip.zip");
        //    }
        //}
    }
}
