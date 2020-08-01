using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYTHUVIEN_PHUONGKIEN.DTO
{
    public class PHIEUMUONDTO
    {
        private string _MaPM;
        private string _MaSACH;
        private string _NgayMuon;
        private string _NgayTra;
        private string _HanTra;

        public string MaPM
        {
            get { return _MaPM; }
            set { _MaPM = value; }
        }
        public string MaSACH
        {
            get { return _MaSACH; }
            set { _MaSACH = value; }
        }
        public string NgayMuon
        {
            get { return _NgayMuon; }
            set { _NgayMuon = value; }
        }
        public string NgayTra
        {
            get { return _NgayTra; }
            set { _NgayTra = value; }
        }
        public string HanTra
        {
            get { return _HanTra; }
            set { _HanTra = value; }
        }
    }
}
