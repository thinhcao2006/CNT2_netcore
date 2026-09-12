using Microsoft.AspNetCore.Mvc;
using CnttLesson07Models.Models;

namespace CnttLesson07Models.Controllers
{
    public class CnttMemberController : Controller
    {
        // Dữ liệu mẫu danh sách thành viên mới
        public static List<CnttMember> members = new List<CnttMember>()
        {
            new CnttMember {
                CnttMemberId = "c82a1945-8fe1-4c12-b912-38d506199a01",
                CnttUserName = "thinhcao2006",
                CnttPassword = "password123",
                CnttFullName = "Cao Văn Thịnh",
                CnttEmail = "thinhcao2006@gmail.com"
            },
            new CnttMember {
                CnttMemberId = "a17f2893-610e-47aa-9eb0-e18b456cd102",
                CnttUserName = "hoangnguyen",
                CnttPassword = "password123",
                CnttFullName = "Nguyễn Minh Hoàng",
                CnttEmail = "hoang.nguyen@cntt.edu.vn"
            },
            new CnttMember {
                CnttMemberId = "b90e3412-28c9-4f32-8419-7d312948ea03",
                CnttUserName = "thaotran",
                CnttPassword = "password123",
                CnttFullName = "Trần Phương Thảo",
                CnttEmail = "thao.tran@cntt.edu.vn"
            },
            new CnttMember {
                CnttMemberId = "e51d6704-51a8-423b-b72e-0a4b918f2c04",
                CnttUserName = "dangvu",
                CnttPassword = "password123",
                CnttFullName = "Vũ Hải Đăng",
                CnttEmail = "dang.vu@cntt.edu.vn"
            },
            new CnttMember {
                CnttMemberId = "f44c8290-7981-4b15-ae73-19ac73d09e05",
                CnttUserName = "quynhnga",
                CnttPassword = "password123",
                CnttFullName = "Đỗ Quỳnh Nga",
                CnttEmail = "nga.do@cntt.edu.vn"
            },
            new CnttMember {
                CnttMemberId = "327b9104-94ef-4576-90cb-ec68241fa706",
                CnttUserName = "huybui",
                CnttPassword = "password123",
                CnttFullName = "Bùi Quang Huy",
                CnttEmail = "huy.bui@cntt.edu.vn"
            }
        };

        // Link 'Member' trên menu: hiển thị 1 member
        public IActionResult Index()
        {
            var member = members.FirstOrDefault();
            ViewBag.member = member;
            return View(member);
        }

        // Link 'Members' trên menu: hiển thị danh sách thành viên như trong ảnh
        public IActionResult Members()
        {
            return View("ListMember", members);
        }

        // Link 'List Member' trên menu: hiển thị danh sách thành viên như trong ảnh
        public IActionResult ListMember()
        {
            return View(members);
        }

        // Action GetMembers tương thích
        public IActionResult GetMembers()
        {
            return View("ListMember", members);
        }

        // Thêm mới (GET)
        [HttpGet]
        public IActionResult Create()
        {
            var newMember = new CnttMember
            {
                CnttMemberId = Guid.NewGuid().ToString()
            };
            return View(newMember);
        }

        // Thêm mới (POST)
        [HttpPost]
        public IActionResult Create(CnttMember member)
        {
            if (string.IsNullOrEmpty(member.CnttMemberId))
            {
                member.CnttMemberId = Guid.NewGuid().ToString();
            }

            members.Add(member);
            return RedirectToAction(nameof(ListMember));
        }

        // Chi tiết
        public IActionResult Details(string id)
        {
            var member = members.FirstOrDefault(m => m.CnttMemberId == id);
            if (member == null)
            {
                return NotFound();
            }
            return View(member);
        }

        // Sửa (GET)
        [HttpGet]
        public IActionResult Edit(string id)
        {
            var member = members.FirstOrDefault(m => m.CnttMemberId == id);
            if (member == null)
            {
                return NotFound();
            }
            return View(member);
        }

        // Sửa (POST)
        [HttpPost]
        public IActionResult Edit(CnttMember member)
        {
            var existing = members.FirstOrDefault(m => m.CnttMemberId == member.CnttMemberId);
            if (existing != null)
            {
                existing.CnttUserName = member.CnttUserName;
                existing.CnttFullName = member.CnttFullName;
                existing.CnttPassword = member.CnttPassword;
                existing.CnttEmail = member.CnttEmail;
            }
            return RedirectToAction(nameof(ListMember));
        }

        // Xóa (GET)
        [HttpGet]
        public IActionResult Delete(string id)
        {
            var member = members.FirstOrDefault(m => m.CnttMemberId == id);
            if (member == null)
            {
                return NotFound();
            }
            return View(member);
        }

        // Xóa (POST)
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(string id)
        {
            var member = members.FirstOrDefault(m => m.CnttMemberId == id);
            if (member != null)
            {
                members.Remove(member);
            }
            return RedirectToAction(nameof(ListMember));
        }
    }
}
