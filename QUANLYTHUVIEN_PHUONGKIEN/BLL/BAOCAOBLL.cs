using System;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using System.Xml;
using QUANLYTHUVIEN_PHUONGKIEN.DTO;

namespace QUANLYTHUVIEN_PHUONGKIEN.BLL
{
    public class BAOCAOBLL
    {
        private XmlDocument doc = new XmlDocument();
        private XmlElement root;
        //private string "QLTV_PK.xml" = @"C:\Users\ltpnt\source\repos\QUANLYTHUVIEN_PHUONGKIEN\QUANLYTHUVIEN_PHUONGKIEN\QLTV_PK.xml";

        public BAOCAOBLL()
        {
            doc.Load("QLTV_PK.xml");
            root = doc.DocumentElement;
        }

        public void Them(BAOCAODTO sachThem)
        {
            //tạo nút sách
            XmlNode sach = doc.CreateElement("BAOCAO");

            //tạo nút con của sách là MaSACH
            XmlElement mabaocao = doc.CreateElement("MaBC");
            mabaocao.InnerText = sachThem.MaBC;//gán giá trị cho mã sách
            sach.AppendChild(mabaocao);//thêm MaSACH vào trong sách(sach nhận MaSACH là con)

            XmlElement ngaybaocao = doc.CreateElement("NgayBC");
            ngaybaocao.InnerText = sachThem.NgayBC;//gán giá trị cho mã sách
            sach.AppendChild(ngaybaocao);//thêm MaSACH vào trong sách(sach nhận MaSACH là con)   

            XmlElement tienthuduoc = doc.CreateElement("TienThuDuoc");
            tienthuduoc.InnerText = sachThem.TienThuDuoc;//gán giá trị cho mã sách
            sach.AppendChild(tienthuduoc);//thêm MaSACH vào trong sách(sach nhận MaSACH là con)

            XmlElement tongtien = doc.CreateElement("TongTien");
            tongtien.InnerText = sachThem.TongTien;//gán giá trị cho mã sách
            sach.AppendChild(tongtien);//thêm MaSACH vào trong sách(sach nhận MaSACH là con)  

            //sau khi tạo xong sách, thì thêm sách vào gốc root
            root.AppendChild(sach);
            doc.Save("QLTV_PK.xml");//lưu dữ liệu
        }


        public void Sua(BAOCAODTO sachSua)
        {
            //láy vị trí cần sửa theo mã sách cũ đưa vào
            XmlNode sachCu = root.SelectSingleNode("BAOCAO[MaBC ='" + sachSua.MaBC + "']");
            if (sachCu != null)
            {
                XmlNode sachSuaMoi = doc.CreateElement("BAOCAO");

                //tạo nút con của sách là MaSACH
                XmlElement mabaocao = doc.CreateElement("MaBC");
                mabaocao.InnerText = sachSua.MaBC;//gán giá trị cho mã sách
                sachSuaMoi.AppendChild(mabaocao);//thêm MaSACH vào trong sách(sach nhận MaSACH là con)               

                XmlElement ngaybaocao = doc.CreateElement("NgayBC");
                ngaybaocao.InnerText = sachSua.NgayBC;//gán giá trị cho mã sách
                sachSuaMoi.AppendChild(ngaybaocao);//thêm MaSACH vào trong sách(sach nhận MaSACH là con)

                XmlElement tienthuduoc = doc.CreateElement("TienThuDuoc");
                tienthuduoc.InnerText = sachSua.TienThuDuoc;//gán giá trị cho mã sách
                sachSuaMoi.AppendChild(tienthuduoc);//thêm MaSACH vào trong sách(sach nhận MaSACH là con)

                XmlElement tongtien = doc.CreateElement("TongTien");
                tongtien.InnerText = sachSua.TongTien;//gán giá trị cho mã sách
                sachSuaMoi.AppendChild(tongtien);//thêm MaSACH vào tong sách(sach nhận MaSACH là con)

                //thay thế sách cũ bằng sách mới(sửa )
                root.ReplaceChild(sachSuaMoi, sachCu);
                doc.Save("QLTV_PK.xml");//lưu lại
            }
        }

        public void Xoa(BAOCAODTO sachXoa)
        {
            XmlNode sachCanXoa = root.SelectSingleNode("BAOCAO[MaBC ='" + sachXoa.MaBC + "']");
            if (sachCanXoa != null)
            {
                root.RemoveChild(sachCanXoa);

                doc.Save("QLTV_PK.xml");
            }
        }

        public void TimKiem(BAOCAODTO sachTim, DataGridView dgv)
        {
            dgv.Rows.Clear();
            XmlNode sachCanTim = root.SelectSingleNode("BAOCAO[MaBC ='" + sachTim.MaBC + "']");

            if (sachCanTim != null)
            {
                dgv.ColumnCount = 4;//khai báo số cột
                dgv.Rows.Add();//thêm một dòng mới

                //đưa dữ liệu vào dòng vừa tạo
                dgv.Rows[0].Cells[0].Value = sachCanTim.SelectSingleNode("MaBC").InnerText;
                dgv.Rows[0].Cells[1].Value = sachCanTim.SelectSingleNode("NgayBC").InnerText;
                dgv.Rows[0].Cells[2].Value = sachCanTim.SelectSingleNode("TienThuDuoc").InnerText;
                dgv.Rows[0].Cells[3].Value = sachCanTim.SelectSingleNode("TongTien").InnerText;
            }
        }

        /// <summary>
        /// Tìm và trả về đối tượng sách tìm thấy, không thấy = null
        /// </summary>
        /// <param name="sachTim">Đối tượng chứa thông tin tìm kiếm</param>
        /// <param name="dgv">grid view hiển thị</param>
        /// <returns>tìm thấy nếu khác null</returns>
        public BAOCAODTO TimKiem2(BAOCAODTO sachTim, DataGridView dgv)
        {
            BAOCAODTO ketQua = null;
            dgv.Rows.Clear();
            XmlNode sachCanTim = root.SelectSingleNode("BAOCAO[MaBC ='" + sachTim.MaBC + "']");
            if (sachCanTim != null)
            {
                dgv.ColumnCount = 4;//khai báo số cột
                dgv.Rows.Add();//thêm một dòng mới

                //đưa dữ liệu vào dòng vừa tạo
                dgv.Rows[0].Cells[0].Value = sachTim.MaBC = sachCanTim.SelectSingleNode("MaBC").InnerText;
                dgv.Rows[0].Cells[1].Value = sachCanTim.SelectSingleNode("NgayBC").InnerText;
                dgv.Rows[0].Cells[2].Value = sachCanTim.SelectSingleNode("TienThuDuoc").InnerText;
                dgv.Rows[0].Cells[3].Value = sachCanTim.SelectSingleNode("TongTien").InnerText;

                ketQua = new BAOCAODTO();

                ketQua.MaBC = sachCanTim.SelectSingleNode("MaBC").InnerText;
                ketQua.NgayBC = sachCanTim.SelectSingleNode("NgayBC").InnerText;
                ketQua.NgayBC = sachCanTim.SelectSingleNode("TienThuDuoc").InnerText;
                ketQua.NgayBC = sachCanTim.SelectSingleNode("TongTien").InnerText;
            }

            return ketQua;
        }

        public void HienThi(DataGridView dgv)
        {
            dgv.Rows.Clear();
            dgv.ColumnCount = 4;

            XmlNodeList ds = root.SelectNodes("BAOCAO");
            int sd = 0;//lưu chỉ số dòng
            foreach (XmlNode item in ds)
            {
                dgv.Rows.Add();
                dgv.Rows[sd].Cells[0].Value = item.SelectSingleNode("MaBC").InnerText;
                dgv.Rows[sd].Cells[1].Value = item.SelectSingleNode("NgayBC").InnerText;
                dgv.Rows[sd].Cells[2].Value = item.SelectSingleNode("TienThuDuoc").InnerText;
                dgv.Rows[sd].Cells[3].Value = item.SelectSingleNode("TongTien").InnerText;
                sd++;
            }
        }
    }
}
