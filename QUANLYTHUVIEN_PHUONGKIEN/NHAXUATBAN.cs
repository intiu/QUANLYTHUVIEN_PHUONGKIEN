using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraEditors.ColorWheel;
using QUANLYTHUVIEN_PHUONGKIEN.BLL;
using QUANLYTHUVIEN_PHUONGKIEN.DTO;
using System.Diagnostics;
namespace QUANLYTHUVIEN_PHUONGKIEN
{
    public partial class NHAXUATBAN : Form
    {
        public NHAXUATBAN()
        {
            InitializeComponent();
        }
        private NHAXUATBANBLL nhaxuatbanBLL = new NHAXUATBANBLL();
        private NHAXUATBANDTO nhaxuatbanDTO = new NHAXUATBANDTO();
        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ABOUT about = new ABOUT();
            //this.Hide();
            about.Show();
            this.Show();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMNXB.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtMNXB.Cut();
            if (txtTNXB.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtTNXB.Cut();
            if (txtDCNXB.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtDCNXB.Cut();
            if (txtENXB.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtENXB.Cut();
            if (txtSDTNXB.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtSDTNXB.Cut();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMNXB.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtMNXB.Copy();
            if (txtTNXB.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtTNXB.Copy();
            if (txtDCNXB.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtDCNXB.Copy();
            if (txtENXB.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtENXB.Copy();
            if (txtSDTNXB.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtSDTNXB.Copy();
        }

        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtMNXB.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show("Do you want to paste over current selection?", "Cut Example", MessageBoxButtons.YesNo) == DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtMNXB.SelectionStart = txtMNXB.SelectionStart + txtMNXB.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtMNXB.Paste();
            }
        }

        private void barButtonItem17_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtTNXB.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show("Do you want to paste over current selection?", "Cut Example", MessageBoxButtons.YesNo) == DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtTNXB.SelectionStart = txtTNXB.SelectionStart + txtTNXB.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtTNXB.Paste();
            }
        }

        private void barButtonItem18_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtDCNXB.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show("Do you want to paste over current selection?", "Cut Example", MessageBoxButtons.YesNo) == DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtDCNXB.SelectionStart = txtDCNXB.SelectionStart + txtDCNXB.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtDCNXB.Paste();
            }
        }

        private void barButtonItem19_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtENXB.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show("Do you want to paste over current selection?", "Cut Example", MessageBoxButtons.YesNo) == DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtENXB.SelectionStart = txtENXB.SelectionStart + txtENXB.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtENXB.Paste();
            }
        }

        private void barButtonItem20_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtSDTNXB.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show("Do you want to paste over current selection?", "Cut Example", MessageBoxButtons.YesNo) == DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtSDTNXB.SelectionStart = txtSDTNXB.SelectionStart + txtSDTNXB.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtSDTNXB.Paste();
            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FontDialog fd = new FontDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                txtMNXB.Font = fd.Font;
                txtTNXB.Font = fd.Font;
                txtDCNXB.Font = fd.Font;
                txtENXB.Font = fd.Font;
                txtSDTNXB.Font = fd.Font;
            }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ColorDialog fd = new ColorDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                txtMNXB.BackColor = fd.Color;
                txtTNXB.BackColor = fd.Color;
                txtDCNXB.BackColor = fd.Color;
                txtENXB.BackColor = fd.Color;
                txtSDTNXB.BackColor = fd.Color;
            }
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtMNXB.Undo();
            txtTNXB.Undo();
            txtDCNXB.Undo();
            txtENXB.Undo();
            txtSDTNXB.Undo();
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMNXB == null) return;
            txtMNXB.SelectAll();
            if (txtTNXB == null) return;
            txtTNXB.SelectAll();
            if (txtDCNXB == null) return;
            txtDCNXB.SelectAll();
            if (txtENXB == null) return;
            txtENXB.SelectAll();
            if (txtSDTNXB == null) return;
            txtSDTNXB.SelectAll();
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            nhaxuatbanBLL.HienThi(dgv);
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMNXB.Text.Trim() != "")
            {
                //gán dữ liệu vào DTO
                nhaxuatbanDTO.MaNXB = txtMNXB.Text.ToLower();
                nhaxuatbanDTO.TenNXB = txtTNXB.Text;
                nhaxuatbanDTO.DiaChiNXB = txtDCNXB.Text;
                nhaxuatbanDTO.EmailNXB = txtENXB.Text;
                nhaxuatbanDTO.SDTNXB = txtSDTNXB.Text;

                nhaxuatbanBLL.Them(nhaxuatbanDTO);
                //hiện lên dgv
                nhaxuatbanBLL.HienThi(dgv);
            }
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMNXB.Text.Trim() != "")
            {
                //gán dữ liệu vào DTO
                nhaxuatbanDTO.MaNXB = txtMNXB.Text.ToLower();
                nhaxuatbanDTO.TenNXB = txtTNXB.Text;
                nhaxuatbanDTO.DiaChiNXB = txtDCNXB.Text;
                nhaxuatbanDTO.EmailNXB = txtENXB.Text;
                nhaxuatbanDTO.SDTNXB = txtSDTNXB.Text;
                //gọi BLL thực hiện
                nhaxuatbanBLL.Sua(nhaxuatbanDTO);
                //hiện lên dgv
                nhaxuatbanBLL.HienThi(dgv);
            }
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMNXB.Text.Trim() != "")
            {
                //gán dữ liệu vào DTO
                nhaxuatbanDTO.MaNXB = txtMNXB.Text.ToLower();

                //gọi BLL thực hiện
                nhaxuatbanBLL.Xoa(nhaxuatbanDTO);
                //hiện lên dgv
                nhaxuatbanBLL.HienThi(dgv);
            }
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMNXB.Text.Trim() != "")
            {
                //gán dữ liệu vào DTO
                nhaxuatbanDTO.MaNXB = txtMNXB.Text.ToLower();
                //gọi BLL thực hiện
                var sachTim = nhaxuatbanBLL.TimKiem2(nhaxuatbanDTO, dgv);
                //khác null là tìm thấy, thực hiện bind lên ui
                if (sachTim != null)
                {
                    txtMNXB.Text = sachTim.MaNXB;
                    txtTNXB.Text = sachTim.TenNXB;
                    txtDCNXB.Text = sachTim.DiaChiNXB;
                    txtENXB.Text = sachTim.EmailNXB;
                    txtSDTNXB.Text = sachTim.SDTNXB;
                }
                else
                {
                    //không thấy thì xóa trăng
                    txtMNXB.Text = txtTNXB.Text = txtDCNXB.Text = txtENXB.Text = txtSDTNXB.Text = string.Empty;
                }
            }
        }

        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ColorWheelForm form = new ColorWheelForm();
            form.StartPosition = FormStartPosition.CenterParent;
            form.SkinMaskColor = UserLookAndFeel.Default.SkinMaskColor;
            form.SkinMaskColor2 = UserLookAndFeel.Default.SkinMaskColor2;
            form.ShowDialog(this);
        }

        private void NHAXUATBAN_Load(object sender, EventArgs e)
        {
            SkinHelper.InitSkinPopupMenu(SkinsLink);
        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var a1 = new ProcessStartInfo("msedge.exe");
            a1.Arguments = "https://www.facebook.com/phuong.lethanh.3158";
            Process.Start(a1);

            var a2 = new ProcessStartInfo("msedge.exe");
            a2.Arguments = "https://www.facebook.com/NguyenCaoKien1998";
            Process.Start(a2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void barButtonItem21_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("calc");
        }
    }
}
