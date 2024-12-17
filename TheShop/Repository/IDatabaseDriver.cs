using TheShop.Models;

namespace TheShop.Repository
{
    public interface IDatabaseDriver
    {
         Article GetById(int id);
         void Save(Article article);
    }
}
