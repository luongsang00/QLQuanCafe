using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace QuanLyQuanCaPhe.Models
{
    class NhanVienMod
    {
        //khai báo các biến và hàm thuộc tính
        private string idNhanVien;
        private string hoLotNV;
        private string tenNV;
        private DateTime ngaySinhNV;
        private string gioiTinhNV;
        private string dienThoaiNV;
        private string emailNV;
        private string diaChiNV;

        public string HoLotNV { get => hoLotNV; set => hoLotNV = value; }
        public string TenNV { get => tenNV; set => tenNV = value; }

        public string GioiTinhNV { get => gioiTinhNV; set => gioiTinhNV = value; }
        public string DienThoaiNV { get => dienThoaiNV; set => dienThoaiNV = value; }
        public DateTime NgaySinhNV { get => ngaySinhNV; set => ngaySinhNV = value; }
        public string EmailNV { get => emailNV; set => emailNV = value; }
        public string DiaChiNV { get => diaChiNV; set => diaChiNV = value; }
        protected string IdNhanVien { get => idNhanVien; set => idNhanVien = value; }

        // khởi tạo
        public NhanVienMod(string _idNhanVien)
        {
            IdNhanVien = _idNhanVien;
        }
        public NhanVienMod() { }

        public NhanVienMod(string  _idNhanVien, string _hoLotNV, string _tenNhanVien, DateTime _ngaySinhNV, string _gioiTinhNV, string _dienThoaiNV, string _emailNV, string _diaChiNV)
        {
            IdNhanVien = _idNhanVien;
            HoLotNV = _hoLotNV;
            TenNV = _tenNhanVien;
            NgaySinhNV = _ngaySinhNV;
            GioiTinhNV = _gioiTinhNV;
            DienThoaiNV = _dienThoaiNV;
            EmailNV = _emailNV;
            DiaChiNV = _diaChiNV;
        }
        //khai báo hàm thêm, sửa, xóa
        public int InsertNhanVien()
        {
            int i = 0;

            string[] paras = new string[8] { "@IdNhanVien", "@HoLot", "@Ten", "@Ngaysinh", "@GioiTinh", "@DienThoai", "@Email", "@DiaChi" };
            object[] values = new object[8] { IdNhanVien, HoLotNV, TenNV, NgaySinhNV, GioiTinhNV, DienThoaiNV, EmailNV, DiaChiNV };
            i = Models.connection.Excute_Sql("spInsertNhanVien", System.Data.CommandType.StoredProcedure, paras, values);
            return i;
        }
        // hàm update
        public int UpdateNhanVien()
        {
            int i = 0;

            string[] paras = new string[8] { "@IdNhanVien", "@HoLot", "@Ten", "@Ngaysinh", "@GioiTinh", "@DienThoai", "@Email", "@DiaChi" };
            object[] values = new object[8] { IdNhanVien, HoLotNV, TenNV, NgaySinhNV, GioiTinhNV, DienThoaiNV, EmailNV, DiaChiNV };
            i = Models.connection.Excute_Sql("spUpdateNhanVien", System.Data.CommandType.StoredProcedure, paras, values);
            return i;
        }
        //delete
        public int DeleteNhanVien()
        {
            int i = 0;

            string[] paras = new string[1] { "@IdNhanVien" };
            object[] values = new object[1] { IdNhanVien };
            i = Models.connection.Excute_Sql("spDeleteNhanVien", System.Data.CommandType.StoredProcedure, paras, values);
            return i;
        }
        // khởi tạo hàm dataset 
        public static DataSet FillDataSetNhanVien()
        {
            //gọi thủ tục getNhanVien 
            return Models.connection.FillDataSet("spgetNhanVien", System.Data.CommandType.StoredProcedure);
        }
        //getNhanVien by id
        public DataSet FillDataSet_getNhanVienById()
        {
            DataSet ds = new DataSet();
            string[] paras = new string[1] { "@IdNhanVien" };
            object[] values = new object[1] { IdNhanVien };
            ds = Models.connection.FillDataSet("spgetNhanVienByIdNhanVien", System.Data.CommandType.StoredProcedure, paras, values);
            return ds;
        }
    }
}
