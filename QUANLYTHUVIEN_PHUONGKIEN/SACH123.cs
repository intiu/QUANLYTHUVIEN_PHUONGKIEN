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
    public partial class SACH : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public SACH()
        {
            InitializeComponent();           
        }
        private SACHBLL sachBLL = new SACHBLL();
        private SACHDTO sachDTO = new SACHDTO();
        private void btnNhap_Click(object sender, EventArgs e)
        {
            sachBLL.HienThi(dgv);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMS.Text.Trim() != "")
            {
                //gán dữ liệu vào DTO
                sachDTO.MaSACH = txtMS.Text.ToLower();
                sachDTO.MaPT = txtPT.Text.ToLower();
                sachDTO.MaPM = txtPM.Text.ToLower();
                sachDTO.TenSach = txtTS.Text;
                sachDTO.TacGia = txtTG.Text;
                sachDTO.TenLoaiSach = txtTLS.Text;
                sachDTO.NgonNgu = txtNN.Text;
                sachDTO.VITRIDATSACH = txtVTDS.Text.ToLower();
                sachDTO.NhaXuatBan = txtNXB.Text;
                sachDTO.TinhTrang = txtTT.Text;
                sachDTO.SLNhap = int.Parse(txtSLN.Text);

                //sachDTO.DongGia = double.Parse(txtTS.Text);
                //gọi BLL thực hiện
                sachBLL.Them(sachDTO);
                //hiện lên dgv
                sachBLL.HienThi(dgv);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMS.Text.Trim() != "")
            {
                //gán dữ liệu vào DTO
                sachDTO.MaSACH = txtMS.Text.ToLower();
                sachDTO.MaPT = txtPT.Text.ToLower();
                sachDTO.MaPM = txtPM.Text.ToLower();
                sachDTO.TenSach = txtTS.Text;
                sachDTO.TacGia = txtTG.Text;
                sachDTO.TenLoaiSach = txtTLS.Text;
                sachDTO.NgonNgu = txtNN.Text;
                sachDTO.SLNhap = int.Parse(txtSLN.Text);
                sachDTO.VITRIDATSACH = txtVTDS.Text.ToLower();
                sachDTO.NhaXuatBan = txtNXB.Text;
                sachDTO.TinhTrang = txtTT.Text;
                //gọi BLL thực hiện
                sachBLL.Sua(sachDTO);
                //hiện lên dgv
                sachBLL.HienThi(dgv);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMS.Text.Trim() != "")
            {
                //gán dữ liệu vào DTO
                sachDTO.MaSACH = txtMS.Text.ToLower();

                //gọi BLL thực hiện
                sachBLL.Xoa(sachDTO);
                //hiện lên dgv
                sachBLL.HienThi(dgv);
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (txtMS.Text.Trim() != "")
            {
                //gán dữ liệu vào DTO
                sachDTO.MaSACH = txtMS.Text.ToLower();
                //gọi BLL thực hiện
                var sachTim = sachBLL.TimKiem2(sachDTO, dgv);
                //khác null là tìm thấy, thực hiện bind lên ui
                if (sachTim != null)
                {
                    txtMS.Text = sachTim.MaSACH;
                    txtPT.Text = sachTim.MaPT;
                    txtPM.Text = sachTim.MaPM;
                    txtTS.Text = sachTim.TenSach;
                    txtTG.Text = sachTim.TacGia;
                    txtTLS.Text = sachTim.TenLoaiSach;
                    txtNN.Text = sachTim.NgonNgu;
                    txtVTDS.Text = sachTim.VITRIDATSACH;
                    txtNXB.Text = sachTim.NhaXuatBan;
                    txtTT.Text = sachTim.TinhTrang;
                    txtSLN.Text = sachTim.SLNhap.ToString();
                }
                else
                {
                    //không thấy thì xóa trăng
                    txtMS.Text = txtPT.Text = txtPM.Text = txtTS.Text = txtTG.Text = txtTLS.Text = txtNN.Text = txtSLN.Text = txtVTDS.Text = txtNXB.Text = txtTT.Text = string.Empty;
                }
            }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMS.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtMS.Cut();
            if (txtPT.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtPT.Cut();
            if (txtPM.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtPM.Cut();
            if (txtTS.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtTS.Cut();
            if (txtTG.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtTG.Cut();
            if (txtTLS.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtTLS.Cut();
            if (txtNN.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtNN.Cut();
            if (txtSLN.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtSLN.Cut();
            if (txtVTDS.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtVTDS.Cut();
            if (txtNXB.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtNXB.Cut();
            if (txtTT.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                txtTT.Cut();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMS.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtMS.Copy();
            if (txtPT.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtPT.Copy();
            if (txtPM.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtPM.Copy();
            if (txtTS.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtTS.Copy();
            if (txtTG.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtTG.Copy();
            if (txtTLS.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtTLS.Copy();
            if (txtNN.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtNN.Copy();
            if (txtSLN.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtSLN.Copy();
            if (txtVTDS.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtVTDS.Copy();
            if (txtNXB.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtNXB.Copy();
            if (txtTT.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                txtTT.Copy();
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            sachBLL.HienThi(dgv);
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMS.Text.Trim() != "")
            {
                //gán dữ liệu vào DTO
                sachDTO.MaSACH = txtMS.Text.ToLower();
                sachDTO.MaPT = txtPT.Text.ToLower();
                sachDTO.MaPM = txtPM.Text.ToLower();
                sachDTO.TenSach = txtTS.Text;
                sachDTO.TacGia = txtTG.Text;
                sachDTO.TenLoaiSach = txtTLS.Text;
                sachDTO.NgonNgu = txtNN.Text;
                sachDTO.VITRIDATSACH = txtVTDS.Text.ToLower();
                sachDTO.NhaXuatBan = txtNXB.Text;
                sachDTO.TinhTrang = txtTT.Text;
                sachDTO.SLNhap = int.Parse(txtSLN.Text);

                //sachDTO.DongGia = double.Parse(txtTS.Text);
                //gọi BLL thực hiện
                sachBLL.Them(sachDTO);
                //hiện lên dgv
                sachBLL.HienThi(dgv);
            }
        }

        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMS.Text.Trim() != "")
            {
                //gán dữ liệu vào DTO
                sachDTO.MaSACH = txtMS.Text.ToLower();

                //gọi BLL thực hiện
                sachBLL.Xoa(sachDTO);
                //hiện lên dgv
                sachBLL.HienThi(dgv);
            }
        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMS.Text.Trim() != "")
            {
                //gán dữ liệu vào DTO
                sachDTO.MaSACH = txtMS.Text.ToLower();
                //gọi BLL thực hiện
                var sachTim = sachBLL.TimKiem2(sachDTO, dgv);
                //khác null là tìm thấy, thực hiện bind lên ui
                if (sachTim != null)
                {
                    txtMS.Text = sachTim.MaSACH;
                    txtPT.Text = sachTim.MaPT;
                    txtPM.Text = sachTim.MaPM;
                    txtTS.Text = sachTim.TenSach;
                    txtTG.Text = sachTim.TacGia;
                    txtTLS.Text = sachTim.TenLoaiSach;
                    txtNN.Text = sachTim.NgonNgu;
                    txtVTDS.Text = sachTim.VITRIDATSACH;
                    txtNXB.Text = sachTim.NhaXuatBan;
                    txtTT.Text = sachTim.TinhTrang;
                    txtSLN.Text = sachTim.SLNhap.ToString();
                }
                else
                {
                    //không thấy thì xóa trăng
                    txtMS.Text = txtPT.Text = txtPM.Text = txtTS.Text = txtTG.Text = txtTLS.Text = txtNN.Text = txtSLN.Text = txtVTDS.Text = txtNXB.Text = txtTT.Text = string.Empty;
                }
            }
        }

        
        
        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtMS.Undo();
            txtPT.Undo();
            txtPM.Undo();
            txtTS.Undo();
            txtTG.Undo();
            txtTLS.Undo();
            txtNN.Undo();
            txtSLN.Undo();
            txtVTDS.Undo();
            txtNXB.Undo();
            txtTT.Undo();
        }

        
        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FontDialog fd = new FontDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                txtMS.Font = fd.Font;
                txtPT.Font = fd.Font;
                txtPM.Font = fd.Font;
                txtTS.Font = fd.Font;
                txtTG.Font = fd.Font;
                txtTLS.Font = fd.Font;
                txtNN.Font = fd.Font;
                txtSLN.Font = fd.Font;
                txtVTDS.Font = fd.Font;
                txtNXB.Font = fd.Font;
                txtTT.Font = fd.Font;
            }
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void barButtonItem15_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void barButtonItem18_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem19_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtPT.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show("Do you want to paste over current selection?", "Cut Example", MessageBoxButtons.YesNo) == DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtPT.SelectionStart = txtPT.SelectionStart + txtPT.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtPT.Paste();
            }
        }

        private void barButtonItem20_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtPM.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show("Do you want to paste over current selection?", "Cut Example", MessageBoxButtons.YesNo) == DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtPM.SelectionStart = txtPM.SelectionStart + txtPM.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtPM.Paste();
            }
        }

        private void barButtonItem21_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtTS.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show("Do you want to paste over current selection?", "Cut Example", MessageBoxButtons.YesNo) == DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtTS.SelectionStart = txtTS.SelectionStart + txtTS.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtTS.Paste();
            }
        }

        private void barButtonItem22_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtTG.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show("Do you want to paste over current selection?", "Cut Example", MessageBoxButtons.YesNo) == DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtTG.SelectionStart = txtTG.SelectionStart + txtTG.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtTG.Paste();
            }
        }

        private void barButtonItem23_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtTLS.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show("Do you want to paste over current selection?", "Cut Example", MessageBoxButtons.YesNo) == DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtTLS.SelectionStart = txtTLS.SelectionStart + txtTLS.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtTLS.Paste();
            }
        }

        private void barButtonItem24_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtNN.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show("Do you want to paste over current selection?", "Cut Example", MessageBoxButtons.YesNo) == DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtNN.SelectionStart = txtNN.SelectionStart + txtNN.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtNN.Paste();
            }
        }

        private void barButtonItem25_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtSLN.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show("Do you want to paste over current selection?", "Cut Example", MessageBoxButtons.YesNo) == DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtSLN.SelectionStart = txtSLN.SelectionStart + txtSLN.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtSLN.Paste();
            }
        }

        private void barButtonItem26_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtVTDS.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show("Do you want to paste over current selection?", "Cut Example", MessageBoxButtons.YesNo) == DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtVTDS.SelectionStart = txtVTDS.SelectionStart + txtVTDS.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtVTDS.Paste();
            }
        }

        private void barButtonItem27_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (txtNXB.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show("Do you want to paste over current selection?", "Cut Example", MessageBoxButtons.YesNo) == DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        txtNXB.SelectionStart = txtNXB.SelectionStart + txtNXB.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                txtNXB.Paste();
            }
        }

        private void barButtonItem28_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            /*ColorDialog col = new ColorDialog();
            col.ShowDialog();
            txtMS.SelectionColor = col.Color;*/
            ColorDialog fd = new ColorDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                txtMS.BackColor = fd.Color;
                txtPT.BackColor = fd.Color;
                txtPM.BackColor = fd.Color;
                txtTS.BackColor = fd.Color;
                txtTG.BackColor = fd.Color;
                txtTLS.BackColor = fd.Color;
                txtNN.BackColor = fd.Color;
                txtSLN.BackColor = fd.Color;
                txtVTDS.BackColor = fd.Color;
                txtNXB.BackColor = fd.Color;
                txtTT.BackColor = fd.Color;
            }
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMS == null) return;
            txtMS.SelectAll();
            if (txtPT == null) return;
            txtPT.SelectAll();
            if (txtPM == null) return;
            txtPM.SelectAll();
            if (txtTS == null) return;
            txtTS.SelectAll();
            if (txtTG == null) return;
            txtTG.SelectAll();
            if (txtTLS == null) return;
            txtTLS.SelectAll();
            if (txtNN == null) return;
            txtNN.SelectAll();
            if (txtSLN == null) return;
            txtSLN.SelectAll();
            if (txtVTDS == null) return;
            txtVTDS.SelectAll();
            if (txtNXB == null) return;
            txtNXB.SelectAll();
            if (txtTT == null) return;
            txtTT.SelectAll();
        }

        private void bbColorMix_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ColorWheelForm form = new ColorWheelForm();
            form.StartPosition = FormStartPosition.CenterParent;
            form.SkinMaskColor = UserLookAndFeel.Default.SkinMaskColor;
            form.SkinMaskColor2 = UserLookAndFeel.Default.SkinMaskColor2;
            form.ShowDialog(this);
        }

        private void barButtonItem15_ItemClick_2(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void SACH_Load(object sender, EventArgs e)
        {
            //SkinHelper.InitSkinPopupMenu(SkinsLink);
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var a1 = new ProcessStartInfo("msedge.exe");
            a1.Arguments = "https://www.facebook.com/phuong.lethanh.3158";
            Process.Start(a1);

            var a2 = new ProcessStartInfo("msedge.exe");
            a2.Arguments = "https://www.facebook.com/NguyenCaoKien1998";
            Process.Start(a2);
        }

        private void barButtonItem15_ItemClick_3(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            About about = new About();
            //this.Hide();
            about.Show();
            this.Show();
        }

        private void bbColorMix_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ColorWheelForm form = new ColorWheelForm();
            form.StartPosition = FormStartPosition.CenterParent;
            form.SkinMaskColor = UserLookAndFeel.Default.SkinMaskColor;
            form.SkinMaskColor2 = UserLookAndFeel.Default.SkinMaskColor2;
            form.ShowDialog(this);
        }

        private void txtMS_TextChanged(object sender, EventArgs e)
        {

        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void dgv_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtTG_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
