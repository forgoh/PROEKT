using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using CapaLogicaNegocio;

namespace CapaPresentacion
{
    public partial class FormContent : Form
    {
        public FormContent()
        {
            InitializeComponent();
        }
     

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            PrivilegioUsuario();
            MostrarUsuarioActivo();
        }
        private void PrivilegioUsuario() { 
        //Deshablitar boton
            if (Program.Cargo != "Администратор")
            {
                btnZ4.Enabled = false;
                btnJ.Enabled = false;
                btnZ3.Enabled = false;
                btnZ2.Enabled = false;
            }

        }
        private void MostrarUsuarioActivo() {
            lblCargo.Text = Program.Cargo;
            lblApellido.Text =  Program.Nombre;
            lblNombre.Text = Program.Apellido;
        }

        private void btnPRODUCTOS_Click(object sender, EventArgs e)
        {
          
                AbrirFormInPanel(new FormZ1());
           
        }

        private void btnVENTAS_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new FormZ3());
        }

        private void btnCLIENTES_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new FormZ2());
        }

        private void btnCOMPRAS_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new FormZ4());
        }

        private void btnEMPLEADOS_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new FormZ2());
        }

        private void iconCerrar_Click(object sender, EventArgs e)
        {
            FormLogin login = new FormLogin();
            this.Hide();
            login.Show();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelHeader_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void AbrirFormInPanel(object formHijo)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            Form fh = formHijo as Form;
            fh.TopLevel = false;
            fh.FormBorderStyle = FormBorderStyle.None;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();
        }

       
        private void iconMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnmenu_Click(object sender, EventArgs e)
        {
            if (MenuVertical.Width == 109)
            {
                MenuVertical.Width = 339;
            }
            else

                MenuVertical.Width = 109;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

      
    }
}
