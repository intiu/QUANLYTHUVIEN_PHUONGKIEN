using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYTHUVIEN_PHUONGKIEN.DTO
{
    public class DOCGIADTO
    {
        private string _MaDG;
        private string _MaTTV;
        private string _TenDG;
        private string _SDTDG;
        private string _GTDG;
        private string _NgaySinhDG;
        private string _NgayCapTTV;
        private string _NgayHetHanTTV;

        public string MaDG
        {
            get { return _MaDG; }
            set { _MaDG = value; }
        }
        public string MaTTV
        {
            get { return _MaTTV; }
            set { _MaTTV = value; }
        }
        public string TenDG
        {
            get { return _TenDG; }
            set { _TenDG = value; }
        }
        public string SDTDG
        {
            get { return _SDTDG; }
            set { _SDTDG = value; }
        }
        public string GTDG
        {
            get { return _GTDG; }
            set { _GTDG = value; }
        }
        public string NgaySinhDG
        {
            get { return _NgaySinhDG; }
            set { _NgaySinhDG = value; }
        }

        public string NgayCapTTV
        {
            get { return _NgayCapTTV; }
            set { _NgayCapTTV = value; }
        }
        public string NgayHetHanTTV
        {
            get { return _NgayHetHanTTV; }
            set { _NgayHetHanTTV = value; }
        }

    }
}
