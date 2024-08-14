using Core.DTO;
using TradeTrack2.Models;

namespace TradeTrack2.Mapping
{
    public static class ProductToDTO
    {
        public static ProductDTO GetProductDTO(this ProductViewModel viewModel)
        {
            var product = new ProductDTO
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Description = viewModel.Description,
                UnitPrice = viewModel.UnitPrice,
            };

            return product;
        }
    }
}
