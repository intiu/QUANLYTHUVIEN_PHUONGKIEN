using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using XML_Login;

namespace QUANLYTHUVIEN_PHUONGKIEN
{
    public partial class DANGNHAP : Form
    {
        public DANGNHAP()
        {
            InitializeComponent();
        }
        public string FromXML_user = "";
        public string FromXML_pwd = "";
        public string FromXML_name = "";

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            string user = username.Text;
            string pws = password.Text;

            XDocument doc = XDocument.Load(Application.StartupPath.ToString() + @"\QLTV_PK.xml");
            var selected_user = from x in doc.Descendants("NHANVIEN").Where(x => (string)x.Element("TaiKhoanNV") == username.Text)
                                select new
                                {
                                    XMLuser = x.Element("TaiKhoanNV").Value,
                                    XMLpwd = x.Element("MatKhauNV").Value,
                                    XMLname = x.Element("TenNV").Value
                                };
            foreach (var x in selected_user)
            {
                FromXML_user = x.XMLuser;
                FromXML_pwd = x.XMLpwd;
                FromXML_name = x.XMLname;
            }

            if (user == FromXML_user)
            {
                if (pws == FromXML_pwd)
                {
                    MessageBox.Show("Đăng nhập thành công");
                    LOADING f = new LOADING();

                    PassUserInformation.Username_user = FromXML_user;
                    PassUserInformation.Name_user = FromXML_name;
                    PassUserInformation.Pwd_user = FromXML_pwd;

                    f.Show();
                    this.Hide();
                    ClearBoxes();
                }
                else
                {
                    MessageBox.Show("Mật khẩu Không Đúng");
                    ClearBoxes();
                }
            }
            else
            {
                MessageBox.Show("Tài Khoản Không Đúng!");
                ClearBoxes();
            }
        }
        private void ClearBoxes()
        {
            username.Clear();
            password.Clear();
        }

        private void gunaImageButton1_Click(object sender, EventArgs e)
        {
            var a1 = new ProcessStartInfo("msedge.exe");
            a1.Arguments = "http://thuvien.ntu.edu.vn/";
            Process.Start(a1);
        }

        private void gunaImageButton3_Click(object sender, EventArgs e)
        {
            var a3 = new ProcessStartInfo("msedge.exe");
            a3.Arguments = "https://mail.google.com/mail/u/0/?tab=wm&ogbl#inbox?compose=CllgCJqZhvFgjskMRfWLrMqLrWtdlNGQmdwMSPxMDkxWRVcRgpNcWXFqFxpRNxqJFpnhLvgBFHL";
            Process.Start(a3);
        }

        private void password_TextChanged(object sender, EventArgs e)
        {

        }

        private void username_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
