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
using OpenQA.Selenium.Edge;

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

        public void Pesquisa(string texto)  // recebe string e depois a string é dividida
        {
            
            string[] entradas = texto.Split(',');

            Console.WriteLine(entradas[0]);  //  negocio
            Console.WriteLine(entradas[1]);  // localização

            //Implementar no prox sprint
            IWebDriver driver = new EdgeDriver(); //driver para edge, tb pode ser chrome com ChromeDriver

            driver.Navigate().GoToUrl("https://www.google.com");

            //IWebElement searchBox = driver.FindElement(By.Name("q"));
            //searchBox.SendKeys("{entradas[0]} em {entradas[1]}");
            //searchBox.SendKeys(OpenQA.Selenium.Keys.Enter);

            //IWebElement businessType = driver.FindElement(By.ClassName("SPZz6b"));
            //Console.WriteLine("Nome do restaurante: {0}", businessType.Text);

            //// Vai buscar o endereço do restaurante
            //IWebElement businessCity = driver.FindElement(By.ClassName("LrzXr");


            // colocar Try "ao abrir a pagina"
            /// Coisas a acontecer
            /// 
            /// conclui e publica informação

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
