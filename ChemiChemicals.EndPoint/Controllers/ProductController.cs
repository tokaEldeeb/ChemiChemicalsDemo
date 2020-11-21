using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChemiChemicals.EndPoint.Core;
using ChemiChemicals.EndPoint.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ChemiChemicals.EndPoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var products = await new DALHandler().GetAllProducts();
                return Ok(products);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> GetRecentlyChangedProducts()
        {
            try
            {
                var products = await new DALHandler().GetRecentlyChangedProducts();
                return Ok(products);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetProductById()
        {
            try
            {
                Guid id = Guid.Parse(RouteData.Values["id"].ToString());
                var products = await new DALHandler().GetProductById(id);
                return Ok(products);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public async Task<IActionResult> DeleteProductByid()
        {
            try
            {
                Guid id = Guid.Parse(RouteData.Values["id"].ToString());
                var products = await new DALHandler().DeleteProductById(id);
                return Ok(products);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> InsertNewProduct(Product product)
        {
            try
            {
                product.BinaryContent = FileConverter.ConvertLinkToBinaryData(product.Url);
                if (ModelState.IsValid)
                {
                    var products = await new DALHandler().InsertProduct(product);
                    return Ok(products);
                }
                else
                {
                    return BadRequest(ModelState.Values);
                }

            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            try
            {
                product.BinaryContent = FileConverter.ConvertLinkToBinaryData(product.Url);
                if (ModelState.IsValid)
                {
                    var products = await new DALHandler().UpdateProduct(product);
                    return Ok(products);
                }
                else
                {
                    return BadRequest(ModelState.Values);
                }

            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
