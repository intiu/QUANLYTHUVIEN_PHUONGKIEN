using DevExpress.LookAndFeel;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraEditors.ColorWheel;
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
using QUANLYTHUVIEN_PHUONGKIEN.BLL;
using QUANLYTHUVIEN_PHUONGKIEN.DTO;
namespace QUANLYTHUVIEN_PHUONGKIEN
{
    public partial class NHANVIEN : Form
    {
        public NHANVIEN()
        {
            InitializeComponent();
        }
        private NHANVIENBLL nhanvienBLL = new NHANVIENBLL();
        private NHANVIENDTO nhanvienDTO = new NHANVIENDTO();
        private void NHANVIEN_Load(object sender, EventArgs e)
        {
            SkinHelper.InitSkinPopupMenu(SkinsLink);
        }

        private void barButtonItem21_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ABOUT about = new ABOUT();
            //this.Hide();
            about.Show();
            this.Show();
        }

        private void barButtonItem20_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var a1 = new ProcessStartInfo("msedge.exe");
            a1.Arguments = "https://www.facebook.com/phuong.lethanh.3158";
            Process.Start(a1);

            var a2 = new ProcessStartInfo("msedge.exe");
            a2.Arguments = "https://www.facebook.com/NguyenCaoKien1998";
            Process.Start(a2);
        }

        private void barButtonItem19_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ColorWheelForm form = new ColorWheelForm();
            form.StartPosition = FormStartPosition.CenterParent;
            form.SkinMaskColor = UserLookAndFeel.Default.SkinMaskColor;
            form.SkinMaskColor2 = UserLookAndFeel.Default.SkinMaskColor2;
            form.ShowDialog(this);
        }

        private void barButtonItem18_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMNV.Text.Trim() != "")
            {
                //gán dữ liệu vào DTO
                nhanvienDTO.MaNV = txtMNV.Text.ToLower();
                //gọi BLL thực hiện
                var sachTim = nhanvienBLL.TimKiem2(nhanvienDTO, dgv);
                //khác null là tìm thấy, thực hiện bind lên ui
                if (sachTim != null)
                {
                    txtMNV.Text = sachTim.MaNV;
                    txtTNV.Text = sachTim.TenNV;
                    txtTKNV.Text = sachTim.TaiKhoanNV;
                    txtMKNV.Text = sachTim.MatKhauNV;
                    txtNSNV.Text = sachTim.NgaySinhNV;
                    txtDCNV.Text = sachTim.DiaChiNV;
                    txtSDTNV.Text = sachTim.SDTNV;
                    txtLNV.Text = sachTim.LuongNV;
                }
                else
                {
                    //không thấy thì xóa trăng
                    txtMNV.Text = txtTNV.Text = txtTKNV.Text = txtMKNV.Text = txtNSNV.Text = txtDCNV.Text = txtSDTNV.Text = txtLNV.Text = string.Empty;
                }
            }
        }

        private void barButtonItem17_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMNV.Text.Trim() != "")
            {
                //gán dữ liệu vào DTO
                nhanvienDTO.MaNV = txtMNV.Text.ToLower();

                //gọi BLL thực hiện
                nhanvienBLL.Xoa(nhanvienDTO);
                //hiện lên dgv
                nhanvienBLL.HienThi(dgv);
            }
        }

        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMNV.Text.Trim() != "")
            {
                //gán dữ liệu vào DTO
                nhanvienDTO.MaNV = txtMNV.Text.ToLower();
                nhanvienDTO.TenNV = txtTNV.Text;
                nhanvienDTO.TaiKhoanNV = txtTKNV.Text;
                nhanvienDTO.MatKhauNV = txtMKNV.Text;
                nhanvienDTO.NgaySinhNV = txtNSNV.Text;
                nhanvienDTO.DiaChiNV = txtDCNV.Text;
                nhanvienDTO.SDTNV = txtSDTNV.Text;
                nhanvienDTO.LuongNV = txtLNV.Text;
                //gọi BLL thực hiện
                nhanvienBLL.Sua(nhanvienDTO);
                //hiện lên dgv
                nhanvienBLL.HienThi(dgv);
            }
        }

        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMNV.Text.Trim() != "")
            {
                //gán dữ liệu vào DTO
                nhanvienDTO.MaNV = txtMNV.Text;
                nhanvienDTO.TenNV = txtTNV.Text;
                nhanvienDTO.TaiKhoanNV = txtTKNV.Text;
                nhanvienDTO.MatKhauNV = txtMKNV.Text;
                nhanvienDTO.NgaySinhNV = txtNSNV.Text;
                nhanvienDTO.DiaChiNV = txtDCNV.Text;
                nhanvienDTO.SDTNV = txtSDTNV.Text;
                nhanvienDTO.LuongNV = txtLNV.Text;

                nhanvienBLL.Them(nhanvienDTO);
                //hiện lên dgv
                nhanvienBLL.HienThi(dgv);
            }
        }

        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MessageBox.Show("Vì lý do bảo mật nên bạn cần có mã chỉnh sửa tài khoản với sự đồng ý từ hiệu trưởng NTU. Vui lòng gửi gmail cho hiệu trưởng để xin mã");
            XACNHAN xacnhan = new XACNHAN();
            //this.Hide();
            xacnhan.Show();
            this.Show();
            /*CODE code = new CODE();
            //this.Hide();
            code.Show();
            this.Show();*/
        }

        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMNV == null) return;
            txtMNV.SelectAll();
            if (txtTNV == null) return;
            txtTNV.SelectAll();
            if (txtTKNV == null) return;
            txtTKNV.SelectAll();
            if (txtMKNV == null) return;
            txtMKNV.SelectAll();
            if (txtNSNV == null) return;
            txtNSNV.SelectAll();
            if (txtDCNV == null) return;
            txtDCNV.SelectAll();
            if (txtSDTNV == null) return;
            txtSDTNV.SelectAll();
            if (txtLNV == null) return;
            txtLNV.SelectAll();
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtMNV.Undo();
            txtTNV.Undo();
            txtTKNV.Undo();
            txtMKNV.Undo();
            txtNSNV.Undo();
            txtDCNV.Undo();
            txtSDTNV.Undo();
            txtLNV.Undo();
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ColorDialog fd = new ColorDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                txtMNV.BackColor = fd.Color;
                txtTNV.BackColor = fd.Color;
                txtTKNV.BackColor = fd.Color;
                txtMKNV.BackColor = fd.Color;
                txtNSNV.BackColor = fd.Color;
                txtDCNV.BackColor = fd.Color;
                txtSDTNV.BackColor = fd.Color;
                txtLNV.BackColor = fd.Color;
            }
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FontDialog fd = new FontDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                txtMNV.Font = fd.Font;
                txtTNV.Font = fd.Font;
                txtTKNV.Font = fd.Font;
                txtMKNV.Font = fd.Font;
                txtNSNV.Font = fd.Font;
                txtDCNV.Font = fd.Font;
                txtSDTNV.Font = fd.Font;
                txtLNV.Font = fd.Font;
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMNV.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtMNV.Cut();
            if (txtTNV.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtTNV.Cut();
            if (txtTKNV.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtTKNV.Cut();
            if (txtMKNV.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtMKNV.Cut();
            if (txtNSNV.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtNSNV.Cut();
            if (txtDCNV.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtDCNV.Cut();
            if (txtSDTNV.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtSDTNV.Cut();
            if (txtLNV.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtLNV.Cut();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMNV.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtMNV.Copy();
            if (txtTNV.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtTNV.Copy();
            if (txtTKNV.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtTKNV.Copy();
            if (txtMKNV.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtMKNV.Copy();
            if (txtNSNV.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtNSNV.Copy();
            if (txtDCNV.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtDCNV.Copy();
            if (txtSDTNV.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtSDTNV.Copy();
            if (txtLNV.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtLNV.Copy();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtMNV.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show("Do you want to paste over current selection?", "Cut Example", MessageBoxButtons.YesNo) == DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtMNV.SelectionStart = txtMNV.SelectionStart + txtMNV.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtMNV.Paste();
            }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtTNV.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show("Do you want to paste over current selection?", "Cut Example", MessageBoxButtons.YesNo) == DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtTNV.SelectionStart = txtTNV.SelectionStart + txtTNV.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtTNV.Paste();
            }
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtNSNV.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show("Do you want to paste over current selection?", "Cut Example", MessageBoxButtons.YesNo) == DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtNSNV.SelectionStart = txtNSNV.SelectionStart + txtNSNV.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtNSNV.Paste();
            }
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtDCNV.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show("Do you want to paste over current selection?", "Cut Example", MessageBoxButtons.YesNo) == DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtDCNV.SelectionStart = txtDCNV.SelectionStart + txtDCNV.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtDCNV.Paste();
            }
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtSDTNV.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show("Do you want to paste over current selection?", "Cut Example", MessageBoxButtons.YesNo) == DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtSDTNV.SelectionStart = txtSDTNV.SelectionStart + txtSDTNV.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtSDTNV.Paste();
            }
        }

        private void barButtonItem22_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtLNV.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show("Do you want to paste over current selection?", "Cut Example", MessageBoxButtons.YesNo) == DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtLNV.SelectionStart = txtLNV.SelectionStart + txtLNV.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtLNV.Paste();
            }
        }

        private void barButtonItem23_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("calc");
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void barButtonItem24_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtTKNV.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show("Do you want to paste over current selection?", "Cut Example", MessageBoxButtons.YesNo) == DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtTKNV.SelectionStart = txtTKNV.SelectionStart + txtTKNV.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtTKNV.Paste();
            }
        }

        private void barButtonItem25_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtMKNV.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show("Do you want to paste over current selection?", "Cut Example", MessageBoxButtons.YesNo) == DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtMKNV.SelectionStart = txtMKNV.SelectionStart + txtMKNV.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtMKNV.Paste();
            }
        }

        private void barButtonItem26_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }       
        private void timer1_Tick(object sender, EventArgs e)
        {         
        }

        private void NHANVIEN_FormClosing(object sender, FormClosingEventArgs e)
        {           
        }

        private void barButtonItem27_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            string pass;
            pass = passwordcode.Text;
            if (pass == "123456")
            {
                MessageBox.Show("Mã bạn nhập thành công");
                /*NHANVIEN f = new NHANVIEN();
                f.Show();
                this.Hide();*/
                nhanvienBLL.HienThi(dgv);
            }
            else
            {
                MessageBox.Show("Bạn nhập sai mã");
            }
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void gunaButton2_Click_1(object sender, EventArgs e)
        {
            string pass;
            pass = passwordcode.Text;
            if (pass == "123456")
            {
                MessageBox.Show("Mã bạn nhập thành công");
                /*NHANVIEN f = new NHANVIEN();
                f.Show();
                this.Hide();*/
                nhanvienBLL.HienThi(dgv);
            }
            else
            {
                MessageBox.Show("Bạn nhập sai mã");
            }
        }

        private void passwordcode_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
