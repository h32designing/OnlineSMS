using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using onlinesms.Models;

namespace onlinesms.Controllers
{
    public class HomeController : Controller
    {
        OnlineSMSEntities1 db = new OnlineSMSEntities1();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult personaldetail()
        {
            return View(new personaldetail());
        }
        [HttpPost]
        public ActionResult personaldetail(personaldetail per)
        {
            db.personaldetails.Add(per);
            per.user_id = Convert.ToInt32(Session["UserId"]);
            per.per_image = "null";
            db.SaveChanges();
            Session["Personal"] = per.persdetail_id;
            Session["Fullpersonalname"] = per.per_name;
            Session["pergender"] = per.per_gender;
            Session["perdob"] = per.per_dob;
            Session["personaladdress"] = per.per_address;
            Session["perstatus"] = per.per_martialstatus;
            Session["personalemail"] = per.per_email;
            Session["perhobbie"] = per.per_hobbies;
            Session["perlike"] = per.per_likes;
            Session["perdislike"] = per.per_dislikes;
            Session["persport"] = per.per_sport;
            Session["personid"] = per.user_id;
            return View("DashProfile");
        }

        public ActionResult professionaldetail()
        {
            return View(new professionaldetail());
        }
        [HttpPost]
        public ActionResult professionaldetail(professionaldetail pro)
        {
            db.professionaldetails.Add(pro);
            pro.user_id = Convert.ToInt32(Session["UserId"]);
            db.SaveChanges();
            Session["Professional"] = pro.prof_id;
            Session["proqualification"] = pro.prof_qualification;
            Session["proschool"] = pro.prof_school;
            Session["procollege"] = pro.prof_college;
            Session["prostatus"] = pro.prof_status;
            Session["proorganization"] = pro.prof_organiztion;
            Session["prodesignation"] = pro.prof_designation;
            return View("DashProfile");
        }
        public ActionResult accept(int id)
        {
            user oldStd = db.users.Where(a => a.u_id == id).FirstOrDefault();
            if (ModelState.IsValid)
            {
                oldStd.status = "Accepted";
                db.SaveChanges();
            }
            return View("Request", db.users.ToList());
        }

        public ActionResult reject(int id)
        {
            user stu = db.users.Where(a => a.u_id == id).FirstOrDefault();
            db.users.Remove(stu);
            db.SaveChanges();
            return View("Request", db.users.ToList()); ;
        }

        public ActionResult About()
        {
            return View();
        }
        public ActionResult Services()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult error()
        {
            return View();
        }


        public ActionResult UserDashboard()
        {
            return View();
        }
        public ActionResult DashEmail()
        {
            return View();
        }
        public ActionResult Sent()
        {
            return View();
        }
        public ActionResult DashSMS()
        {
            int id = Convert.ToInt32(Session["UserId"]);
            ViewBag.contact_name = new SelectList(db.contacts.Where(a=>a.user_id == id),"contact_phone","contact_name");
            
            return View();
        }
        [HttpPost]
        public ActionResult DashSMS(contact con)
        {
            int id = Convert.ToInt32(Session["UserId"]);
            ViewBag.contact_name = new SelectList(db.contacts.Where(a => a.user_id == id), "contact_phone", "contact_name");
            sendSMS(con.contact_name);
            return View("Sent");
        }
        public string sendSMS(string num)
        {
            var MyUsername = "923152727251";
            var MyPassword = "hamza2727";
            var Masking = "Aptech Computer Learning";
            var toNumber = num;
            var MessageText = "Rubaisha here....";
            String URI = "http://sendpk.com" +
            "/api/sms.php?" +
            "username=" + MyUsername +
            "&password=" + MyPassword +
            "&sender=" + Masking +
            "&mobile=" + toNumber +
            "&message=" + Uri.UnescapeDataString(MessageText); // Visual Studio 10-15 
            // Visual Studio 12 
            Session["num"] = num;
            try
            {
                WebRequest req = WebRequest.Create(URI);
                WebResponse resp = req.GetResponse();
                var sr = new System.IO.StreamReader(resp.GetResponseStream());
                return sr.ReadToEnd().Trim();
            }
            catch (WebException ex)
            {
                var httpWebResponse = ex.Response as HttpWebResponse;
                if (httpWebResponse != null)
                {
                    switch (httpWebResponse.StatusCode)
                    {
                        case HttpStatusCode.NotFound:
                            return "404:URL not found :" + URI;
                            break;
                        case HttpStatusCode.BadRequest:
                            return "400:Bad Request";
                            break;
                        default:
                            return httpWebResponse.StatusCode.ToString();
                    }
                }
            }
            return null;
        }
        public ActionResult DashVoice()
        {
            return View();
        }
        public ActionResult DashProfile()
        {
            return View();
        }
        public ActionResult usercontact()
        {
            return View(new contact());
        }
        [HttpPost]
        public ActionResult usercontact(contact contact)
        {
            contact.user_id = Convert.ToInt32(Session["UserId"]);
            db.contacts.Add(contact);
            db.SaveChanges();

            ModelState.Clear();
            ViewBag.SuccessMessage = "Registration Successful";
            return View("DashSMS");
        }
        public ActionResult logout()
        {
            Session.Abandon();
            return View("Signin");
        }
        public ActionResult Request()
        {
            return View(db.users.ToList());
        }
        public ActionResult AdminDashboard()
        {
            return View(db.users.ToList());
        }
        public ActionResult Edit(int id)
        {
            user std = db.users.Where(a => a.u_id == id).FirstOrDefault();
            return View(std);
        }
        [HttpPost]
        public ActionResult Edit(int id, user std)
        {
            user oldStd = db.users.Where(a => a.u_id == id).FirstOrDefault();
            if (ModelState.IsValid)
            {
                oldStd.u_name = std.u_name;
                oldStd.u_email = std.u_email;
                oldStd.login_id = std.login_id;
                db.SaveChanges();
            }
            return View("AdminDashboard", db.users.ToList());
        }
        public ActionResult Delete(int id)
        {
            user stu = db.users.Where(a => a.u_id == id).FirstOrDefault();
            db.users.Remove(stu);
            db.SaveChanges();
            return View("AdminDashboard", db.users.ToList());
        }



        public ActionResult Signin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signin(user user)
        {
            user obj = db.users.Where(a => a.login_id == user.login_id && a.login_pass == user.login_pass).FirstOrDefault();
            if (obj != null)
            {
                if (obj.userrole_id == 2)
                {
                    Session["UserId"] = obj.u_id;
                    Session["Role"] = obj.userrole_id;
                    Session["Status"] = obj.status;
                    Session["Name"] = obj.u_name;
                    Session["loginid"] = obj.login_id;
                    if (obj.status == "Pending" || obj.status == "Reject")
                    {
                        return RedirectToAction("error");
                    }
                    else
                    {
                        return RedirectToAction("UserDashboard");
                    }
                }
                else
                {
                    Session["UserId"] = obj.u_id;
                    Session["Role"] = obj.userrole_id;
                    return RedirectToAction("AdminDashboard");
                }

            }
            else
            {
                ViewBag.error = "UserName Or Password is Incorrect";
            }
            return View();
        }

        [HttpGet]
        public ActionResult Signup()
        {
            return View(new user());
        }
        [HttpPost]
        public ActionResult Signup(user user)
        {
            db.users.Add(user);
            user.userrole_id = 2;
            user.status = "Pending";
            db.SaveChanges();
            
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registration Successful";
            return  View("Signin");
        }
        public ActionResult masksms()
		{
			return View();
		}
		public ActionResult nonmasksms()
		{
			return View();
		}
		public ActionResult Voice()
		{
			return View();
		}
		public ActionResult locationbased()
		{
			return View();
		}
		public ActionResult Promosms()
		{
			return View();
		}
		public ActionResult EmailService()
		{
			return View();
		}
	}
}