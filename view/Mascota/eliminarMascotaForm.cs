using System;
using System.Windows.Forms;
using logic.presenter;

namespace view
{
    public partial class eliminarMascotaForm : Form
    {
        private MascotaPresenter presenter;

        // Constructor que recibe la instancia del presenter
        public eliminarMascotaForm(MascotaPresenter presenter)
        {
            InitializeComponent();
            this.presenter = presenter;
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            int id;

            // Validar que el ID sea un número
            if (int.TryParse(textBoxIngreseId.Text, out id))
            {
                try
                {
                    presenter.eliminarMascota(id);
                    MessageBox.Show("Mascota eliminada correctamente.");
                    this.Close(); // Esto permite refrescar el DataGridView en el formulario principal
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar la mascota: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Por favor ingrese un ID válido.");
            }
        }

        private void textBoxIngreseId_TextChanged(object sender, EventArgs e)
        {
            // Evento vacío si no se necesita lógica adicional
        }

        private void labelEliminarTitulo_Click(object sender, EventArgs e)
        {
            // Evento vacío si no se necesita lógica adicional
        }

        private void labelEliminarId_Click(object sender, EventArgs e)
        {
            // Evento vacío si no se necesita lógica adicional
        }
    }
}
