using DevExpress.LookAndFeel;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraCharts;
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
    public partial class PHIEUTHU : Form
    {
        public PHIEUTHU()
        {
            InitializeComponent();
        }
        private PHIEUTHUBLL phieuthuBLL = new PHIEUTHUBLL();
        private PHIEUTHUDTO phieuthuDTO = new PHIEUTHUDTO();
        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMPT.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtMPT.Cut();
            if (txtMS.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtMS.Cut();
            if (txtNT.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtNT.Cut();
            if (txtGTT.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtGTT.Cut();
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMPT.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtMPT.Copy();
            if (txtMS.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtMS.Copy();
            if (txtNT.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtNT.Copy();
            if (txtGTT.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtGTT.Copy();
        }

        private void barButtonItem18_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtGTT.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show("Do you want to paste over current selection?", "Cut Example", MessageBoxButtons.YesNo) == DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtGTT.SelectionStart = txtGTT.SelectionStart + txtGTT.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtGTT.Paste();
            }
        }

        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtMPT.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show("Do you want to paste over current selection?", "Cut Example", MessageBoxButtons.YesNo) == DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtMPT.SelectionStart = txtMPT.SelectionStart + txtMPT.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtMPT.Paste();
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

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FontDialog fd = new FontDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                txtMPT.Font = fd.Font;
                txtMS.Font = fd.Font;
                txtNT.Font = fd.Font;
                txtGTT.Font = fd.Font;
            }
        }

        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ColorDialog fd = new ColorDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                txtMPT.BackColor = fd.Color;
                txtMS.BackColor = fd.Color;
                txtNT.BackColor = fd.Color;
                txtGTT.BackColor = fd.Color;
            }
        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtMPT.Undo();
            txtMS.Undo();
            txtNT.Undo();
            txtGTT.Undo();
        }

        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMPT == null) return;
            txtMPT.SelectAll();
            if (txtMS == null) return;
            txtMS.SelectAll();
            if (txtNT == null) return;
            txtNT.SelectAll();
            if (txtGTT == null) return;
            txtGTT.SelectAll();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            phieuthuBLL.HienThi(dgv);
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMPT.Text.Trim() != "")
            {
                //gán dữ liệu vào DTO
                phieuthuDTO.MaPT = txtMPT.Text.ToLower();
                phieuthuDTO.MaSACH = txtMS.Text.ToLower();
                phieuthuDTO.NgayThu = txtNT.Text;
                phieuthuDTO.GiaTienThu = txtGTT.Text;

                phieuthuBLL.Them(phieuthuDTO);
                //hiện lên dgv
                phieuthuBLL.HienThi(dgv);
            }
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMPT.Text.Trim() != "")
            {
                //gán dữ liệu vào DTO
                phieuthuDTO.MaPT = txtMPT.Text.ToLower();
                phieuthuDTO.MaSACH = txtMS.Text.ToLower();
                phieuthuDTO.NgayThu = txtNT.Text;
                phieuthuDTO.GiaTienThu = txtGTT.Text;
                //gọi BLL thực hiện
                phieuthuBLL.Sua(phieuthuDTO);
                //hiện lên dgv
                phieuthuBLL.HienThi(dgv);
            }
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMPT.Text.Trim() != "")
            {
                //gán dữ liệu vào DTO
                phieuthuDTO.MaPT = txtMPT.Text.ToLower();

                //gọi BLL thực hiện
                phieuthuBLL.Xoa(phieuthuDTO);
                //hiện lên dgv
                phieuthuBLL.HienThi(dgv);
            }
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMPT.Text.Trim() != "")
            {
                //gán dữ liệu vào DTO
                phieuthuDTO.MaPT = txtMPT.Text.ToLower();
                //gọi BLL thực hiện
                var sachTim = phieuthuBLL.TimKiem2(phieuthuDTO, dgv);
                //khác null là tìm thấy, thực hiện bind lên ui
                if (sachTim != null)
                {
                    txtMPT.Text = sachTim.MaPT;
                    txtMS.Text = sachTim.MaSACH;
                    txtNT.Text = sachTim.NgayThu;
                    txtGTT.Text = sachTim.GiaTienThu;
                }
                else
                {
                    //không thấy thì xóa trăng
                    txtMPT.Text = txtMS.Text = txtNT.Text = txtGTT.Text = string.Empty;
                }
            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ColorWheelForm form = new ColorWheelForm();
            form.StartPosition = FormStartPosition.CenterParent;
            form.SkinMaskColor = UserLookAndFeel.Default.SkinMaskColor;
            form.SkinMaskColor2 = UserLookAndFeel.Default.SkinMaskColor2;
            form.ShowDialog(this);
        }

        private void PHIEUTHU_Load(object sender, EventArgs e)
        {
            SkinHelper.InitSkinPopupMenu(SkinsLink);
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var a1 = new ProcessStartInfo("msedge.exe");
            a1.Arguments = "https://www.facebook.com/phuong.lethanh.3158";
            Process.Start(a1);

            var a2 = new ProcessStartInfo("msedge.exe");
            a2.Arguments = "https://www.facebook.com/NguyenCaoKien1998";
            Process.Start(a2);
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ABOUT about = new ABOUT();
            //this.Hide();
            about.Show();
            this.Show();
        }

        private void chartControl1_Click(object sender, EventArgs e)
        {
            
        }

        private void txtNT_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc");
        }

        private void barButtonItem20_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("calc");
        }
    }
}
