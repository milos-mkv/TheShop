using System;
using System.Collections.Generic;
using System.Linq;
using TheShop.Utils;
using TheShop.Repository;
using TheShop.Models;

namespace TheShop.Services
{
    public class ShopService : IShopService
    {
        private readonly IEnumerable<ISupplier> _suppliers;
        private readonly ILogger _logger;
        private readonly IDatabaseDriver _databaseDriver;

        public ShopService(IEnumerable<ISupplier> suppliers, ILogger logger, IDatabaseDriver _databseDriver) 
        { 
            _suppliers = suppliers;
            _logger = logger;
            _databaseDriver = _databseDriver;
        }

        public Article GetArticleByID(int id)
        {
            return _databaseDriver.GetById(id);
        }

        public void OrderAndSellArticle(int id, int maxExpectedPrice, int buyerId)
        {
            var article = _suppliers
                .Where(s => s.ArticleInInventory(id))
                .Select(s => s.GetArticle(id))
                .FirstOrDefault(a => a.Price <= maxExpectedPrice);

            if (article == null)
            {
                throw new Exception("Could not order article!");
            }

            _logger.Debug("Trying to sell article with id=" + id);

            article.IsSold = true;
            article.SoldDate = DateTime.Now;
            article.BuyerUserId = buyerId;

            try
            {
                _databaseDriver.Save(article);
                _logger.Info("Article with id=" + id + " is sold.");
            }
            catch (Exception)
            {
                _logger.Error("Could not save article with id=" + id);
                throw new Exception("Could not save article with id");
            }
        }
    }
}
