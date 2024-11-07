using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baicuoiki2.Model
{
    internal class Export_slip:IModel
    {
        public int maPhieuXuat { get; set; }
        public int maKhachHang { get; set; }
        public DateTime NngayXuat { get; set; }
    }
}
