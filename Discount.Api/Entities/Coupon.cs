namespace Discount.Api.Entities
{
    public class Coupon
    {
        public int Id { get; set; }
        public string ProductNanme { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
    }
}
