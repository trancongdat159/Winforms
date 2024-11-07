using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace baicuoiki2.Controller
{
    public class ExportSlipDetailsController
    {
        private string connectionString;
        private SqlConnection connection;
        private DataTable dataTable;

        public ExportSlipDetailsController()
        {
            connectionString = ConfigurationManager.ConnectionStrings["QuanLyBanHangNetConnectionString"].ConnectionString;
            connection = new SqlConnection(connectionString);
            dataTable = new DataTable();
        }

        // Phương thức lấy tất cả mã phiếu xuất để hiển thị vào ComboBox
        public DataTable LoadDataForAllPhieuXuat()
        {
            try
            {
                connection.Open();
                string query = "SELECT maPhieuXuat FROM PHIEUXUAT";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                dataTable.Clear();
                adapter.Fill(dataTable);
                return dataTable;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        // Phương thức lưu dữ liệu vào chi tiết phiếu xuất
        public void SaveDataToChiTietPhieuXuat(DataTable dataTable)
        {
            try
            {
                connection.Open();
                foreach (DataRow row in dataTable.Rows)
                {
                    string query = "INSERT INTO CHITIETPHIEUXUAT (maPhieuXuat, maHangHoa, soLuongXuat) VALUES (@maPhieuXuat, @maHangHoa, @soLuongXuat)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@maPhieuXuat", row["maPhieuXuat"]);
                    command.Parameters.AddWithValue("@maHangHoa", row["maHangHoa"]);
                    command.Parameters.AddWithValue("@soLuongXuat", row["soLuongXuat"]);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        // Phương thức lấy thông tin phiếu xuất dựa trên mã phiếu xuất
        public DataRow LoadDataForPhieuXuat(string maPhieuXuat)
        {
            try
            {
                connection.Open();
                string query = "SELECT * FROM PHIEUXUAT WHERE maPhieuXuat = @maPhieuXuat";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@maPhieuXuat", maPhieuXuat);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                dataTable.Clear();
                adapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    return dataTable.Rows[0];
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        // Phương thức lấy thông tin của hàng hóa dựa vào mã hàng hóa
        public DataTable LoadDataForHangHoa(string maHangHoa)
        {
            try
            {
                connection.Open();
                string query = "SELECT * FROM HANGHOA WHERE maHangHoa = @maHangHoa";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@maHangHoa", maHangHoa);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                dataTable.Clear();
                adapter.Fill(dataTable);
                return dataTable;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        // Phương thức lấy tất cả mã hàng hóa để hiển thị vào ComboBox
        public DataTable LoadDataForAllHangHoa()
        {
            try
            {
                connection.Open();
                string query = "SELECT maHangHoa, tenHangHoa FROM HANGHOA";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                dataTable.Clear();
                adapter.Fill(dataTable);
                return dataTable;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
