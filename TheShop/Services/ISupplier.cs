using TheShop.Models;

namespace TheShop.Services
{
    public interface ISupplier
    {
        bool ArticleInInventory(int id);
        Article GetArticle(int id);
    }
}
