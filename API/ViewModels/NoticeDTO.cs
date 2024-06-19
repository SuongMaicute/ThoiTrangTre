using API.Models;

namespace API.ViewModels
{
    public class NoticeDTO
    {
        public int NoticeId { get; set; }

        public string NoticeTitle { get; set; } = null!;

        public string NoticeContent { get; set; } = null!;

        public int UserId { get; set; }

        public string NoticeStatus { get; set; } = null!;
    }
}
