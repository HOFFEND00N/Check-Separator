namespace CheckSeparatorMVC.Models
{
    public class CheckUser
    {
        public int CheckId { get; set; }
        public Check Check { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }

        public CheckUser(int checkId, string userId)
        {
            CheckId = checkId;
            UserId = userId;
        }

        public CheckUser(Check check, User user)
        {
            Check = check;
            User = user;
        }

        public CheckUser()
        {
        }
    }
}
