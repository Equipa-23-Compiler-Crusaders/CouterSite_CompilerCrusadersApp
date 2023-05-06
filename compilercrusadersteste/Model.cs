using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace compilercrusadersteste
{
    class Model
    {

        public delegate void Pesquisa_event(object sender, EventArgs e);
        public event Pesquisa_event Pesquisa_Concluida;
        public event Pesquisa_event Ficheiro_Gerado;
        private View view;
        public Model(View v)
        {
            view = v;
        }

        public void Pesquisa(string negocio,string local, string motor_busca)   // pesquisa com o selenium
        {
            Console.WriteLine(negocio+" em "+ local + " no "+motor_busca);

            Console.WriteLine("Model: a pesquisar");

            Pesquisa_Concluida(this, EventArgs.Empty);
   


    }

        public void GerarFicheiroResultados()  // gerar ficheiro final
        {
            Console.WriteLine("Model: olha eu a fazer um ficheiro com cenas ");
            Ficheiro_Gerado(this, EventArgs.Empty);

            
        }



       
        // evento ficheiro gerado
    }
}
