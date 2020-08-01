using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYTHUVIEN_PHUONGKIEN.DTO
{
    public class THETHUVIENDTO
    {
        private string _MaTTV;
        private string _NgayCapTTV;
        private string _NgayHetHan;

        public string MaTTV
        {
            get { return _MaTTV; }
            set { _MaTTV = value; }
        }
        public string NgayCapTTV
        {
            get { return _NgayCapTTV; }
            set { _NgayCapTTV = value; }
        }
        public string NgayHetHan
        {
            get { return _NgayHetHan; }
            set { _NgayHetHan = value; }
        }       
    }
}
