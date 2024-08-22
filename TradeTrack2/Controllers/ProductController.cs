using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TradeTrack2.Extensions;
using TradeTrack2.Mapping;
using TradeTrack2.Models;

namespace TradeTrack2.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;
        
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var productDto = _productService.GetAllProduct();
            var productViewModel = productDto
                .Select(dto => dto.GetProductViewModel())
                .ToList();

            return View(productViewModel);
        }

        [HttpGet]
        public IActionResult LoadCreateModal()
        {
            var model = new ProductViewModel();
            return PartialView("_CreateModal", model);
        }

        [HttpPost]
        public IActionResult Create(ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid) return View(productViewModel);

            var productDto = productViewModel.GetProductDTO();
            _productService.CreateProduct(productDto);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            var productDto = _productService.GetProductById(id.Value);
            var productViewModel = productDto.GetProductViewModel();

            if (productDto == null) return NotFound();

            return View(productViewModel);  
        }

        [HttpPost]
        public IActionResult Edit(int id, ProductViewModel viewModel)
        {
            if (id != viewModel.Id) return NotFound();

            if (ModelState.IsValid)
            {
                var productDto = viewModel.GetProductDTO();
                _productService.UpdateProduct(productDto);

                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _productService.DeleteProductAsync(id);
                return Json(new { success = true });
            }
            catch (DbUpdateException)
            {
                return Json(new { success = false, errorMessage = "Ошибка. Действие не возможно." });
            }
        }
    }
}
