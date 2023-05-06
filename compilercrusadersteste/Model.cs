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
        private View view;
        public Model(View v)
        {
            view = v;
        }

        public void Pesquisa(string negocio,string local, string motor_busca)   // pesquisa com o selenium
        {
            Console.WriteLine(negocio+" em "+ local + " no "+motor_busca);
        }

        public void GerarFicheiroResultados()  // gerar ficheiro final
        {

        }



        // evento pesquisa concluida para o controller
        // evento ficheiro gerado
    }
}
