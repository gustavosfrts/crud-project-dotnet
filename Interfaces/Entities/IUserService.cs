using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using estudo_dotnet.Entities;

namespace estudo_dotnet.Interfaces.Entities
{
    public interface IUserService
    {
        public Task<bool> Login(string email, string password);
        public Task<string> GenerateToken(string email, int sessionTime);
        public bool ComparePassword(User user, string password);
        public string BytesToString(byte[] bytes);
    }
}