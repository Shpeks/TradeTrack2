using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;
using DAL.Data;
using Core.DTO;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ProductDTO> GetAllProduct()
        {
            return _context.Products.Select(p => new ProductDTO
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                UnitPrice = p.UnitPrice,
            }).ToList();
        }

        public ProductDTO GetProductById(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) return null;

            return new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                UnitPrice = product.UnitPrice,
            };
        }

        public ProductDTO CreateProduct(ProductDTO productDto)
        {
            var product = new Product
            {
                Name = productDto.Name,
                Description = productDto.Description,
                UnitPrice = productDto.UnitPrice,
            };

            _context.Products.Add(product);
            _context.SaveChanges();

            return productDto;
        }

        public void UpdateProduct(ProductDTO productDto)
        {
            var product = _context.Products.Find(productDto.Id);
            if (product == null) return;

            product.Name = productDto.Name;
            product.Description = productDto.Description;
            product.UnitPrice = productDto.UnitPrice;

            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}
