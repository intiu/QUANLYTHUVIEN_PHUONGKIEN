using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYTHUVIEN_PHUONGKIEN.DTO
{
    public class PHIEUTHUDTO
    {
        private string _MaPT;
        private string _MaSACH;
        private string _NgayThu;
        private string _GiaTienThu;

        public string MaPT
        {
            get { return _MaPT; }
            set { _MaPT = value; }
        }
        public string MaSACH
        {
            get { return _MaSACH; }
            set { _MaSACH = value; }
        }
        public string NgayThu
        {
            get { return _NgayThu; }
            set { _NgayThu = value; }
        }
        public string GiaTienThu
        {
            get { return _GiaTienThu; }
            set { _GiaTienThu = value; }
        }
    }
}
