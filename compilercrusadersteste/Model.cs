using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.NetworkInformation;

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
