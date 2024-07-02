namespace API.ViewModels
{
    public class UpdateUser
    {
        public int? userid { get; set; }
        public string UsersName { get; set; } = null!;


        public string UsersPhone { get; set; } = null!;

        public string UsersAddress { get; set; } = null!;
    }
}
