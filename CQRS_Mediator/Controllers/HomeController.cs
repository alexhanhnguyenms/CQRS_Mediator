using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CQRS_Mediator.Models;
using MediatR;
using CQRS_Mediator.RequestModels.CommandRequestModels;
using CQRS_Mediator.RequestModels.QueryRequestModels;

namespace CQRS_Mediator.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpPost("makeorder")]
        public IActionResult MakeOrder([FromBody] MakeOrderRequestModel requestModel)
        {
            //var response = _makeOrderCommandHandler.MakeOrder(requestModel);
            var response = _mediator.Send(requestModel);
            return Ok(response);
        }

        [HttpGet("order")]
        public IActionResult OrderDetails([FromQuery] GetOrderByIdRequestModel requestModel)
        {
            //var response = _getOrderByIdQueryHandler.GetOrderById(requestModel);
            var response = _mediator.Send(requestModel);
            return Ok(response);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
