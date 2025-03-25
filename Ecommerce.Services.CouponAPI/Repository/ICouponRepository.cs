using Ecommerce.Services.CouponAPI.Models.dto;

namespace Ecommerce.Services.CouponAPI.Repository
{
    public interface ICouponRepository
    {
        Task<CouponDto> GetCouponByCode(string couponCode);
    }
}
