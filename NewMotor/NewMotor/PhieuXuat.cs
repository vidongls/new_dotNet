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
    public partial class PhieuXuat : Form
    {
        public PhieuXuat()
        {
            InitializeComponent();
        }
        SqlConnection cnn = new SqlConnection(connect.cnn);
        public void ketnoi()
        {

            cnn.Open();
            string phieunhap = "SELECT PhieuXuat.mapx as 'Mã phiếu', PhieuXuat.tenpx as 'Tên phiếu', PhieuXuat.manv as 'Nhân viên', SanPham.TenSP as 'Sản Phẩm', PhieuXuat.soluong as 'Số lượng', PhieuXuat.dongia as 'Đơn giá', PhieuXuat.tongtien as 'Tổng tiền', KhachHang.TenKhachHang as 'Khách hàng', PhieuXuat.ngaylap as 'Ngày lập' FROM PhieuXuat    INNER JOIN SanPham ON SanPham.MaSP = PhieuXuat.masp INNER JOIN KhachHang ON KhachHang.MaKhachHang = PhieuXuat.idKH";
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
            {
                btnthem.Enabled = true;
                btnxoa.Enabled = true;
                btnsua.Enabled = true;
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
        private void getPX()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM PhieuXuat", cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "PhieuXuat");
            cbxmapx.DataSource = ds.Tables["PhieuXuat"];
            cbxmapx.DisplayMember = "mapx";
            cbxmapx.ValueMember = "mapx";
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
        private void getKH()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM KhachHang", cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "KhachHang");
            cbxkhachhang.DataSource = ds.Tables["KhachHang"];
            cbxkhachhang.DisplayMember = "TenKhachHang";
            cbxkhachhang.ValueMember = "MaKhachHang";
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

        private void btntinhtien_Click(object sender, EventArgs e)
        {

        }

        private void txtTongtien_KeyUp(object sender, KeyEventArgs e)
        {
            var isNumeric = int.TryParse(txtDongia.Text, out int _);
            var isNumbericSL = int.TryParse(txtsoluong.Text, out int _);

            if (txtsoluong.Text == "" || txtDongia.Text == "")
            {

            }
            else if (isNumeric == false || isNumbericSL == false)
            {

            }
            else
            {
                tinhtien();
            }
        }

        private void PhieuXuat_Load(object sender, EventArgs e)
        {
            formatText();
            getMaSP();
            getKH();
            getMaNV();
            ketnoi();
            Action();
            getPX();
        }
        public static int role;
        private void btnthem_Click(object sender, EventArgs e)
        {
                using (var command = cnn.CreateCommand())
            try
            {            
               cnn.Open();
               command.CommandText = @"INSERT INTO PhieuXuat(tenpx,soluong,dongia,manv,masp,tongtien,idKH,ngaylap) VALUES('"+txtTenpx.Text+"','"+txtsoluong.Text+"','"+txtDongia.Text+"','"+cbxnhanvien.SelectedValue+"','"+cbxsp.SelectedValue+"','"+ Convert.ToDecimal(txtTongtien.Text) +"','"+cbxkhachhang.SelectedValue+ "','"+DateTime.Now+"');" +
               "UPDATE SanPham SET  SoLuong = SanPham.SoLuong - '" + txtsoluong.Text + "' From SanPham inner join PhieuXuat ON SanPham.MaSP = PhieuXuat.masp where PhieuXuat.masp ='" + cbxsp.SelectedValue + "';";
               command.ExecuteNonQuery();
               MessageBox.Show("Thêm thành công!");
               xoaText();
               cnn.Close();
               ketnoi(); 

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
        void xoaText() {

            txtTenpx.Text = "";
            txtDongia.Text = "";
            txtsoluong.Text = "";
        }
        private void btnsua_Click(object sender, EventArgs e)
        {
            try
            {
                cnn.Open();
                if (txtTenpx.Text == "" || txtDongia.Text == "" || txtsoluong.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập thông tin!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    string sua = "UPDATE PhieuXuat SET tenpx = N'"+txtTenpx.Text+"',soluong = N'"+txtsoluong.Text+"',dongia = N'"+txtDongia.Text+"',manv = N'"+cbxnhanvien.SelectedValue+"',masp = N'"+cbxsp.SelectedValue+"',tongtien = N'"+ Convert.ToDecimal(txtTongtien.Text) + "',idKH = N'"+cbxkhachhang.SelectedValue+"',ngaylap = N'"+DateTime.Now+"'  Where mapx = N'"+cbxmapx.SelectedValue+"'";
                    SqlCommand cmd = new SqlCommand(sua, cnn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Sửa thành công!");
                    xoaText();
                    cnn.Close();
                    ketnoi();          
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
                string xoa = "DELETE FROM PhieuXuat Where mapx = N'" + cbxmapx.SelectedValue + "'";
                SqlCommand cmd = new SqlCommand(xoa, cnn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xoá thành công!");
                getPX();
                cnn.Close();
                ketnoi();
                xoaText();
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
                    string timkiem = "Select *FROM PhieuXuat where tenpx like '%'+ N'" + txttimkiem.Text + "' + '%'";
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

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    
        private void grvPhieunhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                cbxmapx.SelectedValue = grvPhieunhap.Rows[index].Cells[0].Value;
                txtTenpx.Text = grvPhieunhap.Rows[index].Cells[1].Value.ToString();
                cbxnhanvien.Text = grvPhieunhap.Rows[index].Cells[2].Value.ToString();
                cbxsp.Text = grvPhieunhap.Rows[index].Cells[3].Value.ToString();
                txtsoluong.Text = grvPhieunhap.Rows[index].Cells[4].Value.ToString();
                txtDongia.Text = grvPhieunhap.Rows[index].Cells[5].Value.ToString();
                txtTongtien.Text = grvPhieunhap.Rows[index].Cells[6].Value.ToString();
               cbxkhachhang.Text = grvPhieunhap.Rows[index].Cells[7].Value.ToString();
                //Enable
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
            export2Excel(grvPhieunhap, @"D:\", "PhieuXuatExcel");
        }
    }
}
