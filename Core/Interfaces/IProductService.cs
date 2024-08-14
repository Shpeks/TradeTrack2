using Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IProductService
    {
        IEnumerable<ProductDTO> GetAllProduct();
        
        ProductDTO GetProductById(int id);

        ProductDTO CreateProduct(ProductDTO productDTO);
        
        void UpdateProduct(ProductDTO productDTO);

        Task DeleteProductAsync(int id);
    }
}
