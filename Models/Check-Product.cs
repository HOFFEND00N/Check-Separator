using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CheckSeparatorMVC.Models
{
    public class Check_Product
    {
        [Key]
        [Column(Order = 1)]
        public int ProductId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int CheckId { get; set; }
        [Key]
        [Column(Order = 3)]
        public string UserName { get; set; }
        public Check_Product()
        {
            ProductId = 0;
            CheckId = 0;
            UserName = "admin";
        }

        public Check_Product(int productId, int checkId, string userName)
        {
            ProductId = productId;
            CheckId = checkId;
            UserName = userName;
        }


    }
}
