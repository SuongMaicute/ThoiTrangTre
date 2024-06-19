namespace API.ViewModels
{
    public class RegisterDTO
    {


        public string UsersName { get; set; } = null!;

        public string? UsersEmail { get; set; }

        public string UsersPhone { get; set; } = null!;

        public string UsersAddress { get; set; } = null!;

        public int RoleId { get; set; }

        public string? Passwords { get; set; }
    }
}
