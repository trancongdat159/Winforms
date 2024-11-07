using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using baicuoiki2.Controller;
using baicuoiki2.Model;
using System.Windows.Forms;

namespace baicuoiki2
{
    public partial class Exportslipdetailscontroller : IController
    {
        private string connectionString;

        public Exportslipdetailscontroller()
        {
            connectionString = ConfigurationManager.ConnectionStrings["QuanLyBanHangNetConnectionString"].ConnectionString;
        }

        List<IModel> IController.Items => throw new NotImplementedException();

        public bool Delete(object id)
        {
            throw new NotImplementedException();
        }

        public bool IsExist(object id)
        {
            throw new NotImplementedException();
        }

        public bool Load()
        {
            throw new NotImplementedException();
        }

        bool IController.Add(IModel model)
        {
            throw new NotImplementedException();
        }

        bool IController.Delete(IModel model)
        {
            throw new NotImplementedException();
        }

        IModel IController.Read(object id)
        {
            throw new NotImplementedException();
        }

        bool IController.Update(IModel model)
        {
            throw new NotImplementedException();
        }

        public void LoadHangHoaDataToView(Exportslipdetails view)
        {
            string[] hangHoaList = GetHangHoaList();
            if (hangHoaList.Length == 0)
            {
                MessageBox.Show("Không có dữ liệu để hiển thị trong ComboBox.");
            }
            view.LoadHangHoaData(hangHoaList);
        }

        // Phương thức để lấy dữ liệu chi tiết phiếu xuất dựa trên mã phiếu xuất
        internal List<Export_slip_details> GetChiTietPhieuXuat(string maPhieuXuat)
        {
            List<Export_slip_details> chiTietPhieuXuatList = new List<Export_slip_details>();

            if (!string.IsNullOrEmpty(maPhieuXuat))
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        if (connection.State != ConnectionState.Open)
                        {
                            throw new Exception("Không thể mở kết nối đến cơ sở dữ liệu.");
                        }
                        connection.Open();
                        string query = "SELECT * FROM ChiTietPhieuXuat WHERE maPhieuXuat = @MaPhieuXuat";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@MaPhieuXuat", maPhieuXuat);

                            SqlDataReader reader = command.ExecuteReader();
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    // Tạo đối tượng Export_slip_details từ dữ liệu đọc được
                                    Export_slip_details chiTiet = new Export_slip_details
                                    {
                                        IDPX = Convert.ToInt32(reader["IDPX"]),
                                        MaPhieuXuat = Convert.ToInt32(reader["maPhieuXuat"]),
                                        MaHangHoa = Convert.ToInt32(reader["maHangHoa"]),
                                        SoLuongXuat = Convert.ToInt32(reader["soLuongXuat"]),
                                        GiaXuat = Convert.ToDecimal(reader["giaXuat"])
                                    };
                                    chiTietPhieuXuatList.Add(chiTiet);
                                }
                            }
                            reader.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Lỗi khi lấy chi tiết phiếu xuất: " + ex.Message);
                    }
                }
            }

            return chiTietPhieuXuatList;
        }

        // Phương thức để lấy danh sách tên hàng hóa
        public string[] GetHangHoaList()
        {
            List<string> hangHoaList = new List<string>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT tenHangHoa FROM HangHoa";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            hangHoaList.Add(reader["tenHangHoa"].ToString());
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi lấy danh sách hàng hóa: " + ex.Message);
                }
            }

            return hangHoaList.ToArray();
        }
    }
}