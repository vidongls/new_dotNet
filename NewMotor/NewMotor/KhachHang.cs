using NewMotor.Connect;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using app = Microsoft.Office.Interop.Excel.Application;
namespace NewMotor
{
    public partial class KhachHang : Form
    {
        public KhachHang()
        {
            InitializeComponent();
        }
        SqlConnection cnn = new SqlConnection(connect.cnn);
        public void ketnoi()
        {
            SqlConnection cnn = new SqlConnection(connect.cnn);
            cnn.Open();
            string dangnhap = "SELECT MaKhachHang 'Mã khách hàng', TenKhachHang AS 'Tên khách hàng', LienHe 'Liên hệ', DiaChi 'Địa Chỉ' FROM KhachHang";
            SqlCommand cmd = new SqlCommand(dangnhap, cnn);
            cmd.ExecuteNonQuery();
            DataTable table = new DataTable();
            SqlDataAdapter sdp = new SqlDataAdapter(cmd);
            sdp.Fill(table);
            grvkh.DataSource = table;
        }
        private void getMaKH()
        {
            SqlCommand cmd = new SqlCommand("select *from KhachHang", cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "KhachHang");
            cbxmakh.DataSource = ds.Tables["KhachHang"];
            cbxmakh.DisplayMember = "MaKhachHang";
            cbxmakh.ValueMember = "MaKhachHang";
        }

        private void KhachHang_Load(object sender, EventArgs e)
        {
            getMaKH();
            ketnoi();
        }
        private void xoatext()
        {
            txtdiachi.Text = "";
            txtlienhe.Text = "";
            txttenkh.Text = "";
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
           
            try
            {
                if (txtdiachi.Text == "" || txtlienhe.Text == "" || txttenkh.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập thông tin!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    cnn.Open();
                    string them = "INSERT INTO KhachHang(TenKhachHang,LienHe,DiaChi) VALUES(N'" + txttenkh.Text + "',N'" + txtlienhe.Text + "',N'" + txtdiachi.Text + "')";
                    SqlCommand cmd = new SqlCommand(them, cnn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm thành công!");
                    ketnoi();
                    getMaKH();
                    xoatext();
                }
            }
            catch
            {
                MessageBox.Show("Thêm thất bại!");
            }
            finally
            {
                cnn.Close();
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {          
            try
            {
                cnn.Open();
                if (txtdiachi.Text == "" || txtlienhe.Text == "" || txttenkh.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập thông tin!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    string sua = "UPDATE KhachHang SET TenKHachHang = N'" + txttenkh.Text + "',LienHe = N'" + txtlienhe.Text + "',DiaChi = N'" + txtdiachi.Text + "' Where MaKhachHang = N'" + cbxmakh.SelectedValue + "'";
                    SqlCommand cmd = new SqlCommand(sua, cnn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Sửa thành công!");
                    getMaKH();
                    ketnoi();
                    xoatext();
                }

            }
            catch
            {
                MessageBox.Show("Sửa thất bại!");
            }
            finally
            {
                cnn.Close();
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
       
            try
            {
                cnn.Open();
                string xoa = "DELETE FROM KhachHang Where MaKhachHang = N'" + cbxmakh.SelectedValue + "'";
                SqlCommand cmd = new SqlCommand(xoa, cnn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xoá thành công!");
                getMaKH();
                ketnoi();
                xoatext();
            }
            catch
            {
                MessageBox.Show("Xoá thất bại!");
            }
            finally
            {
                cnn.Close();
            }
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txttimkiem.Text != "")
                {
                    cnn.Open();
                    string timkiem = "Select *FROM KhachHang where TenKhachHang like '%'+ N'" + txttimkiem.Text + "' + '%'";
                    SqlCommand cmd = new SqlCommand(timkiem, cnn);
                    SqlDataReader adt = cmd.ExecuteReader();
                    DataTable table = new DataTable();
                    table.Load(adt);
                    grvkh.DataSource = table;
                    txttimkiem.Text = "";
                }
                else
                {
                    MessageBox.Show("Mời bạn nhập thông tin cần tìm ?", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
            catch
            {
                MessageBox.Show("Tìm kiếm thất bại!");
            }
            finally
            {
                cnn.Close();
            }
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
            export2Excel(grvkh, @"D:\", "KhachHangExcel");
        }

        private void grvkh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                cbxmakh.SelectedValue = grvkh.Rows[index].Cells[0].Value.ToString();
                txttenkh.Text = grvkh.Rows[index].Cells[1].Value.ToString();
                txtlienhe.Text = grvkh.Rows[index].Cells[2].Value.ToString();
                txtdiachi.Text = grvkh.Rows[index].Cells[3].Value.ToString();
                cbxmakh.Enabled = false;
                btnsua.Enabled = true;
                btnxoa.Enabled = true;

            }
        }
    }
}
