﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SemOrder.Common.DTOs.Login;
using SemOrder.Common.DTOs.User;
using SemOrder.Common.Extensions;
using SemOrder.Common.Models;
using SemOrder.Service.Repository.User;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace SemOrder.API.Controllers
{
    [Route("account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AccountController(
            IUserRepository userRepository,
            IMapper mapper,
            IConfiguration configuration)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        //http://localhost:5000/account/login?Email=admin@admin.com&Password=123
        [HttpGet("login")]
        public async Task<WebApiResponse<UserResponse>> Login([FromQuery] LoginRequest request)
        {
            if (ModelState.IsValid)
            {
                var result = await _userRepository.GetByDefault(x => x.Email == request.Email && x.Password == request.Password);
                if (result != null)
                {
                    UserResponse rm = _mapper.Map<UserResponse>(result);
                    rm.AccessToken = SetAccessToken(rm, request.Password);
                    return new WebApiResponse<UserResponse>(true, "Success", rm);
                }
            }
            return new WebApiResponse<UserResponse>(false,
                ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList().ToString());
        }

        private GetAccessToken SetAccessToken(UserResponse rm, string password)
        {
            var claims = new List<Claim>
            {
                //using System.IdentityModel.Tokens.Jwt;
                new Claim(JwtRegisteredClaimNames.Jti,rm.ID.ToString()),
                new Claim(JwtRegisteredClaimNames.Email,rm.Email)
            };

            //JWT

            var systemSecurityKey =
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]));
            var signingCredentials = new SigningCredentials(systemSecurityKey, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Tokens:Expires"]));
            var ticks = expires.ToUnixTime();

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _configuration["Tokens:Issuer"],
                audience: _configuration["Tokens:Audience"],
                claims: claims,
                expires: expires,
                signingCredentials: signingCredentials);

            return new GetAccessToken
            {
                TokenType = "SemOrderAccessToken",
                AccessToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Expires = ticks,
                RefreshToken = $"{rm.Email}_{password}_{ticks}".Encrypt()
            };
        }

        [HttpGet("refreshtoken")]
        public async Task<WebApiResponse<GetAccessToken>> RefreshToken([FromQuery] RefreshToken request)
        {
            if (string.IsNullOrEmpty(request.Refresh_Token))
                throw new Exception("Invalid Refresh Token");

            var key = request.Refresh_Token.Decrypt();
            var userInfo = key.Split('_');

            if (userInfo.Length < 3 || userInfo[0] != request.Email)
                throw new Exception("Geçersiz Token");

            var result = await _userRepository.GetByDefault(x => x.Email == userInfo[0] && x.Password == userInfo[1]);
            if (result != null)
            {
                UserResponse rm = _mapper.Map<UserResponse>(result);
                rm.AccessToken = SetAccessToken(rm, userInfo[1]);
                return new WebApiResponse<GetAccessToken>(true, "Success", rm.AccessToken);
            }
            return new WebApiResponse<GetAccessToken>(false, "Error");
        }
    }
}
