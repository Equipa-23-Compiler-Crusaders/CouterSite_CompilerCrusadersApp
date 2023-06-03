using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.NetworkInformation;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Interactions;
using System.Collections.ObjectModel;

namespace compilercrusadersteste
{
    class Model
    {

        public delegate void Model_event(object sender, EventArgs e);
        public event Model_event Pesquisa_Concluida;
        public event Model_event Ficheiro_Gerado;
        private View view;
        private string resultados;
        public Model(View v)
        {
            view = v;
        }

        //para nao usar ThreadSleep por ser má pratica implementei estas funcoes para esperarem que o elemento exista ou é clickavel
        public static Func<IWebDriver, IWebElement> ElementIsClickable(IWebElement element)
        {
            return driver =>
            {
                try
                {
                    return (element.Displayed && element.Enabled) ? element : null;
                }
                catch (Exception)
                {
                    return null;
                }
            };
        }

        public static Func<IWebDriver, IWebElement> ElementExists(By locator)
        {
            return driver =>
            {
                try
                {
                    return driver.FindElement(locator);
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
            };
        }



        public void Pesquisa(string texto)  // recebe string e depois a string é dividida
        {

            string[] entradas = texto.Split(',');

            //inicializa o web driver para o chrome
            new DriverManager().SetUpDriver(new ChromeConfig());
            IWebDriver driver = new ChromeDriver();

            //abre google.com
            driver.Navigate().GoToUrl("https://www.google.com");

            //maximiza pagina
            driver.Manage().Window.Maximize();

            //ao abrir o Edge vai abrir uma pagina de cookies. Este excerto serve para aceitar as cookies automaticamente
            IWebElement cookiesButton = driver.FindElement(By.Id("L2AGLb"));
            cookiesButton.Click();

            //espera que a pagina abra, vou tirar estes thread sleeps todos 
            Thread.Sleep(500);

            //Procura a searchbox do google

            IWebElement searchBox = driver.FindElement(By.Name("q"));

            //Insere o input
            searchBox.SendKeys(entradas[0] + " em " + entradas[1]);

            //Carrega enter
            searchBox.SendKeys(OpenQA.Selenium.Keys.Enter);

            //espera que a pagina abra
            Thread.Sleep(2000);


            //TESTE PARA APENAS UM ELEMENTO. DEPOIS CRIAR UMA ILIST WEBELEMENTS PARA GUARDAR TUDO!! ->
            //Console.WriteLine("antes do find");

            //declarar js executor
            //IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            //// dar scrool down para o selenium ver os resultados
            //js.ExecuteScript("window.scrollBy(0,500)");

            //Carrega no botao que mostra todos os negocios
            IWebElement showAllButton = driver.FindElement(By.ClassName("jRKCUd"));
            showAllButton.Click();
            List<IWebElement> elements = driver.FindElements(By.CssSelector(".OSrXXb:not(.WaZi0e)")).ToList();


            //ignora os comentarios
            var elements2 = elements.Where(element => !element.Text.StartsWith("\""));

            List<IWebElement> businessNames = elements.Where(element => !string.IsNullOrEmpty(element.Text)).ToList();


            //lista de string endereços
            List<string> businessAddresses = new List<string>();

            //objeto wait para esperar por certos eventos na pagina
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            //para remover de businessNames os negocios que não conseguimos aceder pelo web scrapping e ambas as listas ficarem c o mesmo count
            List<int> toRemove = new List<int>();

            //ir buscar as moradas dos respetivos negocios. Não usei foreach pq ao usar foreach poderia dar duas listas businessNames e businessAddress de tamanho diferente
            //o que nos iria dar problemas
            for (int i = 0; i < businessNames.Count; i++)
            {

                try
                {
                    IWebElement name = businessNames[i];
                    wait.Until(ElementIsClickable(name));
                    name.Click();
                    //Este thread sleep serve para deixar o browser atualizar a pagina, senao todos os address serao iguais pois o browser n iria ter tempo de
                    //abrir a nova pagina no google, não consegui remove-lo e fazer o prog correr como esperado :(
                    Thread.Sleep(700);
                    IWebElement address = wait.Until(ElementExists(By.ClassName("LrzXr")));
                    businessAddresses.Add(address.Text);



                } catch(ElementNotInteractableException) {
                    toRemove.Add(i);
                    continue;
                }

            }

            //para debug
            Console.WriteLine("Count dos names: {0}\n Count dos addresses: {1}", businessNames.Count, businessAddresses.Count);

            //caso o for loop entre no catch, meter as listas do mesmo tamanho
            for (int i = toRemove.Count - 1; i >= 0; i--)
            {
                businessNames.RemoveAt(toRemove[i]);
            }

            //out dos resultados, para debug
            for (int i = 0; i < businessNames.Count; i++)
            {
                Console.WriteLine(businessNames[i].Text);
            }

            for(int j = 0; j < businessAddresses.Count; j++)
            {
                Console.WriteLine(businessAddresses[j]);  
            }


            Pesquisa_Concluida(this, EventArgs.Empty);



        }

        public void GerarFicheiroResultados()  // gerar ficheiro final
        {
            Console.WriteLine("Model: A criar um ficheiro ");
            string header = "Negocio,Morada,Telefone,Email";
            resultados = "teste,1,2,3";  // remover após implemtação do selenium

            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); // guarda na pasta "meus documentos"
            
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "output_.csv"), true))
            {
                outputFile.WriteLine(header);
                outputFile.WriteLine(resultados);
            }


            Ficheiro_Gerado(this, EventArgs.Empty);

            
        }



       
        // evento ficheiro gerado
    }
}
