using Ecommerce.Services.CartAPI.Models.dto;

namespace Ecommerce.Services.CartAPI.Repository
{
    public interface ICouponRepository
    {
        Task<CouponDto> GetCoupon(string couponName);
    }
}
