using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Database.Entities
{
    [Table("Product")]
    public class Product
    {
        [Key] 
        public int ProductID { get; set; }
        [Required] //Not null
        [StringLength(50)]
        public string ProductName { get; set; }
        public string Provider { get; set; }
        public Product(int productID, string productName, string provider)
        {
            ProductID = productID;
            ProductName = productName;
            Provider = provider;
        }
        public Product(string productName, string provider)
        {
            ProductName = productName;
            Provider = provider;
        }
        public void PrintInfor()
        {
            Console.WriteLine($"ProductID={ProductID}, ProductName={ProductName}, Provide={Provider}");
        }
    }
}
