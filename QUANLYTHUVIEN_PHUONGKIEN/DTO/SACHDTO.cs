using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYTHUVIEN_PHUONGKIEN.DTO
{
    public class SACHDTO
    {
        private string _MaSACH;
        private string _MaPT;
        private string _MaPM;
        private string _TenSach;
        private string _TacGia;
        private string _TenLoaiSach;
        private string _NgonNgu;
        private int _SLNhap;
        private string _VITRIDATSACH;
        private string _NhaXuatBan;
        private string _TinhTrang;

        public string MaSACH
        {
            get { return _MaSACH; }
            set { _MaSACH = value; }
        }
        public string MaPT
        {
            get { return _MaPT; }
            set { _MaPT = value; }
        }
        public string MaPM
        {
            get { return _MaPM; }
            set { _MaPM = value; }
        }
        public string TenSach
        {
            get { return _TenSach; }
            set { _TenSach = value; }
        }
        public string TacGia
        {
            get { return _TacGia; }
            set { _TacGia = value; }
        }
        public string TenLoaiSach
        {
            get { return _TenLoaiSach; }
            set { _TenLoaiSach = value; }
        }
        public string NgonNgu
        {
            get { return _NgonNgu; }
            set { _NgonNgu = value; }
        }
        public int SLNhap
        {
            get { return _SLNhap; }
            set { _SLNhap = value; }
        }

        public string VITRIDATSACH
        {
            get { return _VITRIDATSACH; }
            set { _VITRIDATSACH = value; }
        }
        public string NhaXuatBan
        {
            get { return _NhaXuatBan; }
            set { _NhaXuatBan = value; }
        }
        public string TinhTrang
        {
            get { return _TinhTrang; }
            set { _TinhTrang = value; }
        }


    }
}
