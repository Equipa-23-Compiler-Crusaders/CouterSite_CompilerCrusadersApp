using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace compilercrusadersteste
{
    public partial class Form1 : Form
    {
        View view;
        public Form1()
        {
            InitializeComponent();
        }

        public string get_text()
        {
            return TipoPesquisa.Text + "," + LugarPesquisa.Text;
        }
        public void change_label(string mensagem)
        {
            label1.Text = mensagem;
        }
        public View View { get => view; set => view = value; }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MenuVertical_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState=FormWindowState.Normal;
            btnRestaurar.Visible=false;
            btnMaximizar.Visible=true;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panelContentor_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void btnRestaurar_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnRestaurar.Visible=false;
            btnMaximizar.Visible=true;  
        }

        private void btnMinimizar_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void google_Click(object sender, EventArgs e)
        {
            
        }

        private void panelContentor_Paint_1(object sender, PaintEventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void label1_Click_2(object sender, EventArgs e)
        {
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
        }

        private void bing_Click(object sender, EventArgs e)
        {
            
        }

        private void Pesquisar_Click(object sender, EventArgs e)
{
    if (TipoPesquisa.Text == ""  | LugarPesquisa.Text == "")
    {
        if (TipoPesquisa.Text == "")
        {
            label1.Text = "Selecione um negócio!";
            //view.MensagemParaUtilizador("mano seleciona alguma um negocio ex: putaria");

                }
                else
        {
            label1.Text = "Selecione um local!";
            //view.MensagemParaUtilizador("mano seleciona alguma um local ex: perto de casa");
                }
            }
    else
    {
        // Inicializa a barra de progresso.
        progressBar1.Minimum = 0;
        progressBar1.Maximum = 100;
        progressBar1.Value = 0;

        // Simula a operação de pesquisa em andamento.
        for (int i = 0; i <= 100; i++)
        {
            // Simula o trabalho da pesquisa.
            System.Threading.Thread.Sleep(50);

            // Atualiza a barra de progresso.
            progressBar1.Value = i;
        }

        label1.Text = "A pesquisar";
        view.CliqueEmPesquisar(sender, e);
    }
}


        private void label1_Click_3(object sender, EventArgs e)
        {

        }
    }
}
