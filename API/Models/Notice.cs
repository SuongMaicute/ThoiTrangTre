using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Notice
{
    public int NoticeId { get; set; }

    public string NoticeTitle { get; set; } = null!;

    public string NoticeContent { get; set; } = null!;

    public int UserId { get; set; }

    public string NoticeStatus { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
