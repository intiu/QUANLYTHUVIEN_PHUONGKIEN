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
    public partial class BAOCAO : Form
    {
        public BAOCAO()
        {
            InitializeComponent();
        }
        private BAOCAOBLL baocaoBLL = new BAOCAOBLL();
        private BAOCAODTO baocaoDTO = new BAOCAODTO();
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMBC.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtMBC.Cut();
            if (txtNBC.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtNBC.Cut();
            if (txtTTD.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtTTD.Cut();
            if (txtTT.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtTT.Cut();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMBC.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtMBC.Copy();
            if (txtNBC.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtNBC.Copy();
            if (txtTTD.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtTTD.Copy();
            if (txtTT.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtTT.Copy();
        }

        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtMBC.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show("Do you want to paste over current selection?", "Cut Example", MessageBoxButtons.YesNo) == DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtMBC.SelectionStart = txtMBC.SelectionStart + txtMBC.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtMBC.Paste();
            }
        }

        private void barButtonItem17_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtNBC.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show("Do you want to paste over current selection?", "Cut Example", MessageBoxButtons.YesNo) == DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtNBC.SelectionStart = txtNBC.SelectionStart + txtNBC.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtNBC.Paste();
            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FontDialog fd = new FontDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                txtMBC.Font = fd.Font;
                txtNBC.Font = fd.Font;
                txtTTD.Font = fd.Font;
                txtTT.Font = fd.Font;
            }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ColorDialog fd = new ColorDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                txtMBC.BackColor = fd.Color;
                txtNBC.BackColor = fd.Color;
                txtTTD.BackColor = fd.Color;
                txtTT.BackColor = fd.Color;
            }
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtMBC.Undo();
            txtNBC.Undo();
            txtTTD.Undo();
            txtTT.Undo();
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMBC == null) return;
            txtMBC.SelectAll();
            if (txtNBC == null) return;
            txtNBC.SelectAll();
            if (txtTTD == null) return;
            txtTTD.SelectAll();
            if (txtTT == null) return;
            txtTT.SelectAll();
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            baocaoBLL.HienThi(dgv);
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMBC.Text.Trim() != "")
            {
                //gán dữ liệu vào DTO
                baocaoDTO.MaBC = txtMBC.Text.ToLower();
                baocaoDTO.NgayBC = txtNBC.Text;
                baocaoDTO.TienThuDuoc = txtTTD.Text;
                baocaoDTO.TongTien = txtTT.Text;
                baocaoBLL.Them(baocaoDTO);
                //hiện lên dgv
                baocaoBLL.HienThi(dgv);
            }
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMBC.Text.Trim() != "")
            {
                //gán dữ liệu vào DTO
                baocaoDTO.MaBC = txtMBC.Text.ToLower();
                baocaoDTO.NgayBC = txtNBC.Text;
                baocaoDTO.TienThuDuoc = txtTTD.Text;
                baocaoDTO.TongTien = txtTT.Text;
                //gọi BLL thực hiện
                baocaoBLL.Sua(baocaoDTO);
                //hiện lên dgv
                baocaoBLL.HienThi(dgv);
            }
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMBC.Text.Trim() != "")
            {
                //gán dữ liệu vào DTO
                baocaoDTO.MaBC = txtMBC.Text.ToLower();

                //gọi BLL thực hiện
                baocaoBLL.Xoa(baocaoDTO);
                //hiện lên dgv
                baocaoBLL.HienThi(dgv);
            }
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMBC.Text.Trim() != "")
            {
                //gán dữ liệu vào DTO
                baocaoDTO.MaBC = txtMBC.Text.ToLower();
                //gọi BLL thực hiện
                var sachTim = baocaoBLL.TimKiem2(baocaoDTO, dgv);
                //khác null là tìm thấy, thực hiện bind lên ui
                if (sachTim != null)
                {
                    txtMBC.Text = sachTim.MaBC;
                    txtNBC.Text = sachTim.NgayBC;
                    txtTTD.Text = sachTim.TienThuDuoc;
                    txtTT.Text = sachTim.TongTien;
                }
                else
                {
                    //không thấy thì xóa trăng
                    txtMBC.Text = txtNBC.Text = txtTTD.Text = txtTT.Text = string.Empty;
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

        private void BAOCAO_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pTHNVShopDataSet.Products' table. You can move, or remove it, as needed.
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

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void barButtonItem18_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtTT.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show("Do you want to paste over current selection?", "Cut Example", MessageBoxButtons.YesNo) == DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtTT.SelectionStart = txtTT.SelectionStart + txtTT.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtTT.Paste();
            }
        }

        private void chartControl1_Click(object sender, EventArgs e)
        {

        }

        private void printPreviewChartItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem19_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("calc");
        }

        private void barButtonItem20_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtTTD.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show("Do you want to paste over current selection?", "Cut Example", MessageBoxButtons.YesNo) == DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtTTD.SelectionStart = txtTTD.SelectionStart + txtTTD.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtTTD.Paste();
            }
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
