using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;


namespace Testes
{
    [TestClass]
    public class MeuTeste
    {

        private IWebDriver driver;

        [TestInitialize]
        public void TestInit()
        {
            driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            driver.Navigate().GoToUrl("http://projetointegrador2015.azurewebsites.net");
        }

        [TestCleanup]
        public void testCleanup()
        {
            driver.Quit();
        }

        [TestMethod]
        public void Novo_Aluno()
        {
            //Entra na pagina de aluno
            driver.FindElement(By.CssSelector("a[href*='/Aluno']")).Click(); 
            //Clica no botao novo
            driver.FindElement(By.XPath("//*[@id='Novo']")).Click();
            //preenche o campo nome
            IWebElement Nome = driver.FindElement(By.Id("Nome"));
            Nome.SendKeys("Ronaldo");
            //preenche o campo CPF
            IWebElement CPF = driver.FindElement(By.Id("CPF"));
            CPF.SendKeys("12345678901");
            //preenche o campo nome
            IWebElement Matricula = driver.FindElement(By.Id("Matricula"));
            Matricula.SendKeys("12345678");
            Matricula.SendKeys(Keys.Enter);

            string lista = driver.FindElement(By.Id("Lista")).Text;
            Assert.IsTrue(lista.Contains("Ronaldo"));
        }

        [TestMethod]
        public void Editar_Aluno()
        {

        }

        [TestMethod]
        public void Pesquisar_Resultado()
        {
            
            IWebElement searchInput = driver.FindElement(By.Id("searchInput"));
            searchInput.SendKeys("Ronaldo");
            searchInput.SendKeys(Keys.Enter);
            string firstHeading = driver.FindElement(By.Id("firstHeading")).Text;
            Assert.AreEqual("Ronaldo", firstHeading);
        }

        [TestMethod]
        public void Pesquisar_Sem_Resultado()
        {
            IWebElement searchInput = driver.FindElement(By.Id("searchInput"));
            searchInput.SendKeys("asdnjhj");
            searchInput.SendKeys(Keys.Enter);
            string createLink = driver.FindElement(By.ClassName("mw-search-nonefound")).Text;
            Assert.IsTrue(createLink.Contains("A pesquisa não produziu resultados"));
        }

    }
}
