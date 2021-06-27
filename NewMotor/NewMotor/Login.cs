using NewMotor.Connect;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewMotor
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không ?", "Thông báo !", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                cnn.Close();
                Application.Exit();
                return;
            }
            else
            {
                return;
            }

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            pnlogin.SendToBack();
        }
        SqlConnection cnn = new SqlConnection(connect.cnn);
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            pnlogin.BringToFront();
        }
        /* private string getID(string username, string pass)
         {
             string id = "";
             try
             {
                 cnn.Open();
                 SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_user WHERE TaiKhoan = N'" + username + "' and MatKhau =N'" + pass + "'", cnn);
                 SqlDataAdapter da = new SqlDataAdapter(cmd);
                 DataTable dt = new DataTable();
                 da.Fill(dt);
                 if (dt != null)
                 {
                     foreach (DataRow dr in dt.Rows)
                     {
                         id = dr["TaiKhoan"].ToString();
                     }
                 }
             }
             catch (Exception)
             {
                 MessageBox.Show("Lỗi xảy ra khi truy vấn dữ liệu hoặc kết nối với server thất bại !");
             }
             finally
             {
                 cnn.Close();
             }
             return id;
         }*/
        public bool CheckPassword()
        {
            string password = txtmatkhau.Text;
            //string MatchEmailPattern = "(?=.{6,})[a-zA-Z0-9]+[^a-zA-Z]+|[^a-zA-Z]+[a-zA-Z]+";
            string MatchEmailPattern = "^[a-zA-Z0-9]+$";

            if (password != null) return Regex.IsMatch(password, MatchEmailPattern);
            else return false;


        }
        public static int role;
        public static string display;
        void Check()
        {
           /* Regex regex = new Regex(@"^(.{0,7}|[^0-9]*|[^A-Z])$");*/
            cnn.Open();
            string dangnhap = "select Quyen,TenQuyen from PhanQuyen  INNER JOIN NguoiDung ON NguoiDung.Quyen = PhanQuyen.idQuyen  where TaiKhoan = '" + txttaikhoan.Text + "' and MatKhau = '" + txtmatkhau.Text + "'";
            SqlCommand cmd = new SqlCommand(dangnhap, cnn);
            //int soluong = int.Parse(cmd.ExecuteScalar().ToString());
            var dr = cmd.ExecuteReader();
            var dt = new DataTable();
            dt.Load(dr);
            dr.Dispose();
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Đăng nhập thành công!");
                role = (int)dt.Rows[0][0];
                display = dt.Rows[0][1].ToString().Trim();              
                Main ht = new Main();
                ht.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại!");
            }
            cnn.Close();
        }
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            Check();
          
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cnn = new SqlConnection(connect.cnn);
                cnn.Open();
                string them = "Insert into NguoiDung(TaiKhoan,Email,MatKhau,Quyen) VALUES(N'" + txtuserdangky.Text + "',N'" + txtemaildky.Text + "',N'" + txtmatkhaudky.Text + "','" + 2 + "')";
                SqlCommand cmd = new SqlCommand(them, cnn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Đăng ký thành công!");
                pnlogin.BringToFront();
            }
            catch
            {
                MessageBox.Show("Đăng ký thất bại!");
            }
            finally
            {
                SqlConnection cnn = new SqlConnection(connect.cnn);
                cnn.Close();
            }
        }

        private void ckpass_CheckedChanged(object sender, EventArgs e)
        {
            txtmatkhau.PasswordChar = ckpass.Checked ? '\0' : '*';
        }

        private void txtmatkhau_TextChanged(object sender, EventArgs e)
        {

        }

        private void cp2_CheckedChanged(object sender, EventArgs e)
        {
            txtmatkhaudky.PasswordChar = cp2.Checked ? '\0' : '*';
        }

        private void txtmatkhaudky_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không ?", "Thông báo !", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                cnn.Close();
                Application.Exit();
                return;
            }
            else
            {
                return;
            }
        }
    }
}
