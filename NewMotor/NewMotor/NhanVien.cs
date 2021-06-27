using NewMotor.Connect;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using app = Microsoft.Office.Interop.Excel.Application;
namespace NewMotor
{
    public partial class NhanVien : Form
    {
        public NhanVien()
        {
            InitializeComponent();
        }
        SqlConnection cnn = new SqlConnection(connect.cnn);
        public void ketnoi()
        {
            SqlConnection cnn = new SqlConnection(connect.cnn);
            cnn.Open();
            string dangnhap = "SELECT MaNV 'Mã nhân viên', TenNV 'Tên nhân viên', GioiTinh 'Giới tính', NgaySinh 'Ngày sinh', DiaChi 'Địa chỉ', Lienhe 'Liên hệ', MaCV 'Mã chức vụ' FROM dbo.NhanVien";
            SqlCommand cmd = new SqlCommand(dangnhap, cnn);
            cmd.ExecuteNonQuery();
            DataTable table = new DataTable();
            SqlDataAdapter sdp = new SqlDataAdapter(cmd);
            sdp.Fill(table);
            gridviewnv.DataSource = table;
            cnn.Close();
        }
        private void getMaNV()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM NhanVien", cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "NhanVien");
            cbxmanv.DataSource = ds.Tables["NhanVien"];
            cbxmanv.DisplayMember = "MaNV";
            cbxmanv.ValueMember = "MaNV";
        }
        private void getCV()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM ChucVu", cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "ChucVu");
            cbxmacv.DataSource = ds.Tables["ChucVu"];
            cbxmacv.DisplayMember = "tencv";
            cbxmacv.ValueMember = "macv";
        }
        private void vohieu()
        {
            cbxmanv.Enabled = false;
            btnthem.Enabled = true;
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
        }
        private void xoatext()
        {
            txtdiachi.Text = "";
            txtlienhe.Text = "";
            txttennv.Text = "";
            txttimkiem.Text = "";
        }

        private void NhanVien_Load(object sender, EventArgs e)
        {
            ketnoi();
            getMaNV();
            getCV();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
          
            try
            {
                cnn.Close();
                if (txtdiachi.Text == "" || txtlienhe.Text == "" || txttennv.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập thông tin!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    cnn.Open();
                    string them = "INSERT INTO NhanVien(TenNV,GioiTinh,NgaySinh,DiaChi,Lienhe,MaCV) VALUES(N'" + txttennv.Text + "',N'" + cbxgioitinh.Text + "',N'" + Convert.ToDateTime(datetimepk.Text) + "',N'" + txtdiachi.Text + "',N'" + txtlienhe.Text + "',N'" + cbxmacv.SelectedValue + "')";
                    SqlCommand cmd = new SqlCommand(them, cnn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm thành công!");
                    ketnoi();
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
            vohieu();
      
            try
            {
                cnn.Close();
                cnn.Open();
                if (txtdiachi.Text == "" || txtlienhe.Text == "" || txttennv.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập thông tin!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    string sua = "UPDATE NhanVien SET TenNV = N'" + txttennv.Text + "',GioiTinh = N'" + cbxgioitinh.Text + "',NgaySinh = N'" + datetimepk.Text + "',DiaChi=N'" + txtdiachi.Text + "',MaCV = N'" + cbxmacv.SelectedValue + "',LienHe =N'" + txtlienhe.Text + "' Where MaNV = N'" + cbxmanv.SelectedValue + "'";
                    SqlCommand cmd = new SqlCommand(sua, cnn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Sửa thành công!");
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

            vohieu();
       
            try
            {
                cnn.Open();
                string xoa = "DELETE FROM NhanVien Where MaNV = N'" + cbxmanv.SelectedValue + "'";
                SqlCommand cmd = new SqlCommand(xoa, cnn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xoá thành công!");
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
                    string timkiem = "Select * from NhanVien where TenNV  like '%'+ N'"+txttimkiem.Text+"' + '%'";
                    SqlCommand cmd = new SqlCommand(timkiem, cnn);
                    SqlDataReader adt = cmd.ExecuteReader();
                    DataTable table = new DataTable();
                    table.Load(adt);
                    gridviewnv.DataSource = table;
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

        private void btnexcel_Click(object sender, EventArgs e)
        {

        }

        private void gridviewnv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                cbxmanv.SelectedValue = gridviewnv.Rows[index].Cells[0].Value.ToString();
                txttennv.Text = gridviewnv.Rows[index].Cells[1].Value.ToString();
                cbxgioitinh.DisplayMember = gridviewnv.Rows[index].Cells[2].Value.ToString();
                datetimepk.Text = gridviewnv.Rows[index].Cells[3].Value.ToString();

                txtdiachi.Text = gridviewnv.Rows[index].Cells[4].Value.ToString();
                txtlienhe.Text = gridviewnv.Rows[index].Cells[5].Value.ToString();


                cbxmacv.SelectedValue = gridviewnv.Rows[index].Cells[6].Value.ToString();

                cbxmanv.Enabled = false;
                btnsua.Enabled = true;
                btnxoa.Enabled = true;

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

        private void btnexcel_Click_1(object sender, EventArgs e)
        {
            export2Excel(gridviewnv, @"D:\", "NhanVienExcel");
        }
    }
}
