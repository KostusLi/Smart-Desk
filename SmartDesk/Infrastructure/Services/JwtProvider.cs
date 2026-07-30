using Api.AuthOptions;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Services
{
    public class JwtProvider(IOptions<JwtOptions> _options) : IJwtProvider
    {

        private readonly JwtOptions _jwtOptions = _options.Value;

        public async Task<string> GenerateToken(User user)
        {
            Claim[] claims = [new("userId", user.Id.ToString()), new(ClaimTypes.Role, user.Role.ToString()), new("userEmail", user.Email.ToString())];


            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtOptions.SecretKey)),
                SecurityAlgorithms.HmacSha512
                );

            var token = new JwtSecurityToken(
                audience: AuthOptions.AUDIENCE,
                issuer: AuthOptions.ISSUER,
                claims: claims,
                signingCredentials: signingCredentials,
                expires: DateTime.UtcNow.AddHours(_jwtOptions.ExpiresHours));

            string secureString = new JwtSecurityTokenHandler().WriteToken(token);

            return secureString;
        }
    }
}
