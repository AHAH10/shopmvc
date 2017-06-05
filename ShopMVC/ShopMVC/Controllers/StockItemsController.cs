using ShopMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopMVC.Controllers
{
    public class StockItemsController : Controller
    {
          StockItemsRepository repo = null;

        public StockItemsController()
        {
            repo = new StockItemsRepository();
        }

        //Edit
        public ActionResult Edit(int id)
        {
            return View(repo.GetStockItemByArticleNumber(id));  // ska returnera en Itemlista från Repository
        }
        [HttpPost]
        public ActionResult Edit(StockItem i)
        {
            repo.EditStockItem(i);

            return RedirectToAction("Index");
        }

        //Details
        public ActionResult Details(int id)
        {
            return View(repo.DetailStockItem(id));

            //return RedirectToAction("Index");
        }

        //Delete  
        public ActionResult Delete(int id)
        {
            repo.DeleteStockItem(id);

            return RedirectToAction("Index");
        }

        // Search 

        [HttpGet]
        public ActionResult Search(int id)
        {
            return View(repo.GetStockItemByArticleNumber(id));  
        }
        [HttpPost]
        public ActionResult Search(StockItem i)
        {
            repo.SearchStockItem(i);

            return RedirectToAction("Index");
        }

        // Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();  // 
        }
        [HttpPost]
        public ActionResult Create(StockItem i)
        {
            repo.AddStockItem(i);

            return RedirectToAction("Index");
        }

        // Get: StockItems
          public ActionResult Index(string Search)
        {
            if (Search != null)
            {
                return View(repo.Search(Search));       
            }
            else 
            { 
              return View(repo.GetAllStockItems());
            }
        }
        public ActionResult Detailes(int Id)
        {
            return View(repo.GetAllStockItems());
     }
   }
}