using Ecommerce.Web.Models;
using Ecommerce.Web.Services.IServices;
using Ecommerce.Web.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Ecommerce.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {

        private readonly IProductService _productService;
        public IWebHostEnvironment _environment;
        public ProductController(IProductService productService, IWebHostEnvironment environment)
        {
            _productService = productService;
            _environment = environment;
        }

        public async Task<IActionResult> ProductIndex()
        {
            List<ProductDto> list = new();
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var response = await _productService.GetAllProductsAsync<ResponseDto>(accessToken);
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(response.Result));
            }
            return View(list);
        }

        public async Task<IActionResult> ProductCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductCreate(ProductViewModel model)
        {
            //if (ModelState.IsValid)
            //  {
            string yuklenenResimAdi = ResimYukle(model);
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            ProductDto productDto = new ProductDto
            {
                ProductId = model.ProductId,
                Name = model.Name,
                Price = model.Price,
                Description = model.Description,
                ImageUrl = yuklenenResimAdi,
                CategoryName = model.CategoryName,
                Count = model.Count
            };

            var response = await _productService.CreateProductAsync<ResponseDto>(productDto, accessToken);
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction(nameof(ProductIndex));
            }
            //}
            return View(model);
        }

        public async Task<IActionResult> ProductEdit(int productId)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var response = await _productService.GetProductByIdAsync<ResponseDto>(productId, accessToken);
            if (response != null && response.IsSuccess)
            {
                ProductDto model = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));

                ProductViewModel productViewModel = new ProductViewModel
                {
                    ProductId = model.ProductId,
                    Name = model.Name,
                    Price = model.Price,
                    Description = model.Description,
                    ImageUrl = model.ImageUrl,
                    CategoryName = model.CategoryName,
                    Count = model.Count
                };

                return View(productViewModel);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductEdit(ProductViewModel model)
        {


            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var guncellencekUrun = await _productService.GetProductByIdAsync<ResponseDto>(model.ProductId, accessToken);

            if (guncellencekUrun != null && guncellencekUrun.IsSuccess)
            {
                ProductDto model2 = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(guncellencekUrun.Result));

                if (model.ProductPicture != null)
                {
                    //resmini değiştirmek istediğim ürünün database deki kitapResim kolonundaki adına göre
                    // git wwwroot klasörü altındaki Uploads klasöründeki ilgili resmi bul ve sil
                    string filePath = Path.Combine(_environment.WebRootPath, "Uploads", model2.ImageUrl);
                    System.IO.File.Delete(filePath);
                    string yuklenenResimAdi = ResimYukle(model);
                    model2.ImageUrl = yuklenenResimAdi;
                    model2.Name = model.Name;
                    model2.Price = model.Price;
                    model2.CategoryName = model.CategoryName;
                    model2.Count = model.Count;
                    model2.Description = model.Description;
                    var response = await _productService.UpdateProductAsync<ResponseDto>(model2, accessToken);
                    if (response != null && response.IsSuccess)
                    {
                        return RedirectToAction(nameof(ProductIndex));
                    }

                }

            }

            return View(model);
        }



        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ProductDelete(int productId)
        {
            if (productId == null)
            {
                return NotFound();
            }

            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var silinecekUrun = await _productService.GetProductByIdAsync<ResponseDto>(productId, accessToken);

            if (silinecekUrun != null && silinecekUrun.IsSuccess)
            {
                ProductDto silinecekProductDto = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(silinecekUrun.Result));

                string filePath = Path.Combine(_environment.WebRootPath, "Uploads", silinecekProductDto.ImageUrl);
                System.IO.File.Delete(filePath);
            }
            var response = await _productService.DeleteProductAsync<ResponseDto>(productId, accessToken);
            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(ProductIndex));
            }
            return RedirectToAction(nameof(ProductIndex));
        }

        private string ResimYukle(ProductViewModel model)
        {
            string dosyaAdi = "";
            string dosyaninYuklenecegiKlasorYolu = Path.Combine(_environment.WebRootPath, "Uploads");

            if (!Directory.Exists(dosyaninYuklenecegiKlasorYolu))
            {
                Directory.CreateDirectory(dosyaninYuklenecegiKlasorYolu);
            }

            if (model.ProductPicture.FileName != null)
            {
                dosyaAdi = model.ProductPicture.FileName;
                string filePath = Path.Combine(dosyaninYuklenecegiKlasorYolu, dosyaAdi);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    //seçilen resim ilgili klasörü ilgili ismi ile birlikte oluşturulur
                    model.ProductPicture.CopyTo(fileStream);
                }

            }
            return dosyaAdi;
        }


    }
}
