using System;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using System.Xml;
using QUANLYTHUVIEN_PHUONGKIEN.DTO;

namespace QUANLYTHUVIEN_PHUONGKIEN.BLL
{
    public class NHANVIENBLL
    {
        private XmlDocument doc = new XmlDocument();
        private XmlElement root;
        //private string "QLTV_PK.xml" = @"C:\Users\ltpnt\source\repos\QUANLYTHUVIEN_PHUONGKIEN\QUANLYTHUVIEN_PHUONGKIEN\QLTV_PK.xml";

        public NHANVIENBLL()
        {
            doc.Load("QLTV_PK.xml");
            root = doc.DocumentElement;
        }

        public void Them(NHANVIENDTO nhanvienThem)
        {
            XmlNode nhanvien = doc.CreateElement("NHANVIEN");

            XmlElement manhanvien = doc.CreateElement("MaNV");
            manhanvien.InnerText = nhanvienThem.MaNV;
            nhanvien.AppendChild(manhanvien);

            XmlElement taikhoannhanvienn = doc.CreateElement("TaiKhoanNV");
            taikhoannhanvienn.InnerText = nhanvienThem.TaiKhoanNV;
            nhanvien.AppendChild(taikhoannhanvienn);

            XmlElement matkhaunhanvien = doc.CreateElement("MatKhauNV");
            matkhaunhanvien.InnerText = nhanvienThem.MatKhauNV;
            nhanvien.AppendChild(matkhaunhanvien);

            XmlElement tennhanvien = doc.CreateElement("TenNV");
            tennhanvien.InnerText = nhanvienThem.TenNV;
            nhanvien.AppendChild(tennhanvien);

            XmlElement ngaysinhnhanvien = doc.CreateElement("NgaySinhNV");
            ngaysinhnhanvien.InnerText = nhanvienThem.NgaySinhNV;
            nhanvien.AppendChild(ngaysinhnhanvien);

            XmlElement diachinhanvien = doc.CreateElement("DiaChiNV");
            diachinhanvien.InnerText = nhanvienThem.DiaChiNV;
            nhanvien.AppendChild(diachinhanvien);

            XmlElement sodienthoainhanvien = doc.CreateElement("SDTNV");
            sodienthoainhanvien.InnerText = nhanvienThem.SDTNV;
            nhanvien.AppendChild(sodienthoainhanvien);

            XmlElement luongnhanvien = doc.CreateElement("LuongNV");
            luongnhanvien.InnerText = nhanvienThem.LuongNV;
            nhanvien.AppendChild(luongnhanvien);

            //sau khi tạo xong sách, thì thêm sách vào gốc root
            root.AppendChild(nhanvien);
            doc.Save("QLTV_PK.xml");//lưu dữ liệu
        }


        public void Sua(NHANVIENDTO nhanvienSua)
        {
            //láy vị trí cần sửa theo mã sách cũ đưa vào
            XmlNode nhanvienCu = root.SelectSingleNode("NHANVIEN[MaNV ='" + nhanvienSua.MaNV + "']");
            if (nhanvienCu != null)
            {
                XmlNode nhanvienSuaMoi = doc.CreateElement("NHANVIEN");

                //tạo nút con của sách là Manhanvien
                XmlElement manhanvien = doc.CreateElement("MaNV");
                manhanvien.InnerText = nhanvienSua.MaNV;//gán giá trị cho mã sách
                nhanvienSuaMoi.AppendChild(manhanvien);//thêm Manhanvien vào trong sách(nhanvien nhận Manhanvien là con)               
                XmlElement tennhanvien = doc.CreateElement("TenNV");
                tennhanvien.InnerText = nhanvienSua.TenNV;//gán giá trị cho mã sách
                nhanvienSuaMoi.AppendChild(tennhanvien);//thêm Manhanvien vào trong sách(nhanvien nhận Manhanvien là con)

                XmlElement taikhoannhanvienn = doc.CreateElement("TaiKhoanNV");
                taikhoannhanvienn.InnerText = nhanvienSua.TaiKhoanNV;//gán giá trị cho mã sách
                nhanvienSuaMoi.AppendChild(taikhoannhanvienn);//thêm Manhanvien vào trong sách(nhanvien nhận Manhanvien là con) 

                XmlElement matkhaunhanvien = doc.CreateElement("MatKhauNV");
                matkhaunhanvien.InnerText = nhanvienSua.MatKhauNV;//gán giá trị cho mã sách
                nhanvienSuaMoi.AppendChild(matkhaunhanvien);//thêm Manhanvien vào trong sách(nhanvien nhận Manhanvien là con) 
               
                XmlElement ngaysinhnhanvien = doc.CreateElement("NgaySinhNV");
                ngaysinhnhanvien.InnerText = nhanvienSua.NgaySinhNV;//gán giá trị cho mã sách
                nhanvienSuaMoi.AppendChild(ngaysinhnhanvien);//thêm Manhanvien vào trong sách(nhanvien nhận Manhanvien là con)

                XmlElement diachinhanvien = doc.CreateElement("DiaChiNV");
                diachinhanvien.InnerText = nhanvienSua.DiaChiNV;
                nhanvienSuaMoi.AppendChild(diachinhanvien);

                XmlElement sodienthoainhanvien = doc.CreateElement("SDTNV");
                sodienthoainhanvien.InnerText = nhanvienSua.SDTNV;
                nhanvienSuaMoi.AppendChild(sodienthoainhanvien);

                XmlElement luongnhanvien = doc.CreateElement("LuongNV");
                luongnhanvien.InnerText = nhanvienSua.LuongNV;
                nhanvienSuaMoi.AppendChild(luongnhanvien);

                //thay thế sách cũ bằng sách mới(sửa )
                root.ReplaceChild(nhanvienSuaMoi, nhanvienCu);
                doc.Save("QLTV_PK.xml");//lưu lại
            }
        }

        public void Xoa(NHANVIENDTO nhanvienXoa)
        {
            XmlNode nhanvienCanXoa = root.SelectSingleNode("NHANVIEN[MaNV ='" + nhanvienXoa.MaNV + "']");
            if (nhanvienCanXoa != null)
            {
                root.RemoveChild(nhanvienCanXoa);

                doc.Save("QLTV_PK.xml");
            }
        }

        public void TimKiem(NHANVIENDTO nhanvienTim, DataGridView dgv)
        {
            dgv.Rows.Clear();
            XmlNode nhanvienCanTim = root.SelectSingleNode("NHANVIEN[MaNV ='" + nhanvienTim.MaNV + "']");

            if (nhanvienCanTim != null)
            {
                dgv.ColumnCount = 8;//khai báo số cột
                dgv.Rows.Add();//thêm một dòng mới

                //đưa dữ liệu vào dòng vừa tạo
                dgv.Rows[0].Cells[0].Value = nhanvienCanTim.SelectSingleNode("MaNV").InnerText;
                dgv.Rows[0].Cells[1].Value = nhanvienCanTim.SelectSingleNode("TenNV").InnerText;
                dgv.Rows[0].Cells[2].Value = nhanvienCanTim.SelectSingleNode("TaiKhoanNV").InnerText;
                dgv.Rows[0].Cells[3].Value = nhanvienCanTim.SelectSingleNode("MatKhauNV").InnerText;
                dgv.Rows[0].Cells[4].Value = nhanvienCanTim.SelectSingleNode("NgaySinhNV").InnerText;
                dgv.Rows[0].Cells[5].Value = nhanvienCanTim.SelectSingleNode("DiaChiNV").InnerText;
                dgv.Rows[0].Cells[6].Value = nhanvienCanTim.SelectSingleNode("SDTNV").InnerText;
                dgv.Rows[0].Cells[7].Value = nhanvienCanTim.SelectSingleNode("LuongNV").InnerText;

            }
        }

        /// <summary>
        /// Tìm và trả về đối tượng sách tìm thấy, không thấy = null
        /// </summary>
        /// <param name="nhanvienTim">Đối tượng chứa thông tin tìm kiếm</param>
        /// <param name="dgv">grid view hiển thị</param>
        /// <returns>tìm thấy nếu khác null</returns>
        public NHANVIENDTO TimKiem2(NHANVIENDTO nhanvienTim, DataGridView dgv)
        {
            NHANVIENDTO ketQua = null;
            dgv.Rows.Clear();
            XmlNode nhanvienCanTim = root.SelectSingleNode("NHANVIEN[MaNV ='" + nhanvienTim.MaNV + "']");
            if (nhanvienCanTim != null)
            {
                dgv.ColumnCount = 8;//khai báo số cột
                dgv.Rows.Add();//thêm một dòng mới

                //đưa dữ liệu vào dòng vừa tạo
                dgv.Rows[0].Cells[0].Value = nhanvienTim.MaNV = nhanvienCanTim.SelectSingleNode("MaNV").InnerText;
                dgv.Rows[0].Cells[1].Value = nhanvienCanTim.SelectSingleNode("TenNV").InnerText;
                dgv.Rows[0].Cells[2].Value = nhanvienCanTim.SelectSingleNode("TaiKhoanNV").InnerText;
                dgv.Rows[0].Cells[3].Value = nhanvienCanTim.SelectSingleNode("MatKhauNV").InnerText;
                dgv.Rows[0].Cells[4].Value = nhanvienCanTim.SelectSingleNode("NgaySinhNV").InnerText;
                dgv.Rows[0].Cells[5].Value = nhanvienCanTim.SelectSingleNode("DiaChiNV").InnerText;
                dgv.Rows[0].Cells[6].Value = nhanvienCanTim.SelectSingleNode("SDTNV").InnerText;
                dgv.Rows[0].Cells[7].Value = nhanvienCanTim.SelectSingleNode("LuongNV").InnerText;

                ketQua = new NHANVIENDTO();

                ketQua.MaNV = nhanvienCanTim.SelectSingleNode("MaNV").InnerText;
                ketQua.TenNV = nhanvienCanTim.SelectSingleNode("TenNV").InnerText;
                ketQua.TaiKhoanNV = nhanvienCanTim.SelectSingleNode("TaiKhoanNV").InnerText;
                ketQua.MatKhauNV = nhanvienCanTim.SelectSingleNode("MatKhauNV").InnerText;
                ketQua.NgaySinhNV = nhanvienCanTim.SelectSingleNode("NgaySinhNV").InnerText;
                ketQua.DiaChiNV = nhanvienCanTim.SelectSingleNode("DiaChiNV").InnerText;
                ketQua.SDTNV = nhanvienCanTim.SelectSingleNode("SDTNV").InnerText;
                ketQua.LuongNV = nhanvienCanTim.SelectSingleNode("LuongNV").InnerText;
            }

            return ketQua;
        }

        public void HienThi(DataGridView dgv)
        {
            dgv.Rows.Clear();
            dgv.ColumnCount = 8;

            XmlNodeList ds = root.SelectNodes("NHANVIEN");
            int sd = 0;//lưu chỉ số dòng
            foreach (XmlNode item in ds)
            {
                dgv.Rows.Add();
                dgv.Rows[sd].Cells[0].Value = item.SelectSingleNode("MaNV").InnerText;
                dgv.Rows[sd].Cells[1].Value = item.SelectSingleNode("TenNV").InnerText;
                dgv.Rows[sd].Cells[2].Value = item.SelectSingleNode("TaiKhoanNV").InnerText;
                dgv.Rows[sd].Cells[3].Value = item.SelectSingleNode("MatKhauNV").InnerText;
                dgv.Rows[sd].Cells[4].Value = item.SelectSingleNode("NgaySinhNV").InnerText;
                dgv.Rows[sd].Cells[5].Value = item.SelectSingleNode("DiaChiNV").InnerText;
                dgv.Rows[sd].Cells[6].Value = item.SelectSingleNode("SDTNV").InnerText;
                dgv.Rows[sd].Cells[7].Value = item.SelectSingleNode("LuongNV").InnerText;
                sd++;
            }
        }
    }
}
