using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using estudo_dotnet.Data.Context;
using estudo_dotnet.Entities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace estudo_dotnet.Data.Seed
{
    internal class DbInitializer
    {
        internal static void Initialize(EstudoContext context)
        {
            ArgumentNullException.ThrowIfNull(context, nameof(context));
            context.Database.EnsureCreated();
            if (context.User.Any()) { return; }

            var password = BytesToString(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes("123456")));
            var user = new User("Gustavo da Silva Freitas", "teste@teste.com.br", password.ToUpper());
            
            context.User.Add(user);
            context.SaveChanges();
        }
        
        static private string BytesToString(byte[] bytes)
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