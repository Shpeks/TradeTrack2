using Core.DTO;
using TradeTrack2.Models;

namespace TradeTrack2.Extensions
{
    public static class ProductViewModelExtension
    {
        public static ProductViewModel GetProductViewModel(this ProductDTO model)
        {
            var product = new ProductViewModel
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                UnitPrice = model.UnitPrice,
            };

            return product;
        }
    }
}
