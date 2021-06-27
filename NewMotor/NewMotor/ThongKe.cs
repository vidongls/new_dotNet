using NewMotor.Connect;
using System;
using System.Collections.Generic;

using System.Data;
using System.Data.SqlClient;

using System.Windows.Forms;
using app = Microsoft.Office.Interop.Excel.Application;
namespace NewMotor
{
    public partial class ThongKe : Form
    {
        private static int index;
       
        public ThongKe()
        {
            InitializeComponent();
        }
        SqlConnection cnn = new SqlConnection(connect.cnn);

        private void btnhienthi_Click(object sender, EventArgs e)
        {
            try
            {
                cnn.Open();
                string opera = "  select mapx As 'Mã phiếu',tenpx As 'Tên Phiếu Xuất',TenSP As 'Tên Sản Phẩm',Gia 'Đơn Giá',PhieuXuat.soluong as 'Số lượng',SanPham.Gia*PhieuXuat.soluong as 'Tổng Tiền',ngaylap as 'Ngày lập' from PhieuXuat INNER JOIN SanPham ON SanPham.MaSP = PhieuXuat.masp where ngaylap between '" + dtTu.Value + "' and '" + dtDe.Value + "' order by tongtien desc";
                SqlCommand cmd = new SqlCommand(opera, cnn);
                cmd.ExecuteNonQuery();
                DataTable table = new DataTable();
                SqlDataAdapter sdp = new SqlDataAdapter(cmd);
                sdp.Fill(table);
                grvthongke.DataSource = table;           
                if (grvthongke.Rows.Count == 0)
                {
                    MessageBox.Show("Không tồn tại tháng cần thống kê!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
               
            }
            catch
            {
                MessageBox.Show("Thất bại!");

            }
            finally
            {
                cnn.Close();
            }
        }
             
        private void grvthongke_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            if (index >= 0)
            {
                txttongtien.Text = grvthongke.Rows[index].Cells["Tổng tiền"].Value.ToString();
            }
        }

        private void grvthongke_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
          
        }

        private void ThongKe_Load(object sender, EventArgs e)
        {
            txttongtien.Enabled = false;
            Action();
        }
        void Action()
        {
            if (Login.role == 1)
            {
                btnhienthi.Enabled = true;

            }
            else if (Login.role == 2)
            {
                btnhienthi.Enabled = false;
            }
            else if (Login.role == 3)
            {
                btnhienthi.Enabled = true;
            }
        }
        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }
        private void export2Excel(DataGridView g, string duongDan, string tenTap)
        {
            app obj = new app();
            obj.Application.Workbooks.Add(Type.Missing);
            obj.Columns.ColumnWidth = 25;
            for (int i = 1; i < g.Columns.Count + 1; i++) { obj.Cells[1, i] = g.Columns[i - 1].HeaderText; }
            for (int i = 0; i < g.Rows.Count; i++)
            {
                for (int j = 0; j < g.Columns.Count; j++)
                {
                    if (g.Rows[i].Cells[j].Value != null) { obj.Cells[i + 2, j + 1] = g.Rows[i].Cells[j].Value.ToString(); }
                }
            }
            obj.ActiveWorkbook.SaveCopyAs(duongDan + tenTap + ".xlsx");
            obj.ActiveWorkbook.Saved = true;
        }
        private void btnexcel_Click(object sender, EventArgs e)
        {
            export2Excel(grvthongke, @"D:\", "ThongKeExcel");
            /*
            if (grvthongke.Rows.Count <=0)
            {
                MessageBox.Show("Không tồn tại dữ liệu!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else{
                Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel.Worksheet worksheet = null;
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            app.Visible = true;
            worksheet.Cells[1, 5] = "BẢNG Thống Kê";
            worksheet.Cells[3, 1] = "STT";
            worksheet.Cells[3, 2] = "Mã phiếu"+grvthongke.Rows[index].Cells[0].Value.ToString();
            worksheet.Cells[3, 3] = "Tên phiếu" + grvthongke.Rows[index].Cells[1].Value.ToString();
            worksheet.Cells[3, 4] = "Tên sản phẩm" + grvthongke.Rows[index].Cells[2].Value.ToString();
            worksheet.Cells[3, 5] = "Đơn giá" + grvthongke.Rows[index].Cells[3].Value.ToString();
            worksheet.Cells[3, 6] = "Số lượng" + grvthongke.Rows[index].Cells[4].Value.ToString();
            worksheet.Cells[3, 7] = "Tổng Tiền" + grvthongke.Rows[index].Cells[5].Value.ToString();
            worksheet.Cells[3, 8] = "Ngày Lập" + grvthongke.Rows[index].Cells[6].Value.ToString();

            for (int i = 0; i < grvthongke.RowCount; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    worksheet.Cells[i + 4, 1] = i + 1;
                    worksheet.Cells[i + 4, j + 2] = grvthongke.Rows[i].Cells[j].FormattedValue.ToString();
                }
            }

            }*/

        }
    }
}
