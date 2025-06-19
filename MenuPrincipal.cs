using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Inventario_Libreria.Persistencia.Autores;
using Inventario_Libreria.Persistencia.Libros;
using Inventario_Libreria.Persistencia.Inventario;


namespace Inventario_Libreria
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void btnAutores_Click(object sender, EventArgs e)
        {
            FRMListaAutores frm = new FRMListaAutores();
            frm.ShowDialog(); // o frm.Show();
        }

        private void btnLibros_Click(object sender, EventArgs e)
        {
            FRMListaLibros frm = new FRMListaLibros();
            frm.ShowDialog();
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            FRMInventario frm = new FRMInventario();
            frm.ShowDialog();
        }

    }
}
