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
using XML_Login;

namespace QUANLYTHUVIEN_PHUONGKIEN
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void btnslide_Click(object sender, EventArgs e)
        {
            if (MenuVertical.Width == 190)
            {
                MenuVertical.Width = 50;
            }
            else
                MenuVertical.Width = 190;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void AbrirFormInPanel(object ltp)
        {
            if (this.panel1.Controls.Count > 0)
                this.panel1.Controls.RemoveAt(0);
            Form pn = ltp as Form;
            pn.TopLevel = false;
            pn.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(pn);
            this.panel1.Tag = pn;
            pn.Show();
        }

        private void btnprod_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new SACH());
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new NHANVIEN());
            //AbrirFormInPanel(new NHANVIEN());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new NHAXUATBAN());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new DOCGIA());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new BAOCAO());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new PHIEUMUON());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new PHIEUTHU());
        }

        private void MenuVertical_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label2.Text = PassUserInformation.Name_user;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            /*Form1 about = new Form1();
            this.Hide();
            about.Show();
            //this.Show();*/
            AbrirFormInPanel(new DASHBOARD());
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
