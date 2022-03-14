using Azure.Storage.Blobs;
using MyFileUploader.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyFileUploader.Controllers
{
    public class FileUpload : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost("FileUpload")]

        public async Task<IActionResult> Index(IFormFile files)
        {
            
            if (files == null || files.Length == 0)
            {
                ViewBag.message = "Please upload a valid text file";
            }

            else
            {
                string connectionstring = "DefaultEndpointsProtocol=https;AccountName=uploaderstoragesharon;AccountKey=QiAQUuuL1iagNrjYI9PydmlPAMRI7rGBIYwZUHRBPy3yhqX8ImHI88O6OsmwVm7/iHmuQViX1iM/+AStfqgoqg==;EndpointSuffix=core.windows.net";
                string blobContainerName = "mycontainer";
                BlobClient blobClient = new BlobClient(connectionString: connectionstring, blobContainerName: blobContainerName, blobName: files.FileName);
                try
                {
                    var result = await blobClient.UploadAsync(files.OpenReadStream());
                    ViewBag.message ="File successfully uploaded to blob storage!!";
                }
                catch (Exception)
                {
                    ViewBag.message = "Upload Failed, please try again later!";
                }

                //TempData["message"] = message;
            }
            return View();

        }
    }
}
