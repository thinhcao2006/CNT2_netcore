using Microsoft.AspNetCore.Mvc;
using CnttLesson08Model.Models.CnttDataModels;
using CnttLesson08Model.Models.CnttBusinessModels;

namespace CnttLesson08Model.Controllers
{
    public class CnttMemberController : Controller
    {
        private readonly CnttMemberBusiness _business = new CnttMemberBusiness();

        // 1. Trang danh sách thành viên / sinh viên (như hình chụp localhost:.../CnttMember/Index)
        public IActionResult Index()
        {
            var list = _business.GetAll();
            ViewBag.members = list;
            return View("~/Views/CnttMember/Index.cshtml", list);
        }

        // 2. Trang thông tin sinh viên đơn (minh họa đưa 1 đối tượng ra View theo Slide 4, 6, 8, 9)
        public IActionResult MemberInfo()
        {
            var member = _business.GetDefault();
            ViewBag.member = member;
            return View("~/Views/CnttMember/MemberInfo.cshtml", member);
        }

        // Action tương thích cho link /CnttMember/GetMembers (Slide 5, 11)
        public IActionResult GetMembers()
        {
            var list = _business.GetAll();
            ViewBag.members = list;
            return View("~/Views/CnttMember/Index.cshtml", list);
        }

        // 3. Thêm mới thành viên - GET (Slide 11, 12)
        [HttpGet]
        public IActionResult Create()
        {
            var newMember = new CnttMember
            {
                CnttMemberId = Guid.NewGuid().ToString()
            };
            return View("~/Views/CnttMember/Create.cshtml", newMember);
        }

        // 3. Thêm mới thành viên - POST (Slide 11, 12, 14)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CnttMember member)
        {
            if (string.IsNullOrEmpty(member.CnttMemberId))
            {
                member.CnttMemberId = Guid.NewGuid().ToString();
            }

            _business.Add(member);
            TempData["SuccessMessage"] = "Thêm mới thành viên thành công!";
            return RedirectToAction(nameof(Index));
        }

        // 4. Xem chi tiết thành viên - Details (Slide 15 - Scaffolding Details)
        public IActionResult Details(string id)
        {
            var member = _business.GetById(id);
            if (member == null)
            {
                return NotFound();
            }
            return View("~/Views/CnttMember/Details.cshtml", member);
        }

        // 5. Chỉnh sửa thành viên - GET (Slide 15 - Scaffolding Edit)
        [HttpGet]
        public IActionResult Edit(string id)
        {
            var member = _business.GetById(id);
            if (member == null)
            {
                return NotFound();
            }
            return View("~/Views/CnttMember/Edit.cshtml", member);
        }

        // 5. Chỉnh sửa thành viên - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CnttMember member)
        {
            var success = _business.Update(member);
            if (success)
            {
                TempData["SuccessMessage"] = "Cập nhật thành viên thành công!";
                return RedirectToAction(nameof(Index));
            }
            return View("~/Views/CnttMember/Edit.cshtml", member);
        }

        // 6. Xóa thành viên - GET (Slide 15 - Scaffolding Delete)
        [HttpGet]
        public IActionResult Delete(string id)
        {
            var member = _business.GetById(id);
            if (member == null)
            {
                return NotFound();
            }
            return View("~/Views/CnttMember/Delete.cshtml", member);
        }

        // 6. Xóa thành viên - POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            _business.Delete(id);
            TempData["SuccessMessage"] = "Xóa thành viên thành công!";
            return RedirectToAction(nameof(Index));
        }
    }
}
