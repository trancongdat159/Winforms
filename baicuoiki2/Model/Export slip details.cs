using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace baicuoiki2.Model
{
    internal class Export_slip_details : IModel
    {
        public int IDPX { get; set; }
        public int MaPhieuXuat { get; set; }
        public int MaHangHoa { get; set; }
        public int SoLuongXuat { get; set; }
        public decimal GiaXuat { get; set; }
        public DockStyle Dock { get; internal set; }
    }
}
