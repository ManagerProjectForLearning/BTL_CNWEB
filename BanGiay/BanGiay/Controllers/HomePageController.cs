using System;
using System.Collections.Generic;
using System.IO;
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
            ViewBag.brandN = dbcontext.Database.SqlQuery<BrandSho>("select *from BrandShoes").ToList();
            ViewBag.cateList = dbcontext.Database.SqlQuery<Categorieshop>("select * from Categorieshop").ToList();
            return View();
        }
        
        
        public ActionResult Product(string id)// trang product chỉ hiện thị 1 chi tiết sảm phẩm do người dùng muốn xem
        {
            
            ViewBag.inforWeb = dbcontext.MyWebShops.First();
            
            ViewBag.cateList = dbcontext.Database.SqlQuery<Categorieshop>("select * from Categorieshop").ToList();
            var p = dbcontext.Products.Find(id);
            ViewBag.brandN = dbcontext.BrandShoes.ToList();
            return View(p);
        }

        public ActionResult Shop()
        {
            ViewBag.inforWeb = dbcontext.MyWebShops.First();
            ViewBag.product4 = dbcontext.Database.SqlQuery<Product>("select * from Product").ToList();
            ViewBag.brandN = dbcontext.Database.SqlQuery<BrandSho>("select *  from BrandShoes").ToList();
            ViewBag.cateList = dbcontext.Database.SqlQuery<Categorieshop>("select * from Categorieshop").ToList();
            return View();
        }

        public ActionResult TimKiemSP()
        {
            ViewBag.inforWeb = dbcontext.MyWebShops.First();
            ViewBag.product4 = dbcontext.Database.SqlQuery<Product>("select * from Product").ToList();
            ViewBag.brandN = dbcontext.Database.SqlQuery<BrandSho>("select *  from BrandShoes").ToList();
            ViewBag.cateList = dbcontext.Database.SqlQuery<Categorieshop>("select * from Categorieshop").ToList();
            string brand = Request["Brand"];
            string giatri = Request["timkiem"];
            var data = new List<Product>();
            if (brand.Equals("00"))
            {
                data = dbcontext.Products.SqlQuery("select * from Product where " +
                "nameP like N'%" + giatri + "%'").ToList();
            }
            else
                data= dbcontext.Products.SqlQuery("select * from Product where idBrand ='"+brand+"' and "+
                "nameP like N'%"+giatri+"%'").ToList();
            return View("Shop",data);
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
            ViewBag.inforWeb = dbcontext.MyWebShops.First();
            ViewBag.brandN = dbcontext.Database.SqlQuery<BrandSho>("select *from BrandShoes").ToList();
            return View();
        }
        public ActionResult Checkout()
        {
            ViewBag.inforWeb = dbcontext.MyWebShops.First();
            ViewBag.brandN = dbcontext.Database.SqlQuery<BrandSho>("select *from BrandShoes").ToList();
            var cart = (AccountCartShop)Session["CartSession"];
  
            return View(cart);
        }

        public ActionResult Payment()
        {
            ViewBag.brandN = dbcontext.Database.SqlQuery<BrandSho>("select *from BrandShoes").ToList();
            ViewBag.inforWeb = dbcontext.MyWebShops.First();
            var cart = (AccountCartShop)Session["CartSession"];
            if(cart != null)
            {
                cart.ListP.Clear();
            }
            Session["CartSession"] = cart;
            return View("Cart"); // nên thay thanh view thanh toan thang cong
        }


        public ActionResult Cart()
        {
            ViewBag.brandN = dbcontext.Database.SqlQuery<BrandSho>("select *from BrandShoes").ToList();
            ViewBag.inforWeb = dbcontext.MyWebShops.First();
            var cart = (AccountCartShop)Session["CartSession"];
            if (cart == null)
            {
                cart = new AccountCartShop();
            }
            return View(cart);
        }
        public ActionResult Collection()
        {
            ViewBag.brandN = dbcontext.Database.SqlQuery<BrandSho>("select *from BrandShoes").ToList();
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

            //if (Request.Files.Count > 0)
            //{
            //    var file = Request.Files[0];

            //    if (file != null && file.ContentLength > 0)
            //    {
            //        var fileName = Path.GetFileName(file.FileName);
            //        var path = Path.Combine(Server.MapPath("~/Images/"), fileName);
            //        file.SaveAs(path);
            //    }
            //}



            if (pass.Equals(repass))
                addAcc(user,pass);
            return View("Index");
        }
        public ActionResult FileUpload(HttpPostedFileBase file)
        {
            if (file != null)
            {
                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(
                                       Server.MapPath("~/images/profile"), pic);
                // file is uploaded
                file.SaveAs(path);

                // save the image path path to the database or you can send image 
                // directly to database
                // in-case if you want to store byte[] ie. for DB
                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                }

            }
            // after successfully uploading redirect the user
            return RedirectToAction("actionname", "controller name");
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

        [HttpPost]
        public ActionResult CheckLogin()
        {
            string user = Request["username"].ToString();
            string pass = Request["pass"].ToString();
            var acc = dbcontext.AccountShops.Find(user);
            if (acc != null && acc.pass.Equals(pass))
            {
                // kiểm tra acc là admin hay và người dùng
                //if (acc.tenQ == "Admin")
                //    return RedirectToAction("Index","Admin");
                //else
                    return View("Index");
            }
            else
            {
                return View("Login");
            }
        }
        

    }
}