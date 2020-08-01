using DevExpress.LookAndFeel;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraEditors.ColorWheel;
using QUANLYTHUVIEN_PHUONGKIEN.BLL;
using QUANLYTHUVIEN_PHUONGKIEN.DTO;
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

namespace QUANLYTHUVIEN_PHUONGKIEN
{
    public partial class PHIEUMUON : Form
    {
        public PHIEUMUON()
        {
            InitializeComponent();
        }
        private PHIEUMUONBLL phieumuonBLL = new PHIEUMUONBLL();
        private PHIEUMUONDTO phieumuonDTO = new PHIEUMUONDTO();
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMPM.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtMPM.Cut();
            if (txtMS.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtMS.Cut();
            if (txtNM.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtNM.Cut();
            if (txtNT.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtNT.Cut();
            if (txtHT.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtHT.Cut();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMPM.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtMPM.Copy();
            if (txtMS.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtMS.Copy();
            if (txtNM.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtNM.Copy();
            if (txtNT.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtNT.Copy();
            if (txtHT.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtHT.Copy();
        }

        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtMPM.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show("Do you want to paste over current selection?", "Cut Example", MessageBoxButtons.YesNo) == DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtMPM.SelectionStart = txtMPM.SelectionStart + txtMPM.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtMPM.Paste();
            }
        }

        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtMS.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show("Do you want to paste over current selection?", "Cut Example", MessageBoxButtons.YesNo) == DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtMS.SelectionStart = txtMS.SelectionStart + txtMS.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtMS.Paste();
            }
        }

        private void barButtonItem17_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtNM.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show("Do you want to paste over current selection?", "Cut Example", MessageBoxButtons.YesNo) == DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtNM.SelectionStart = txtNM.SelectionStart + txtNM.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtNM.Paste();
            }
        }

        private void barButtonItem18_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtNT.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show("Do you want to paste over current selection?", "Cut Example", MessageBoxButtons.YesNo) == DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtNT.SelectionStart = txtNT.SelectionStart + txtNT.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtNT.Paste();
            }
        }

        private void barButtonItem19_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtHT.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show("Do you want to paste over current selection?", "Cut Example", MessageBoxButtons.YesNo) == DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtHT.SelectionStart = txtHT.SelectionStart + txtHT.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtHT.Paste();
            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FontDialog fd = new FontDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                txtMPM.Font = fd.Font;
                txtMS.Font = fd.Font;
                txtNM.Font = fd.Font;
                txtNT.Font = fd.Font;
                txtHT.Font = fd.Font;
            }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ColorDialog fd = new ColorDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                txtMPM.BackColor = fd.Color;
                txtMS.BackColor = fd.Color;
                txtNM.BackColor = fd.Color;
                txtNT.BackColor = fd.Color;
                txtHT.BackColor = fd.Color;
            }
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtMPM.Undo();
            txtMS.Undo();
            txtNM.Undo();
            txtNT.Undo();
            txtHT.Undo();
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMPM == null) return;
            txtMPM.SelectAll();
            if (txtMS == null) return;
            txtMS.SelectAll();
            if (txtNM == null) return;
            txtNM.SelectAll();
            if (txtNT == null) return;
            txtNT.SelectAll();
            if (txtHT == null) return;
            txtHT.SelectAll();
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            phieumuonBLL.HienThi(dgv);
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMPM.Text.Trim() != "")
            {
                //gán dữ liệu vào DTO
                phieumuonDTO.MaPM = txtMPM.Text.ToLower();
                phieumuonDTO.MaSACH = txtMS.Text;
                phieumuonDTO.NgayMuon = txtNM.Text;
                phieumuonDTO.NgayTra = txtNT.Text;
                phieumuonDTO.HanTra = txtHT.Text;

                phieumuonBLL.Them(phieumuonDTO);
                //hiện lên dgv
                phieumuonBLL.HienThi(dgv);
            }
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMPM.Text.Trim() != "")
            {
                //gán dữ liệu vào DTO
                phieumuonDTO.MaPM = txtMPM.Text.ToLower();
                phieumuonDTO.MaSACH = txtMS.Text.ToLower();
                phieumuonDTO.NgayMuon = txtNM.Text;
                phieumuonDTO.NgayTra = txtNT.Text;
                phieumuonDTO.HanTra = txtHT.Text;
                //gọi BLL thực hiện
                phieumuonBLL.Sua(phieumuonDTO);
                //hiện lên dgv
                phieumuonBLL.HienThi(dgv);
            }
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMPM.Text.Trim() != "")
            {
                //gán dữ liệu vào DTO
                phieumuonDTO.MaPM = txtMPM.Text.ToLower();

                //gọi BLL thực hiện
                phieumuonBLL.Xoa(phieumuonDTO);
                //hiện lên dgv
                phieumuonBLL.HienThi(dgv);
            }
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMPM.Text.Trim() != "")
            {
                //gán dữ liệu vào DTO
                phieumuonDTO.MaPM = txtMPM.Text.ToLower();
                //gọi BLL thực hiện
                var sachTim = phieumuonBLL.TimKiem2(phieumuonDTO, dgv);
                //khác null là tìm thấy, thực hiện bind lên ui
                if (sachTim != null)
                {
                    txtMPM.Text = sachTim.MaPM;
                    txtMS.Text = sachTim.MaSACH;
                    txtNM.Text = sachTim.NgayMuon;
                    txtNT.Text = sachTim.NgayTra;
                    txtHT.Text = sachTim.HanTra;
                }
                else
                {
                    //không thấy thì xóa trăng
                    txtMPM.Text = txtMS.Text = txtNM.Text = txtNT.Text = txtHT.Text = string.Empty;
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

        private void PHIEUMUON_Load(object sender, EventArgs e)
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

        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ABOUT about = new ABOUT();
            //this.Hide();
            about.Show();
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc");
        }

        private void barButtonItem21_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("calc");
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
