using System;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using System.Xml;
using QUANLYTHUVIEN_PHUONGKIEN.DTO;

namespace QUANLYTHUVIEN_PHUONGKIEN.BLL
{
    public class NHAXUATBANBLL
    {
        private XmlDocument doc = new XmlDocument();
        private XmlElement root;
        //private string "QLTV_PK.xml" = @"C:\Users\ltpnt\source\repos\QUANLYTHUVIEN_PHUONGKIEN\QUANLYTHUVIEN_PHUONGKIEN\QLTV_PK.xml";

        public NHAXUATBANBLL()
        {
            doc.Load("QLTV_PK.xml");
            root = doc.DocumentElement;
        }

        public void Them(NHAXUATBANDTO sachThem)
        {
            //tạo nút sách
            XmlNode sach = doc.CreateElement("NHAXUATBAN");

            //tạo nút con của sách là MaSACH
            XmlElement manhaxuatban = doc.CreateElement("MaNXB");
            manhaxuatban.InnerText = sachThem.MaNXB;//gán giá trị cho mã sách
            sach.AppendChild(manhaxuatban);//thêm MaSACH vào trong sách(sach nhận MaSACH là con)

            XmlElement tennhaxuatban = doc.CreateElement("TenNXB");
            tennhaxuatban.InnerText = sachThem.TenNXB;//gán giá trị cho mã sách
            sach.AppendChild(tennhaxuatban);//thêm MaSACH vào trong sách(sach nhận MaSACH là con)

            XmlElement diachinhaxuatban = doc.CreateElement("DiaChiNXB");
            diachinhaxuatban.InnerText = sachThem.DiaChiNXB;//gán giá trị cho mã sách
            sach.AppendChild(diachinhaxuatban);//thêm MaSACH vào trong sách(sach nhận MaSACH là con)

            XmlElement emailnhaxuatban= doc.CreateElement("EmailNXB");
            emailnhaxuatban.InnerText = sachThem.EmailNXB;
            sach.AppendChild(emailnhaxuatban);

            XmlElement sodienthoainhaxuatban = doc.CreateElement("SDTNXB");
            sodienthoainhaxuatban.InnerText = sachThem.SDTNXB;
            sach.AppendChild(sodienthoainhaxuatban);
          
            //sau khi tạo xong sách, thì thêm sách vào gốc root
            root.AppendChild(sach);
            doc.Save("QLTV_PK.xml");//lưu dữ liệu
        }


        public void Sua(NHAXUATBANDTO sachSua)
        {
            //láy vị trí cần sửa theo mã sách cũ đưa vào
            XmlNode sachCu = root.SelectSingleNode("NHAXUATBAN[MaNXB ='" + sachSua.MaNXB + "']");
            if (sachCu != null)
            {
                XmlNode sachSuaMoi = doc.CreateElement("NHAXUATBAN");

                //tạo nút con của sách là MaSACH
                XmlElement manhaxuatban = doc.CreateElement("MaNXB");
                manhaxuatban.InnerText = sachSua.MaNXB;//gán giá trị cho mã sách
                sachSuaMoi.AppendChild(manhaxuatban);//thêm MaSACH vào trong sách(sach nhận MaSACH là con)               

                XmlElement tennhaxuatban = doc.CreateElement("TenNXB");
                tennhaxuatban.InnerText = sachSua.TenNXB;//gán giá trị cho mã sách
                sachSuaMoi.AppendChild(tennhaxuatban);//thêm MaSACH vào trong sách(sach nhận MaSACH là con)

                XmlElement diachinhaxuatban = doc.CreateElement("DiaChiNXB");
                diachinhaxuatban.InnerText = sachSua.DiaChiNXB;//gán giá trị cho mã sách
                sachSuaMoi.AppendChild(diachinhaxuatban);//thêm MaSACH vào trong sách(sach nhận MaSACH là con)

                XmlElement emailnhaxuatban = doc.CreateElement("EmailNXB");
                emailnhaxuatban.InnerText = sachSua.EmailNXB;
                sachSuaMoi.AppendChild(emailnhaxuatban);

                XmlElement sodienthoainhaxuatban = doc.CreateElement("SDTNXB");
                sodienthoainhaxuatban.InnerText = sachSua.SDTNXB;
                sachSuaMoi.AppendChild(sodienthoainhaxuatban);
                
                //thay thế sách cũ bằng sách mới(sửa )
                root.ReplaceChild(sachSuaMoi, sachCu);
                doc.Save("QLTV_PK.xml");//lưu lại
            }
        }

        public void Xoa(NHAXUATBANDTO sachXoa)
        {
            XmlNode sachCanXoa = root.SelectSingleNode("NHAXUATBAN[MaNXB ='" + sachXoa.MaNXB + "']");
            if (sachCanXoa != null)
            {
                root.RemoveChild(sachCanXoa);

                doc.Save("QLTV_PK.xml");
            }
        }

        public void TimKiem(NHAXUATBANDTO sachTim, DataGridView dgv)
        {
            dgv.Rows.Clear();
            XmlNode sachCanTim = root.SelectSingleNode("NHAXUATBAN[MaNXB ='" + sachTim.MaNXB + "']");

            if (sachCanTim != null)
            {
                dgv.ColumnCount = 5;//khai báo số cột
                dgv.Rows.Add();//thêm một dòng mới

                //đưa dữ liệu vào dòng vừa tạo
                dgv.Rows[0].Cells[0].Value = sachCanTim.SelectSingleNode("MaNXB").InnerText;
                dgv.Rows[0].Cells[1].Value = sachCanTim.SelectSingleNode("TenNXB").InnerText;
                dgv.Rows[0].Cells[2].Value = sachCanTim.SelectSingleNode("DiaChiNXB").InnerText;
                dgv.Rows[0].Cells[3].Value = sachCanTim.SelectSingleNode("EmailNXB").InnerText;
                dgv.Rows[0].Cells[4].Value = sachCanTim.SelectSingleNode("SDTNXB").InnerText;
            }
        }

        /// <summary>
        /// Tìm và trả về đối tượng sách tìm thấy, không thấy = null
        /// </summary>
        /// <param name="sachTim">Đối tượng chứa thông tin tìm kiếm</param>
        /// <param name="dgv">grid view hiển thị</param>
        /// <returns>tìm thấy nếu khác null</returns>
        public NHAXUATBANDTO TimKiem2(NHAXUATBANDTO sachTim, DataGridView dgv)
        {
            NHAXUATBANDTO ketQua = null;
            dgv.Rows.Clear();
            XmlNode sachCanTim = root.SelectSingleNode("NHAXUATBAN[MaNXB ='" + sachTim.MaNXB + "']");
            if (sachCanTim != null)
            {
                dgv.ColumnCount = 5;//khai báo số cột
                dgv.Rows.Add();//thêm một dòng mới

                //đưa dữ liệu vào dòng vừa tạo
                dgv.Rows[0].Cells[0].Value = sachTim.MaNXB = sachCanTim.SelectSingleNode("MaNXB").InnerText;
                dgv.Rows[0].Cells[1].Value = sachCanTim.SelectSingleNode("TenNXB").InnerText;
                dgv.Rows[0].Cells[2].Value = sachCanTim.SelectSingleNode("DiaChiNXB").InnerText;
                dgv.Rows[0].Cells[3].Value = sachCanTim.SelectSingleNode("EmailNXB").InnerText;
                dgv.Rows[0].Cells[4].Value = sachCanTim.SelectSingleNode("SDTNXB").InnerText;

                ketQua = new NHAXUATBANDTO();

                ketQua.MaNXB = sachCanTim.SelectSingleNode("MaNXB").InnerText;
                ketQua.TenNXB = sachCanTim.SelectSingleNode("TenNXB").InnerText;
                ketQua.DiaChiNXB = sachCanTim.SelectSingleNode("DiaChiNXB").InnerText;
                ketQua.EmailNXB = sachCanTim.SelectSingleNode("EmailNXB").InnerText;
                ketQua.SDTNXB = sachCanTim.SelectSingleNode("SDTNXB").InnerText;
            }

            return ketQua;
        }

        public void HienThi(DataGridView dgv)
        {
            dgv.Rows.Clear();
            dgv.ColumnCount = 5;

            XmlNodeList ds = root.SelectNodes("NHAXUATBAN");
            int sd = 0;//lưu chỉ số dòng
            foreach (XmlNode item in ds)
            {
                dgv.Rows.Add();
                dgv.Rows[sd].Cells[0].Value = item.SelectSingleNode("MaNXB").InnerText;
                dgv.Rows[sd].Cells[1].Value = item.SelectSingleNode("TenNXB").InnerText;
                dgv.Rows[sd].Cells[2].Value = item.SelectSingleNode("DiaChiNXB").InnerText;
                dgv.Rows[sd].Cells[3].Value = item.SelectSingleNode("EmailNXB").InnerText;
                dgv.Rows[sd].Cells[4].Value = item.SelectSingleNode("SDTNXB").InnerText;
                sd++;
            }
        }
    }
}
