using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BanGiay.Models;
using System.IO;
using BanGiay.Controllers;
namespace BanGiay.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin/Admin
        ShopShoesDB dbcontext = new ShopShoesDB();
        AccountShop acc = LoginController.account;
        static string curPage = "1";

        public ActionResult Index()
        {
            if(acc == null)
            {
                return RedirectToAction("Login", "Login", new { Area = "" });
            }
            if (acc.PhanQuyenS.Equals("ADMIN"))
            {
                int page = Int32.Parse(curPage);
                // lấy ra sô trang <10sp>
                ViewBag.countPage = (dbcontext.Products.ToList().Count()) / 10 + 1;
                ViewBag.product10 = dbcontext.Products.OrderBy(x => x.IDProduct).Skip((page - 1) * 10).Take(10).ToList();
                ViewBag.column = dbcontext.Database.SqlQuery<colName>("select * from colName where TABLE_NAME = 'Product'" +
                   "ORDER BY ORDINAL_POSITION").ToList();
                ViewBag.product = ViewBag.product10;
                ViewBag.acc = acc;
                return View();
            }
            else
                return RedirectToAction("Index", "HomePage", new { Area = "" });
          
        }
        public ActionResult AddProduct()
        {
            if (acc == null)
            {
                RedirectToAction("Login", "Login", new { Area = "" });
            }
            if (acc.PhanQuyenS.Equals("ADMIN"))
            {
                ViewBag.nameB = dbcontext.BrandShoes.ToList();
                return View();
            }
            else
                return RedirectToAction("Index", "HomePage",new {Area= "" });
                
        }
        [HttpPost]
        public ActionResult AddProductME()
        {
            string imgName = null;
            var file = Request.Files[0];
            if(Request.Files.Count >0)
            {
                var fileName = Path.GetFileName(file.FileName);
                imgName = fileName;
                var path = Path.Combine(Server.MapPath("~/Content/img/AllProduct/"), fileName);
                file.SaveAs(path);
            }
            Product p = new Product();
            p.nameP = Request["name"];
            p.IDBrand = Request["IDBrand"];
            p.cost = Request["price"];
            p.size = Convert.ToInt32(Request["size"]);
            p.descriptionP = Request["description"];
            p.IDProduct = Request["ID"];
            p.img1 = imgName;
           
            if(dbcontext.Products.Find(p.IDProduct)==null)
            {
                dbcontext.Products.Attach(p);
                dbcontext.Products.Add(p);
            }
            dbcontext.SaveChanges();
            curPage = ((dbcontext.Products.ToList().Count()) / 10 + 1).ToString(); // trỏ về trang cuối
            ViewBag.countPage = (dbcontext.Products.ToList().Count()) / 10 + 1; // lấy ra số trang
            int page = Int32.Parse(curPage); // gán trang = trang hiện tại
            ViewBag.product10 = dbcontext.Products.OrderBy(x => x.IDProduct).Skip((page - 1) * 10).Take(10).ToList(); // lấy tra sp ơ trang hiển tại
            ViewBag.column = dbcontext.Database.SqlQuery<colName>("select * from colName where TABLE_NAME = 'Product'" +
               "ORDER BY ORDINAL_POSITION").ToList();
            ViewBag.product = ViewBag.product10;

            return View("Index");
        }
        public ActionResult EditProduct(string id)
        {
            if (acc == null)
            {
                RedirectToAction("Login", "Login", new { Area = "" });
            }
            if (acc.PhanQuyenS.Equals("ADMIN"))
            {
                var model = dbcontext.Products.Find(id);

                ViewBag.nameB = dbcontext.BrandShoes.ToList();
                //ViewBag.product = dbcontext.Database.SqlQuery<Product>("select * from Product").ToList();

                return View(model);
            }
            else
                return RedirectToAction("Index", "HomePage", new { Area = "" });
           
        }
        public ActionResult DeleteProduct(string id)

        {
            int page = Int32.Parse(curPage);
            // lấy ra sô trang <10sp>
            ViewBag.countPage = (dbcontext.Products.ToList().Count()) / 10 + 1;
            ViewBag.product10 = dbcontext.Products.OrderBy(x => x.IDProduct).Skip((page - 1) * 10).Take(10).ToList();
            ViewBag.column = dbcontext.Database.SqlQuery<colName>("select * from colName where TABLE_NAME = 'Product'" +
               "ORDER BY ORDINAL_POSITION").ToList();
           
            ViewBag.product = ViewBag.product10;
            Product p = dbcontext.Products.Find(id);
            if (p != null)
            {
                
                dbcontext.Products.Remove(p);
            }
            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult EditProductME(string id)
        {
            string imgName = null;
            var file = Request.Files[0];
            if (Request.Files.Count > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                imgName = fileName;
                var path = Path.Combine(Server.MapPath("~/Content/img/AllProduct/"), fileName);
                file.SaveAs(path);
            }
            int page = Int32.Parse(curPage);
            // lấy ra sô trang <10sp>
            ViewBag.countPage = (dbcontext.Products.ToList().Count()) / 10 + 1;
            ViewBag.product10 = dbcontext.Products.OrderBy(x => x.IDProduct).Skip((page - 1) * 10).Take(10).ToList();
            ViewBag.column = dbcontext.Database.SqlQuery<colName>("select * from colName where TABLE_NAME = 'Product'" +
               "ORDER BY ORDINAL_POSITION").ToList();
            ViewBag.product = ViewBag.product10;
            ViewBag.nameB = dbcontext.BrandShoes.ToList();
            Product p = dbcontext.Products.Find(id);
            p.nameP = Request["name"];
            p.IDBrand = Request["IDBrand"];
            p.cost = Request["price"];
            p.img1 = imgName;
            p.size = Convert.ToInt32(Request["size"]);
            p.descriptionP = Request["description"];
            //p.IDProduct = Request["ID"];

            if (dbcontext.BrandShoes.Find(p.IDBrand) != null)
            {
             
                dbcontext.SaveChanges();
            }
           


            return RedirectToAction("Index");
        }
        public ActionResult ViewProduct(string id)
        {
            if (acc == null)
            {
                RedirectToAction("Login", "Login", new { Area = "" });
            }
            if (acc.PhanQuyenS.Equals("ADMIN"))
            {
                var model = dbcontext.Products.Find(id);
                return View(model);
            }
            else
                return RedirectToAction("Index", "HomePage", new { Area = "" });
            
        }
        [HttpPost]
        public ActionResult chagePage(string pageS)
        {
            int page = Int32.Parse(pageS);
            curPage = pageS; // luu trang hien tại
            // lấy ra sô trang <10sp>
            ViewBag.countPage = (dbcontext.Products.ToList().Count()) / 10 + 1;
            ViewBag.product10 = dbcontext.Products.OrderBy(x => x.IDProduct).Skip((page - 1) * 10).Take(10).ToList();
            ViewBag.product = ViewBag.product10;
            ViewBag.column = dbcontext.Database.SqlQuery<colName>("select * from colName where TABLE_NAME = 'Product'" +
             "ORDER BY ORDINAL_POSITION").ToList();

            return PartialView("admin_viewproduct");
        }
        
        public ActionResult AccountView()
        {
            if (acc == null)
            {
                return RedirectToAction("Login", "Login", new { Area = "" });
            }
            if (acc.PhanQuyenS.Equals("ADMIN"))
            {
                ViewBag.allAcc = dbcontext.AccountShops.ToList();
            ViewBag.role = dbcontext.PhanQuyenShops.ToList();
            return View();
            }
            else
                return RedirectToAction("Index", "HomePage", new { Area = "" });
        }
    }
}