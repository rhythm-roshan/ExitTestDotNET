using Nagarro.CasinoPortal.Web.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
using System.Text;

namespace Nagarro.CasinoPortal.Admin.Controllers
{

    public class UserController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RegisterUser()
        {
            return View();
        }

        public void AddImage(HttpPostedFileBase file)
        {
            if (file.ContentLength > 0)
            {
                try
                {
                    var filename = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("../uploads/"), filename);
                    file.SaveAs(path);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        [HttpPost]
        public ActionResult RegisterUser(UserViewModel user)
        {
            if (user.file != null)
            {
                AddImage(user.file);
                Byte[] bt = Encoding.UTF8.GetBytes(user.file.FileName);
                user.image = bt;
                user.file = null;

            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:56636/api/");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<UserViewModel>("admin", user);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");



            return View(user);
        }

        [HttpPost]
        public ActionResult RechargeAmount(UserViewModel user)
        {


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:56636/api/admin");

                //HTTP POST
                var putTask = client.PutAsJsonAsync<UserViewModel>("admin/"+user.UserID.ToString(), user);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("GetALlUser");
                }
            }
            return View(user);




        }



        // GET: User
        public ActionResult GetAllUser(string searchName = null, string searchContact = null, string searchEmail = null)
        {
            IEnumerable<UserViewModel> users = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:56636/api/");

                var responseTask = client.GetAsync("admin");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<UserViewModel>>();
                    readTask.Wait();
                    users = readTask.Result.Where(r => (searchName == null || r.UserName.Contains(searchName)) &&
                        (searchContact == null || r.Contact.ToString().Contains(searchContact)) &&
                        (searchEmail == null || r.Email.Contains(searchEmail)));
                }
                else
                {
                    users = Enumerable.Empty<UserViewModel>();
                    //ModelState.AddModelError(string.Empty);
                }
            }
            return View(users);

        }
    }
}