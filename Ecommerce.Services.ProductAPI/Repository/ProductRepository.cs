using AutoMapper;
using Ecommerce.Services.ProductAPI.dbcontexts;
using Ecommerce.Services.ProductAPI.dto;
using Ecommerce.Services.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Services.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public ProductRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
        {
            try
            {
                var product = _mapper.Map<Product>(productDto);

                if (product.Variants != null)
                {
                    foreach (var variant in product.Variants)
                    {
                        variant.ProductId = product.ProductId;
                    }
                }

                if (product.Images != null)
                {
                    foreach (var image in product.Images)
                    {
                        image.ProductId = product.ProductId;
                    }
                }

                if (product.ProductId > 0)
                {
                    _db.Products.Update(product);
                }
                else
                {
                    _db.Products.Add(product);
                }

                await _db.SaveChangesAsync();
                return _mapper.Map<ProductDto>(product);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            try
            {
                var product = await _db.Products.Include(p => p.Variants).Include(p => p.Images)
                    .FirstOrDefaultAsync(u => u.ProductId == productId);

                if (product == null)
                {
                    return false;
                }

                _db.Products.Remove(product);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<ProductDto> GetProductById(int productId)
        {
            var product = await _db.Products
                .Include(p => p.Variants)
                .Include(p => p.Images)
                .FirstOrDefaultAsync(x => x.ProductId == productId);

            return _mapper.Map<ProductDto>(product);
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            var productList = await _db.Products
                .Include(p => p.Variants)
                .Include(p => p.Images)
                .ToListAsync();

            return _mapper.Map<List<ProductDto>>(productList);
        }
    }
}