using AnimalAtlas.Api.Dto.User;
using AnimalAtlas.Infrastructure.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AnimalAtlas.Api.Controllers.v1
{
    [Route("api/v1/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AnimalAtlasContext _db;

        public UserController(AnimalAtlasContext db)
        {
            _db = db;
        }

        [HttpGet]
        //[Authorize]
        public ActionResult<GetUserDto> GetCurrentUser()
        {
            var user = _db.Users.SingleOrDefault();

            if(user is null)
            {
                return NotFound();
            }

            var userDto = new GetUserDto(user);

            return Ok(userDto);
        }

        [Authorize]
        [HttpPut]
        public ActionResult CreateOrUpdateCurrentUser(CreateUserDto createUserDto)
        {
            var userId = User.Claims.Single(p => p.Type == ClaimTypes.NameIdentifier).Value;

            var existingUser = _db.Users.SingleOrDefault(p => p.ExternalId == userId);
            if(existingUser is null)
            {
                var user = new User
                {
                    ExternalId = userId,
                    FirstName = createUserDto.FirstName,
                    LastName = createUserDto.LastName,
                    Email = createUserDto.Email,
                    CreatedBy = userId,
                    CreatedUtc = DateTime.UtcNow,
                    LastUpdatedBy = userId,
                    LastUpdatedUtc = DateTime.UtcNow,
                };
                _db.Users.Add(user);
            }
            else
            {
                existingUser.FirstName = createUserDto.FirstName;
                existingUser.LastName = createUserDto.LastName;
                existingUser.Email = createUserDto.Email;
                existingUser.LastUpdatedBy = userId;
                existingUser.LastUpdatedUtc = DateTime.UtcNow;
            }

            _db.SaveChanges();
            return NoContent();
        }
    }
}
