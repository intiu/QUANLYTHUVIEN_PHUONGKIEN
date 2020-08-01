using System;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using System.Xml;
using QUANLYTHUVIEN_PHUONGKIEN.DTO;

namespace QUANLYTHUVIEN_PHUONGKIEN.BLL
{
    public class SACHBLL
    {
        private XmlDocument doc = new XmlDocument();
        private XmlElement root;
        //private string "QLTV_PK.xml" = @"C:\Users\ltpnt\source\repos\QUANLYTHUVIEN_PHUONGKIEN\QUANLYTHUVIEN_PHUONGKIEN\QLTV_PK.xml";
        public SACHBLL()
        {
            doc.Load("QLTV_PK.xml");
            root = doc.DocumentElement;
        }

        public void Them(SACHDTO sachThem)
        {
            //tạo nút sách
            XmlNode sach = doc.CreateElement("SACH");

            //tạo nút con của sách là MaSACH
            XmlElement masach = doc.CreateElement("MaSACH");
            masach.InnerText = sachThem.MaSACH;//gán giá trị cho mã sách
            sach.AppendChild(masach);//thêm MaSACH vào trong sách(sach nhận MaSACH là con)

            XmlElement maphieuthu = doc.CreateElement("MaPT");
            maphieuthu.InnerText = sachThem.MaPT;//gán giá trị cho mã sách
            sach.AppendChild(maphieuthu);//thêm MaSACH vào trong sách(sach nhận MaSACH là con)

            XmlElement maphieumuon = doc.CreateElement("MaPM");
            maphieumuon.InnerText = sachThem.MaPM;//gán giá trị cho mã sách
            sach.AppendChild(maphieumuon);//thêm MaSACH vào trong sách(sach nhận MaSACH là con)

            XmlElement tensach = doc.CreateElement("TenSach");
            tensach.InnerText = sachThem.TenSach;
            sach.AppendChild(tensach);

            XmlElement tacgia = doc.CreateElement("TacGia");
            tacgia.InnerText = sachThem.TacGia;
            sach.AppendChild(tacgia);

            XmlElement tenloaisach = doc.CreateElement("TenLoaiSach");
            tenloaisach.InnerText = sachThem.TenLoaiSach;
            sach.AppendChild(tenloaisach);

            XmlElement ngonngu = doc.CreateElement("NgonNgu");
            ngonngu.InnerText = sachThem.NgonNgu;
            sach.AppendChild(ngonngu);

            XmlElement soluongnhap = doc.CreateElement("SLNhap");
            soluongnhap.InnerText = sachThem.SLNhap.ToString();
            sach.AppendChild(soluongnhap);

            XmlElement vitridatsach = doc.CreateElement("VITRIDATSACH");
            vitridatsach.InnerText = sachThem.VITRIDATSACH;
            sach.AppendChild(vitridatsach);

            XmlElement nhaxuatban = doc.CreateElement("NhaXuatBan");
            nhaxuatban.InnerText = sachThem.NhaXuatBan;
            sach.AppendChild(nhaxuatban);

            XmlElement tinhtrang = doc.CreateElement("TinhTrang");
            tinhtrang.InnerText = sachThem.TinhTrang;
            sach.AppendChild(tinhtrang);

            //sau khi tạo xong sách, thì thêm sách vào gốc root
            root.AppendChild(sach);
            doc.Save("QLTV_PK.xml");//lưu dữ liệu
        }


        public void Sua(SACHDTO sachSua)
        {
            //láy vị trí cần sửa theo mã sách cũ đưa vào
            XmlNode sachCu = root.SelectSingleNode("SACH[MaSACH ='" + sachSua.MaSACH + "']");
            if (sachCu != null)
            {
                XmlNode sachSuaMoi = doc.CreateElement("SACH");

                //tạo nút con của sách là MaSACH
                XmlElement MaSACH = doc.CreateElement("MaSACH");
                MaSACH.InnerText = sachSua.MaSACH;//gán giá trị cho mã sách
                sachSuaMoi.AppendChild(MaSACH);//thêm MaSACH vào trong sách(sach nhận MaSACH là con)               

                XmlElement maphieuthu = doc.CreateElement("MaPT");
                maphieuthu.InnerText = sachSua.MaPT;//gán giá trị cho mã sách
                sachSuaMoi.AppendChild(maphieuthu);//thêm MaSACH vào trong sách(sach nhận MaSACH là con)

                XmlElement maphieumuon = doc.CreateElement("MaPM");
                maphieumuon.InnerText = sachSua.MaPM;//gán giá trị cho mã sách
                sachSuaMoi.AppendChild(maphieumuon);//thêm MaSACH vào trong sách(sach nhận MaSACH là con)

                XmlElement tensach = doc.CreateElement("TenSach");
                tensach.InnerText = sachSua.TenSach;
                sachSuaMoi.AppendChild(tensach);

                XmlElement tacgia = doc.CreateElement("TacGia");
                tacgia.InnerText = sachSua.TacGia;
                sachSuaMoi.AppendChild(tacgia);

                XmlElement tenloaisach = doc.CreateElement("TenLoaiSach");
                tenloaisach.InnerText = sachSua.TenLoaiSach;
                sachSuaMoi.AppendChild(tenloaisach);

                XmlElement ngonngu = doc.CreateElement("NgonNgu");
                ngonngu.InnerText = sachSua.NgonNgu;
                sachSuaMoi.AppendChild(ngonngu);

                XmlElement soluongnhap = doc.CreateElement("SLNhap");
                soluongnhap.InnerText = sachSua.SLNhap.ToString();
                sachSuaMoi.AppendChild(soluongnhap);

                XmlElement vitridatsach = doc.CreateElement("VITRIDATSACH");
                vitridatsach.InnerText = sachSua.VITRIDATSACH;
                sachSuaMoi.AppendChild(vitridatsach);

                XmlElement nhaxuatban = doc.CreateElement("NhaXuatBan");
                nhaxuatban.InnerText = sachSua.NhaXuatBan;
                sachSuaMoi.AppendChild(nhaxuatban);

                XmlElement tinhtrang = doc.CreateElement("TinhTrang");
                tinhtrang.InnerText = sachSua.TinhTrang;
                sachSuaMoi.AppendChild(tinhtrang);

                //thay thế sách cũ bằng sách mới(sửa )
                root.ReplaceChild(sachSuaMoi, sachCu);
                doc.Save("QLTV_PK.xml");//lưu lại
            }
        }

        public void Xoa(SACHDTO sachXoa)
        {
            XmlNode sachCanXoa = root.SelectSingleNode("SACH[MaSACH ='" + sachXoa.MaSACH + "']");
            if (sachCanXoa != null)
            {
                root.RemoveChild(sachCanXoa);

                doc.Save("QLTV_PK.xml");
            }
        }

        public void TimKiem(SACHDTO sachTim, DataGridView dgv)
        {
            dgv.Rows.Clear();
            XmlNode sachCanTim = root.SelectSingleNode("SACH[MaSACH ='" + sachTim.MaSACH + "']");

            if (sachCanTim != null)
            {
                dgv.ColumnCount = 11;//khai báo số cột
                dgv.Rows.Add();//thêm một dòng mới

                //đưa dữ liệu vào dòng vừa tạo
                dgv.Rows[0].Cells[0].Value = sachCanTim.SelectSingleNode("MaSACH").InnerText;
                dgv.Rows[0].Cells[1].Value = sachCanTim.SelectSingleNode("MaPT").InnerText;
                dgv.Rows[0].Cells[2].Value = sachCanTim.SelectSingleNode("MaPM").InnerText;
                dgv.Rows[0].Cells[3].Value = sachCanTim.SelectSingleNode("TenSach").InnerText;
                dgv.Rows[0].Cells[4].Value = sachCanTim.SelectSingleNode("TacGia").InnerText;
                dgv.Rows[0].Cells[5].Value = sachCanTim.SelectSingleNode("TenLoaiSach").InnerText;
                dgv.Rows[0].Cells[6].Value = sachCanTim.SelectSingleNode("NgonNgu").InnerText;
                dgv.Rows[0].Cells[7].Value = sachCanTim.SelectSingleNode("SLNhap").InnerText;
                dgv.Rows[0].Cells[8].Value = sachCanTim.SelectSingleNode("VITRIDATSACH").InnerText;
                dgv.Rows[0].Cells[9].Value = sachCanTim.SelectSingleNode("NhaXuatBan").InnerText;
                dgv.Rows[0].Cells[10].Value = sachCanTim.SelectSingleNode("TinhTrang").InnerText;
            }
        }

        /// <summary>
        /// Tìm và trả về đối tượng sách tìm thấy, không thấy = null
        /// </summary>
        /// <param name="sachTim">Đối tượng chứa thông tin tìm kiếm</param>
        /// <param name="dgv">grid view hiển thị</param>
        /// <returns>tìm thấy nếu khác null</returns>
        public SACHDTO TimKiem2(SACHDTO sachTim, DataGridView dgv)
        {
            SACHDTO ketQua = null;
            dgv.Rows.Clear();
            XmlNode sachCanTim = root.SelectSingleNode("SACH[MaSACH ='" + sachTim.MaSACH + "']");
            if (sachCanTim != null)
            {
                dgv.ColumnCount = 11;//khai báo số cột
                dgv.Rows.Add();//thêm một dòng mới

                //đưa dữ liệu vào dòng vừa tạo
                dgv.Rows[0].Cells[0].Value = sachTim.MaSACH = sachCanTim.SelectSingleNode("MaSACH").InnerText;
                dgv.Rows[0].Cells[1].Value = sachCanTim.SelectSingleNode("MaPT").InnerText;
                dgv.Rows[0].Cells[2].Value = sachCanTim.SelectSingleNode("MaPM").InnerText;
                dgv.Rows[0].Cells[3].Value = sachCanTim.SelectSingleNode("TenSach").InnerText;
                dgv.Rows[0].Cells[4].Value = sachCanTim.SelectSingleNode("TacGia").InnerText;
                dgv.Rows[0].Cells[5].Value = sachCanTim.SelectSingleNode("TenLoaiSach").InnerText;
                dgv.Rows[0].Cells[6].Value = sachCanTim.SelectSingleNode("NgonNgu").InnerText;
                dgv.Rows[0].Cells[7].Value = sachCanTim.SelectSingleNode("SLNhap").InnerText;
                dgv.Rows[0].Cells[8].Value = sachCanTim.SelectSingleNode("VITRIDATSACH").InnerText;
                dgv.Rows[0].Cells[9].Value = sachCanTim.SelectSingleNode("NhaXuatBan").InnerText;
                dgv.Rows[0].Cells[10].Value = sachCanTim.SelectSingleNode("TinhTrang").InnerText;

                ketQua = new SACHDTO();

                ketQua.MaSACH = sachCanTim.SelectSingleNode("MaSACH").InnerText;
                ketQua.MaPT = sachCanTim.SelectSingleNode("MaPT").InnerText;
                ketQua.MaPM = sachCanTim.SelectSingleNode("MaPM").InnerText;
                ketQua.TenSach = sachCanTim.SelectSingleNode("TenSach").InnerText;
                ketQua.TacGia = sachCanTim.SelectSingleNode("TacGia").InnerText;
                ketQua.TenLoaiSach = sachCanTim.SelectSingleNode("TenLoaiSach").InnerText;
                ketQua.NgonNgu = sachCanTim.SelectSingleNode("NgonNgu").InnerText;
                ketQua.SLNhap = int.Parse(sachCanTim.SelectSingleNode("SLNhap").InnerText);
                ketQua.VITRIDATSACH = sachCanTim.SelectSingleNode("VITRIDATSACH").InnerText;
                ketQua.NhaXuatBan = sachCanTim.SelectSingleNode("NhaXuatBan").InnerText;
                ketQua.TinhTrang = sachCanTim.SelectSingleNode("TinhTrang").InnerText;
                //ketQua.DongGia = double.Parse(sachCanTim.SelectSingleNode("dongia").InnerText);
            }

            return ketQua;
        }

        public void HienThi(DataGridView dgv)
        {
            dgv.Rows.Clear();
            dgv.ColumnCount = 11;

            XmlNodeList ds = root.SelectNodes("SACH");
            int sd = 0;//lưu chỉ số dòng
            foreach (XmlNode item in ds)
            {
                dgv.Rows.Add();
                dgv.Rows[sd].Cells[0].Value = item.SelectSingleNode("MaSACH").InnerText;
                dgv.Rows[sd].Cells[1].Value = item.SelectSingleNode("MaPT").InnerText;
                dgv.Rows[sd].Cells[2].Value = item.SelectSingleNode("MaPM").InnerText;
                dgv.Rows[sd].Cells[3].Value = item.SelectSingleNode("TenSach").InnerText;
                dgv.Rows[sd].Cells[4].Value = item.SelectSingleNode("TacGia").InnerText;
                dgv.Rows[sd].Cells[5].Value = item.SelectSingleNode("TenLoaiSach").InnerText;
                dgv.Rows[sd].Cells[6].Value = item.SelectSingleNode("NgonNgu").InnerText;
                dgv.Rows[sd].Cells[7].Value = item.SelectSingleNode("SLNhap").InnerText;
                dgv.Rows[sd].Cells[8].Value = item.SelectSingleNode("VITRIDATSACH").InnerText;
                dgv.Rows[sd].Cells[9].Value = item.SelectSingleNode("NhaXuatBan").InnerText;
                dgv.Rows[sd].Cells[10].Value = item.SelectSingleNode("TinhTrang").InnerText;
                sd++;
            }
        }
    }
}
