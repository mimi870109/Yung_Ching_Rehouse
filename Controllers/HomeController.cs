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

        public IActionResult Insert()
        {
 
                return View();
        }
        [HttpPost]
        public string Insertdata( string name, string phone, string birthday, string sum)
        {

            using (var conn = new MySqlConnection("server=sg2nlmysql47plsk.secureserver.net;port=3306;user id=xcard;password=aa901078;database=ph13886867778_;charset=utf8;"))
            {
                var sql = @"insert into student (name,phone,birthday,sum) values(@name,@phone,@birthday,@sum)";
                var result = conn.Execute(sql, new { name = name, phone = phone, birthday= birthday, sum = sum });

            }
            return "成功";
        }
        public IActionResult Edit(string id)
        {
            using (var conn = new MySqlConnection("server=sg2nlmysql47plsk.secureserver.net;port=3306;user id=xcard;password=aa901078;database=ph13886867778_;charset=utf8;"))
            {
                var list=conn.Query<studentData>("select * from `student`where id=@id",new { id = id }).ToList();
                var data = new studentData();
                data.id = list[0].id;
                data.name = list[0].name;
                data.phone = list[0].phone;
                data.sum = list[0].sum;
                conn.Close();

                return View(data);

            }
            
        }

        public string Delete(string id)
        {
            using (var conn = new MySqlConnection("server=sg2nlmysql47plsk.secureserver.net;port=3306;user id=xcard;password=aa901078;database=ph13886867778_;charset=utf8;"))
            {
                var list = conn.Query("DELETE from `student` where id=@id", new { id = id });

                conn.Close();
            }
            return "成功";
        }
        [HttpPost]
        public string Editdata(string id, string name, string phone, string sum)
        {
            using (var conn = new MySqlConnection("server=sg2nlmysql47plsk.secureserver.net;port=3306;user id=xcard;password=aa901078;database=ph13886867778_;charset=utf8;"))
            {
                var sql = @"update student set name=@name,phone=@phone,sum=@sum where id=@id";
                var result = conn.Execute(sql, new { id = id,name=name,phone=phone,sum=sum });

            }
            return "成功";
        }
       
    }
}
