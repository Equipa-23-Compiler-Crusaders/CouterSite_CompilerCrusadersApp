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

        }
        public void IniciarPrograma()
        {
            view.AtivarInterface();
        }

        public void CliqueEmPesquisar()   //evento
        {

        }
        //public void VerificarInput()    // já não precisa
        //{}

        public void IniciarPesquisa()   // depois de confirmar input iniciar a pesquisa no model.
        {

        }

        public void GerarResultados()  // evento para a model gerar resultados
        {

        }


    }
}
