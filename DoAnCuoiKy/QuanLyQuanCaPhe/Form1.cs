using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCaPhe
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        internal static List<byte> typePages = new List<byte>();
        public void ThemTabPages(UserControl uct, byte typeConTrol, string tenTab)
        {
            //kiểm tra trang tồn tại chưa?
            for(int i=0; i<tabHienThi.TabPages.Count; i++)
            {
                if(tabHienThi.TabPages[i].Contains(uct)==true)
                {
                    tabHienThi.SelectedTab = tabHienThi.TabPages[i];
                    return;
                }    
            }
            TabPage tab = new TabPage();
            typePages.Add(typeConTrol);
            tab.Name = uct.Name;
            tab.Size = tabHienThi.Size;
            tab.Text = tenTab;
            tabHienThi.TabPages.Add(tab);
            tabHienThi.SelectedTab = tab;
            uct.Dock = DockStyle.Fill;
            tab.Controls.Add(uct);
            uct.Focus();
        }
        //Đóng tab hiện tại
        public void DongTabHienTai()
        {
            tabHienThi.TabPages.Remove(tabHienThi.SelectedTab);
        }
        //Đóng all tab
        public void DongAllTab()
        {
            while(tabHienThi.TabPages.Count>0)
            {
                DongTabHienTai();
            }    
        }
        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn thoát", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
            else
                return;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThemTabPages(Views.uctNhanVien.uctNV,4, "Quản Lý Nhân Viên");
        }

        private void đóngTrangHiệnTạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DongTabHienTai();
        }

        private void đóngTấtCảTrangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DongAllTab();
        }
    }
}
