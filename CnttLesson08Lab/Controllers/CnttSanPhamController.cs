using CnttLesson08Lab.Models;
using Microsoft.AspNetCore.Mvc;

namespace CnttLesson08Lab.Controllers
{
    /// <summary>
    /// Controller quản lý Sản phẩm - Lab 04: ASP.NET Core Model
    /// </summary>
    public class CnttSanPhamController : Controller
    {
        // Dữ liệu mẫu (thay thế cho database trong bài lab)
        private static List<CnttSanPham> _danhSachSP = new List<CnttSanPham>
        {
            new CnttSanPham { MaSP = 1, TenSP = "Laptop Dell XPS 15", LoaiSP = "Điện tử", DonGia = 25000000, SoLuong = 10, NgayNhap = new DateTime(2025, 1, 10), MoTa = "Laptop cao cấp dành cho lập trình viên" },
            new CnttSanPham { MaSP = 2, TenSP = "Chuột không dây Logitech", LoaiSP = "Phụ kiện", DonGia = 350000, SoLuong = 50, NgayNhap = new DateTime(2025, 2, 15), MoTa = "Chuột không dây tiện dụng" },
            new CnttSanPham { MaSP = 3, TenSP = "Bàn phím cơ Keychron K2", LoaiSP = "Phụ kiện", DonGia = 1800000, SoLuong = 25, NgayNhap = new DateTime(2025, 3, 5), MoTa = "Bàn phím cơ compact 75%" },
            new CnttSanPham { MaSP = 4, TenSP = "Màn hình LG 27 inch 4K", LoaiSP = "Điện tử", DonGia = 8500000, SoLuong = 8, NgayNhap = new DateTime(2025, 4, 20), MoTa = "Màn hình 4K IPS chuyên nghiệp" },
            new CnttSanPham { MaSP = 5, TenSP = "USB Hub 7 cổng Anker", LoaiSP = "Phụ kiện", DonGia = 450000, SoLuong = 30, NgayNhap = new DateTime(2025, 5, 8), MoTa = "Hub USB 3.0 tốc độ cao" },
        };

        private static int _nextId = 6;

        // GET: /CnttSanPham/Index
        public IActionResult Index()
        {
            return View(_danhSachSP);
        }

        // GET: /CnttSanPham/Details/5
        public IActionResult Details(int id)
        {
            var sp = _danhSachSP.FirstOrDefault(x => x.MaSP == id);
            if (sp == null) return NotFound();
            return View(sp);
        }

        // GET: /CnttSanPham/Create
        public IActionResult Create()
        {
            return View(new CnttSanPham { NgayNhap = DateTime.Today });
        }

        // POST: /CnttSanPham/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CnttSanPham model)
        {
            if (ModelState.IsValid)
            {
                model.MaSP = _nextId++;
                _danhSachSP.Add(model);
                TempData["SuccessMessage"] = $"Thêm sản phẩm '{model.TenSP}' thành công!";
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: /CnttSanPham/Edit/5
        public IActionResult Edit(int id)
        {
            var sp = _danhSachSP.FirstOrDefault(x => x.MaSP == id);
            if (sp == null) return NotFound();
            return View(sp);
        }

        // POST: /CnttSanPham/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, CnttSanPham model)
        {
            if (id != model.MaSP) return BadRequest();

            if (ModelState.IsValid)
            {
                var sp = _danhSachSP.FirstOrDefault(x => x.MaSP == id);
                if (sp == null) return NotFound();

                sp.TenSP = model.TenSP;
                sp.LoaiSP = model.LoaiSP;
                sp.DonGia = model.DonGia;
                sp.SoLuong = model.SoLuong;
                sp.MoTa = model.MoTa;
                sp.NgayNhap = model.NgayNhap;

                TempData["SuccessMessage"] = $"Cập nhật sản phẩm '{model.TenSP}' thành công!";
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: /CnttSanPham/Delete/5
        public IActionResult Delete(int id)
        {
            var sp = _danhSachSP.FirstOrDefault(x => x.MaSP == id);
            if (sp == null) return NotFound();
            return View(sp);
        }

        // POST: /CnttSanPham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var sp = _danhSachSP.FirstOrDefault(x => x.MaSP == id);
            if (sp != null)
            {
                string tenSP = sp.TenSP;
                _danhSachSP.Remove(sp);
                TempData["SuccessMessage"] = $"Xóa sản phẩm '{tenSP}' thành công!";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
