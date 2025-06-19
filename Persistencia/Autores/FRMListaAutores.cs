using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Inventario_Libreria.Acceso_Datos;
using Inventario_Libreria.Datos;

namespace Inventario_Libreria.Persistencia.Autores
{
    public partial class FRMListaAutores : Form
    {
        private AutorDAO autorDAO = new AutorDAO();

        public FRMListaAutores()
        {
            InitializeComponent();
            this.Load += new EventHandler(FRMListaAutores_Load);
        }

        private void FRMListaAutores_Load(object sender, EventArgs e)
        {
            CargarAutores();
        }

        private void CargarAutores()
        {
            try
            {
                dgvAutores.DataSource = autorDAO.ObtenerAutores();
                dgvAutores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                // Ocultar columna AutorID si no deseas mostrarla
                if (dgvAutores.Columns.Contains("AutorID"))
                {
                    dgvAutores.Columns["AutorID"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar autores: " + ex.Message);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();

            if (!string.IsNullOrEmpty(nombre))
            {
                try
                {
                    autorDAO.InsertarAutor(nombre);
                    MessageBox.Show("Autor agregado correctamente.");
                    txtNombre.Clear();
                    CargarAutores();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al agregar autor: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Por favor, escribe un nombre.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvAutores.CurrentRow != null)
            {
                int autorID = Convert.ToInt32(dgvAutores.CurrentRow.Cells["AutorID"].Value);
                try
                {
                    autorDAO.EliminarAutor(autorID);
                    MessageBox.Show("Autor eliminado correctamente.");
                    CargarAutores();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar autor: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Selecciona un autor para eliminar.");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvAutores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Opcional: puedes dejarlo vacío o usarlo para otras acciones
        }
    }
}
