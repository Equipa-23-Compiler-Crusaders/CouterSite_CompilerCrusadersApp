using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace compilercrusadersteste
{
    class View
    {
        private Model model;
        private Form1 janela;

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


        }

        public void MensagemParaUtilizador()  // subscriver do controller para mostar mensagem  ao utilizador
        {

        }

    }
}
