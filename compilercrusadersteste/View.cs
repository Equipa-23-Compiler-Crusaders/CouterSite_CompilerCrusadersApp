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

        public void CliqueEmPesquisar(object origem, EventArgs e) // subscriver 
        {

            Console.WriteLine("View S: click pesquisar");
            BotãoPressionado(origem, e);
        }

        public string Texto()
        {

            return janela.get_text();
        }

        public void MensagemParaUtilizador(string mensagem)  // subscriver do controller para mostar mensagem  ao utilizador
        {
            //Console.WriteLine("View:" );
            janela.change_label(mensagem);
             
           
        }

    }
}
