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
    public partial class PhieuNhap : Form
    {
        public PhieuNhap()
        {
            InitializeComponent();
        }
        SqlConnection cnn = new SqlConnection(connect.cnn);
        public void ketnoi()
        {
     
            cnn.Open();
            string phieunhap = "SELECT PhieuNhap.mapn as 'Mã phiếu', PhieuNhap.tenpn as 'Tên phiếu', NhanVien.TenNV as 'Nhân viên', SanPham.TenSP as 'Sản Phẩm', PhieuNhap.sl as 'Số lượng', PhieuNhap.dongia as 'Đơn giá', sl*dongia as 'Tổng tiền', NhaCC.tenncc as 'Nhà cung cấp', PhieuNhap.ngaylap as 'Ngày lập' FROM dbo.PhieuNhap INNER JOIN SanPham ON SanPham.MaSP = PhieuNhap.masp INNER JOIN NhanVien ON NhanVien.MaNV = PhieuNhap.manv INNER JOIN NhaCC ON NhaCC.mancc = PhieuNhap.mancc";
            SqlCommand cmd = new SqlCommand(phieunhap, cnn);
            cmd.ExecuteNonQuery();
            DataTable table = new DataTable();
            SqlDataAdapter sdp = new SqlDataAdapter(cmd);
            sdp.Fill(table);
            grvPhieunhap.DataSource = table;
            cnn.Close();
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
            {   btnthem.Enabled = false;
                btnxoa.Enabled = false;
                btnsua.Enabled = false;
              
            }
            else if (Login.role == 3)
            {
                btnthem.Enabled = true;
                btnxoa.Enabled = true;
                btnsua.Enabled = true;
            }
        }
        private void getMaNV()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM NhanVien", cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "NhanVien");
            cbxnhanvien.DataSource = ds.Tables["NhanVien"];
            cbxnhanvien.DisplayMember = "TenNV";
            cbxnhanvien.ValueMember = "MaNV";
        }
        private void getMaSP()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM SanPham", cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "SanPham");
            cbxsp.DataSource = ds.Tables["SanPham"];
            cbxsp.DisplayMember = "TenSP";
            cbxsp.ValueMember = "MaSP";
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
        private void getPN()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM PhieuNhap", cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "PhieuNhap");
            cbxmapn.DataSource = ds.Tables["PhieuNhap"];
            cbxmapn.DisplayMember = "mapn";
            cbxmapn.ValueMember = "mapn";
        }
        void formatText()
        {
            txtsoluong.Text = "0";
            txtDongia.Text = "0";
            txtTongtien.Text = "0";
        }
        public void tinhtien()
        {
            
                Decimal soluong = Convert.ToDecimal(txtsoluong.Text),
                gia = Convert.ToDecimal(txtDongia.Text),
                tongtien = Convert.ToDecimal(soluong * gia);
                txtTongtien.Text = tongtien.ToString();
                txtTongtien.Text = string.Format("{0:#,0.00}", tongtien).ToString();
        }
        public static int role;
        void checksll()
        {
                cnn.Close();
                cnn.Open();
                 string them = "UPDATE SanPham SET  SoLuong = SanPham.SoLuong + '"+txtsoluong.Text+"' From SanPham inner join PhieuNhap ON SanPham.MaSP = PhieuNhap.masp where PhieuNhap.masp ='" +cbxsp.SelectedValue + "'";
                SqlCommand cmd1 = new SqlCommand(them, cnn);
                cmd1.ExecuteNonQuery();                          
                string them2 = "INSERT INTO PhieuNhap(tenpn,manv,masp,sl,dongia,tongtien,mancc,ngaylap) VALUES(N'" + txtTenpn.Text + "','" + cbxnhanvien.SelectedValue + "','" + cbxsp.SelectedValue + "','" + txtsoluong.Text + "','" + txtDongia.Text + "','" + Convert.ToDecimal(txtTongtien.Text) + "','" + cbxncc.SelectedValue + "','" + DateTime.Now + "')";
                SqlCommand cmd2 = new SqlCommand(them2, cnn);
                cmd2.ExecuteNonQuery();
                 MessageBox.Show("Đã nhập thêm sản phẩm");  
                cnn.Close();
                ketnoi();
     
          
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            try
            {
                checksll();
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


        private void txtTongtien_KeyUp(object sender, KeyEventArgs e)
        {
            var isNumeric = int.TryParse(txtDongia.Text, out int _);
            var isNumbericSL = int.TryParse(txtsoluong.Text, out int _);

            if (txtsoluong.Text == "" || txtDongia.Text == "" )
            {
          
            }
            else if (isNumeric == false || isNumbericSL == false) {
            
            }
            else
            {
                tinhtien();
            }              
        }

        private void PhieuNhap_Load(object sender, EventArgs e)
        {  
            formatText();
            getMaSP();
            getNCC();
            getMaNV(); 
            getPN();
            ketnoi();
            Action();
          
        }

        private void txtsoluong_TextChanged(object sender, EventArgs e)
        {
          /*  if (String.IsNullOrEmpty(txtsoluong.Text) && String.IsNullOrEmpty(txtDongia.Text))
            {
                formatText();
            }*/
        }

        private void txtDongia_TextChanged(object sender, EventArgs e)
        {
            
           
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            try
            {
                cnn.Close();
                cnn.Open();

                if (txtTenpn.Text == "" || txtDongia.Text == "" || txtsoluong.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập thông tin!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    string sua = "	UPDATE PhieuNhap SET tenpn = N'" + txtTenpn.Text + "',sl = N'" + txtsoluong.Text + "',dongia = N'" + txtDongia.Text + "',manv = N'" + cbxnhanvien.SelectedValue + "',masp = N'" + cbxsp.SelectedValue + "',tongtien = N'" + Convert.ToDecimal(txtTongtien.Text) + "',mancc = N'" + cbxncc.SelectedValue + "',ngaylap = N'" + DateTime.Now + "'  Where mapn = N'" + cbxmapn.SelectedValue + "'";
                    SqlCommand cmd = new SqlCommand(sua, cnn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Sửa thành công!");
                    getPN();
                    cnn.Close();
                    ketnoi();
                }

            }
            catch
            {
                MessageBox.Show("Sửa thất bại!");
            }
            finally{
            cnn.Close();
            }
            
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {

            try
            {
                cnn.Close();
                cnn.Open();
                string xoa = "DELETE FROM PhieuNhap Where mapn = N'" + cbxmapn.SelectedValue + "'";
                SqlCommand cmd = new SqlCommand(xoa, cnn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xoá thành công!");
                cnn.Close();
                getPN();
                ketnoi();
             
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
                    string timkiem = "Select *FROM PhieuNhap where tenpn like '%'+ N'" + txttimkiem.Text + "' + '%'";
                    SqlCommand cmd = new SqlCommand(timkiem, cnn);
                    SqlDataReader adt = cmd.ExecuteReader();
                    DataTable table = new DataTable();
                    table.Load(adt);
                    grvPhieunhap.DataSource = table;
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

        private void grvPhieunhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                cbxmapn.SelectedValue = grvPhieunhap.Rows[index].Cells[0].Value;
                txtTenpn.Text = grvPhieunhap.Rows[index].Cells[1].Value.ToString();
                cbxnhanvien.Text = grvPhieunhap.Rows[index].Cells[2].Value.ToString();
                cbxsp.Text = grvPhieunhap.Rows[index].Cells[3].Value.ToString();
                txtsoluong.Text = grvPhieunhap.Rows[index].Cells[4].Value.ToString();
                txtDongia.Text = grvPhieunhap.Rows[index].Cells[5].Value.ToString();
                txtTongtien.Text = grvPhieunhap.Rows[index].Cells[6].Value.ToString();
                cbxncc.Text = grvPhieunhap.Rows[index].Cells[7].Value.ToString();
                //Enable
            }
        }

        private void btntinhtien_Click(object sender, EventArgs e)
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
            export2Excel(grvPhieunhap, @"D:\", "PhieuNhapExcel");
        }
    }
}
