namespace CnttLesson07Models.Models
{
    public class CnttMember
    {
        public string CnttMemberId { get; set; } = string.Empty;
        public string CnttUserName { get; set; } = string.Empty;
        public string CnttPassword { get; set; } = string.Empty;
        public string CnttFullName { get; set; } = string.Empty;
        public string CnttEmail { get; set; } = string.Empty;

        // Thuộc tính tương thích
        public string MemberId { get => CnttMemberId; set => CnttMemberId = value; }
        public string Username { get => CnttUserName; set => CnttUserName = value; }
        public string Fullname { get => CnttFullName; set => CnttFullName = value; }
        public string Password { get => CnttPassword; set => CnttPassword = value; }
        public string Email { get => CnttEmail; set => CnttEmail = value; }
    }

    public class Member : CnttMember
    {
    }
}
