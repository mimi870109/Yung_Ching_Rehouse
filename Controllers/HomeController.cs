using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Yung_Ching_Rehouse.Models;
using Dapper;
using MySqlConnector;

namespace Yung_Ching_Rehouse.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            using (var conn = new MySqlConnection("server=sg2nlmysql47plsk.secureserver.net;port=3306;user id=xcard;password=aa901078;database=ph13886867778_;charset=utf8;"))
            {
                var list = conn.Query<studentData>("select * from `student`").ToList();
               
                conn.Close();

                return View(list);

            }
          
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
