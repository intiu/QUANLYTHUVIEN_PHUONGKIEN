using System;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using System.Xml;
using QUANLYTHUVIEN_PHUONGKIEN.DTO;

namespace QUANLYTHUVIEN_PHUONGKIEN.BLL
{
    public class PHIEUTHUBLL
    {
        private XmlDocument doc = new XmlDocument();
        private XmlElement root;
        //private string "QLTV_PK.xml" = @"C:\Users\ltpnt\source\repos\QUANLYTHUVIEN_PHUONGKIEN\QUANLYTHUVIEN_PHUONGKIEN\QLTV_PK.xml";

        public PHIEUTHUBLL()
        {
            doc.Load("QLTV_PK.xml");
            root = doc.DocumentElement;
        }

        public void Them(PHIEUTHUDTO sachThem)
        {
            //tạo nút sách
            XmlNode sach = doc.CreateElement("PHIEUTHU");

            //tạo nút con của sách là MaSACH
            XmlElement maphieuthu = doc.CreateElement("MaPT");
            maphieuthu.InnerText = sachThem.MaPT;//gán giá trị cho mã sách
            sach.AppendChild(maphieuthu);//thêm MaSACH vào trong sách(sach nhận MaSACH là con)

            XmlElement masach = doc.CreateElement("MaSACH");
            masach.InnerText = sachThem.MaSACH;//gán giá trị cho mã sách
            sach.AppendChild(masach);//thêm MaSACH vào trong sách(sach nhận MaSACH là con)

            XmlElement ngaythu = doc.CreateElement("NgayThu");
            ngaythu.InnerText = sachThem.NgayThu;//gán giá trị cho mã sách
            sach.AppendChild(ngaythu);//thêm MaSACH vào trong sách(sach nhận MaSACH là con)

            XmlElement giatienthu = doc.CreateElement("GiaTienThu");
            giatienthu.InnerText = sachThem.GiaTienThu;
            sach.AppendChild(giatienthu);
            
            //sau khi tạo xong sách, thì thêm sách vào gốc root
            root.AppendChild(sach);
            doc.Save("QLTV_PK.xml");//lưu dữ liệu
        }


        public void Sua(PHIEUTHUDTO sachSua)
        {
            //láy vị trí cần sửa theo mã sách cũ đưa vào
            XmlNode sachCu = root.SelectSingleNode("PHIEUTHU[MaPT ='" + sachSua.MaPT + "']");
            if (sachCu != null)
            {
                XmlNode sachSuaMoi = doc.CreateElement("PHIEUTHU");

                //tạo nút con của sách là MaSACH
                XmlElement maphieuthu = doc.CreateElement("MaPT");
                maphieuthu.InnerText = sachSua.MaPT;//gán giá trị cho mã sách
                sachSuaMoi.AppendChild(maphieuthu);//thêm MaSACH vào trong sách(sach nhận MaSACH là con)               

                XmlElement masach = doc.CreateElement("MaSACH");
                masach.InnerText = sachSua.MaSACH;//gán giá trị cho mã sách
                sachSuaMoi.AppendChild(masach);//thêm MaSACH vào trong sách(sach nhận MaSACH là con)

                XmlElement ngaythu = doc.CreateElement("NgayThu");
                ngaythu.InnerText = sachSua.NgayThu;//gán giá trị cho mã sách
                sachSuaMoi.AppendChild(ngaythu);//thêm MaSACH vào trong sách(sach nhận MaSACH là con)

                XmlElement giatienthu = doc.CreateElement("GiaTienThu");
                giatienthu.InnerText = sachSua.GiaTienThu;
                sachSuaMoi.AppendChild(giatienthu);
                
                //thay thế sách cũ bằng sách mới(sửa )
                root.ReplaceChild(sachSuaMoi, sachCu);
                doc.Save("QLTV_PK.xml");//lưu lại
            }
        }

        public void Xoa(PHIEUTHUDTO sachXoa)
        {
            XmlNode sachCanXoa = root.SelectSingleNode("PHIEUTHU[MaPT ='" + sachXoa.MaPT + "']");
            if (sachCanXoa != null)
            {
                root.RemoveChild(sachCanXoa);

                doc.Save("QLTV_PK.xml");
            }
        }

        public void TimKiem(PHIEUTHUDTO sachTim, DataGridView dgv)
        {
            dgv.Rows.Clear();
            XmlNode sachCanTim = root.SelectSingleNode("PHIEUTHU[MaPT ='" + sachTim.MaPT + "']");

            if (sachCanTim != null)
            {
                dgv.ColumnCount = 4;//khai báo số cột
                dgv.Rows.Add();//thêm một dòng mới

                //đưa dữ liệu vào dòng vừa tạo
                dgv.Rows[0].Cells[0].Value = sachCanTim.SelectSingleNode("MaPT").InnerText;
                dgv.Rows[0].Cells[1].Value = sachCanTim.SelectSingleNode("MaSACH").InnerText;
                dgv.Rows[0].Cells[2].Value = sachCanTim.SelectSingleNode("NgayThu").InnerText;
                dgv.Rows[0].Cells[3].Value = sachCanTim.SelectSingleNode("GiaTienThu").InnerText;
            }
        }

        /// <summary>
        /// Tìm và trả về đối tượng sách tìm thấy, không thấy = null
        /// </summary>
        /// <param name="sachTim">Đối tượng chứa thông tin tìm kiếm</param>
        /// <param name="dgv">grid view hiển thị</param>
        /// <returns>tìm thấy nếu khác null</returns>
        public PHIEUTHUDTO TimKiem2(PHIEUTHUDTO sachTim, DataGridView dgv)
        {
            PHIEUTHUDTO ketQua = null;
            dgv.Rows.Clear();
            XmlNode sachCanTim = root.SelectSingleNode("PHIEUTHU[MaPT ='" + sachTim.MaPT + "']");
            if (sachCanTim != null)
            {
                dgv.ColumnCount = 4;//khai báo số cột
                dgv.Rows.Add();//thêm một dòng mới

                //đưa dữ liệu vào dòng vừa tạo
                dgv.Rows[0].Cells[0].Value = sachTim.MaPT = sachCanTim.SelectSingleNode("MaPT").InnerText;
                dgv.Rows[0].Cells[1].Value = sachCanTim.SelectSingleNode("MaSACH").InnerText;
                dgv.Rows[0].Cells[2].Value = sachCanTim.SelectSingleNode("NgayThu").InnerText;
                dgv.Rows[0].Cells[3].Value = sachCanTim.SelectSingleNode("GiaTienThu").InnerText;

                ketQua = new PHIEUTHUDTO();

                ketQua.MaPT = sachCanTim.SelectSingleNode("MaPT").InnerText;
                ketQua.MaSACH = sachCanTim.SelectSingleNode("MaSACH").InnerText;
                ketQua.NgayThu = sachCanTim.SelectSingleNode("NgayThu").InnerText;
                ketQua.GiaTienThu = sachCanTim.SelectSingleNode("GiaTienThu").InnerText;
            }

            return ketQua;
        }

        public void HienThi(DataGridView dgv)
        {
            dgv.Rows.Clear();
            dgv.ColumnCount = 4;

            XmlNodeList ds = root.SelectNodes("PHIEUTHU");
            int sd = 0;//lưu chỉ số dòng
            foreach (XmlNode item in ds)
            {
                dgv.Rows.Add();
                dgv.Rows[sd].Cells[0].Value = item.SelectSingleNode("MaPT").InnerText;
                dgv.Rows[sd].Cells[1].Value = item.SelectSingleNode("MaSACH").InnerText;
                dgv.Rows[sd].Cells[2].Value = item.SelectSingleNode("NgayThu").InnerText;
                dgv.Rows[sd].Cells[3].Value = item.SelectSingleNode("GiaTienThu").InnerText;
                sd++;
            }
        }
    }
}
