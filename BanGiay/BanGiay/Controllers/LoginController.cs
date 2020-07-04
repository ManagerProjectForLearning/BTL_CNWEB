using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BanGiay.Models;

namespace BanGiay.Controllers
{
    public class LoginController : Controller
    {
        ShopShoesDB db = new ShopShoesDB();
        public static AccountShop account=null;
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CheckAccount()
        {
            string user = Request["username"];
            string pass = Request["pass"];
            // kiếm tra acc
            var acc=db.AccountShops.Find(user);
            if (acc != null)
            {
                account = acc;
                if (acc.PhanQuyenS.Equals("ADMIN"))
                    return RedirectToAction("Index", "Admin",new { Area = "Admin" });
                else
                    return RedirectToAction("Index", "HomePage");
            }
            else
                return View("Login");
        }

    }



}