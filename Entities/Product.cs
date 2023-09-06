using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using estudo_dotnet.Entities;

namespace estudo_dotnet.Entities
{
    public class Product : EntityBase
    {
        public Product () { }

        public Product (string productName, decimal price, int quantity)
        {
            ProductName = productName;
            Price = price;
            Quantity = quantity;
        }
        [Required(ErrorMessage = "O nome do produto é obrigatório")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "O preço é obrigatório")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "A quantidade é obrigatória")]
        public int Quantity { get; set; }
    }
}