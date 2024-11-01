using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Data;
using OrderManagement.Models;
using System.Threading.Tasks;

namespace OrderManagement.Controllers
{
    public class HomeController : Controller  
    {   
         public IActionResult Index()  
        {  
            return View();  
        }  

         public IActionResult Create()  
        {  
            return View();  
        }  
         public IActionResult Edit()  
        {  
            return View();  
        }  
        public IActionResult AnotherAction()  
        {  
            ViewBag.Message = TempData["Message"];  
            return View();  
        }  

        public IActionResult Error()  
        {  
            return View();
        }  
    }   
}
