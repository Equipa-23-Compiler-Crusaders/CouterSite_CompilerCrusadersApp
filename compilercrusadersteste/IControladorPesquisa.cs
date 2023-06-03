using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace compilercrusadersteste
{
    public interface IControladorPesquisa
    {
        void IniciarPrograma();
        void CliqueEmPesquisar(object origem, EventArgs e);
        void GerarResultados(object origem, EventArgs e);
        void Erros(object origem, EventArgs e);
    }
}