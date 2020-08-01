using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYTHUVIEN_PHUONGKIEN.DTO
{
    public class NHAXUATBANDTO
    {
        private string _MaNXB;
        private string _TenNXB;
        private string _DiaChiNXB;
        private string _EmailNXB;
        private string _SDTNXB;       

        public string MaNXB
        {
            get { return _MaNXB; }
            set { _MaNXB = value; }
        }
        public string TenNXB
        {
            get { return _TenNXB; }
            set { _TenNXB = value; }
        }
        public string DiaChiNXB
        {
            get { return _DiaChiNXB; }
            set { _DiaChiNXB = value; }
        }
        public string EmailNXB
        {
            get { return _EmailNXB; }
            set { _EmailNXB = value; }
        }
        public string SDTNXB
        {
            get { return _SDTNXB; }
            set { _SDTNXB = value; }
        }       

    }
}
