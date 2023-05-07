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

            Console.WriteLine("Controller S: model bota ai a pesquisa");
            model.Pesquisa("putaria", "braga", "bing");

        }
     
        public void GerarResultados(object origem, EventArgs e)  // subscriver
        {
            Console.WriteLine("Model P : pesquisa concluido");
            Console.WriteLine("Controller S: model bota ai o ficheiro ");
            model.GerarFicheiroResultados();

        }

        public void MensagemFinal(object origem, EventArgs e) //subscriver
        {
            Console.WriteLine("Model P: acabei o ficheiro");
            Console.WriteLine("Contoller S: View informa o utilizador");
            view.MensagemParaUtilizador("Pesquisa conluida, consulte o ficheiro.");
        }


    }
}
