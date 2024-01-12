namespace OnlineShoppingCart
{
    public class GlobalConfig
    {
        public static string LoginSessionName { get; } = "OSC-Session";
        public static string LoginCookieName { get; } = "OSC-Abc";
        public const string AdminRole = "Admin";
        public const string ShopKeeperRole = "Shopkeeper";
        public const string Customer = "Customer";
    }
}
