using data.models;
using logic.presenter;
using System;
using System.Windows.Forms;

// Alias para evitar conflicto con nombres de espacio y clases
using ModeloSolicitud = data.models.Solicitud;
using ModeloMascota = data.models.Mascota;
using ModeloAdoptante = data.models.Adoptante;

namespace view.Solicitud
{
    public partial class modificarSolicitudForm : Form
    {
        private ModeloSolicitud solicitudOriginal;

        public modificarSolicitudForm(ModeloSolicitud solicitud)
        {
            InitializeComponent();
            solicitudOriginal = solicitud;

            // Cargar datos en los controles
            textBoxAgregarMascotaId.Text = solicitudOriginal.Mascota?.id.ToString();
            textBoxAgregarAdoptanteId.Text = solicitudOriginal.Adoptante?.id.ToString();
            dateTimePicker1.Value = solicitudOriginal.FechaSolicitud;

            switch (solicitudOriginal.Estado)
            {
                case "Aprobado":
                    radioButton1.Checked = true;
                    break;
                case "Rechazado":
                    radioButton2.Checked = true;
                    break;
                case "Pendiente":
                    radioButton3.Checked = true;
                    break;
            }
        }

        private void buttonAgregar_Click_1(object sender, EventArgs e)
        {
            try
            {
                solicitudOriginal.Mascota = new ModeloMascota
                {
                    id = int.Parse(textBoxAgregarMascotaId.Text)
                };
                solicitudOriginal.Adoptante = new ModeloAdoptante
                {
                    id = int.Parse(textBoxAgregarAdoptanteId.Text)
                };
                solicitudOriginal.FechaSolicitud = dateTimePicker1.Value;
                solicitudOriginal.Estado = radioButton1.Checked ? "Aprobado" :
                                           radioButton2.Checked ? "Rechazado" :
                                           radioButton3.Checked ? "Pendiente" : "Sin seleccionar";

                SolicitudPresenter presenter = new SolicitudPresenter();
                presenter.ModificarSolicitud(solicitudOriginal);

                MessageBox.Show("Solicitud modificada correctamente.");

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar solicitud: " + ex.Message);
            }
        }
    }
}
