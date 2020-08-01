using System;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using System.Xml;
using QUANLYTHUVIEN_PHUONGKIEN.DTO;

namespace QUANLYTHUVIEN_PHUONGKIEN.BLL
{
    public class THETHUVIENBLL
    {
        private XmlDocument doc = new XmlDocument();
        private XmlElement root;
        //private string "QLTV_PK.xml" = @"C:\Users\ltpnt\source\repos\QUANLYTHUVIEN_PHUONGKIEN\QUANLYTHUVIEN_PHUONGKIEN\QLTV_PK.xml";

        public THETHUVIENBLL()
        {
            doc.Load("QLTV_PK.xml");
            root = doc.DocumentElement;
        }

        public void Them(THETHUVIENDTO sachThem)
        {
            //tạo nút sách
            XmlNode sach = doc.CreateElement("THETHUVIEN");

            //tạo nút con của sách là MaSACH
            XmlElement mathethuvien = doc.CreateElement("MaTTV");
            mathethuvien.InnerText = sachThem.MaTTV;//gán giá trị cho mã sách
            sach.AppendChild(mathethuvien);//thêm MaSACH vào trong sách(sach nhận MaSACH là con)

            XmlElement ngaycapthethuvien = doc.CreateElement("NgayCapTTV");
            ngaycapthethuvien.InnerText = sachThem.NgayCapTTV;//gán giá trị cho mã sách
            sach.AppendChild(ngaycapthethuvien);//thêm MaSACH vào trong sách(sach nhận MaSACH là con)

            XmlElement ngayhethan = doc.CreateElement("NgayHetHan");
            ngayhethan.InnerText = sachThem.NgayHetHan;//gán giá trị cho mã sách
            sach.AppendChild(ngayhethan);//thêm MaSACH vào trong sách(sach nhận MaSACH là con)
           
            //sau khi tạo xong sách, thì thêm sách vào gốc root
            root.AppendChild(sach);
            doc.Save("QLTV_PK.xml");//lưu dữ liệu
        }


        public void Sua(THETHUVIENDTO sachSua)
        {
            //láy vị trí cần sửa theo mã sách cũ đưa vào
            XmlNode sachCu = root.SelectSingleNode("THETHUVIEN[MaTTV ='" + sachSua.MaTTV + "']");
            if (sachCu != null)
            {
                XmlNode sachSuaMoi = doc.CreateElement("THETHUVIEN");

                //tạo nút con của sách là MaSACH
                XmlElement mathethuvien = doc.CreateElement("MaTTV");
                mathethuvien.InnerText = sachSua.MaTTV;//gán giá trị cho mã sách
                sachSuaMoi.AppendChild(mathethuvien);//thêm MaSACH vào trong sách(sach nhận MaSACH là con)               

                XmlElement ngaycapthethuvien = doc.CreateElement("NgayCapTTV");
                ngaycapthethuvien.InnerText = sachSua.NgayCapTTV;//gán giá trị cho mã sách
                sachSuaMoi.AppendChild(ngaycapthethuvien);//thêm MaSACH vào trong sách(sach nhận MaSACH là con)

                XmlElement ngayhethan = doc.CreateElement("NgayHetHan");
                ngayhethan.InnerText = sachSua.NgayHetHan;//gán giá trị cho mã sách
                sachSuaMoi.AppendChild(ngayhethan);//thêm MaSACH vào trong sách(sach nhận MaSACH là con)
               
                //thay thế sách cũ bằng sách mới(sửa )
                root.ReplaceChild(sachSuaMoi, sachCu);
                doc.Save("QLTV_PK.xml");//lưu lại
            }
        }

        public void Xoa(THETHUVIENDTO sachXoa)
        {
            XmlNode sachCanXoa = root.SelectSingleNode("THETHUVIEN[MaTTV ='" + sachXoa.MaTTV + "']");
            if (sachCanXoa != null)
            {
                root.RemoveChild(sachCanXoa);

                doc.Save("QLTV_PK.xml");
            }
        }

        public void TimKiem(THETHUVIENDTO sachTim, DataGridView dgv)
        {
            dgv.Rows.Clear();
            XmlNode sachCanTim = root.SelectSingleNode("THETHUVIEN[MaTTV ='" + sachTim.MaTTV + "']");

            if (sachCanTim != null)
            {
                dgv.ColumnCount = 3;//khai báo số cột
                dgv.Rows.Add();//thêm một dòng mới

                //đưa dữ liệu vào dòng vừa tạo
                dgv.Rows[0].Cells[0].Value = sachCanTim.SelectSingleNode("MaTTV").InnerText;
                dgv.Rows[0].Cells[1].Value = sachCanTim.SelectSingleNode("NgayCapTTV").InnerText;
                dgv.Rows[0].Cells[2].Value = sachCanTim.SelectSingleNode("NgayHetHan").InnerText;
            }
        }

        /// <summary>
        /// Tìm và trả về đối tượng sách tìm thấy, không thấy = null
        /// </summary>
        /// <param name="sachTim">Đối tượng chứa thông tin tìm kiếm</param>
        /// <param name="dgv">grid view hiển thị</param>
        /// <returns>tìm thấy nếu khác null</returns>
        public THETHUVIENDTO TimKiem2(THETHUVIENDTO sachTim, DataGridView dgv)
        {
            THETHUVIENDTO ketQua = null;
            dgv.Rows.Clear();
            XmlNode sachCanTim = root.SelectSingleNode("THETHUVIEN[MaTTV ='" + sachTim.MaTTV + "']");
            if (sachCanTim != null)
            {
                dgv.ColumnCount = 3;//khai báo số cột
                dgv.Rows.Add();//thêm một dòng mới

                //đưa dữ liệu vào dòng vừa tạo
                dgv.Rows[0].Cells[0].Value = sachTim.MaTTV = sachCanTim.SelectSingleNode("MaTTV").InnerText;
                dgv.Rows[0].Cells[1].Value = sachCanTim.SelectSingleNode("NgayCapTTV").InnerText;
                dgv.Rows[0].Cells[2].Value = sachCanTim.SelectSingleNode("NgayHetHan").InnerText;

                ketQua = new THETHUVIENDTO();

                ketQua.MaTTV = sachCanTim.SelectSingleNode("MaTTV").InnerText;
                ketQua.NgayCapTTV = sachCanTim.SelectSingleNode("NgayCapTTV").InnerText;
                ketQua.NgayHetHan = sachCanTim.SelectSingleNode("NgayHetHan").InnerText;               
            }

            return ketQua;
        }

        public void HienThi(DataGridView dgv)
        {
            dgv.Rows.Clear();
            dgv.ColumnCount = 3;

            XmlNodeList ds = root.SelectNodes("THETHUVIEN");
            int sd = 0;//lưu chỉ số dòng
            foreach (XmlNode item in ds)
            {
                dgv.Rows.Add();
                dgv.Rows[sd].Cells[0].Value = item.SelectSingleNode("MaTTV").InnerText;
                dgv.Rows[sd].Cells[1].Value = item.SelectSingleNode("NgayCapTTV").InnerText;
                dgv.Rows[sd].Cells[2].Value = item.SelectSingleNode("NgayHetHan").InnerText;
                sd++;
            }
        }
    }
}
