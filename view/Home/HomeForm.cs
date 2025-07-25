using System;
using System.Drawing;
using System.Windows.Forms;
// Asegúrate que el namespace de SolicitudForm es view.Solicitud y que está en el proyecto referenciado
using view.Solicitud;

namespace view.Home
{
    public partial class HomeForm : Form
    {
        private Button buttonVerMascotas;
        private Button buttonVerAdoptantes;
        private Button buttonVerSolicitudes;
        private Label titulo;
        private Label subtitulo;
        private Panel menuLateral;
        private Button btnMenuMascotas;
        private Button btnMenuAdoptantes;
        private Button btnMenuSolicitudes;

        public HomeForm()
        {
            InitializeComponent();
            this.Text = "🐾 Sistema de adopción de mascotas";
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.FromArgb(245, 245, 245); // Gris claro
            this.StartPosition = FormStartPosition.CenterScreen;
            InicializarControles();

            // Redibujar todo cuando se cambia el tamaño
            this.Resize += (s, e) =>
            {
                Controls.Clear();
                InicializarControles();
            };
        }

        private void InicializarControles()
        {
            // Menú lateral
            menuLateral = new Panel();
            menuLateral.Size = new Size(220, this.ClientSize.Height);
            menuLateral.BackColor = Color.FromArgb(33, 150, 243);
            menuLateral.Dock = DockStyle.Left;
            this.Controls.Add(menuLateral);

            // Botones menú lateral
            btnMenuMascotas = CrearBotonMenu("🐶 Mascotas", new Point(10, 60));
            btnMenuAdoptantes = CrearBotonMenu("👤 Adoptantes", new Point(10, 120));
            btnMenuSolicitudes = CrearBotonMenu("📄 Solicitudes", new Point(10, 180));
            menuLateral.Controls.Add(btnMenuMascotas);
            menuLateral.Controls.Add(btnMenuAdoptantes);
            menuLateral.Controls.Add(btnMenuSolicitudes);

            btnMenuMascotas.Click += buttonVerMascotas_Click;
            btnMenuAdoptantes.Click += buttonVerAdoptantes_Click;
            btnMenuSolicitudes.Click += buttonVerSolicitudes_Click;

            // Título
            titulo = new Label();
            titulo.Text = "Bienvenido al sistema para adoptar mascotas";
            titulo.Font = new Font("Segoe UI", 24, FontStyle.Bold);
            titulo.ForeColor = Color.FromArgb(30, 30, 30);
            titulo.AutoSize = true;
            this.Controls.Add(titulo);
            titulo.Location = new Point(menuLateral.Width + (this.ClientSize.Width - menuLateral.Width - titulo.Width) / 2, 130);

            // Subtítulo
            subtitulo = new Label();
            subtitulo.Text = "Utilizá los accesos rápidos para administrar mascotas, adoptantes y solicitudes.";
            subtitulo.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            subtitulo.ForeColor = Color.FromArgb(80, 80, 80);
            subtitulo.AutoSize = true;
            this.Controls.Add(subtitulo);
            subtitulo.Location = new Point(menuLateral.Width + (this.ClientSize.Width - menuLateral.Width - subtitulo.Width) / 2, titulo.Bottom + 25);

            // Tarjetas de acceso rápido
            int cardWidth = 220, cardHeight = 160, cardSpacing = 60;
            int totalWidth = (cardWidth * 3) + (cardSpacing * 2);
            int startX = menuLateral.Width + (this.ClientSize.Width - menuLateral.Width - totalWidth) / 2;
            int startY = subtitulo.Bottom + 90;

            buttonVerMascotas = CrearTarjeta("🐶 Mascotas", "Ver y administrar mascotas disponibles", new Point(startX, startY), cardWidth, cardHeight, Color.FromArgb(255, 255, 255));
            buttonVerAdoptantes = CrearTarjeta("👤 Adoptantes", "Ver y administrar adoptantes registrados", new Point(startX + cardWidth + cardSpacing, startY), cardWidth, cardHeight, Color.FromArgb(255, 255, 255));
            buttonVerSolicitudes = CrearTarjeta("📄 Solicitudes", "Ver y gestionar solicitudes de adopción", new Point(startX + (cardWidth + cardSpacing) * 2, startY), cardWidth, cardHeight, Color.FromArgb(255, 255, 255));

            buttonVerMascotas.Click += buttonVerMascotas_Click;
            buttonVerAdoptantes.Click += buttonVerAdoptantes_Click;
            buttonVerSolicitudes.Click += buttonVerSolicitudes_Click;

            this.Controls.Add(buttonVerMascotas);
            this.Controls.Add(buttonVerAdoptantes);
            this.Controls.Add(buttonVerSolicitudes);
        }

        private Button CrearBotonMenu(string texto, Point ubicacion)
        {
            Button boton = new Button();
            boton.Text = texto;
            boton.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            boton.Size = new Size(200, 40);
            boton.Location = ubicacion;
            boton.BackColor = Color.FromArgb(33, 150, 243);
            boton.ForeColor = Color.White;
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 0;
            boton.Cursor = Cursors.Hand;
            boton.TextAlign = ContentAlignment.MiddleLeft;
            return boton;
        }

        private Button CrearTarjeta(string titulo, string descripcion, Point ubicacion, int width, int height, Color colorFondo)
        {
            Button tarjeta = new Button();
            tarjeta.Text = $"{titulo}\n\n{descripcion}";
            tarjeta.Font = new Font("Segoe UI", 13, FontStyle.Regular);
            tarjeta.Size = new Size(width, height);
            tarjeta.Location = ubicacion;
            tarjeta.BackColor = colorFondo;
            tarjeta.ForeColor = Color.FromArgb(33, 150, 243);
            tarjeta.FlatStyle = FlatStyle.Flat;
            tarjeta.FlatAppearance.BorderColor = Color.FromArgb(33, 150, 243);
            tarjeta.FlatAppearance.BorderSize = 2;
            tarjeta.Cursor = Cursors.Hand;
            tarjeta.TextAlign = ContentAlignment.TopLeft;
            tarjeta.Padding = new Padding(12);
            return tarjeta;
        }

        private void buttonVerMascotas_Click(object sender, EventArgs e)
        {
            mascotaForm verMascotas = new mascotaForm();
            verMascotas.ShowDialog();
            this.Close();

        }

        private void buttonVerAdoptantes_Click(object sender, EventArgs e)
        {
            adoptanteForm verAdoptantes = new adoptanteForm();
            verAdoptantes.ShowDialog();
            this.Close();

        }

        private void buttonVerSolicitudes_Click(object sender, EventArgs e)
        {
            solicitudForm verSolicitudes = new solicitudForm();
            verSolicitudes.ShowDialog();
            this.Close();
        }
    }
}