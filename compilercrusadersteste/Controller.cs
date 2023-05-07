using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace compilercrusadersteste
{
    class Controller
    {
        Model model;
        View view;

        

        public Controller()
        {
            view = new View(model);
            model = new Model(view);

            view.BotãoPressionado += CliqueEmPesquisar;
            model.Pesquisa_Concluida += GerarResultados;
            model.Ficheiro_Gerado += MensagemFinal;
            
        }
        public void IniciarPrograma()
        {
            view.AtivarInterface();
        }

        public void CliqueEmPesquisar(object origem, EventArgs e)   //subscriver
        {
            string texto;
            Console.WriteLine("Controller S: model começa a pesquisa");
            texto = view.Texto();
            model.Pesquisa(texto);  

        }
     
        public void GerarResultados(object origem, EventArgs e)  // subscriver
        {
            Console.WriteLine("Model P : pesquisa concluida");
            Console.WriteLine("Controller S: model cria o ficheiro ");
            model.GerarFicheiroResultados();

        }

        public void MensagemFinal(object origem, EventArgs e) //subscriver
        {
            Console.WriteLine("Model P: acabei o ficheiro");
            Console.WriteLine("Contoller S: View informa o utilizador");
            view.MensagemParaUtilizador("Pesquisa concluida, consulte o ficheiro.");
        }


    }
}
