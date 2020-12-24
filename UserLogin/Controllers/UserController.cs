using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using UserLogin.Models;

namespace UserLogin.Controllers
{

    public class UserController : Controller
    {
        //GET:LOGIN
        
        public ActionResult CreateLogin()
        {
            User user = new User();

            return View(user);
        }

        //POST:LOGIN
        [HttpPost]
        public ActionResult CreateLogin(User user)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=newDatabase;Integrated Security=True;Pooling=False";
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "select * from Users where LoginName = @LoginName and Password = @Password";

                cmd.Parameters.AddWithValue("@LoginName", user.LoginName);
                cmd.Parameters.AddWithValue("@Password", user.Password);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    Session["LoginName"] = user.LoginName;

                    //HttpCookie cookie = new HttpCookie("userInfo");
                    //cookie["LoginName"] = user.LoginName;
                    //cookie["Password"] = user.Password;
                    //Response.Cookies.Add(cookie);

                    return RedirectToAction("homepage");
                }
                else
                    return RedirectToAction("CreateLogin");

            }
            catch
            {
                return View();
            }

        }


        public ActionResult homepage()
        {
            if (Session["LoginName"] == null)
            {
                return RedirectToAction("CreateLogin");
            }
           
            User user = new User();
            try
            {
               
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=newDatabase;Integrated Security=True;Pooling=False";
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "select * from Users where LoginName = @LoginName";
                string LoginName = (string)Session["LoginName"];
                cmd.Parameters.AddWithValue("@LoginName", LoginName);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    user.CityId = (int)dr["Cityid"];
                    user.LoginName = (string)dr["LoginName"];
                    user.FullName = (string)dr["FullName"];
                    user.Phone = (string)dr["Phone"];
                    user.EmailId = (string)dr["Emailid"];
                    return View(user);
                }
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }


        // GET: User
        public ActionResult Index()
        {

            return View();
        }


        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            User user = new User();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=newDatabase;Integrated Security=true";

            con.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = con;
            command.CommandType = CommandType.Text;
            command.CommandText = "select * from Cities";
           
            SqlDataReader dr = command.ExecuteReader();
            List<SelectListItem> lstcity = new List<SelectListItem>();
            while (dr.Read())
            {
                lstcity.Add(new SelectListItem { Text = (string)dr["CityName"], Value = Convert.ToInt32(dr["Cityid"]).ToString() });
            }
            user.Cities = lstcity;
            Session["LoginName"] = null;
            dr.Close();
            con.Close();
            return View(user);
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection();
                con.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=newDatabase;Integrated Security=True;Pooling=False";
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "AddUser";

                cmd.Parameters.AddWithValue("@LoginName", user.LoginName);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@FullName", user.FullName);
                cmd.Parameters.AddWithValue("@Emailid", user.EmailId);
                cmd.Parameters.AddWithValue("@CityId", user.CityId);
                cmd.Parameters.AddWithValue("@Phone", user.Phone);
                Session["LoginName"] = user.LoginName;
                cmd.ExecuteNonQuery();

                return RedirectToAction("homepage");
            }
            catch
            {
                return View();
            }
            finally
            {
                con.Close();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit()
        {
            SqlConnection cn = new SqlConnection();
            string LoginName = Session["LoginName"].ToString();
            User user = new User();

            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=newDatabase;Integrated Security=True;Pooling=False";
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "Select * from users where LoginName = @LoginName ";

            cmd.Parameters.AddWithValue("@LoginName", LoginName);

            SqlDataReader dr = cmd.ExecuteReader();

            dr.Read();

            user.LoginName = (string)dr["LoginName"];
            user.Password = (string)dr["Password"];
            user.FullName = (string)dr["FullName"];
            user.CityId = (int)dr["Cityid"];
            user.EmailId = (string)dr["Emailid"];
            user.Phone = (string)dr["Phone"];


            dr.Close();
            cn.Close();
            return View(user);


        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(User user)
        {
            try
            {
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=newDatabase;Integrated Security=True;Pooling=False";
                cn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "UpdateUser";

                cmd.Parameters.AddWithValue("@LoginName", user.LoginName);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@FullName", user.FullName);
                cmd.Parameters.AddWithValue("@Emailid", user.EmailId);
                cmd.Parameters.AddWithValue("@Cityid", user.CityId);
                cmd.Parameters.AddWithValue("@Phone", user.Phone);

                cmd.ExecuteNonQuery();
                cn.Close();

                return RedirectToAction("homepage");

            }
            catch
            {
                return View();
            }
        }


        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session["LoginName"] = null;
            Session.Abandon();
            return RedirectToAction("CreateLogin");
        }
    }
}