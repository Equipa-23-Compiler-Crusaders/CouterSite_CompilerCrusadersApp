using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace compilercrusadersteste
{
    public class View
    {
        private Model model;
        private Form1 janela;


        public delegate void Clique(object sender, EventArgs e);
        public event Clique BotãoPressionado;


        internal View(Model m)
        {
            model = m;
        }



        public void AtivarInterface()
        {
            janela = new Form1();
            janela.View = this;
            // A API WinForms desenha as janelas e botões automaticamente
            janela.ShowDialog();

        }

        public void CliqueEmPesquisar(object origem, EventArgs e) // subscriver para clique no controller
        {

            Console.WriteLine("View S: click pesquisar");
            BotãoPressionado(origem, e);
        }

        public void MensagemParaUtilizador()  // subscriver do controller para mostar mensagem  ao utilizador
        {
            Console.WriteLine("View: ficehiro gerado" );
        }

    }
}
