using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProject.Models;
using WebProject.Models;

namespace WebProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult login1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login1(ProductModel p1)
        {
            ProductModel p2 = new ProductModel();
            p2.custName = "ashwin";
            p2.password = "pass";
            if(p1.custName==p2.custName && p1.password==p2.password)
            {
                return View("Index");
            }
            return View();
        }
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult login()
        {
                return View();
            }
        [HttpPost]
        public ActionResult login(Logmodel l1)
        {
            string cs = "datasource=.;database=FirstDB;integrated Security=SSPI";
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("Select * from LoginTable1", con);
            con.Open();
            cmd.ExecuteReader();
            con.Close();
            Logmodel l2 = new Logmodel();
            l2.name = "ashwin";
            l2.password = "password";
            if(l1.name==l2.name && l1.password==l2.password)
            {
                return View("Index");
            }
            return View();
        }
        string cs = @"Data Source=KALIDASA\SQLDEV2016;Database=FirstDB;integrated Security=True";
        [HttpGet]
        public ActionResult About()
        {
          
            DataTable DB = new DataTable();
            using (SqlConnection con = new SqlConnection(cs))
            {
               // SqlCommand cmd = new SqlCommand("Select * from LoginTable1", con);
                con.Open();
                SqlDataAdapter sqlDb=new SqlDataAdapter("Select * from LoginTable1", con);
                sqlDb.Fill(DB);
              //  cmd.ExecuteReader();
             
            }
           // ViewBag.Message = "Your application description page.";

            return View(DB);
        }
        public ActionResult Create()
        {
      
                return View(new ProductModel());
        }
        [HttpPost]
        public ActionResult Create(ProductModel p1)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                string query = "INSERT INTO LoginTable1 VALUES(@custId,@Age,@City,@Country,@custName,@password)";
                SqlCommand sqlcmd = new SqlCommand(query, con);
                sqlcmd.Parameters.AddWithValue("@custId", p1.custId);
                sqlcmd.Parameters.AddWithValue("@Age", p1.Age);
                sqlcmd.Parameters.AddWithValue("@City", p1.City);
                sqlcmd.Parameters.AddWithValue("@Country", p1.Country);
                sqlcmd.Parameters.AddWithValue("@custName", p1.custName);
                sqlcmd.Parameters.AddWithValue("@password", p1.password);
              sqlcmd.ExecuteNonQuery();
            }

            return View();
        }
        public ActionResult Edit(int id)
        {
            ProductModel pm = new ProductModel();
            DataTable db = new DataTable();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                string query = "SELECT * FROM LoginTable1 where custId=@custId";
                SqlDataAdapter sd = new SqlDataAdapter(query, con);
                sd.SelectCommand.Parameters.AddWithValue("@custId",id);
                sd.Fill(db);

            }
            if(db.Rows.Count==1)
            {
                pm.custId = Convert.ToInt32(db.Rows[0][0].ToString());
                pm.Age = Convert.ToInt32(db.Rows[0][1].ToString());
                pm.City = db.Rows[0][2].ToString();
                pm.Country = db.Rows[0][3].ToString();
                pm.custName =db.Rows[0][4].ToString();
                pm.password =db.Rows[0][5].ToString();
                return View(pm);
            }
            else
                return View("Create");
        }
        [HttpPost]
        public ActionResult Edit(ProductModel p1)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                string query = "UPDATE LoginTable1 SET Age=@Age,City=@City,Country=@Country,custName=@custName,password=@password WHERE custId=@custId";
                SqlCommand sqlcmd = new SqlCommand(query, con);
                sqlcmd.Parameters.AddWithValue("@custId", p1.custId);
                sqlcmd.Parameters.AddWithValue("@Age", p1.Age);
                sqlcmd.Parameters.AddWithValue("@City", p1.City);
                sqlcmd.Parameters.AddWithValue("@Country", p1.Country);
                sqlcmd.Parameters.AddWithValue("@custName", p1.custName);
                sqlcmd.Parameters.AddWithValue("@password", p1.password);
                sqlcmd.ExecuteNonQuery();
            }
            return View("Index");
        }
        //Get:/Home/Delete/100 
        //id should be passed to delete
        public ActionResult Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                string query = "DELETE FROM LoginTable1 WHERE custId=@custId";
                SqlCommand sqlcmd = new SqlCommand(query, con);
                sqlcmd.Parameters.AddWithValue("@custId", id);
                sqlcmd.ExecuteNonQuery();
            }
            return View();
                //return View("Index");
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}