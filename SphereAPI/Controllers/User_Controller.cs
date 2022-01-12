using Microsoft.AspNetCore.Mvc;
using SphereAPI.IRepository;
using SphereAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SphereAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class User_Controller : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public User_Controller(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        // GET: api/<User_Controllercs>
        [HttpGet]
        public async Task<IActionResult> GetUsers(int id)
        {
            var result = await unitOfWork.AppUsers.GetAll();
            return Ok(result);
        }

        // GET api/<User_Controllercs>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var result = await unitOfWork.AppUsers.GetT(q => q.Id == id);
            return Ok(result);
        }

        // POST api/<User_Controllercs>
        [HttpPost]
        public async Task CreateUser([FromBody] AppUser newUser_)
        {
            await unitOfWork.AppUsers.Insert(newUser_);
            await unitOfWork.Save();
        }

        // PUT api/<User_Controllercs>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<User_Controllercs>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
