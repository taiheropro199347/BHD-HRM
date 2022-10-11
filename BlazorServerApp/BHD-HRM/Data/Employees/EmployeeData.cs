using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BHD_HRM.Data.Employee
{    public class EmployeeData
    {
        public int Id { get; set; }
        public string MaSoThue { get; set; }
        public string CardNumber { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập họ tên")]
        public string HoTen { get; set; }
        public int? IdcongTy { get; set; } = null;
        public string IdphongBan { get; set; }
        public string ChucVu { get; set; }
        public DateTime? NgaySinh { get; set; }
        [Required(ErrorMessage = "Bạn phải chọn giới tính")]
        public string GioiTinh { get; set; }
        public string DanToc { get; set; }
        public string Dkhk { get; set; }
        public string ThuongTru { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập số điện thoại")]
        public string SoDt { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập email")]
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string SoCmnd { get; set; }
        public DateTime? NgayCap { get; set; }
        public string NoiCap { get; set; }
        public string TrangThai { get; set; }
        public string LoaiHopDong { get; set; }
        public string SoTaiKhoanNh { get; set; }
        public string TenNganHang { get; set; }
        public int? NgayPhepDauKy { get; set; }
        public DateTime? NgayVaoCongTy { get; set; }
        public string LoaiDongThue { get; set; }
        public string LanCuoiChinhSua { get; set; }
        public string MembershipId { get; set; }
        public string Cccd { get; set; }
        public string SdtKhanCap { get; set; }
        public string NhomMau { get; set; }
        public string ChieuCao { get; set; }
        public int? Idcapbac { get; set; } = null;
        public int? Idnhomquyen { get; set; } = null;
        public int? Luongthoathuan { get; set; } = null;
        public string Vitri { get; set; }
        public int? Luonggop { get; set; }
        public DateTime? Ngaynghiviec { get; set; }
        public DateTime? NgayKyHDLD { get; set; }
        public string SoBhxh { get; set; }
        public string NoiDkbhxh { get; set; }
        public string LoaiNhanVien { get; set; }
        public string NgKhanCap { get; set; }
        public string TrinhDo { get; set; }
        [Required(ErrorMessage = "Bạn phải chọn Trạng thái hôn nhân")]
        public string HonNhan { get; set; }
        public string TamTru { get; set; }
        public string Role { get; set; }
        public string AnhNhanVien { get; set; } = "/usersupload/avatar/test.jpg";
    }
}
