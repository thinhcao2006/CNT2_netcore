using CnttLesson09Annotation.Models;
using Microsoft.AspNetCore.Mvc;

namespace CnttLesson09Annotation.Controllers
{
    public class TvcMemberController : Controller
    {
        // Dữ liệu mẫu lưu trong memory (thay bằng database thực tế nếu cần)
        private static List<TvcMemberRegister> _members = new List<TvcMemberRegister>
        {
            new TvcMemberRegister { TvcMemberId = 1, TvcUserName = "admin", TvcPassword = "123456", TvcEmail = "admin@email.com", TvcPhoneNumber = "0901111111", TvcFullName = "Quản trị viên", TvcBirthday = new DateTime(1990, 1, 1), TvcRole = "Admin" },
            new TvcMemberRegister { TvcMemberId = 2, TvcUserName = "user01", TvcPassword = "123456", TvcEmail = "user01@email.com", TvcPhoneNumber = "0902222222", TvcFullName = "Nguyễn Thị Mai", TvcBirthday = new DateTime(2000, 6, 15), TvcRole = "Member" },
        };
        private static int _nextId = 3;

        // GET: TvcMember
        public IActionResult Index()
        {
            return View(_members);
        }

        // GET: TvcMember/Details/5
        public IActionResult Details(int id)
        {
            var member = _members.FirstOrDefault(m => m.TvcMemberId == id);
            if (member == null) return NotFound();
            return View(member);
        }

        // GET: TvcMember/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TvcMember/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TvcMemberRegister member)
        {
            if (ModelState.IsValid)
            {
                member.TvcMemberId = _nextId++;
                _members.Add(member);
                TempData["Success"] = "Thêm thành viên thành công!";
                return RedirectToAction(nameof(Index));
            }
            return View(member);
        }

        // GET: TvcMember/Edit/5
        public IActionResult Edit(int id)
        {
            var member = _members.FirstOrDefault(m => m.TvcMemberId == id);
            if (member == null) return NotFound();
            return View(member);
        }

        // POST: TvcMember/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, TvcMemberRegister member)
        {
            if (ModelState.IsValid)
            {
                var existing = _members.FirstOrDefault(m => m.TvcMemberId == id);
                if (existing == null) return NotFound();
                existing.TvcUserName = member.TvcUserName;
                existing.TvcEmail = member.TvcEmail;
                existing.TvcPhoneNumber = member.TvcPhoneNumber;
                existing.TvcFullName = member.TvcFullName;
                existing.TvcBirthday = member.TvcBirthday;
                existing.TvcRole = member.TvcRole;
                TempData["Success"] = "Cập nhật thành viên thành công!";
                return RedirectToAction(nameof(Index));
            }
            return View(member);
        }

        // GET: TvcMember/Delete/5
        public IActionResult Delete(int id)
        {
            var member = _members.FirstOrDefault(m => m.TvcMemberId == id);
            if (member == null) return NotFound();
            return View(member);
        }

        // POST: TvcMember/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var member = _members.FirstOrDefault(m => m.TvcMemberId == id);
            if (member != null)
            {
                _members.Remove(member);
                TempData["Success"] = "Xóa thành viên thành công!";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
