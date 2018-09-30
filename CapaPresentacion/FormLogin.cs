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
using System.Data.SqlClient;
using CapaDatos;

namespace CapaPresentacion
{
    public partial class FormLogin : Form
    {
   
        public FormLogin()
        {
            InitializeComponent();
        }
        private void btnlogin_Click(object sender, EventArgs e)
        {
            CNEmpleado ObjEmpleado = new CNEmpleado();
            SqlDataReader Loguear;

            ObjEmpleado.Usuario = txtuser.Text;
            ObjEmpleado.Contraseña = txtpass.Text;

            if (ObjEmpleado.Usuario == txtuser.Text)
            {
                lblErrorUser.Visible = false;
                if (ObjEmpleado.Contraseña == txtpass.Text)
                {
                    lblErrorPass.Visible = false;
            Loguear = ObjEmpleado.IniciarSesion();

            if (Loguear.Read() == true)
            {
                this.Hide();
                FormContent ObjFP = new FormContent();
                Program.Cargo = Loguear["Cargo"].ToString();
                Program.Nombre = Loguear["Nombres"].ToString();
                Program.Apellido = Loguear["Apellidos"].ToString();
                ObjFP.Show();
            }
            else
            {
                lblErrorAcceso.Text = "Неправильный логин или пароль, попробуйте еще раз";
                lblErrorAcceso.Visible = true;
                txtpass.Text = "";
                txtpass_Leave(null, e);
                txtuser.Focus();
            }
                }
                else
                {
                    lblErrorPass.Text = ObjEmpleado.Contraseña;
                    lblErrorPass.Visible = true;
                }
            }
            else
            {
                lblErrorUser.Text = ObjEmpleado.Usuario;
                lblErrorUser.Visible = true;
            }

        }


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);


        private void txtuser_Enter(object sender, EventArgs e)
        {
            if (txtuser.Text == "ЛОГИН") {
                txtuser.Text = "";
                txtuser.ForeColor = Color.LightGray;
            }
        }

        private void txtuser_Leave(object sender, EventArgs e)
        {
            if(txtuser.Text==""){
                txtuser.Text = "ЛОГИН";
                txtuser.ForeColor = Color.Silver;
            }
        }

        private void txtpass_Enter(object sender, EventArgs e)
        {
           lblErrorUser.Visible = false;
            if (txtpass.Text == "ПАРОЛЬ")
            {
                txtpass.Text = "";
                txtpass.ForeColor = Color.LightGray;
                txtpass.UseSystemPasswordChar = true;
            }
        }

        private void txtpass_Leave(object sender, EventArgs e)
        {
            if(txtpass.Text==""){
                txtpass.Text = "ПАРОЛЬ";
                txtpass.ForeColor = Color.Silver;
                txtpass.UseSystemPasswordChar = false;
            }
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtpass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnlogin_Click(null, e);
            }
        }

        private void txtuser_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
