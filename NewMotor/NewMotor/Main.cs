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

namespace NewMotor
{

    public partial class Main : Form
    {    private bool isCollapsed;
        public Main()
        {
            InitializeComponent();       
        }
        private void addform(Form f)
        {
            f.TopLevel = false;
            f.AutoScroll = true;
            f.Dock = DockStyle.Fill;
            pnhienthi.Controls.Add(f);
            f.Show();
        }
        SqlConnection cnn = new SqlConnection(connect.cnn);
        private void timer1_Tick(object sender, EventArgs e)
        {   
            if (isCollapsed)
            {
                pndropdown.Height += 10;
                if (pndropdown.Size == pndropdown.MaximumSize)
                {
                    timer1.Stop();
                    isCollapsed = false;
                }
            }
            else
            {
                pndropdown.Height -= 10;
                if (pndropdown.Size == pndropdown.MinimumSize)
                {
                    timer1.Stop();
                    isCollapsed = true;
                }
            }
        }
        private void btnphieu_Click(object sender, EventArgs e)
        {
            timer1.Start();
            pnChecked.Hide();
           
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        { 
            Login lg = new Login();
            
            DialogResult result = MessageBox.Show("Bạn muốn đăng xuất?", "Thông báo !", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                cnn.Close();
                this.Hide();
                lg.Show();
                return;
            }
            else
            {
                return;
            }
        }

        private void btnkh_Click(object sender, EventArgs e)
        {
            pnChecked.Height = btnkh.Height;
            pnChecked.Top = btnkh.Top;       
            pnChecked.Show(); 
            pnhienthi.Controls.Clear();
            KhachHang khach = new KhachHang();
            addform(khach);
        }

        private void btnsp_Click(object sender, EventArgs e)
        {
            pnChecked.Height = btnsp.Height;
            pnChecked.Top = btnsp.Top; pnChecked.Show();
            pnhienthi.Controls.Clear();
            SanPham sp = new SanPham();
            addform(sp);
        }

        private void bntnv_Click(object sender, EventArgs e)
        {  
            if (Login.role == 2 || Login.role == 3)
            {
                MessageBox.Show("Bạn không có quyền sử dụng chức năng này", "Thông báo !", MessageBoxButtons.OK);

            }
            else { 
             pnChecked.Height = bntnv.Height;
            pnChecked.Top = bntnv.Top; pnChecked.Show();
            pnhienthi.Controls.Clear();
            NhanVien nv = new NhanVien();
            addform(nv);            
            }
            
        }

        private void btnthongke_Click(object sender, EventArgs e)
        {
            if (Login.role == 2)
            {
                MessageBox.Show("Bạn không có quyền sử dụng chức năng này", "Thông báo !", MessageBoxButtons.OK);

            }
            else { 
            
             pnChecked.Height = btnthongke.Height;
            pnChecked.Top = btnthongke.Top;
            pnhienthi.Controls.Clear();
            ThongKe tk = new ThongKe();
            addform(tk);
            pnChecked.Show();
            }
           
        }
        
        private void horafecha_Tick(object sender, EventArgs e)
        {
            lbtime.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void Main_Load(object sender, EventArgs e)
        {
            pnChecked.Hide();
          
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            
            DialogResult result= MessageBox.Show("Bạn có muốn thoát không ?","Thông báo !",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                cnn.Close();
                Application.Exit();
                return;
            }
            else {
                return;
            }

        }

        private void btnpn_Click(object sender, EventArgs e)
        {

            pnhienthi.Controls.Clear();
            PhieuNhap pn = new PhieuNhap();
            addform(pn);
        
        }

        private void btnpx_Click(object sender, EventArgs e)
        {
        
            pnhienthi.Controls.Clear();
            PhieuXuat px = new PhieuXuat();
            addform(px);
    
        }

        private void button1_Click(object sender, EventArgs e)
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
