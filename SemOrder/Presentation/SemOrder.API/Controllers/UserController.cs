using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SemOrder.API.Controllers.Base;
using SemOrder.Common.DTOs.User;
using SemOrder.Common.Models;
using SemOrder.Model.Entities;
using SemOrder.Service.Repository.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SemOrder.API.Controllers
{
    [Route("user")]
    public class UserController : BaseApiController<UserController>
    {
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;
        public UserController(IUserRepository userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<WebApiResponse<List<UserResponse>>>> GetUsers()
        {
            var users = await _userRepo.TableNoTracking.ToListAsync();
            var ur = _mapper.Map<List<UserResponse>>(users);
            if (ur != null)
                return new WebApiResponse<List<UserResponse>>(true, "Success", ur);
            return new WebApiResponse<List<UserResponse>>(false, "Error");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WebApiResponse<UserResponse>>> GetUser(Guid id)
        {
            if (id == Guid.Empty)
                return NotFound();
            var user = _mapper.Map<UserResponse>(await _userRepo.GetById(id));
            if (user != null)
                return new WebApiResponse<UserResponse>(true, "Success", user);
            return new WebApiResponse<UserResponse>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<UserResponse>>> AddUser(UserRequest request)
        {
            var userMap = _mapper.Map<User>(request);
            var data = await _userRepo.Add(userMap);
            var userResponse = _mapper.Map<UserResponse>(data);
            if (userResponse != null)
                return new WebApiResponse<UserResponse>(true, "Success", userResponse);
            return new WebApiResponse<UserResponse>(false, "Error");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<UserResponse>>> UpdateUser(Guid id, UserRequest request)
        {
            if (id != request.ID)
                return BadRequest();
            try
            {
                User userMap = await _userRepo.GetById(id);

                if (userMap == null)
                    return NotFound();

                _mapper.Map(request, userMap);

                var data = await _userRepo.Update(userMap);
                if (data != null)
                {
                    var userResponse = _mapper.Map<UserResponse>(data);
                    return new WebApiResponse<UserResponse>(true, "Success", userResponse);
                }
                else
                    return new WebApiResponse<UserResponse>(false, "Error");

            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<UserResponse>>> DeleteUser(Guid id)
        {
            var user = await _userRepo.GetById(id);
            if (user == null)
                return NotFound();
            var data = await _userRepo.Remove(user);
            if (data)
            {
                var userResponse = _mapper.Map<UserResponse>(data);
                return new WebApiResponse<UserResponse>(true, "Success", userResponse);
            }
            else 
                return new WebApiResponse<UserResponse>(false, "Error");
        }

        [HttpGet("getactive")]
        public async Task<ActionResult<WebApiResponse<List<UserResponse>>>> GetActiveUsers()
        {
            var activeUsers = await _userRepo.GetActive().ToListAsync();
            var userResponse = _mapper.Map<List<UserResponse>>(activeUsers);
            if (userResponse.Count > 0)
                return new WebApiResponse<List<UserResponse>>(true, "Success", userResponse);
            return new WebApiResponse<List<UserResponse>>(false, "Error");
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> ActivateUser(Guid id)
        {
            var activatedUsers = await _userRepo.Activate(id);
            var userResponse = _mapper.Map<UserResponse>(activatedUsers);
            if (userResponse != null)
                return new WebApiResponse<bool>(true, "Success", true);
            return new WebApiResponse<bool>(false, "Error");
        }
    }
}
