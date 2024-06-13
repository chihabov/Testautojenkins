using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace TestProject1
{
    [TestFixture]
    public class SendForm
    {
        public IWebDriver driver;
        IJavaScriptExecutor js;
        ReadData read=new ReadData();
        List<Client> clients;
        public Client client;


        [SetUp]
        public void Debut()
        {
            // Chemin vers le dossier contenant chromedriver.exe
            driver = new ChromeDriver(@"C:\\selenuim\\chromedriver-win64\\chromedriver-win64\\chromedriver.exe");
            Console.WriteLine("je suis dans la partie setup");
            js = (IJavaScriptExecutor)driver;
             
        }

        [Test]
        public void Envoyezleforumpourlefrancais()
        {
            clients = read.ReadDataFromJson();
            driver.Navigate().GoToUrl("https://sendform.nicepage.io/?version=13efcba7-1a49-45a5-9967-c2da8ebdd189&uid=f7bd60f0-34c8-40e3-8e2c-06cc19fcb730");
            //driver.Manage().Window.Size = new System.Drawing.Size(532, 408);
            //driver.Manage().Window.Maximize();

            client = clients[0];

            //Choisir le genre  
            driver.FindElement(By.Id("field-aa6c")).Click();


            // Attendre que le champ de sélection du préfixe soit visible
            // Création de l'objet WebDriverWait pour définir une attente 
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            // Attendre jusqu'à ce que l'élément avec l'ID "prefix_4" soit visible sur la page
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("select-9648")));

            // Sélectionne le pays de naissance
            SelectElement selectP = new SelectElement(driver.FindElement(By.Id("select-9648")));
            selectP.SelectByValue("IT");


            //ecrire le mail 
            driver.FindElement(By.Id("email-c6a3")).SendKeys(client.Email);


            //ecrire le nom 
            driver.FindElement(By.Id("name-c6a3")).SendKeys(client.Name);

            //ecrire le phone 
            driver.FindElement(By.Id("phone-84d9")).SendKeys(client.Phone);

            //ecrire l'adresse 
            driver.FindElement(By.Id("address-be2d")).SendKeys(client.Address);
            //driver.FindElement(By.Id("address-be2d")).SendKeys($"{client.Address.Num} {client.Address.Rue} {client.Address.CodePostal} {client.Address.Ville}");


            //ecrire message 
            driver.FindElement(By.Id("message-c6a3")).SendKeys(client.Message);


            // Trouver l'élément select
            IWebElement genreElement = driver.FindElement(By.Id("field-aa6c"));

            //////////////////////////////////// Obtenir la valeur sélectionnée
            string selectedValGenre = genreElement.GetAttribute("value");

            Console.WriteLine("Genre sélectionné : " + selectedValGenre);


            // Trouver la case à cocher
            IWebElement checkbox = driver.FindElement(By.Id("select-9648"));

            // Vérifier si la case est sélectionnée
            bool isSelected = checkbox.Selected;

            ////////////////////////////////// Obtenir la valeur de la case à cocher
            string selectedValPays = checkbox.GetAttribute("value");

            Console.WriteLine("La case est sélectionnée : " + isSelected);
            Console.WriteLine("Valeur de la case à cocher : " + selectedValPays);


            if (selectedValGenre == "women" && selectedValPays == "IT")
            {
                //Selectionner product 

                // Attendre que le champ de sélection du préfixe soit visible
                // Création de l'objet WebDriverWait pour définir une attente 
                WebDriverWait waitt = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

                // Attendre jusqu'à ce que l'élément avec l'ID "prefix_4" soit visible sur la page
                waitt.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("select-c283")));

                // Sélectionne le PRODUCT
                SelectElement selectt = new SelectElement(driver.FindElement(By.Id("select-c283")));
                selectt.SelectByText("Vélo");

                //Choisir loisir  
                driver.FindElement(By.Id("checkbox-1848")).Click();

            }
            else
            {
                // Sélectionne le produit Vélo
                SelectElement selectProduct = new SelectElement(driver.FindElement(By.Id("select-c283")));
                selectProduct.SelectByText("Moto");

                // Choisir loisir Littérature
                driver.FindElement(By.Id("checkbox-3250")).Click(); 
            }



        }


        [Test]
              public void Envoyezleforumpourlespagnole()
               {
                   clients = read.ReadDataFromJson();
                   driver.Navigate().GoToUrl("https://sendform.nicepage.io/?version=13efcba7-1a49-45a5-9967-c2da8ebdd189&uid=f7bd60f0-34c8-40e3-8e2c-06cc19fcb730");
                   //driver.Manage().Window.Size = new System.Drawing.Size(532, 408);
                   //driver.Manage().Window.Maximize();


                   //Choisir le genre  
                   driver.FindElement(By.Id("field-aa6c")).Click();

                client = clients[1];
            // Attendre que le champ de sélection du préfixe soit visible
            // Création de l'objet WebDriverWait pour définir une attente 
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

                   // Attendre jusqu'à ce que l'élément avec l'ID "prefix_4" soit visible sur la page
                   wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("select-9648")));
            SelectElement selectPP = new SelectElement(driver.FindElement(By.Id("select-9648")));
            selectPP.SelectByText("Espagne");

            // Sélectionne le pays de naissance
            //SelectElement selectt = new SelectElement(driver.FindElement(By.Id("select-9648")));
            //selectt.SelectByText(clients[1].Paysdenaissance);


            //ecrire le mail 
            driver.FindElement(By.Id("email-c6a3")).SendKeys(client.Email);


            //ecrire le nom 
            driver.FindElement(By.Id("name-c6a3")).SendKeys(client.Name);

            //ecrire le phone 
            driver.FindElement(By.Id("phone-84d9")).SendKeys(client.Phone);

            //ecrire l'adresse 
            driver.FindElement(By.Id("address-be2d")).SendKeys(client.Address);

            //ecrire message 
            driver.FindElement(By.Id("message-c6a3")).SendKeys(client.Message);

            // Trouver l'élément select
            IWebElement genreElement = driver.FindElement(By.Id("field-aa6c"));

            //////////////////////////////////// Obtenir la valeur sélectionnée
            string selectedValGenre = genreElement.GetAttribute("value");

            Console.WriteLine("Genre sélectionné : " + selectedValGenre);


            // Trouver la case à cocher
            IWebElement checkbox = driver.FindElement(By.Id("select-9648"));

            // Vérifier si la case est sélectionnée
            bool isSelected = checkbox.Selected;

            ////////////////////////////////// Obtenir la valeur de la case à cocher
            string selectedValPays = checkbox.GetAttribute("value");

            Console.WriteLine("La case est sélectionnée : " + isSelected);
            Console.WriteLine("Valeur de la case à cocher : " + selectedValPays);

            if (selectedValGenre == "man" && selectedValPays == "FR")
            {
                //Selectionner product 

                // Attendre que le champ de sélection du préfixe soit visible
                // Création de l'objet WebDriverWait pour définir une attente 
                WebDriverWait waitt = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

                // Attendre jusqu'à ce que l'élément avec l'ID "prefix_4" soit visible sur la page
                waitt.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("select-c283")));

                // Sélectionne le PRODUCT
                SelectElement selectt = new SelectElement(driver.FindElement(By.Id("select-c283")));
                selectt.SelectByText("Moto");

                //Choisir loisir  
                driver.FindElement(By.Id("checkbox-1848")).Click();

            }
            else
            {
                // Sélectionne le produit Vélo
                SelectElement selectProduct = new SelectElement(driver.FindElement(By.Id("select-c283")));
                selectProduct.SelectByText("Vélo");

                // Choisir loisir Littérature
                driver.FindElement(By.Id("checkbox-1848")).Click(); // Remplacez par l'ID correct pour le loisir Littérature
            }



            /*/Selectionner product 

            // Attendre que le champ de sélection du préfixe soit visible
            // Création de l'objet WebDriverWait pour définir une attente 
            WebDriverWait waitt = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

                   // Attendre jusqu'à ce que l'élément avec l'ID "prefix_4" soit visible sur la page
                   waitt.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("select-c283")));

                   // Sélectionne le PRODCUT
                   SelectElement selectpp = new SelectElement(driver.FindElement(By.Id("select-c283")));
            selectpp.SelectByText(client.Product);

                   //Choisir loisir  
                   driver.FindElement(By.Id("checkbox-1848")).Click();*/



            // Fait défiler la page jusqu'à l'élément radio button
            //js.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(By.Id("label_input_7_1")));




            // Vérifie si le client a un guest et remplit les informations du guest

            // Fait défiler la page jusqu'à l'élément radio button
            //js.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(By.Id("label_input_22_1")));
            //driver.FindElement(By.Id("label_input_22_1")).Click(); // Sélectionne l'option "Yes" ou "No"





            //SelectElement select = new SelectElement(driver.FindElement(By.Id("prefix_4")));
            /*select.SelectByValue("Mr.");
            select.SelectByIndex(2);
            select.SelectByText("Mrs.");*/



            //Assert.AreEqual("Thank You!", driver.FindElement(By.XPath("//*[@id=\"stage\"]/div[1]/div/div/h1")).Text);


        }

        [TearDown]
        public void Fin()
        {
            driver.Quit();
            driver.Dispose();
            string reportFilePath = @"C:\path\to\report\test_report.txt";
           
            //Console.WriteLine("je suis dans la partie fin");
        }
    }
}
