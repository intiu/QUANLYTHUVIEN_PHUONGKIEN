using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYTHUVIEN_PHUONGKIEN.DTO
{
    public class NHANVIENDTO
    {
        private string _MaNV;
        private string _TenNV;
        private string _TaiKhoanNV;
        private string _MatKhauNV;
        private string _NgaySinhNV;
        private string _DiaChiNV;
        private string _SDTNV;
        private string _LuongNV;

        public string MaNV
        {
            get { return _MaNV; }
            set { _MaNV = value; }
        }
        public string TenNV
        {
            get { return _TenNV; }
            set { _TenNV = value; }
        }
        public string TaiKhoanNV
        {
            get { return _TaiKhoanNV; }
            set { _TaiKhoanNV = value; }
        }
        public string MatKhauNV
        {
            get { return _MatKhauNV; }
            set { _MatKhauNV = value; }
        }
        public string NgaySinhNV
        {
            get { return _NgaySinhNV; }
            set { _NgaySinhNV = value; }
        }
        public string DiaChiNV
        {
            get { return _DiaChiNV; }
            set { _DiaChiNV = value; }
        }
        public string SDTNV
        {
            get { return _SDTNV; }
            set { _SDTNV = value; }
        }
        public string LuongNV
        {
            get { return _LuongNV; }
            set { _LuongNV = value; }
        }
    }
}
