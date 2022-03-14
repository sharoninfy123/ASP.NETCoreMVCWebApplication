using Microsoft.AspNetCore.Mvc;
using MyFileUploader.Models;
using System.Collections.Generic;
using System.Linq;


namespace MyFileUploader.Controllers
{
    public class CityController : Controller
    {
        [HttpGet("CityController")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("CityController")]
        public JsonResult Index(string Prefix)
        {
            //Note : you can bind same list from database  
            List<City> ObjList = new List<City>()
            {

                new City {Id=1,Name="Latur" },
                new City {Id=2,Name="Mumbai" },
                new City {Id=3,Name="Pune" },
                new City {Id=4,Name="Delhi" },
                new City {Id=5,Name="Dehradun" },
                new City {Id=6,Name="Noida" },
                new City {Id=7,Name="New Delhi" }

        };
            //Searching records from list using LINQ query  
            var Name = (from N in ObjList
                        where N.Name.StartsWith(Prefix)
                        select new { N.Name });
            return Json(Name);
        }
    }
}
