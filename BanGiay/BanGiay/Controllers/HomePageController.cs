using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BanGiay.Models;

namespace BanGiay.Controllers
{
    public class HomePageController : Controller
    {
        // GET: HomePage
        private ShopShoesDB dbcontext = new ShopShoesDB();

        public ActionResult Index()
        {

            ViewBag.inforWeb = dbcontext.MyWebShops.First();
            ViewBag.product4 = dbcontext.Database.SqlQuery<Product>("select * from Product").ToList();
            ViewBag.brandN = dbcontext.Database.SqlQuery<BrandShoes>("select *from BrandShoes").ToList();
            ViewBag.cateList = dbcontext.Database.SqlQuery<Categorieshop>("select * from Categorieshop").ToList();
            return View();
        }
        
        [HttpGet]
        public ActionResult Product(string id)// trang product chỉ hiện thị 1 chi tiết sảm phẩm do người dùng muốn xem
        {
            /*
            ViewBag.inforWeb = dbcontext.MyWebShops.First();
            
            var cateList = dbcontext.Database.SqlQuery<Categorieshop>("select * from Categorieshop").ToList();
            //string id = Request["idP"].ToString();
                      ViewBag.productDetial = dbcontext.Products.Find(id);
            */
            ViewBag.brandN = dbcontext.Database.SqlQuery<BrandShoes>("select *from BrandShoes").ToList();
            var cateList = dbcontext.Products.Find(id);

            return View(cateList);
        }
        public ActionResult Shop()
        {
            ViewBag.inforWeb = dbcontext.MyWebShops.First();
            ViewBag.product4 = dbcontext.Database.SqlQuery<Product>("select * from Product").ToList();
            ViewBag.brandN = dbcontext.Database.SqlQuery<BrandShoes>("select *from BrandShoes").ToList();
            ViewBag.cateList = dbcontext.Database.SqlQuery<Categorieshop>("select * from Categorieshop").ToList();
            return View();
        }
        public ActionResult NikeShoes()
        {
            ViewBag.inforWeb = dbcontext.MyWebShops.First();
            return View();
        }
        public ActionResult AdidasShoes()
        {
            ViewBag.inforWeb = dbcontext.MyWebShops.First();
            return View();
        }
        public ActionResult VansShoes()
        {
            ViewBag.inforWeb = dbcontext.MyWebShops.First();
            return View();
        }
        public ActionResult ConverseShoes()
        {
            ViewBag.inforWeb = dbcontext.MyWebShops.First();
            return View();
        }
        public ActionResult Login()
        {
            ViewBag.inforWeb = dbcontext.MyWebShops.First();
            return View();
        }
        public ActionResult Contact()
        {
            //ViewBag.inforWeb = dbcontext.MyWebShops.First();
            return View();
        }
        public ActionResult Checkout()
        {
            ViewBag.inforWeb = dbcontext.MyWebShops.First();
            return View();
        }
        public ActionResult Cart()
        {
            ViewBag.inforWeb = dbcontext.MyWebShops.First();
            return View();
        }
        public ActionResult Collection()
        {  
             ViewBag.inforWeb = dbcontext.MyWebShops.First();
            return View();
        }
        public ActionResult Register()
        {
            ViewBag.inforWeb = dbcontext.MyWebShops.First();
            return View();
        }
        [HttpPost]
        public ActionResult registerAcc()
        {
            ViewBag.inforWeb = dbcontext.MyWebShops.First();
            string user = Request["username"].ToString();
            string pass = Request["password"].ToString();
            string repass = Request["confirm_pass"].ToString();
            if (pass.Equals(repass))
                addAcc(user,pass);
            return View("Index");
        }


        public void addAcc(string user,string pass)
        {
            AccountShop account = new AccountShop();
            account.username = user;
            account.pass = pass;

            if(dbcontext.AccountShops.Find(user) == null)
            {
                dbcontext.AccountShops.Add(account);
            }
            dbcontext.SaveChanges();
        }

    }
}