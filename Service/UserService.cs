using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using estudo_dotnet.Data.Context;
using estudo_dotnet.Entities;
using estudo_dotnet.Interfaces.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace estudo_dotnet.Service
{
    public class UserService : IUserService
    {
        private readonly EstudoContext _context;
        public UserService(EstudoContext context)
        {
            _context = context;
        }
        public async Task<bool> Login(string email, string password)
        {
            User? user = await _context.User.Where(u => u.Email == email).FirstOrDefaultAsync();
            
            if (user == null)
            {
                return false;
            }
            
            return ComparePassword(user, password);
        }

        public async Task<string> GenerateToken(string email, int sessionTime)
        {
            if (sessionTime <= 0)
            {
                throw new ArgumentException("O tempo de sessão precisa ser maior que 0.");
            }

            User? user = await _context.User.Where(u => u.Email == email).FirstOrDefaultAsync();
            
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("aqui vai a chave secreta");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("Login", user.Email.ToString()),
                    new Claim("Id", user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(sessionTime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public bool ComparePassword(User user, string password)
        {
            password = BytesToString(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(password)));
            return user.Password.ToUpper() == password.ToUpper();
        }
        public string BytesToString(byte[] bytes)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
}