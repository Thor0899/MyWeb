using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebShoopingMall.Models;

namespace WebShoopingMall.Controllers
{
    public class ProductsController : BaseController
    {
        [HttpGet]
        public IActionResult GetProducts() {
          var productList =  Products.ListAll();
            return new JsonResult(productList);
        }
    }
}