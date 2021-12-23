using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_api.Data;
using web_api.Entities;

namespace web_api.Controllers
{
    [ApiController]
    [Route("Api/[Controller]")]
    public class UsersController : ControllerBase
    {
        private DataContext _Context { get; set; }
        public UsersController(DataContext _Context) 
        {
            this._Context = _Context;
               
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<appUser>>> GetUsers(){
            return await _Context.Users.ToListAsync();
        }
        
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<appUser>> GetUserById(int id){

            return await _Context.Users.FindAsync(id);
        }
    }
}