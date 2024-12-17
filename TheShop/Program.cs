using System;
using System.Collections.Generic;
using TheShop.Repository;
using TheShop.Services;
using TheShop.Utils;

/*** 
This is a refactoring exercise in C#. 
Imagine that this is a part of larger enterprise system and you are given this code to do code review before this goes to production. 
Please apply every principle and practice that you would in real situation so that this solution satisfies all of the coding standards.
Code is really simple. There's a ShopService that has the ability to display, order and sell the items. 
Client code (Program.cs) orders and sells items and also displays those that he has been able to find and those that he hasn't been able to find in the Shop.
When ordering an article, Shop needs to find the article amongst the given suppliers 
(It can be any external service) where they have it in stock 
and where the price is not more expensive than the maximum price a client is ready to pay for.
If naming and structure doesn't suit you, fell free to change them.
Introducing tests to the existing code is more than welcome.
Once you're finished with coding send us your code via email or URL to your GitHub/Bitbucket repository. Please include your source control history.
Should you have any questions or feedback for the assignment, feel free to contact us.
*/

namespace TheShop
{
	internal class Program
	{
		private static void Main(string[] args)
		{
            // NOTE: I did not change any of the logic in this code, as I understood this to be purely a
			// refactoring task. Therefore, the logic remains the same, even though some parts may
			// not make complete sense. My focus was on reorganizing the code into their respective
			// C# units, aiming to adhere to SOLID principles and best practices.
            //

            IEnumerable<ISupplier> list = new List<ISupplier>()
			{
				new Supplier("Supplier1", 458),
				new Supplier("Supplier2", 459),
				new Supplier("Supplier3", 460),
			};
			ILogger logger = new Logger();
			IDatabaseDriver databaseDriver = new DatabaseDriver();

			IShopService shopService = new ShopService(list, logger, databaseDriver);

			try
			{
				shopService.OrderAndSellArticle(1, 600, 10);
            }
            catch (Exception ex)
			{
				Console.WriteLine(ex);
			}

			try
			{
				var article = shopService.GetArticleByID(1);
				Console.WriteLine("Found article with ID: " + article.ID);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Article not found: " + ex);
			}

			try
			{
				var article = shopService.GetArticleByID(12);
				Console.WriteLine("Found article with ID: " + article.ID);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Article not found: " + ex);
			}

			Console.ReadKey();
		}
	}
}