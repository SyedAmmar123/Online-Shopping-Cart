namespace OnlineShoppingCart.Models
{
    public class LoginHistory : ShareModel
    {
        public string UserId { get; set; }
        public virtual AppUser User { get; set; }
        public string IPAddress { get; set; }
        public string ClientInfo { get; set; }
        public string OS { get; set; }
        public DateTime ValidTill { get; set; }
        public DateTime? ClosedTime { get; set; }

        public string Token { get; set; } = Guid.NewGuid().ToString().Replace("-", "");
    }
}
