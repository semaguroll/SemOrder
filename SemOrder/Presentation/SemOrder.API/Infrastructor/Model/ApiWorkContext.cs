using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using SemOrder.Common.DTOs.User;
using SemOrder.Common.WorkContext;
using SemOrder.Service.Repository.User;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace SemOrder.API.Infrastructor.Model
{
    public class ApiWorkContext : IWorkContext
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IUserRepository _userRepository;
        private readonly IWorkContext _workContext;
        private readonly IMapper _mapper;

        public ApiWorkContext(IHttpContextAccessor contextAccessor, IUserRepository userRepository, IWorkContext workContext, IMapper mapper)
        {
            _contextAccessor = contextAccessor;
            _userRepository = userRepository;
            _workContext = workContext;
            _mapper = mapper;
        }
        public UserResponse CurrentUser
        {
            get
            {
                var authResult = _contextAccessor.HttpContext.AuthenticateAsync(JwtBearerDefaults.AuthenticationScheme).Result;

                if (!authResult.Succeeded)
                    return null;
                var email = authResult.Principal.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value;

                var userId = authResult.Principal.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value;
                var userResult = _userRepository.GetById(Guid.Parse(userId)).Result;
                UserResponse user = _mapper.Map<UserResponse>(userResult);
                return user;
            }
            set
            {
                CurrentUser = value;
            }

        }
    }
}
