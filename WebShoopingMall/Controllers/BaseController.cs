using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebShoopingMall.Controllers
{
    [EnableCors("any")]
    [Route("[controller]/[Action]")]
    public class BaseController : ControllerBase
    {
    }
}