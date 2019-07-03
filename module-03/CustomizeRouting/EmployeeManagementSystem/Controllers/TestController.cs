using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    public class TestController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public  ActionResult Action1(int Id)
        {
            return View();
        }
        public ActionResult Action2(int id,string role)
        {
            return View();
        }
        public ActionResult Action3(int index)
        {
            return View();
        }
        public ActionResult Action4(int page, string role)
        {
            return View();
        }
    }
}