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
    public partial class SanPham : Form
    {
        public SanPham()
        {
            InitializeComponent();
        }
        SqlConnection cnn = new SqlConnection(connect.cnn);
        public void ketnoi()
        {
            SqlConnection cnn = new SqlConnection(connect.cnn);
            cnn.Open();
            string dangnhap = "SELECT MaSP 'Mã sản phẩm', TenSP 'Tên sản phẩm', Mau 'Màu sắc', SoLuong 'Số lượng', Gia 'Giá', maloai 'Mã loại', manCC 'Mã NCC' FROM dbo.SanPham";
            SqlCommand cmd = new SqlCommand(dangnhap, cnn);
            cmd.ExecuteNonQuery();
            DataTable table = new DataTable();
            SqlDataAdapter sdp = new SqlDataAdapter(cmd);
            sdp.Fill(table);
            gridsanpham.DataSource = table;
        }
        private void getLoai()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM PhanLoai", cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "PhanLoai");
            cbxloai.DataSource = ds.Tables["PhanLoai"];
            cbxloai.DisplayMember = "tenloai";
            cbxloai.ValueMember = "maloai";
        }
        private void getMaSP()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM SanPham", cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "SanPham");
            cbbmasp.DataSource = ds.Tables["SanPham"];
            cbbmasp.DisplayMember = "MaSP";
            cbbmasp.ValueMember = "MaSP";
        }
        private void getNCC()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM NhaCC", cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "NhaCC");
            cbxncc.DataSource = ds.Tables["NhaCC"];
            cbxncc.DisplayMember = "tenncc";
            cbxncc.ValueMember = "mancc";
        }
       
        private void xoatext()
        {
            txtgia.Text = "";
            txtmau.Text = "";
            txtsoluong.Text = "";
            txttensp.Text = "";
        }
        void Action()
        {
            if (Login.role == 1)
            {
                btnthem.Enabled = true;
                btnxoa.Enabled = true;
                btnsua.Enabled = true;

            }
            else if (Login.role == 2)
            {
                btnxoa.Enabled = true;
            }
            else if(Login.role == 3) {
                btnthem.Enabled = false;
                btnxoa.Enabled = false;
                btnsua.Enabled = false;
            }
        }
        private void btnthem_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (txtgia.Text == "" || txtmau.Text == "" || txtsoluong.Text == "" || txttensp.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập thông tin!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    cnn.Open();
                    string them = "Insert into SanPham(TenSP,Mau,SoLuong,Gia,maloai,mancc) VALUES(N'" + txttensp.Text + "',N'" + txtmau.Text + "',N'" + txtsoluong.Text + "',N'" + txtgia.Text + "',N'" + cbxloai.SelectedValue + "',N'" + cbxncc.SelectedValue + "')";
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

        private void SanPham_Load(object sender, EventArgs e)
        {
            ketnoi();
            Action();
            getLoai();
            getMaSP();
            getNCC();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            
            try
            {
               
                cnn.Open();
                if (txtgia.Text == "" || txtmau.Text == "" || txtsoluong.Text == "" || txttensp.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập thông tin!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    string sua = "UPDATE SanPham SET TenSP = N'" + txttensp.Text + "',Mau = N'" + txtmau.Text + "',SoLuong = N'" + txtsoluong.Text + "',Gia = N'" + txtgia.Text + "',maloai = '" + cbxloai.SelectedValue + "',mancc= N'" + cbxncc.SelectedValue + "' Where MaSP = N'" + cbbmasp.SelectedValue + "'";
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
          
            try
            {
               
                cnn.Open();
                string xoa = "DELETE FROM SanPham Where MaSP = N'" + cbbmasp.SelectedValue + "'";
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

        private void gridsanpham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                cbbmasp.SelectedValue = gridsanpham.Rows[index].Cells[0].Value;
                txttensp.Text = gridsanpham.Rows[index].Cells[1].Value.ToString();
                txtmau.Text = gridsanpham.Rows[index].Cells[2].Value.ToString();
                txtsoluong.Text = gridsanpham.Rows[index].Cells[3].Value.ToString();
                txtgia.Text = gridsanpham.Rows[index].Cells[4].Value.ToString();
                cbxloai.SelectedValue = gridsanpham.Rows[index].Cells[5].Value;
                cbxncc.SelectedValue = gridsanpham.Rows[index].Cells[6].Value.ToString();
                //Enable
                cbbmasp.Enabled = false;

            }
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            try
            {
                cnn.Close();
                if (txttimkiem.Text != "")
                {
                    cnn.Open();
                    string timkiem = "Select *FROM SanPham where TenSP like '%'+ N'" + txttimkiem.Text + "' + '%'";
                    SqlCommand cmd = new SqlCommand(timkiem, cnn);
                    SqlDataReader adt = cmd.ExecuteReader();
                    DataTable table = new DataTable();
                    table.Load(adt);
                    gridsanpham.DataSource = table;
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
            export2Excel(gridsanpham, @"D:\", "SanPhamExcel");
        }
    }
}
