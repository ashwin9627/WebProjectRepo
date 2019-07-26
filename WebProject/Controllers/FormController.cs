using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProject.Models;

namespace WebProject.Controllers
{
    public class FormController : Controller
    {
        // GET: Form
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Test()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Test(EntityTable1 e1)
        {
            using (FirstDBEntities1 entities = new FirstDBEntities1())
            {
                entities.EntityTable1.Add(e1);
                entities.SaveChanges();
                int id = e1.ID;
             //   return View("Index");
            }
            return View(e1);
        }
        public void test1()
        {

        }
    }
   
}