using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BanGiay.Models;

namespace BanGiay.Controllers
{
    public class CartController : Controller
    {
        ShopShoesDB db = new ShopShoesDB();
        // GET: Cart


        public ActionResult AddToCart(string id , string returnURL)
        {
            Product p = db.Products.Find(id); // lay sap ra

            // lay ra cart  hinh tai
            var cart = (AccountCartShop)Session["CartSession"];
            if (cart != null)
            {
                // chi tiet sp trong cart
                DeltailCartShop pC= new DeltailCartShop();
                
                // kiểm tra xem sảm phẩm đã có trong cart
                foreach(DeltailCartShop item in cart.ListP)
                {
                    if(item.IDProduct.Equals(p.IDProduct))
                    {
                        item.soluong += 1;
                        item.timeAdd = DateTime.Now;
                    }
                    else
                    {
                        pC.IDCart = cart.IDCart;
                        pC.IDProduct = p.IDProduct;
                        pC.img1 = p.img1;
                        pC.realCost = p.realCost;
                        pC.nameP = p.nameP;
                        pC.soluong = 1;
                        pC.timeAdd = DateTime.Now;
                    }
                }
                cart.ListP.Add(pC);
                //Gán vào session
                Session["CartSession"] = cart;
            }
            else
            {
                //tạo mới đối tượng cart item
                cart = new AccountCartShop();
                DeltailCartShop pC = new DeltailCartShop();
                pC.IDCart = cart.IDCart;
                pC.IDProduct = p.IDProduct;
                pC.img1 = p.img1;
                pC.realCost = p.realCost;
                pC.nameP = p.nameP;
                pC.soluong = 1;
                pC.timeAdd = DateTime.Now;
                cart.ListP = new List<DeltailCartShop>();
                cart.ListP.Add(pC);
                //Gán vào session
                Session["CartSession"] = cart;
            }

            if (string.IsNullOrEmpty(returnURL))
            {
                return RedirectToAction("Index");
            }
            return Redirect(returnURL);
        }

        public ActionResult DeleteProCart (string id)
        {
            var product = db.Products.Find(id);

            var cart = (AccountCartShop)Session["CartSession"];

            if (cart != null)
            {
                foreach(DeltailCartShop it in cart.ListP)
                {
                    if(it.IDProduct.Equals(product.IDProduct))
                    {
                        cart.ListP.Remove(it);
                        break;
                    }
                }
                //Gán vào session
                Session["CartSession"] = cart;
            }
            return RedirectToAction("Cart", "HomePage");
        }

        public ActionResult DeleletAllCart()
        {
            var cart = (AccountCartShop)Session["CartSession"];
            if (cart != null)
            {
                cart.ListP.Clear();
                //Gán vào session
                Session["CartSession"] = cart;
            }
            return RedirectToAction("Cart", "HomePage");
        }

        public ActionResult UpdateCart()
        { 
            var cart = (AccountCartShop)Session["CartSession"];
            if (cart != null)
            {
                string[] masp = Request.Form.GetValues("masp");
                string[] sl = Request.Form.GetValues("sl");
                for (int i = 0; i< masp.Count() ; i++)
                {
                    foreach(DeltailCartShop it in cart.ListP)
                    {
                        if(it.IDProduct.Equals(masp[i]))
                        {
                            it.soluong = (Int32.Parse(sl[i]));
                        }
                    }
                }

                Session["CartSession"] = cart;
            }

            return RedirectToAction("Cart","HomePage");

        }

    }
}