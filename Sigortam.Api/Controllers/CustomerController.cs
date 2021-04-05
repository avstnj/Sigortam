using Microsoft.AspNetCore.Mvc;
using Sigortam.DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sigortam.Api.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private IUnitOfWork unitOfWork;
        public CustomerController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
