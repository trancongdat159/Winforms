using baicuoiki2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace baicuoiki2.Controller
{
    internal class Export_slip_controller : IController
    {
        // Danh sách lưu trữ các phiếu xuất
        private List<IModel> items;

        // Khởi tạo danh sách các phiếu xuất
        public Export_slip_controller()
        {
            items = new List<IModel>();
        }

        // Danh sách các Items - trả về danh sách các phiếu xuất
        public List<IModel> Items => items;

        // Thêm một phiếu xuất vào danh sách
        public bool Add(IModel model)
        {
            if (model is baicuoiki2.Model.Export_slip exportSlip)
            {
                if (!IsExist(exportSlip.maPhieuXuat))
                {
                    items.Add(exportSlip);
                    return true;
                }
                else
                {
                    Console.WriteLine("Phiếu xuất đã tồn tại.");
                    return false;
                }
            }
            else
            {
                throw new ArgumentException("Model không hợp lệ.");
            }
        }

        // Xóa phiếu xuất dựa trên đối tượng model
        public bool Delete(IModel model)
        {
            if (model is baicuoiki2.Model.Export_slip exportSlip)
            {
                return items.Remove(exportSlip);
            }
            else
            {
                throw new ArgumentException("Model không hợp lệ.");
            }
        }

        // Xóa phiếu xuất dựa trên ID
        public bool Delete(object id)
        {
            var item = items.FirstOrDefault(m => (m as baicuoiki2.Model.Export_slip)?.maPhieuXuat == (int)id);
            if (item != null)
            {
                return items.Remove(item);
            }
            return false;
        }

        // Kiểm tra xem phiếu xuất với ID cụ thể có tồn tại không
        public bool IsExist(object id)
        {
            return items.Any(m => (m as baicuoiki2.Model.Export_slip)?.maPhieuXuat == (int)id);
        }

        // Tải danh sách phiếu xuất (giả định load từ cơ sở dữ liệu)
        public bool Load()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["QuanLyBanHangNetConnectionString"].ConnectionString;

            try
            {
                // Mở kết nối đến CSDL
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Tạo câu lệnh SQL để lấy dữ liệu từ bảng PHIEUXUAT
                    string query = "SELECT maPhieuXuat, maKhachHang, ngayXuat FROM PHIEUXUAT";

                    // Thực hiện truy vấn SQL
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Xóa danh sách cũ
                            items.Clear();

                            // Đọc dữ liệu từ reader và thêm vào danh sách items
                            while (reader.Read())
                            {
                                items.Add(new baicuoiki2.Model.Export_slip
                                {
                                    maPhieuXuat = reader.GetInt32(0),  // Lấy giá trị từ cột đầu tiên (maPhieuXuat)
                                    maKhachHang = reader.GetInt32(1),  // Lấy giá trị từ cột thứ hai (maKhachHang)
                                    NngayXuat = reader.GetDateTime(2)  // Lấy giá trị từ cột thứ ba (ngayXuat)
                                });
                            }
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

        // Đọc dữ liệu của phiếu xuất từ ID
        public IModel Read(object id)
        {
            return items.FirstOrDefault(m => (m as baicuoiki2.Model.Export_slip)?.maPhieuXuat == (int)id);
        }

        // Cập nhật thông tin phiếu xuất
        public bool Update(IModel model)
        {
            if (model is baicuoiki2.Model.Export_slip exportSlip)
            {
                var existingItem = items.FirstOrDefault(m => (m as baicuoiki2.Model.Export_slip)?.maPhieuXuat == exportSlip.maPhieuXuat);
                if (existingItem != null)
                {
                    items.Remove(existingItem);
                    items.Add(exportSlip);
                    return true;
                }
                else
                {
                    Console.WriteLine("Phiếu xuất không tồn tại để cập nhật.");
                    return false;
                }
            }
            else
            {
                throw new ArgumentException("Model không hợp lệ.");
            }
        }
    }
}
