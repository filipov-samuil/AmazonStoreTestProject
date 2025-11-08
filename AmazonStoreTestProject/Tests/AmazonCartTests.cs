using AmazonStoreTestProject.Pages;
using AmazonStoreTestProject.Products;

namespace AmazonStoreTestProject.Tests
{
    public class AmazonCartTests : TestBase
    {
        [Test]
        public void AddBookToCart()
        {
            var AmazonHomePage = new HomePage(driver);
            var resultsPage = new SearchResultsPage(driver);
            var productPage = new ProductPage(driver);
            var cartPage = new CartPage(driver);
            var book = Books.FinalEmpireMistbornBookOne;

            AmazonHomePage.OpenHomePage();
            AmazonHomePage.SearchForItemInSearchBox(book.Name);
            resultsPage.ClickProductByName(book.Name);
            productPage.SelectHardcover();
            productPage.AddProductToCart();

            Assert.IsTrue(driver.PageSource.Contains("Added to Cart"), "Book was not added to cart.");

            cartPage.ClickOnCartButton();

            Assert.IsTrue(cartPage.IsItemInCart(book.CartTitle), "Book was not found in the cart.");
        }
    }
}
