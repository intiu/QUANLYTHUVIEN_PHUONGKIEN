using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYTHUVIEN_PHUONGKIEN.DTO
{
    public class BAOCAODTO
    {
        private string _MaBC;
        private string _NgayBC;
        private string _TienThuDuoc;
        private string _TongTien;

        public string MaBC
        {
            get { return _MaBC; }
            set { _MaBC = value; }
        }
        public string NgayBC
        {
            get { return _NgayBC; }
            set { _NgayBC = value; }
        }
        public string TienThuDuoc
        {
            get { return _TienThuDuoc; }
            set { _TienThuDuoc = value; }
        }
        public string TongTien
        {
            get { return _TongTien; }
            set { _TongTien = value; }
        }
    }
}
