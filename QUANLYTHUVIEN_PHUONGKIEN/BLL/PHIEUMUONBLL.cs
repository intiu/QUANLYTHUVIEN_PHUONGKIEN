using System;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using System.Xml;
using QUANLYTHUVIEN_PHUONGKIEN.DTO;

namespace QUANLYTHUVIEN_PHUONGKIEN.BLL
{
    public class PHIEUMUONBLL
    {
        private XmlDocument doc = new XmlDocument();
        private XmlElement root;
        //private string "QLTV_PK.xml" = @"C:\Users\ltpnt\source\repos\QUANLYTHUVIEN_PHUONGKIEN\QUANLYTHUVIEN_PHUONGKIEN\QLTV_PK.xml";

        public PHIEUMUONBLL()
        {
            doc.Load("QLTV_PK.xml");
            root = doc.DocumentElement;
        }

        public void Them(PHIEUMUONDTO sachThem)
        {
            //tạo nút sách
            XmlNode sach = doc.CreateElement("PHIEUMUON");

            //tạo nút con của sách là MaSACH
            XmlElement maphieumuon = doc.CreateElement("MaPM");
            maphieumuon.InnerText = sachThem.MaPM;//gán giá trị cho mã sách
            sach.AppendChild(maphieumuon);//thêm MaSACH vào trong sách(sach nhận MaSACH là con)

            XmlElement masach = doc.CreateElement("MaSACH");
            masach.InnerText = sachThem.MaSACH;//gán giá trị cho mã sách
            sach.AppendChild(masach);//thêm MaSACH vào trong sách(sach nhận MaSACH là con)

            XmlElement ngaymuon = doc.CreateElement("NgayMuon");
            ngaymuon.InnerText = sachThem.NgayMuon;//gán giá trị cho mã sách
            sach.AppendChild(ngaymuon);//thêm MaSACH vào trong sách(sach nhận MaSACH là con)

            XmlElement ngaytra = doc.CreateElement("NgayTra");
            ngaytra.InnerText = sachThem.NgayTra;
            sach.AppendChild(ngaytra);

            XmlElement hantra = doc.CreateElement("HanTra");
            hantra.InnerText = sachThem.HanTra;
            sach.AppendChild(hantra);
            
            //sau khi tạo xong sách, thì thêm sách vào gốc root
            root.AppendChild(sach);
            doc.Save("QLTV_PK.xml");//lưu dữ liệu
        }


        public void Sua(PHIEUMUONDTO sachSua)
        {
            //láy vị trí cần sửa theo mã sách cũ đưa vào
            XmlNode sachCu = root.SelectSingleNode("PHIEUMUON[MaPM ='" + sachSua.MaPM + "']");
            if (sachCu != null)
            {
                XmlNode sachSuaMoi = doc.CreateElement("PHIEUMUON");

                //tạo nút con của sách là MaSACH
                XmlElement maphieumuon = doc.CreateElement("MaPM");
                maphieumuon.InnerText = sachSua.MaPM;//gán giá trị cho mã sách
                sachSuaMoi.AppendChild(maphieumuon);//thêm MaSACH vào trong sách(sach nhận MaSACH là con)               

                XmlElement masach = doc.CreateElement("MaSACH");
                masach.InnerText = sachSua.MaSACH;//gán giá trị cho mã sách
                sachSuaMoi.AppendChild(masach);//thêm MaSACH vào trong sách(sach nhận MaSACH là con)

                XmlElement ngaymuon = doc.CreateElement("NgayMuon");
                ngaymuon.InnerText = sachSua.NgayMuon;//gán giá trị cho mã sách
                sachSuaMoi.AppendChild(ngaymuon);//thêm MaSACH vào trong sách(sach nhận MaSACH là con)

                XmlElement ngaytra = doc.CreateElement("NgayTra");
                ngaytra.InnerText = sachSua.NgayTra;
                sachSuaMoi.AppendChild(ngaytra);

                XmlElement hantra = doc.CreateElement("HanTra");
                hantra.InnerText = sachSua.HanTra;
                sachSuaMoi.AppendChild(hantra);
               
                //thay thế sách cũ bằng sách mới(sửa )
                root.ReplaceChild(sachSuaMoi, sachCu);
                doc.Save("QLTV_PK.xml");//lưu lại
            }
        }

        public void Xoa(PHIEUMUONDTO sachXoa)
        {
            XmlNode sachCanXoa = root.SelectSingleNode("PHIEUMUON[MaPM ='" + sachXoa.MaPM + "']");
            if (sachCanXoa != null)
            {
                root.RemoveChild(sachCanXoa);

                doc.Save("QLTV_PK.xml");
            }
        }

        public void TimKiem(PHIEUMUONDTO sachTim, DataGridView dgv)
        {
            dgv.Rows.Clear();
            XmlNode sachCanTim = root.SelectSingleNode("PHIEUMUON[MaPM ='" + sachTim.MaPM + "']");

            if (sachCanTim != null)
            {
                dgv.ColumnCount = 5;//khai báo số cột
                dgv.Rows.Add();//thêm một dòng mới

                //đưa dữ liệu vào dòng vừa tạo
                dgv.Rows[0].Cells[0].Value = sachCanTim.SelectSingleNode("MaPM").InnerText;
                dgv.Rows[0].Cells[1].Value = sachCanTim.SelectSingleNode("MaSACH").InnerText;
                dgv.Rows[0].Cells[2].Value = sachCanTim.SelectSingleNode("NgayMuon").InnerText;
                dgv.Rows[0].Cells[3].Value = sachCanTim.SelectSingleNode("NgayTra").InnerText;
                dgv.Rows[0].Cells[4].Value = sachCanTim.SelectSingleNode("HanTra").InnerText;
            }
        }

        /// <summary>
        /// Tìm và trả về đối tượng sách tìm thấy, không thấy = null
        /// </summary>
        /// <param name="sachTim">Đối tượng chứa thông tin tìm kiếm</param>
        /// <param name="dgv">grid view hiển thị</param>
        /// <returns>tìm thấy nếu khác null</returns>
        public PHIEUMUONDTO TimKiem2(PHIEUMUONDTO sachTim, DataGridView dgv)
        {
            PHIEUMUONDTO ketQua = null;
            dgv.Rows.Clear();
            XmlNode sachCanTim = root.SelectSingleNode("PHIEUMUON[MaPM ='" + sachTim.MaPM + "']");
            if (sachCanTim != null)
            {
                dgv.ColumnCount = 5;//khai báo số cột
                dgv.Rows.Add();//thêm một dòng mới

                //đưa dữ liệu vào dòng vừa tạo
                dgv.Rows[0].Cells[0].Value = sachTim.MaPM = sachCanTim.SelectSingleNode("MaPM").InnerText;
                dgv.Rows[0].Cells[1].Value = sachCanTim.SelectSingleNode("MaSACH").InnerText;
                dgv.Rows[0].Cells[2].Value = sachCanTim.SelectSingleNode("NgayMuon").InnerText;
                dgv.Rows[0].Cells[3].Value = sachCanTim.SelectSingleNode("NgayTra").InnerText;
                dgv.Rows[0].Cells[4].Value = sachCanTim.SelectSingleNode("HanTra").InnerText;

                ketQua = new PHIEUMUONDTO();

                ketQua.MaPM = sachCanTim.SelectSingleNode("MaPM").InnerText;
                ketQua.MaSACH = sachCanTim.SelectSingleNode("MaSACH").InnerText;
                ketQua.NgayMuon = sachCanTim.SelectSingleNode("NgayMuon").InnerText;
                ketQua.NgayTra = sachCanTim.SelectSingleNode("NgayTra").InnerText;
                ketQua.HanTra = sachCanTim.SelectSingleNode("HanTra").InnerText;
            }

            return ketQua;
        }

        public void HienThi(DataGridView dgv)
        {
            dgv.Rows.Clear();
            dgv.ColumnCount = 5;

            XmlNodeList ds = root.SelectNodes("PHIEUMUON");
            int sd = 0;//lưu chỉ số dòng
            foreach (XmlNode item in ds)
            {
                dgv.Rows.Add();
                dgv.Rows[sd].Cells[0].Value = item.SelectSingleNode("MaPM").InnerText;
                dgv.Rows[sd].Cells[1].Value = item.SelectSingleNode("MaSACH").InnerText;
                dgv.Rows[sd].Cells[2].Value = item.SelectSingleNode("NgayMuon").InnerText;
                dgv.Rows[sd].Cells[3].Value = item.SelectSingleNode("NgayTra").InnerText;
                dgv.Rows[sd].Cells[4].Value = item.SelectSingleNode("HanTra").InnerText;
                sd++;
            }
        }
    }
}
