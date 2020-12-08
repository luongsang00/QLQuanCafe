using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCaPhe.Views
{
    public partial class uctNhanVien : UserControl
    {
        public uctNhanVien()
        {
            InitializeComponent();
        }
        //khai báo biến để phân biệt lúc Thêm Sửa 
        int flag = 0;
        public static uctNhanVien uctNV = new uctNhanVien();
        // khai báo hàm hiển thị DSNV để đổ dữ liệu vào datagridview
        public void HienThiDanhSachNhanVien()
        {
            //trỏ tới data nhân viên...
            dgvDanhSachNhanVien.DataSource = Models.NhanVienMod.FillDataSetNhanVien().Tables[0];
            dgvDanhSachNhanVien.Dock = DockStyle.Fill;
            dgvDanhSachNhanVien.BorderStyle = BorderStyle.Fixed3D;
        }
        private void uctNhanVien_Load(object sender, EventArgs e)
        {
            HienThiDanhSachNhanVien();
            dis_end(false);
            bingding();
        }
        // tạo hàm để trỏ đến dữ liệu datagridview 
        void bingding()
        {
            txtIdNhanVien.DataBindings.Clear();
            txtIdNhanVien.DataBindings.Add("Text", dgvDanhSachNhanVien.DataSource, "IdNhanVien");
            txtHoLot.DataBindings.Clear();
            txtHoLot.DataBindings.Add("Text", dgvDanhSachNhanVien.DataSource, "HoLot");
            txtTen.DataBindings.Clear();
            txtTen.DataBindings.Add("Text", dgvDanhSachNhanVien.DataSource, "Ten");
            dtpNgaysinh.DataBindings.Clear();
            dtpNgaysinh.DataBindings.Add("Text", dgvDanhSachNhanVien.DataSource, "Ngaysinh");
            cmbGioiTinh.DataBindings.Clear();
            cmbGioiTinh.DataBindings.Add("Text", dgvDanhSachNhanVien.DataSource, "GioiTinh");
            txtDienThoai.DataBindings.Clear();
            txtDienThoai.DataBindings.Add("Text", dgvDanhSachNhanVien.DataSource, "DienThoai");
            txtEmail.DataBindings.Clear();
            txtEmail.DataBindings.Add("Text", dgvDanhSachNhanVien.DataSource, "Email");
            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("Text", dgvDanhSachNhanVien.DataSource, "DiaChi");

        }
        // hàm dis-end các button khi load lên...
        void dis_end(bool e)
        {
            txtHoLot.Enabled = e;
            txtTen.Enabled = e;
            dtpNgaysinh.Enabled = e;
            cmbGioiTinh.Enabled = e;
            txtDiaChi.Enabled = e;
            txtDienThoai.Enabled = e;
            txtEmail.Enabled = e;
            btnLuu.Enabled = e;
            btnHuy.Enabled = e;
            btnThem.Enabled = !e;
            btnXoa.Enabled = !e;
            btnSua.Enabled = !e;
        }
        // hàm load giới tính nhân viên
        void loadcontrol()
        {
            cmbGioiTinh.Items.Clear();
            cmbGioiTinh.Items.Add("Nam");
            cmbGioiTinh.Items.Add("Nữ");
            cmbGioiTinh.Items.Add("Khác");
        }
        //hàm xóa dữ liệu ở textbox lúc ta nhấn vào button
        void clearData()
        {
            //txtIdNhanVien.Text = Models.connection.ExcuteScalar("");
            txtHoLot.Text = "";
            txtTen.Text = "";
            txtDienThoai.Text = "";
            txtEmail.Text = "";
            txtDiaChi.Text = "";
            loadcontrol();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            // load lại 
            uctNhanVien_Load(sender, e);
            dis_end(false);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            //lúc sửa mặc đinh cho flag = 1;
            flag = 1;
            dis_end(true);
            loadcontrol();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            flag = 0;
            clearData();
            dis_end(true);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // ta khai báo các biến
            string _idNhanVien ="";
            try
            {
                _idNhanVien  = txtIdNhanVien.Text;

            }
            catch { }
            string _hoLotNV ="";
            try
            {
                _hoLotNV = txtHoLot.Text;

            }
            catch { }
            string _tenNhanVien="";
            try
            {
                _tenNhanVien = txtTen.Text;

            }
            catch { }
            DateTime _ngaySinhNV = dtpNgaysinh.Value;
            try
            {
                

            }
            catch { }
            string _gioiTinhNV ="";
            try
            {
                _gioiTinhNV  = cmbGioiTinh.Text;

            }
            catch { }
            string _emailNV ="";
            try
            {
                _emailNV  = txtEmail.Text;

            }
            catch { }
            string _dienThoaiNV ="";
            try
            {
                _dienThoaiNV  = txtDienThoai.Text;

            }
            catch { }
            string _diaChiNV ="";
            try
            {
                _diaChiNV  = txtDiaChi.Text;

            }
            catch { }
            if(flag==0)
            {
                //thêm mới 
                if (_idNhanVien == "" || _tenNhanVien == "" || _hoLotNV == "")
                    MessageBox.Show("Hãy nhập đầy đủ thông tin");
                else
                {
                    int i = 0;
                    i = Controllers.NhanVienCtrl.InsertNhanVien(_idNhanVien, _hoLotNV, _tenNhanVien, _ngaySinhNV, _gioiTinhNV, _dienThoaiNV, _emailNV, _diaChiNV);
                    if(i>0)
                    {
                        MessageBox.Show("Thêm thành công !");
                        HienThiDanhSachNhanVien();
                    }  
                    else
                    {
                        MessageBox.Show("Thêm mới thất bại !");
                    }    
                }   
            }
            else
            {
                int i = 0;
                i = Controllers.NhanVienCtrl.UpdateNhanVien(_idNhanVien, _hoLotNV, _tenNhanVien, _ngaySinhNV, _gioiTinhNV, _dienThoaiNV, _emailNV, _diaChiNV);
                if (i > 0)
                {
                    MessageBox.Show("Sửa thành công !");
                    HienThiDanhSachNhanVien();
                }
                else
                {
                    MessageBox.Show("Sửa thất bại !");
                }
            }
            uctNhanVien_Load(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string _idNhanVien = "";
            try
            {
                _idNhanVien = txtIdNhanVien.Text;
            }
            catch { }
            DialogResult dr = MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                int i = 0;
                i = Controllers.NhanVienCtrl.DeleteNhanVien(_idNhanVien);
                if (i > 0)
                {
                    MessageBox.Show("Xóa thành công");
                    HienThiDanhSachNhanVien();
                    uctNhanVien_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Xóa không thành công");
                }
            }
            else
                return;

        }
    }
}
