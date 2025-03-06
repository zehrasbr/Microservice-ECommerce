using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _context;
        public DiscountService(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateCouponAsync(CreateCouponDto createCouponDto)
        {
            string query = "Insert Into Coupons (Code,Rate,IsAsctive,ValidDate) values (@code,@rate,@isActive,@validDate)";
            var parametres = new DynamicParameters();
            parametres.Add("@code", createCouponDto.Code);
            parametres.Add("@rate", createCouponDto.Rate);
            parametres.Add("@isActive", createCouponDto.IsActive);
            parametres.Add("@validDate", createCouponDto.ValidDate);
            using (var connection = _context.CreateConnection()) 
            {
                await connection.ExecuteAsync(query, parametres);
            }
        }

        public Task DeleteCouponAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResultCouponDto>> GetAllCouponAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GetByIdCouponDto> GetByIdCouponAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCouponAsync(UpdateCouponDto updateCouponDto)
        {
            throw new NotImplementedException();
        }
    }
}
