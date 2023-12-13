using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Testinggg
{

    [TestClass]
    public class Inregistrare
    {
        private ChromeDriver driver;

        [TestInitialize]
        public void TestInitialize()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [TestMethod]
        public void Test_Inregistrare()
        {
            // var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            // Accesează pagina principală
            driver.Navigate().GoToUrl("https://anticariat-odin.ro/");

            // Caută și dă click pe butonul "Contul meu"
            IWebElement contulMeuButton = driver.FindElement(By.CssSelector(".icon-user"));
            contulMeuButton.Click();

            // Caută și dă click pe opțiunea "Inregistreaza-te"
            IWebElement registerButton = driver.FindElement(By.CssSelector("a.color-dark[href='https://anticariat-odin.ro/autentificare?create_account=1']"));
            registerButton.Click();

            // Completează câmpurile cu prenume, nume, email și parolă
            IWebElement numeInput = driver.FindElement(By.CssSelector("input.form-control[name='firstname']"));
            numeInput.SendKeys("Ancuta-Nicoleta");

            IWebElement numeFamilieInput = driver.FindElement(By.CssSelector("input.form-control[name='lastname']"));
            numeFamilieInput.SendKeys("Zamfiroiu");

            IWebElement emailInput = driver.FindElement(By.CssSelector("input.form-control[name='email']"));
            emailInput.SendKeys("anca567@gmail.com");

            IWebElement passwordInput = driver.FindElement(By.CssSelector("input.form-control[name='password']"));
            passwordInput.SendKeys("bbbbbbbb");

            //Bifarea checkbox-ului pentru acceptarea termenilor si conditiilor
            IWebElement checkbox = driver.FindElement(By.CssSelector("input[name='psgdpr'][type='checkbox']"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", checkbox);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", checkbox);


            // Dă clic pe butonul "Salvați"
            IWebElement saveButton = driver.FindElement(By.CssSelector("footer.form-footer button.btn.btn-outline-primary-2[data-link-action='save-customer']"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", saveButton);
            saveButton.Click();

            // Așteaptă până la afișarea paginii de autentificare completă
            Thread.Sleep(5000);
        }
        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }

    [TestClass]
    public class Cautare
    {
        private ChromeDriver driver;

        [TestInitialize]
        public void TestInitialize()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [TestMethod]
        public void Test_Cautare()
        {
            // var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            // Accesează pagina principală
            driver.Navigate().GoToUrl("https://anticariat-odin.ro/");

            // Caută și dă click pe butonul "Contul meu"
            IWebElement contulMeuButton = driver.FindElement(By.CssSelector(".icon-user"));
            contulMeuButton.Click();

            // Caută și dă click pe opțiunea "Autentificare"
            IWebElement registerButton = driver.FindElement(By.CssSelector("a.color-dark[href='https://anticariat-odin.ro/contul-meu']"));
            registerButton.Click();

            // Completeaza campul cu emailul corespunzator contului creat
            IWebElement emailInput = driver.FindElement(By.CssSelector("input[name='email']"));
            emailInput.SendKeys("ancuta.zamfiroiu06@gmail.com");

            // Completeaza campul cu parola corespunzatoare contului creat 
            IWebElement passwordInput = driver.FindElement(By.CssSelector("input[name='password']"));
            passwordInput.SendKeys("bbbbbbbb");

            // Autentificare
            IWebElement loginButton = driver.FindElement(By.CssSelector("button[data-link-action='sign-in']"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", loginButton);
            loginButton.Click();

            // Găsirea elementului pentru bara de căutare și introducerea textului "Ion Creangă"
            IWebElement searchInput = driver.FindElement(By.CssSelector("input[name='search_query']"));
            searchInput.SendKeys("Ion Creanga");

            // Apăsarea tastei Enter pentru a iniția căutarea
            searchInput.SendKeys(Keys.Enter);

            // Așteaptă până la afișarea paginii de autentificare completă
            Thread.Sleep(5000);
        }
        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }
   

    [TestClass]
    public class AddToCart
    {
        private ChromeDriver driver;

        [TestInitialize]
        public void TestInitialize()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [TestMethod]
        public void Cart()
        {
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://anticariat-odin.ro/");

            IWebElement account_button = driver.FindElement(By.CssSelector(".icon-user"));
            account_button.Click();

            IWebElement register_button = driver.FindElement(By.CssSelector("a.color-dark[href='https://anticariat-odin.ro/contul-meu']"));
            register_button.Click();

            IWebElement email_field = driver.FindElement(By.CssSelector("input[name='email']"));
            email_field.SendKeys("blanarur.rb@gmail.com");

            IWebElement password_field = driver.FindElement(By.CssSelector("input[name='password']"));
            password_field.SendKeys("bbb97bbb");

            IWebElement login_button = driver.FindElement(By.CssSelector("button[data-link-action='sign-in']"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", login_button);
            login_button.Click();

            By logoLinkLocator = By.CssSelector("a[href='https://anticariat-odin.ro/']");
            IWebElement logoLink = driver.FindElement(logoLinkLocator);
            logoLink.Click();

            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollBy(0, 500);");

            IWebElement bookLink = driver.FindElement(By.CssSelector("h3.product-title a.product-link"));
            bookLink.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            IWebElement addToCartButton = driver.FindElement(By.CssSelector("button.btn-default.add-to-cart.product-btn.cart-button[data-button-action='add-to-cart']"));
            addToCartButton.Click();

            IWebElement finalizeazaComandaButton = driver.FindElement(By.CssSelector("a.btn.btn-primary.customBtnTop"));
            finalizeazaComandaButton.Click();

            Thread.Sleep(5000);
        }
        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }

    [TestClass]
    public class Newsletter
    {
        private ChromeDriver driver;

        [TestInitialize]
        public void TestInitialize()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }
        [TestMethod]
        public void News()
        {
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://anticariat-odin.ro/");

            IWebElement account_button = driver.FindElement(By.CssSelector(".icon-user"));
            account_button.Click();

            IWebElement register_button = driver.FindElement(By.CssSelector("a.color-dark[href='https://anticariat-odin.ro/contul-meu']"));
            register_button.Click();

            IWebElement email_field = driver.FindElement(By.CssSelector("input[name='email']"));
            email_field.SendKeys("blanarur.rb@gmail.com");

            IWebElement password_field = driver.FindElement(By.CssSelector("input[name='password']"));
            password_field.SendKeys("bbb97bbb");

            IWebElement login_button = driver.FindElement(By.CssSelector("button[data-link-action='sign-in']"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", login_button);
            login_button.Click();

            By link = By.CssSelector("a[href='https://anticariat-odin.ro/']");
            IWebElement home = driver.FindElement(link);
            home.Click();

            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");

            IWebElement emailInput = driver.FindElement(By.CssSelector(".input-group.newsletter-input-group input[name='email']"));
            emailInput.SendKeys("blanarur.rb@gmail.com");

            IWebElement checkbox = driver.FindElement(By.CssSelector("input#psgdpr_consent_checkbox_21[name='psgdpr_consent_checkbox'][type='checkbox']"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", checkbox);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", checkbox);

            Thread.Sleep(1000);
            By news_button = By.XPath("//button[contains(., 'Abonează-te')]");
            IWebElement button = driver.FindElement(news_button);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", button);
            button.Click();

            Thread.Sleep(5000);
        }
        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }

    [TestClass]
    public class AddToCartTests
    {
        private ChromeDriver driver;

        [TestInitialize]
        public void TestInitialize()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [TestMethod]
        public void AddToCartAndVerify()
        {
            driver.Navigate().GoToUrl("https://anticariat-odin.ro/");

            // Adaugă cartea în coșul de cumpărături
            IWebElement bookLink = driver.FindElement(By.CssSelector("h3.product-title a.product-link"));

            bookLink.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            IWebElement addToCartButton = driver.FindElement(By.CssSelector("button.btn-default.add-to-cart.product-btn.cart-button[data-button-action='add-to-cart']"));
            addToCartButton.Click();

            // Navighează către coșul de cumpărături
            IWebElement finalizeazaComandaButton = driver.FindElement(By.CssSelector("a.btn.btn-primary.customBtnTop"));
            finalizeazaComandaButton.Click();

            Thread.Sleep(5000);

            // Revino la pagina principală
            driver.Navigate().GoToUrl("https://anticariat-odin.ro/");

            // Verifică dacă produsul se află în coșul de cumpărături
            bool isProductInCart = driver.PageSource.Contains("Die Jungend Tanzt - R. Krentzlin");

            // Asertare pentru verificarea rezultatului
            Assert.IsTrue(isProductInCart, "Produsul nu se află în coșul de cumpărături.");

            Thread.Sleep(2000);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }

    [TestClass]
    public class AddToCartTest
    {
        private ChromeDriver driver;


        [TestInitialize]
        public void TestInitialize()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [TestMethod]
        public void VerifyOutOfStockMessage()
        {
            try
            {
                driver.Navigate().GoToUrl("https://anticariat-odin.ro/");

                // Selecteaza "Promotii"
                IWebElement promotiiLink = driver.FindElement(By.CssSelector("a[href*='q=Discount-Produse+cu+discount']"));
                promotiiLink.Click();

                // mergi la pagina 40
                IReadOnlyCollection<IWebElement> paginationLinks = driver.FindElements(By.CssSelector("nav.pagination ul a"));

                // gaseste pag 40 dupa  index
                IWebElement page40Link = null;
                foreach (IWebElement link in paginationLinks)
                {
                    if (link.Text.Trim() == "40")
                    {
                        page40Link = link;
                        break;
                    }
                }

                page40Link.Click();

                Thread.Sleep(2000);

                By booksLocator = By.CssSelector("#js-product-list > div.products.row > div:nth-child(15) > div > div.product-preview.outofstockclass > div.customOutOfSTock");

                List<IWebElement> books = driver.FindElements(booksLocator).ToList();


                foreach (IWebElement book in books)
                {

                    Console.WriteLine(book.Text);
                }
            }
            catch (Exception ex)
            {
                Assert.Fail($"Testul a eșuat cu excepția: {ex.Message}");
            }
            Thread.Sleep(5000);
        }


        [TestCleanup]
        public void TestCleanup()
        {
            try
            {
                if (driver != null)
                {
                    driver.Quit();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Eroare la închiderea driverului: {ex.Message}");
            }
        }

    }
    [TestClass]
    public class ContulMeuButton
    {
        private ChromeDriver driver;

        [TestInitialize]
        public void TestInitialize()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [TestMethod]
        public void MenuStripContentContulMeu_Test()
        {
            // var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            // Accesează pagina principală
            driver.Navigate().GoToUrl("https://anticariat-odin.ro/");

            // Caută și dă click pe butonul "Contul meu"
            IWebElement contulMeuButton = driver.FindElement(By.CssSelector(".icon-user"));
            contulMeuButton.Click();

            // Caută și dă click pe opțiunea "Autentificare"
            IWebElement registerButton = driver.FindElement(By.CssSelector("a.color-dark[href='https://anticariat-odin.ro/contul-meu']"));
            registerButton.Click();

            // Completeaza campul cu emailul corespunzator contului creat
            IWebElement emailInput = driver.FindElement(By.CssSelector("input[name='email']"));
            emailInput.SendKeys("ancuta.zamfiroiu06@gmail.com");

            // Completeaza campul cu parola corespunzatoare contului creat 
            IWebElement passwordInput = driver.FindElement(By.CssSelector("input[name='password']"));
            passwordInput.SendKeys("bbbbbbbb");

            // Autentificare
            IWebElement loginButton = driver.FindElement(By.CssSelector("button[data-link-action='sign-in']"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", loginButton);
            loginButton.Click();

            IWebElement acasaButton = driver.FindElement(By.XPath("/html/body/div/header/div[1]/div/div[2]/div/div/div[2]/div/div/ul/li[1]/a"));
            acasaButton.Click();

            IWebElement contulMeuAcasa = driver.FindElement(By.XPath("//*[@id=\"header-middle\"]/div/div/div[3]/div/div[1]/a"));
            contulMeuAcasa.Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement tooltip = wait.Until(driver =>
            {
                try
                {
                    return driver.FindElement(By.XPath("//*[@id=\"login\"]/ul/li[1]/a"));
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
            });

            //Verify that the tooltip text is correct
            Assert.AreEqual("Contul meu", tooltip.Text);
            Thread.Sleep(5000);
        }
        public void TestCleanup()
        {
            driver.Quit();
        }
    }

    [TestClass]
    public class NumberOfProductsMenu
    {
        private ChromeDriver driver;

        [TestInitialize]
        public void TestInitialize()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [TestMethod]
        public void NumberOfProductsMenu_Test()
        {
            // var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            // var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            // Accesează pagina principală
            driver.Navigate().GoToUrl("https://anticariat-odin.ro/");

            // Caută și dă click pe butonul "Contul meu"
            IWebElement contulMeuButton = driver.FindElement(By.CssSelector(".icon-user"));
            contulMeuButton.Click();

            // Caută și dă click pe opțiunea "Autentificare"
            IWebElement registerButton = driver.FindElement(By.CssSelector("a.color-dark[href='https://anticariat-odin.ro/contul-meu']"));
            registerButton.Click();

            // Completeaza campul cu emailul corespunzator contului creat
            IWebElement emailInput = driver.FindElement(By.CssSelector("input[name='email']"));
            emailInput.SendKeys("ancuta.zamfiroiu06@gmail.com");

            // Completeaza campul cu parola corespunzatoare contului creat 
            IWebElement passwordInput = driver.FindElement(By.CssSelector("input[name='password']"));
            passwordInput.SendKeys("bbbbbbbb");

            // Autentificare
            IWebElement loginButton = driver.FindElement(By.CssSelector("button[data-link-action='sign-in']"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", loginButton);
            loginButton.Click();

            // Găsirea elementului pentru bara de căutare și introducerea textului "Ion Creangă"
            IWebElement searchInput = driver.FindElement(By.CssSelector("input[name='search_query']"));
            searchInput.SendKeys("Blandiana");

            // Apăsarea tastei Enter pentru a iniția căutarea
            searchInput.SendKeys(Keys.Enter);

            IWebElement Afiseaza = driver.FindElement(By.CssSelector("#js-product-list-top > div > div.col-12.col-sm-12.col-md-6.col-lg-6.col-pagination.text-left.customLeft > div > label.form-control-label.sort-label.customAscuns_Mobile"));

            IWebElement noProduse = driver.FindElement(By.CssSelector("#js-product-list-top > div > div.col-12.col-sm-12.col-md-6.col-lg-6.col-pagination.text-left.customLeft > div > div > a"));
            noProduse.Click();

            IWebElement noProduse1 = driver.FindElement(By.CssSelector("#js-product-list-top > div > div.col-12.col-sm-12.col-md-6.col-lg-6.col-pagination.text-left.customLeft > div > div > div > a:nth-child(2)"));
            noProduse1.Click();

            string actualURL = "https://anticariat-odin.ro/cautare";
            string expectedURL = "https://anticariat-odin.ro/cautare?controller=search&orderby=position&orderway=desc&search_query=Blandiana&submit_search=";
            Assert.AreEqual(expectedURL, actualURL);
        }
        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }
}
