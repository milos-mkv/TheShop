using TheShop.Models;

namespace TheShop.Services
{
    public interface IShopService
    {
        Article GetArticleByID(int id);

        void OrderAndSellArticle(int id, int maxExpectedPrice, int buyerId);
    }
}
