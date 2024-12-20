﻿using System.Collections.Generic;
using System.Linq;
using TheShop.Models;

namespace TheShop.Repository
{
    public class DatabaseDriver : IDatabaseDriver
    {
        private List<Article> _articles;

        public DatabaseDriver() 
        {
            _articles = new List<Article>();
        }
        
        public Article GetById(int id)
        {
            return _articles.Single(x => x.ID == id);
        }

        public void Save(Article article)
        {
            _articles.Add(article);
        }
    }
}
