using ShopMVC.DataAccess;
using ShopMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace ShopMVC.Controllers
{
    class StockItemsRepository
    {
        int id;
        int Details;
        StoreContext context = new StoreContext();

        public IEnumerable<StockItem> GetAllStockItems()
        {
            return context.Items.ToList();
        }

        public StockItem GetStockItemByArticleNumber(int ArticleNumber)
        {
            return context.Items.SingleOrDefault(stockItem => stockItem.ArticleNumber == ArticleNumber);
        }

        //Delete
        public void DeleteStockItem(int id)
        {
                context.Items.Remove(context.Items.Where(item=>item.ArticleNumber==id).FirstOrDefault());
            context.SaveChanges();
        }

        // Search specific ArticleNumber 

        public IEnumerable<StockItem> Search(string Search)
        {
            if (Search.All(char.IsDigit))
            {
                int articleNumber = Convert.ToInt32(Search);
                var query = from item in GetAllStockItems()
                            where item.ArticleNumber == articleNumber
                            select item;
                return query;
            }
            return null;
        }
      
        //Details
        public void GetAllStockItems(int id)
        {
            context.Items.Find(context.Items.Where(item => item.ArticleNumber == id).FirstOrDefault());
            context.SaveChanges();
        }

        //Edit
        public void EditStockItem(StockItem i)
        {
            context.Entry(i).State = EntityState.Modified;
            context.SaveChanges();
        }

        //Add
        public void AddStockItem(StockItem i)
        {
            context.Items.Add(i);
            context.SaveChanges();
        }

        internal void AddStockItems(StockItems i)
        {
            throw new NotImplementedException();
        }

        internal void SearchStockItem(StockItem i)
        {
            throw new NotImplementedException();
        }

        internal void DetailsStockItem(StockItem i)
        {
            throw new NotImplementedException();
        }

        public StockItem DetailStockItem(int id)
        {
            return context.Items.FirstOrDefault(item => item.ArticleNumber == id);
           
        }
    }
}
