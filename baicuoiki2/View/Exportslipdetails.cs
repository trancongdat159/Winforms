using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using baicuoiki2.Controller;
using baicuoiki2.Model;
using baicuoiki2.View;

namespace baicuoiki2
{
    public partial class Exportslipdetails : UserControl, Iview
    {
        private Exportslipdetailscontroller controller;
        private string selectedMaHangHoa;

        public Exportslipdetails()
        {
            InitializeComponent();
            controller = new Exportslipdetailscontroller();
            LoadData();
        }

        private void LoadData()
        {
            controller.LoadHangHoaDataToView(this);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Xử lý logic vẽ trên panel nếu cần thiết
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string maPhieuXuat = textBox1.Text;

            if (!string.IsNullOrEmpty(maPhieuXuat))
            {
                try
                {
                    List<Export_slip_details> chiTietPhieuXuatList = controller.GetChiTietPhieuXuat(maPhieuXuat);
                    if (chiTietPhieuXuatList.Count > 0)
                    {
                        foreach (var chiTiet in chiTietPhieuXuatList)
                        {
                            // Xử lý dữ liệu lấy được từ bảng ChiTietPhieuXuat
                            MessageBox.Show($"Mã Hàng Hóa: {chiTiet.MaHangHoa}, Số Lượng Xuất: {chiTiet.SoLuongXuat}, Giá Xuất: {chiTiet.GiaXuat}");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy mã phiếu xuất.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                string selectedHangHoa = comboBox1.SelectedItem.ToString();
                MessageBox.Show($"Bạn đã chọn: {selectedHangHoa}");
            }
        }

        // Phương thức này được gọi từ controller để đổ dữ liệu vào ComboBox
        public void LoadHangHoaData(string[] hangHoaList)
        {
            comboBox1.Items.Clear();
            if (hangHoaList != null && hangHoaList.Length > 0)
            {
                foreach (string tenHangHoa in hangHoaList)
                {
                    comboBox1.Items.Add(tenHangHoa);
                }

                MessageBox.Show($"Đã tìm thấy {comboBox1.Items.Count} sản phẩm trong danh sách hàng hóa.");
            }
            else
            {
                MessageBox.Show("Không có dữ liệu trong comboBox.");
            }
        }

        public void GetDataFromText()
        {
            throw new NotImplementedException();
        }

        public void SetDataToText(object item)
        {
            throw new NotImplementedException();
        }

        public void ClearFields()
        {
            throw new NotImplementedException();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0)
            //{
            //    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            //    string idpx = row.Cells["IDPX"].Value.ToString();
            //    string maPhieuXuat = row.Cells["MaPhieuXuat"].Value.ToString();
            //    string maHangHoa = row.Cells["MaHangHoa"].Value.ToString();
            //    string soLuongXuat = row.Cells["SoLuongXuat"].Value.ToString();
            //    string giaXuat = row.Cells["GiaXuat"].Value.ToString();

            //    MessageBox.Show($"IDPX: {idpx}, Mã Phiếu Xuất: {maPhieuXuat}, Mã Hàng Hóa: {maHangHoa}, Số Lượng Xuất: {soLuongXuat}, Giá Xuất: {giaXuat}");
            //    selectedMaHangHoa = maHangHoa;
            //}
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(selectedMaHangHoa))
            //{
            //    DataGridViewRow newRow = new DataGridViewRow();
            //    newRow.CreateCells(dataGridView1);
            //    newRow.Cells[0].Value = selectedMaHangHoa; // Mã hàng hóa
            //    newRow.Cells[1].Value = comboBox1.SelectedItem.ToString(); // Tên hàng hóa
            //    dataGridView1.Rows.Add(newRow);
            //    MessageBox.Show($"Đã thêm mã hàng hóa: {selectedMaHangHoa} vào DataGridView.");
            //}
            //else
            //{
            //    MessageBox.Show("Vui lòng chọn một hàng hóa từ ComboBox trước khi ấn nút.");
            //}
        }

        //private void button1_Click(object sender, EventArgs e)
        //{

        //}

    }
}
