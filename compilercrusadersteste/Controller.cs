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

        public delegate void Controller_event(object sender, EventArgs e);
        public event Controller_event Iniciar_pesquisa;
        public event Controller_event Execucao_concluida;
        public event Controller_event Gerar_Ficheiro;
        public event Controller_event Aviso_Erro;
       

        public Controller()
        {
            view = new View(model);
            model = new Model(view);

            view.BotãoPressionado += CliqueEmPesquisar;
            model.Pesquisa_Concluida += GerarResultados;
            model.Ficheiro_Gerado += FicheiroGerado;
            this.Execucao_concluida += view.Mensagem_Final;
            this.Iniciar_pesquisa += model.Iniciar;
            this.Gerar_Ficheiro += model.Gerar_ficheiro;
            this.Aviso_Erro += view.Informar_utilizador;
            model.Erro_m += Erros;

        }
        public void IniciarPrograma()
        {
            view.AtivarInterface();
        }

        public void CliqueEmPesquisar(object origem, EventArgs e)   //subscriver
        {
            
            Console.WriteLine("Controller S: model começa a pesquisa");

            //model.Pesquisa(texto);  
            Iniciar_pesquisa(this, EventArgs.Empty);

        }
     
        public void GerarResultados(object origem, EventArgs e)  // subscriver
        {
            Console.WriteLine("Model P : pesquisa concluida");
            Console.WriteLine("Controller S: model cria o ficheiro ");
            // model.GerarFicheiroResultados();
            Gerar_Ficheiro(this, EventArgs.Empty);
        }

        public void FicheiroGerado(object origem, EventArgs e) //subscriver
        {
            Console.WriteLine("Model P: acabei o ficheiro");
            Console.WriteLine("Contoller S: View informa o utilizador");
            // view.MensagemParaUtilizador("Pesquisa concluida, consulte o ficheiro.");
            Execucao_concluida(this, EventArgs.Empty);

        }

        public void Erros(object origem, EventArgs e) { 
        
            Aviso_Erro(this,EventArgs.Empty);

        }


    }
}
