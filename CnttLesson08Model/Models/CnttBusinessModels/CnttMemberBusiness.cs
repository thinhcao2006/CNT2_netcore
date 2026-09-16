using CnttLesson08Model.Models.CnttDataModels;

namespace CnttLesson08Model.Models.CnttBusinessModels
{
    public class CnttMemberBusiness
    {
        // Danh sách dữ liệu mẫu sinh viên mới đa dạng, thực tế
        public static List<CnttMember> Members = new List<CnttMember>()
        {
            new CnttMember
            {
                CnttMemberId = "24010101-cntt-4a92-8fe1-38d506199a01",
                CnttUserName = "thinhcao2006",
                CnttPassword = "ThinhCao@2026",
                CnttFullName = "Cao Văn Thịnh",
                CnttEmail = "thinhcao2006@cntt.edu.vn"
            },
            new CnttMember
            {
                CnttMemberId = "24010102-cntt-4c68-ae1b-96d333af1822",
                CnttUserName = "nguyenan",
                CnttPassword = "AnNguyen#123",
                CnttFullName = "Nguyễn Văn An",
                CnttEmail = "an.nguyen@cntt.edu.vn"
            },
            new CnttMember
            {
                CnttMemberId = "24010103-cntt-4220-9d98-4f16ba58aa23",
                CnttUserName = "maitran",
                CnttPassword = "MaiTran$456",
                CnttFullName = "Trần Thị Tuyết Mai",
                CnttEmail = "mai.tran@cntt.edu.vn"
            },
            new CnttMember
            {
                CnttMemberId = "24010104-cntt-4edd-9551-157387802c24",
                CnttUserName = "namle",
                CnttPassword = "NamLe@789!",
                CnttFullName = "Lê Hoàng Nam",
                CnttEmail = "nam.le@cntt.edu.vn"
            },
            new CnttMember
            {
                CnttMemberId = "24010105-cntt-49ab-8712-32b10948ea25",
                CnttUserName = "ducpham",
                CnttPassword = "DucPham&321",
                CnttFullName = "Phạm Minh Đức",
                CnttEmail = "duc.pham@cntt.edu.vn"
            },
            new CnttMember
            {
                CnttMemberId = "24010106-cntt-4b15-ae73-19ac73d09e26",
                CnttUserName = "quynhtrang",
                CnttPassword = "TrangDo*654",
                CnttFullName = "Đỗ Quỳnh Trang",
                CnttEmail = "trang.do@cntt.edu.vn"
            },
            new CnttMember
            {
                CnttMemberId = "24010107-cntt-4576-90cb-ec68241fa727",
                CnttUserName = "huyvu",
                CnttPassword = "HuyVu@987",
                CnttFullName = "Vũ Quang Huy",
                CnttEmail = "huy.vu@cntt.edu.vn"
            }
        };

        // Lấy toàn bộ danh sách sinh viên
        public List<CnttMember> GetAll()
        {
            return Members;
        }

        // Lấy thông tin sinh viên đầu tiên (mặc định)
        public CnttMember? GetDefault()
        {
            return Members.FirstOrDefault();
        }

        // Lấy sinh viên theo ID
        public CnttMember? GetById(string id)
        {
            return Members.FirstOrDefault(m => m.CnttMemberId == id);
        }

        // Thêm mới sinh viên
        public void Add(CnttMember member)
        {
            if (string.IsNullOrEmpty(member.CnttMemberId))
            {
                member.CnttMemberId = Guid.NewGuid().ToString();
            }
            Members.Add(member);
        }

        // Cập nhật thông tin sinh viên
        public bool Update(CnttMember member)
        {
            var existing = GetById(member.CnttMemberId);
            if (existing == null) return false;

            existing.CnttUserName = member.CnttUserName;
            existing.CnttFullName = member.CnttFullName;
            existing.CnttPassword = member.CnttPassword;
            existing.CnttEmail = member.CnttEmail;
            return true;
        }

        // Xóa sinh viên
        public bool Delete(string id)
        {
            var existing = GetById(id);
            if (existing == null) return false;

            Members.Remove(existing);
            return true;
        }
    }
}
