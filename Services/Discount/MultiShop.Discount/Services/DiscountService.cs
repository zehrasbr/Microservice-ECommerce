﻿using Dapper;
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

        public async Task DeleteCouponAsync(int id)
        {
            string query = "Delete From Coupons where CouponId=@couponId";
            var parametres = new DynamicParameters();
            parametres.Add("couponId", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parametres);
            }
        }

        public async Task<List<ResultCouponDto>> GetAllCouponAsync()
        {
            string query = "Select * From Coupons";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCouponDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdCouponDto> GetByIdCouponAsync(int id)
        {
            string query = "Select * From Coupons Where CouponId=@couponId";
            var parametres = new DynamicParameters();
            parametres.Add("@couponId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIdCouponDto>(query);
                return values;
            }
        }

        public async Task UpdateCouponAsync(UpdateCouponDto updateCouponDto)
        {
            string query = "Update Coupons Set Code=@code,Rate=@rate,IsActive=@isActive,ValidDate=@validDate where CouponId=@couponId";
            var parametres = new DynamicParameters();
            parametres.Add("@code", updateCouponDto.Code);
            parametres.Add("@rate", updateCouponDto.Rate);
            parametres.Add("@isActive", updateCouponDto.IsActive);
            parametres.Add("@validDate", updateCouponDto.ValidDate);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parametres);
            }
        }
    }
}
