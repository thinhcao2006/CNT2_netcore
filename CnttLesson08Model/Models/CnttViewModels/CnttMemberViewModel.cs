using CnttLesson08Model.Models.CnttDataModels;

namespace CnttLesson08Model.Models.CnttViewModels
{
    public class CnttMemberViewModel
    {
        public CnttMember? CurrentMember { get; set; }
        public List<CnttMember> MemberList { get; set; } = new List<CnttMember>();
        public string Title { get; set; } = "Danh sách thành viên";
        public int TotalCount => MemberList.Count;
    }
}
