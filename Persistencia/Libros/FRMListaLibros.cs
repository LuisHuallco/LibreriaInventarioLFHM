using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Inventario_Libreria.Acceso_Datos;
using Inventario_Libreria.Datos;

namespace Inventario_Libreria.Persistencia.Libros
{
    public partial class FRMListaLibros : Form
    {
        private LibroDAO libroDAO = new LibroDAO();
        private AutorDAO autorDAO = new AutorDAO();

        public FRMListaLibros()
        {
            InitializeComponent();
            this.Load += FRMListaLibros_Load;
        }

        private void FRMListaLibros_Load(object sender, EventArgs e)
        {
            CargarAutores();
            CargarLibros();
        }

        private void CargarAutores()
        {
            try
            {
                cbAutor.DataSource = autorDAO.ObtenerAutores();
                cbAutor.DisplayMember = "Nombre";
                cbAutor.ValueMember = "AutorID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar autores: " + ex.Message);
            }
        }

        private void CargarLibros()
        {
            try
            {
                dgvLibros.DataSource = libroDAO.ObtenerLibros();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar libros: " + ex.Message);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string titulo = txtTitulo.Text.Trim();
            string genero = txtGenero.Text.Trim();
            string anioTexto = txtAnio.Text.Trim();

            if (!string.IsNullOrEmpty(titulo) && !string.IsNullOrEmpty(genero) && int.TryParse(anioTexto, out int anio))
            {
                int autorID = Convert.ToInt32(cbAutor.SelectedValue);

                try
                {
                    libroDAO.InsertarLibro(titulo, genero, anio, autorID);
                    MessageBox.Show("Libro agregado correctamente.");
                    LimpiarCampos();
                    CargarLibros();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al agregar libro: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Completa todos los campos correctamente.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvLibros.CurrentRow != null)
            {
                int libroID = Convert.ToInt32(dgvLibros.CurrentRow.Cells["LibroID"].Value);
                try
                {
                    libroDAO.EliminarLibro(libroID);
                    MessageBox.Show("Libro eliminado correctamente.");
                    CargarLibros();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar libro: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Selecciona un libro para eliminar.");
            }
        }

        private void LimpiarCampos()
        {
            txtTitulo.Clear();
            txtGenero.Clear();
            txtAnio.Clear();
            cbAutor.SelectedIndex = 0;
        }

        // Opcional: puedes dejar vacío o eliminar si no se usa
        private void txtTitulo_TextChanged(object sender, EventArgs e) { }
        private void txtGenero_TextChanged(object sender, EventArgs e) { }
        private void txtAnio_TextChanged(object sender, EventArgs e) { }
        private void cbAutor_SelectedIndexChanged(object sender, EventArgs e) { }
        private void dgvLibros_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
