using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [Area("ProductManage")]
    public class ProductController : Controller

    {
        private readonly ProductService _productService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(ProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            //neu co atribute area thi no se k tim thu muc view nua no se tim theo cau truc /Areas/AreaName/View/Controller/Action.cshtml
            
            var products = _productService.OrderBy(p => p.Name).ToList();
            return View(products);
        }
        
    }
}