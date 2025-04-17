﻿using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GestionPizza.DL.Entities;
using Microsoft.Extensions.Configuration;

namespace GestionPizza.API.Utils
{
    public class JwtUtils
    {

        private readonly string _issuer, _audience, _secret;
        public JwtUtils(IConfiguration config)
        {
            _issuer = config.GetSection("TokenInfo").GetSection("issuer").Value!;
            _audience = config.GetSection("TokenInfo").GetSection("audience").Value!;
            _secret = config.GetSection("TokenInfo").GetSection("secret").Value!;
        }
        public string GenerateToken(Customer customer)
        {
            if (customer is null) throw new ArgumentNullException();

            //Creer la Signin key
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret));

            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            //Creation du payload
            Claim[] claims = new Claim[]
            {
                new Claim(ClaimTypes.Sid, customer.Id.ToString()),
                new Claim(ClaimTypes.Role, customer.Role)
            };

            //Configuration du token
            JwtSecurityToken token = new JwtSecurityToken(
                    claims: claims,
                    signingCredentials: credentials,
                    issuer: _issuer,
                    audience: _audience
                );

            //Generation du token
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            return handler.WriteToken(token);
        }
    }
}
