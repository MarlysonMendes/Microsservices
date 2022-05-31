using Dapper;
using Discount.Api.Entities;
using Npgsql;

namespace Discount.Api.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly IConfiguration _configuration;

        public DiscountRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> CreateDiscount(Coupon coupon)
        {
            NpgsqlConnection connection = GetConnection();

            var affected = await connection.ExecuteAsync
                ("INSERT INTO Coupon (ProductName, Description, Amount)" + 
                "VALUES (@ProductName, @Description, @Amount",
                new {ProductName = coupon.ProductNanme, Description = coupon.Description, Amount = coupon.Amount});
            
            if (affected == 0) return false;

            return true;

        }

        public async Task<bool> DeleteDiscount(string productName)
        {
            NpgsqlConnection connection = GetConnection();

            var affected = await connection.ExecuteAsync
                ("DELETE FROM Coupon WHERE ProductName)" +
                " = @ProductName",
                new { ProductName = productName });

            if (affected == 0) return false;

            return true;
        }

        public async Task<Coupon> GetDiscount(string productName)
        {
;
            NpgsqlConnection connection = GetConnection();

            var coupon = await connection.QueryFirstOrDefaultAsync<Coupon>
                ("SELECT * FROM Coupon WHERE ProductName = @ProductName",
                new {ProductName = productName});

            if (coupon == null)
                return new Coupon { ProductNanme = "No Discount", Amount = 0, Description="No Discount Desc" };
            return coupon;
        }

        public async Task<bool> UpdateDiscount(Coupon coupon)
        {
            NpgsqlConnection connection = GetConnection();

            var affected = await connection.ExecuteAsync
                ("INSERT INTO Coupon (ProductName, Description, Amount)" +
                "VALUES (@ProductName, @Description, @Amount WHERE Id = @Id",
                new { ProductName = coupon.ProductNanme, Description = coupon.Description, Amount = coupon.Amount, Id = coupon.Id });

            if (affected == 0) return false;

            return true;
        }
        private NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection
                (_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
        }
    }
}
