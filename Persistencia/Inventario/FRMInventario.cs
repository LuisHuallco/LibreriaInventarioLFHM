using System;
using System.Windows.Forms;
using Inventario_Libreria.Acceso_Datos;
using Inventario_Libreria.Datos;

namespace Inventario_Libreria.Persistencia.Inventario
{
    public partial class FRMInventario : Form
    {
        private InventarioDAO inventarioDAO = new InventarioDAO();
        private LibroDAO libroDAO = new LibroDAO();

        public FRMInventario()
        {
            InitializeComponent();
            this.Load += FRMInventario_Load;
        }

        private void FRMInventario_Load(object sender, EventArgs e)
        {
            CargarLibros();
            CargarInventario();
        }

        private void CargarLibros()
        {
            try
            {
                cbLibro.DataSource = libroDAO.ObtenerLibros();
                cbLibro.DisplayMember = "Titulo";
                cbLibro.ValueMember = "LibroID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar libros: " + ex.Message);
            }
        }

        private void CargarInventario()
        {
            try
            {
                dgvInventario.DataSource = inventarioDAO.ObtenerInventario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar inventario: " + ex.Message);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtCantidad.Text.Trim(), out int cantidad))
            {
                int libroID = Convert.ToInt32(cbLibro.SelectedValue);
                try
                {
                    inventarioDAO.InsertarInventario(libroID, cantidad);
                    MessageBox.Show("Stock agregado correctamente.");
                    txtCantidad.Clear();
                    CargarInventario();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al agregar stock: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Cantidad inválida.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvInventario.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvInventario.CurrentRow.Cells["InventarioID"].Value);
                try
                {
                    inventarioDAO.EliminarInventario(id);
                    MessageBox.Show("Registro eliminado correctamente.");
                    CargarInventario();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar registro: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Selecciona un registro para eliminar.");
            }
        }

        // Métodos vacíos generados por el diseñador (opcionales)
        private void cbLibro_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txtCantidad_TextChanged(object sender, EventArgs e) { }
        private void dgvInventario_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
