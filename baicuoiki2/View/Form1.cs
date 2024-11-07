using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using baicuoiki2.View;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using baicuoiki2;

namespace baicuoiki2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Thiết lập kích thước và thuộc tính cho panelTC
            panelTC.Size = new Size(800, 600);  // Đặt kích thước lớn cho panel
            panelTC.Location = new Point(10, 60);  // Đặt vị trí cho panel để dễ dàng nhìn thấy
            panelTC.Dock = DockStyle.Fill;  // Đảm bảo panel chiếm toàn bộ không gian còn lại trên form
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Thêm mã xử lý khi Form1 load nếu cần thiết
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            // Thêm mã xử lý khi người dùng nhấn vào toolStripLabel1
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            // Thêm mã xử lý khi người dùng nhấn vào toolStripLabel2
        }

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            // Thêm mã xử lý khi người dùng nhấn vào toolStripLabel3
        }

        private void toolStrip3_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // Thêm mã xử lý khi một mục trong toolStrip3 được nhấn
        }

        private void toolStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // Thêm mã xử lý khi một mục trong toolStrip2 được nhấn
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // Thêm mã xử lý khi một mục trong toolStrip1 được nhấn
        }

        private void quảnLýPhiếuXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Export_slip exportSlip = new Export_slip();  // Tạo đối tượng từ lớp Export_slip
            panelTC.Controls.Clear();  // Xóa tất cả các điều khiển cũ trong panelTC
            exportSlip.Dock = DockStyle.Fill;  // Cho phép exportSlip chiếm toàn bộ không gian của panelTC
            panelTC.Controls.Add(exportSlip);  // Thêm exportSlip vào panelTC
            // Không cần exportSlip.Show() vì UserControl không có phương thức Show()
        }

        private void quảnLýKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Client clientForm = new Client();
            clientForm.Show();  // Hiển thị form quản lý khách hàng
        }




        private void panelTC_Paint(object sender, PaintEventArgs e)
        {
            // Thêm mã xử lý khi panelTC cần vẽ lại nếu cần thiết
        }

        private void quảnLýPhiếuXuấtToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                Exportslipdetails exportSlipdetails = new Exportslipdetails();
                panelTC.Controls.Clear();
                exportSlipdetails.Dock = DockStyle.Fill;
                panelTC.Controls.Add(exportSlipdetails);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void quảnLýChiTiếtPhiếuXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    Exportslipdetails exportslipdetail = new Exportslipdetails();
        //    panelTC.Controls.Clear();
        //    exportslipdetail.Dock = DockStyle.Fill;
        //    panelTC.Controls.Add(exportslipdetail);

        //}

    }
    
}
