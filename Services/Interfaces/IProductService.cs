using FanKart.FanKartDbModels;
using System.Security.Cryptography;

namespace FanKart.Services.Interfaces
{
    public interface IProductService
    {
        public List<Category> GetCategories();
        public List<Size> GetSizes();
        public List<Brand> GetBrands();
        //List<Inventory> GetInventoryItems(List<string>? productNames = null, List<int>? brandIds = null, List<int>? categoryIds = null, List<int>? sizeIds = null);

        public List<Inventory> GetInventoryItems(string searchText = null, int? brandId = null, int? categoryId = null, int? sizeId = null);
    }
}
