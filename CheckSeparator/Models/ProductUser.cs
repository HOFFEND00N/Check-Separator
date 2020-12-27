namespace CheckSeparatorMVC.Models
{
    public class ProductUser
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public ProductUser(User user, Product product)
        {
            User = user;
            Product = product;
        }

        public ProductUser()
        {
        }
    }
}
