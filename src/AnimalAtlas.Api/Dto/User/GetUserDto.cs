namespace AnimalAtlas.Api.Dto.User
{
    public class GetUserDto
    {
        public GetUserDto(Infrastructure.Models.User user)
        {
            FirstName = user.FirstName ?? "";
            LastName = user.LastName ?? "";
            Name = user.FirstName + " " + user.LastName;
            Email = user.Email ?? "";
            IsAdmin = user.Roles.Any(p => p.RoleName == Infrastructure.Models.UserAppRole.Admin);
            IsSysadmin = user.Roles.Any(p => p.RoleName == Infrastructure.Models.UserAppRole.Sysadmin);
            UserProfileCompleted = user.UserProfileCompleted;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool UserProfileCompleted { get; set; }
        public bool? IsAdmin { get; set; }
        public bool? IsSysadmin { get; set; }
    }
}
