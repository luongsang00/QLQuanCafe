using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyQuanCaPhe.Controllers
{
    public class NhanVienCtrl
    {
        public static DataSet FillDataSet_getNhanVienById(string _idNhanVien)
        {
            try 
            {
                Models.NhanVienMod nvien = new Models.NhanVienMod(_idNhanVien);
                return nvien.FillDataSet_getNhanVienById();
            }
            catch
            {
                return null;
            }
        }
        //method add
        public static int InsertNhanVien(string _idNhanVien, string _hoLotNV, string _tenNhanVien, DateTime _ngaySinhNV, string _gioiTinhNV, string _dienThoaiNV, string _emailNV, string _diaChiNV)
        {
            try
            {
                Models.NhanVienMod _nhanVien = new Models.NhanVienMod(_idNhanVien, _hoLotNV, _tenNhanVien, _ngaySinhNV, _gioiTinhNV, _dienThoaiNV, _emailNV, _diaChiNV);
                return _nhanVien.InsertNhanVien();
            }
            catch
            {
                return 0;
            }
        }
        //method update
        public static int UpdateNhanVien(string _idNhanVien, string _hoLotNV, string _tenNhanVien, DateTime _ngaySinhNV, string _gioiTinhNV, string _dienThoaiNV, string _emailNV, string _diaChiNV)
        {
            try
            {
                Models.NhanVienMod _nhanVien = new Models.NhanVienMod(_idNhanVien, _hoLotNV, _tenNhanVien, _ngaySinhNV, _gioiTinhNV, _dienThoaiNV, _emailNV, _diaChiNV);
                return _nhanVien.UpdateNhanVien();
            }
            catch
            {
                return 0;
            }
        }
        //method delete
        public static int DeleteNhanVien(string _idNhanVien)
        {
            try
            {
                Models.NhanVienMod _nhanvien = new Models.NhanVienMod(_idNhanVien);
                return _nhanvien.DeleteNhanVien();

            }
            catch
            {
                return 0;
            }
        }

    }
}
