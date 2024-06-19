namespace API.ViewModels
{
    public class ChangePassDTO
    {
        public string email { get; set; } = null!;

        public string? OldPass { get; set; }

        public string NewPass { get; set; } = null!;

    }
}
