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
    }
}
