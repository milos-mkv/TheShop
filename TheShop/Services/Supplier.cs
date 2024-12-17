using TheShop.Models;
using TheShop.Services;

namespace TheShop
{
    public class Supplier : ISupplier
    {
        private readonly string _name;
        private readonly int _price;

        public Supplier(string name, int price)
        {
            _name = name;
            _price = price;
        }

        public bool ArticleInInventory(int id)
        {
            return true;
        }

        public Article GetArticle(int id)
        {
            return new Article()
            {
                ID = id,
                Name = "Article from " + _name,
                Price = _price
            };
        }
    }
}
