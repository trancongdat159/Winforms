using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baicuoiki2.Model
{
    internal class Client : IModel
    {
        public int MaKhachHang { get; set; }
        public int MaTK { get; set; }
        public string TenKhachHang { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }

    }
}
