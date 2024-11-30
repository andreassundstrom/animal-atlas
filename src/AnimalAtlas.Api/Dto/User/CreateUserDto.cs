using System.ComponentModel.DataAnnotations;

namespace AnimalAtlas.Api.Dto.User
{
    public class CreateUserDto
    {
        [Required]
        public required string FirstName { get; set; }
        [Required]
        public required string LastName { get; set; }
        [Required]
        public required string Email { get; set; }
    }
}
