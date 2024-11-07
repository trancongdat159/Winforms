using baicuoiki2.Controller;
using baicuoiki2.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;

namespace baicuoiki2.View
{
    public partial class Export_slip : UserControl, Iview
    {
        private Export_slip_controller controller;

        public Export_slip()
        {
            InitializeComponent();
            this.Size = new Size(800, 600); // Đặt kích thước cụ thể cho UserControl

            // Khởi tạo controller
            controller = new Export_slip_controller();
            this.Load += new EventHandler(OnExportSlipLoad);
        }

        private void OnExportSlipLoad(object sender, EventArgs e)
        {
            // Tải dữ liệu từ controller và hiển thị trên DataGridView
            LoadDataToGrid();
        }

        public void LoadDataToGrid()
        {
            if (controller.Load())
            {
                // Chuyển đổi danh sách items từ controller thành danh sách Export_slip
                var exportSlips = controller.Items.OfType<baicuoiki2.Model.Export_slip>().ToList();
                if (exportSlips.Count > 0)
                {
                    // Gán danh sách vào DataGridView
                    dataGridView1.DataSource = exportSlips;
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu để hiển thị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Không thể tải dữ liệu từ cơ sở dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Phương thức này dùng để xóa tất cả các trường text
        public void ClearFields()
        {
            //textBox1.Clear();
            textBox2.Clear();
        }

        public void GetDataFromText()
        {
            try
            {
                // Lấy dữ liệu từ các trường nhập liệu của View
                //int maPhieuXuat = Convert.ToInt32(textBox1.Text);
                int maKhachHang = Convert.ToInt32(textBox2.Text);
                DateTime ngayXuat = dateTimePicker1.Value;

                // Tạo đối tượng Export_slip từ dữ liệu vừa nhập
                baicuoiki2.Model.Export_slip exportSlip = new baicuoiki2.Model.Export_slip
                {
                    //maPhieuXuat = maPhieuXuat,
                    maKhachHang = maKhachHang,
                    NngayXuat = ngayXuat
                };

                // Lưu dữ liệu vào cơ sở dữ liệu
                SaveToDatabase(exportSlip);
            }
            catch (FormatException)
            {
                MessageBox.Show("Dữ liệu nhập không hợp lệ. Vui lòng kiểm tra và thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SetDataToText(object item)
        {
            // Gán dữ liệu của đối tượng item vào các trường text
            if (item is baicuoiki2.Model.Export_slip exportSlip)
            {
                //textBox1.Text = exportSlip.maPhieuXuat.ToString();
                textBox2.Text = exportSlip.maKhachHang.ToString();
                dateTimePicker1.Value = exportSlip.NngayXuat;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy giá trị của ô được nhấn trong DataGridView và hiển thị lên các trường nhập liệu
                var selectedRow = dataGridView1.Rows[e.RowIndex].DataBoundItem as baicuoiki2.Model.Export_slip;
                if (selectedRow != null)
                {
                    SetDataToText(selectedRow);
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            // Xử lý sự kiện cho label5 (giữ nguyên theo yêu cầu)
        }

        private void label6_Click(object sender, EventArgs e)
        {
            // Giả sử lưu dữ liệu từ các trường vào cơ sở dữ liệu thông qua controller
            GetDataFromText();
            MessageBox.Show("Dữ liệu đã được lưu thành công", "Thông báo");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Thêm mã cần thiết cho việc vẽ, hoặc giữ trống nếu không cần
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Lưu dữ liệu từ các trường vào cơ sở dữ liệu thông qua controller
            GetDataFromText();
            // Tải lại dữ liệu vào DataGridView sau khi lưu thành công
            LoadDataToGrid();
            MessageBox.Show("Dữ liệu đã được lưu thành công", "Thông báo");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0].DataBoundItem as baicuoiki2.Model.Export_slip;
                if (selectedRow != null)
                {
                    controller.Delete(selectedRow.maPhieuXuat);
                    MessageBox.Show("Dữ liệu đã được xóa thành công", "Thông báo");

                    // Tải lại dữ liệu
                    LoadDataToGrid();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa", "Lỗi");
            }
        }

        private void SaveToDatabase(baicuoiki2.Model.Export_slip exportSlip)
        {
            // Lấy chuỗi kết nối từ app.config
            string connectionString = ConfigurationManager.ConnectionStrings["QuanLyBanHangNetConnectionString"].ConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Tạo câu lệnh SQL để thêm dữ liệu vào bảng PHIEUXUAT và lấy maPhieuXuat vừa được tạo
                    string query = "INSERT INTO PHIEUXUAT (maKhachHang, ngayXuat) VALUES (@maKhachHang, @ngayXuat); SELECT SCOPE_IDENTITY();";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thêm các tham số cho lệnh SQL
                        command.Parameters.AddWithValue("@maKhachHang", exportSlip.maKhachHang);
                        command.Parameters.AddWithValue("@ngayXuat", exportSlip.NngayXuat);

                        // Thực hiện lệnh SQL và lấy maPhieuXuat vừa được tạo
                        int maPhieuXuat = Convert.ToInt32(command.ExecuteScalar());

                        if (maPhieuXuat > 0)
                        {
                            MessageBox.Show("Dữ liệu đã được lưu thành công vào cơ sở dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Gọi lại phương thức LoadDataToGrid() để cập nhật DataGridView
                            LoadDataToGrid();

                            // Chuyển sang trang chi tiết phiếu xuất để thêm các chi tiết cho phiếu xuất này
                            //OpenExportSlipDetails(maPhieuXuat);
                        }
                        else
                        {
                            MessageBox.Show("Không có bản ghi nào được thêm vào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu vào cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hàm mở form Export_slip_details và truyền maPhieuXuat để thêm chi tiết
        private System.Windows.Forms.Panel panelTC;
        //private void OpenExportSlipDetails(int maPhieuXuat)
        //{
        //    Export_slip_details exportSlipDetailsView = new Export_slip_details(maPhieuXuat);
        //    panelTC.Controls.Clear();
        //    exportSlipDetailsView.Dock = DockStyle.Fill;
        //    panelTC.Controls.Add(exportSlipDetailsView);
        //}
    }
}