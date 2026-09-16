using CnttLesson08Lab.Models;
using Microsoft.AspNetCore.Mvc;

namespace CnttLesson08Lab.Controllers
{
    /// <summary>
    /// Controller quản lý Sinh viên - Lab 04: ASP.NET Core Model
    /// </summary>
    public class CnttSinhVienController : Controller
    {
        // Dữ liệu mẫu (thay thế cho database trong bài lab)
        private static List<CnttSinhVien> _danhSachSV = new List<CnttSinhVien>
        {
            new CnttSinhVien { MaSV = 1, HoTen = "Nguyễn Văn An", Email = "an.nv@student.edu.vn", SoDienThoai = "0901234567", Lop = "CNTT01", Nganh = "Công nghệ thông tin", NgaySinh = new DateTime(2003, 5, 12), DiemTB = 8.5, DiaChi = "Quận 1, TP.HCM" },
            new CnttSinhVien { MaSV = 2, HoTen = "Trần Thị Bình", Email = "binh.tt@student.edu.vn", SoDienThoai = "0912345678", Lop = "CNTT01", Nganh = "Công nghệ thông tin", NgaySinh = new DateTime(2003, 8, 20), DiemTB = 9.2, DiaChi = "Quận 3, TP.HCM" },
            new CnttSinhVien { MaSV = 3, HoTen = "Lê Văn Cường", Email = "cuong.lv@student.edu.vn", SoDienThoai = "0923456789", Lop = "CNTT02", Nganh = "Kỹ thuật phần mềm", NgaySinh = new DateTime(2002, 12, 3), DiemTB = 7.0, DiaChi = "Bình Dương" },
            new CnttSinhVien { MaSV = 4, HoTen = "Phạm Thị Dung", Email = "dung.pt@student.edu.vn", SoDienThoai = "0934567890", Lop = "CNTT02", Nganh = "Kỹ thuật phần mềm", NgaySinh = new DateTime(2003, 3, 15), DiemTB = 6.2, DiaChi = "Đồng Nai" },
            new CnttSinhVien { MaSV = 5, HoTen = "Hoàng Minh Đức", Email = "duc.hm@student.edu.vn", SoDienThoai = "0945678901", Lop = "CNTT03", Nganh = "Hệ thống thông tin", NgaySinh = new DateTime(2002, 7, 28), DiemTB = 4.5, DiaChi = "Long An" },
        };

        private static int _nextId = 6;

        // GET: /CnttSinhVien/Index
        public IActionResult Index()
        {
            return View(_danhSachSV);
        }

        // GET: /CnttSinhVien/Details/1
        public IActionResult Details(int id)
        {
            var sv = _danhSachSV.FirstOrDefault(x => x.MaSV == id);
            if (sv == null) return NotFound();
            return View(sv);
        }

        // GET: /CnttSinhVien/Create
        public IActionResult Create()
        {
            return View(new CnttSinhVien { NgaySinh = new DateTime(2000, 1, 1) });
        }

        // POST: /CnttSinhVien/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CnttSinhVien model)
        {
            if (ModelState.IsValid)
            {
                model.MaSV = _nextId++;
                _danhSachSV.Add(model);
                TempData["SuccessMessage"] = $"Thêm sinh viên '{model.HoTen}' thành công!";
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: /CnttSinhVien/Edit/1
        public IActionResult Edit(int id)
        {
            var sv = _danhSachSV.FirstOrDefault(x => x.MaSV == id);
            if (sv == null) return NotFound();
            return View(sv);
        }

        // POST: /CnttSinhVien/Edit/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, CnttSinhVien model)
        {
            if (id != model.MaSV) return BadRequest();

            if (ModelState.IsValid)
            {
                var sv = _danhSachSV.FirstOrDefault(x => x.MaSV == id);
                if (sv == null) return NotFound();

                sv.HoTen = model.HoTen;
                sv.Email = model.Email;
                sv.SoDienThoai = model.SoDienThoai;
                sv.Lop = model.Lop;
                sv.Nganh = model.Nganh;
                sv.NgaySinh = model.NgaySinh;
                sv.DiemTB = model.DiemTB;
                sv.DiaChi = model.DiaChi;

                TempData["SuccessMessage"] = $"Cập nhật sinh viên '{model.HoTen}' thành công!";
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: /CnttSinhVien/Delete/1
        public IActionResult Delete(int id)
        {
            var sv = _danhSachSV.FirstOrDefault(x => x.MaSV == id);
            if (sv == null) return NotFound();
            return View(sv);
        }

        // POST: /CnttSinhVien/Delete/1
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var sv = _danhSachSV.FirstOrDefault(x => x.MaSV == id);
            if (sv != null)
            {
                string hoTen = sv.HoTen;
                _danhSachSV.Remove(sv);
                TempData["SuccessMessage"] = $"Xóa sinh viên '{hoTen}' thành công!";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
