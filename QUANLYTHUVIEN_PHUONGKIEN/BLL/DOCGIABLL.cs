using System;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using System.Xml;
using QUANLYTHUVIEN_PHUONGKIEN.DTO;

namespace QUANLYTHUVIEN_PHUONGKIEN.BLL
{
    public class DOCGIABLL
    {
        private XmlDocument doc = new XmlDocument();
        private XmlElement root;
        //private string "QLTV_PK.xml" = @"C:\Users\ltpnt\source\repos\QUANLYTHUVIEN_PHUONGKIEN\QUANLYTHUVIEN_PHUONGKIEN\QLTV_PK.xml";

        public DOCGIABLL()
        {
            doc.Load("QLTV_PK.xml");
            root = doc.DocumentElement;
        }

        public void Them(DOCGIADTO sachThem)
        {
            //tạo nút sách
            XmlNode sach = doc.CreateElement("DOCGIA");

            //tạo nút con của sách là MaSACH
            XmlElement madocgia = doc.CreateElement("MaDG");
            madocgia.InnerText = sachThem.MaDG;//gán giá trị cho mã sách
            sach.AppendChild(madocgia);//thêm MaSACH vào trong sách(sach nhận MaSACH là con)

            XmlElement mathethuvien = doc.CreateElement("MaTTV");
            mathethuvien.InnerText = sachThem.MaTTV;//gán giá trị cho mã sách
            sach.AppendChild(mathethuvien);//thêm MaSACH vào trong sách(sach nhận MaSACH là con)

            XmlElement tendocgia = doc.CreateElement("TenDG");
            tendocgia.InnerText = sachThem.TenDG;//gán giá trị cho mã sách
            sach.AppendChild(tendocgia);//thêm MaSACH vào trong sách(sach nhận MaSACH là con)

            XmlElement sodienthoaidocgia = doc.CreateElement("SDTDG");
            sodienthoaidocgia.InnerText = sachThem.SDTDG;//gán giá trị cho mã sách
            sach.AppendChild(sodienthoaidocgia);//thêm MaSACH vào trong sách(sach nhận MaSACH là con)

            XmlElement gioitinhdocgia = doc.CreateElement("GTDG");
            gioitinhdocgia.InnerText = sachThem.GTDG;
            sach.AppendChild(gioitinhdocgia);

            XmlElement ngaysinhdocgia = doc.CreateElement("NgaySinhDG");
            ngaysinhdocgia.InnerText = sachThem.NgaySinhDG;
            sach.AppendChild(ngaysinhdocgia);

            XmlElement ngaycapthethuvien = doc.CreateElement("NgayCapTTV");
            ngaycapthethuvien.InnerText = sachThem.NgayCapTTV;//gán giá trị cho mã sách
            sach.AppendChild(ngaycapthethuvien);//thêm MaSACH vào trong sách(sach nhận MaSACH là con)

            XmlElement ngayhethanthethuvien = doc.CreateElement("NgayHetHanTTV");
            ngayhethanthethuvien.InnerText = sachThem.NgayHetHanTTV;//gán giá trị cho mã sách
            sach.AppendChild(ngayhethanthethuvien);//thêm MaSACH vào trong sách(sach nhận MaSACH là con)

            //sau khi tạo xong sách, thì thêm sách vào gốc root
            root.AppendChild(sach);
            doc.Save("QLTV_PK.xml");//lưu dữ liệu
        }


        public void Sua(DOCGIADTO sachSua)
        {
            //láy vị trí cần sửa theo mã sách cũ đưa vào
            XmlNode sachCu = root.SelectSingleNode("DOCGIA[MaDG ='" + sachSua.MaDG + "']");
            if (sachCu != null)
            {
                XmlNode sachSuaMoi = doc.CreateElement("DOCGIA");

                //tạo nút con của sách là MaSACH
                XmlElement madocgia = doc.CreateElement("MaDG");
                madocgia.InnerText = sachSua.MaDG;//gán giá trị cho mã sách
                sachSuaMoi.AppendChild(madocgia);//thêm MaSACH vào trong sách(sach nhận MaSACH là con) 

                XmlElement mathethuvien = doc.CreateElement("MaTTV");
                mathethuvien.InnerText = sachSua.MaTTV;//gán giá trị cho mã sách
                sachSuaMoi.AppendChild(mathethuvien);//thêm MaSACH vào trong sách(sach nhận MaSACH là con)

                XmlElement tendocgia = doc.CreateElement("TenDG");
                tendocgia.InnerText = sachSua.TenDG;//gán giá trị cho mã sách
                sachSuaMoi.AppendChild(tendocgia);//thêm MaSACH vào trong sách(sach nhận MaSACH là con)

                XmlElement sodienthoaidocgia = doc.CreateElement("SDTDG");
                sodienthoaidocgia.InnerText = sachSua.SDTDG;//gán giá trị cho mã sách
                sachSuaMoi.AppendChild(sodienthoaidocgia);//thêm MaSACH vào trong sách(sach nhận MaSACH là con)

                XmlElement gioitinhdocgia = doc.CreateElement("GTDG");
                gioitinhdocgia.InnerText = sachSua.GTDG;
                sachSuaMoi.AppendChild(gioitinhdocgia);

                XmlElement ngaysinhdocgia = doc.CreateElement("NgaySinhDG");
                ngaysinhdocgia.InnerText = sachSua.NgaySinhDG;
                sachSuaMoi.AppendChild(ngaysinhdocgia);

                XmlElement ngaycapthethuvien = doc.CreateElement("NgayCapTTV");
                ngaycapthethuvien.InnerText = sachSua.NgayCapTTV;//gán giá trị cho mã sách
                sachSuaMoi.AppendChild(ngaycapthethuvien);//thêm MaSACH vào trong sách(sach nhận MaSACH là con)

                XmlElement ngayhethanthethuvien = doc.CreateElement("NgayHetHanTTV");
                ngayhethanthethuvien.InnerText = sachSua.MaTTV;//gán giá trị cho mã sách
                sachSuaMoi.AppendChild(ngayhethanthethuvien);//thêm MaSACH vào trong sách(sach nhận MaSACH là con)

                //thay thế sách cũ bằng sách mới(sửa )
                root.ReplaceChild(sachSuaMoi, sachCu);
                doc.Save("QLTV_PK.xml");//lưu lại
            }
        }

        public void Xoa(DOCGIADTO sachXoa)
        {
            XmlNode sachCanXoa = root.SelectSingleNode("DOCGIA[MaDG ='" + sachXoa.MaDG + "']");
            if (sachCanXoa != null)
            {
                root.RemoveChild(sachCanXoa);

                doc.Save("QLTV_PK.xml");
            }
        }

        public void TimKiem(DOCGIADTO sachTim, DataGridView dgv)
        {
            dgv.Rows.Clear();
            XmlNode sachCanTim = root.SelectSingleNode("DOCGIA[MaDG ='" + sachTim.MaDG + "']");

            if (sachCanTim != null)
            {
                dgv.ColumnCount = 8;//khai báo số cột
                dgv.Rows.Add();//thêm một dòng mới

                //đưa dữ liệu vào dòng vừa tạo
                dgv.Rows[0].Cells[0].Value = sachCanTim.SelectSingleNode("MaDG").InnerText;
                dgv.Rows[0].Cells[1].Value = sachCanTim.SelectSingleNode("MaTTV").InnerText;
                dgv.Rows[0].Cells[2].Value = sachCanTim.SelectSingleNode("TenDG").InnerText;
                dgv.Rows[0].Cells[3].Value = sachCanTim.SelectSingleNode("SDTDG").InnerText;
                dgv.Rows[0].Cells[4].Value = sachCanTim.SelectSingleNode("GTDG").InnerText;
                dgv.Rows[0].Cells[5].Value = sachCanTim.SelectSingleNode("NgaySinhDG").InnerText;
                dgv.Rows[0].Cells[6].Value = sachCanTim.SelectSingleNode("NgayCapTTV").InnerText;
                dgv.Rows[0].Cells[7].Value = sachCanTim.SelectSingleNode("NgayHetHanTTV").InnerText;
            }
        }

        /// <summary>
        /// Tìm và trả về đối tượng sách tìm thấy, không thấy = null
        /// </summary>
        /// <param name="sachTim">Đối tượng chứa thông tin tìm kiếm</param>
        /// <param name="dgv">grid view hiển thị</param>
        /// <returns>tìm thấy nếu khác null</returns>
        public DOCGIADTO TimKiem2(DOCGIADTO sachTim, DataGridView dgv)
        {
            DOCGIADTO ketQua = null;
            dgv.Rows.Clear();
            XmlNode sachCanTim = root.SelectSingleNode("DOCGIA[MaDG ='" + sachTim.MaDG + "']");
            if (sachCanTim != null)
            {
                dgv.ColumnCount = 8;//khai báo số cột
                dgv.Rows.Add();//thêm một dòng mới

                //đưa dữ liệu vào dòng vừa tạo
                dgv.Rows[0].Cells[0].Value = sachTim.MaDG = sachCanTim.SelectSingleNode("MaDG").InnerText;
                dgv.Rows[0].Cells[1].Value = sachTim.MaTTV = sachCanTim.SelectSingleNode("MaTTV").InnerText;
                dgv.Rows[0].Cells[2].Value = sachCanTim.SelectSingleNode("TenDG").InnerText;
                dgv.Rows[0].Cells[3].Value = sachCanTim.SelectSingleNode("SDTDG").InnerText;
                dgv.Rows[0].Cells[4].Value = sachCanTim.SelectSingleNode("GTDG").InnerText;
                dgv.Rows[0].Cells[5].Value = sachCanTim.SelectSingleNode("NgaySinhDG").InnerText;
                dgv.Rows[0].Cells[6].Value = sachCanTim.SelectSingleNode("NgayCapTTV").InnerText;
                dgv.Rows[0].Cells[7].Value = sachCanTim.SelectSingleNode("NgayHetHanTTV").InnerText;

                ketQua = new DOCGIADTO();

                ketQua.MaDG = sachCanTim.SelectSingleNode("MaDG").InnerText;
                ketQua.MaTTV = sachCanTim.SelectSingleNode("MaTTV").InnerText;
                ketQua.TenDG = sachCanTim.SelectSingleNode("TenDG").InnerText;
                ketQua.SDTDG = sachCanTim.SelectSingleNode("SDTDG").InnerText;
                ketQua.GTDG = sachCanTim.SelectSingleNode("GTDG").InnerText;
                ketQua.NgaySinhDG = sachCanTim.SelectSingleNode("NgaySinhDG").InnerText;
                ketQua.NgayCapTTV = sachCanTim.SelectSingleNode("NgayCapTTV").InnerText;
                ketQua.NgayHetHanTTV = sachCanTim.SelectSingleNode("NgayHetHanTTV").InnerText;
            }

            return ketQua;
        }

        public void HienThi(DataGridView dgv)
        {
            dgv.Rows.Clear();
            dgv.ColumnCount = 8;

            XmlNodeList ds = root.SelectNodes("DOCGIA");
            int sd = 0;//lưu chỉ số dòng
            foreach (XmlNode item in ds)
            {
                dgv.Rows.Add();
                dgv.Rows[sd].Cells[0].Value = item.SelectSingleNode("MaDG").InnerText;
                dgv.Rows[sd].Cells[1].Value = item.SelectSingleNode("MaTTV").InnerText;
                dgv.Rows[sd].Cells[2].Value = item.SelectSingleNode("TenDG").InnerText;
                dgv.Rows[sd].Cells[3].Value = item.SelectSingleNode("SDTDG").InnerText;
                dgv.Rows[sd].Cells[4].Value = item.SelectSingleNode("GTDG").InnerText;
                dgv.Rows[sd].Cells[5].Value = item.SelectSingleNode("NgaySinhDG").InnerText;
                dgv.Rows[sd].Cells[6].Value = item.SelectSingleNode("NgayCapTTV").InnerText;
                dgv.Rows[sd].Cells[7].Value = item.SelectSingleNode("NgayHetHanTTV").InnerText;
                sd++;
            }
        }
    }
}
