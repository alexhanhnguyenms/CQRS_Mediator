using CQRS_Mediator.Controllers;
using CQRS_Mediator.RequestModels.CommandRequestModels;
using CQRS_Mediator.RequestModels.QueryRequestModels;
using CQRS_Mediator.ResponseModels.CommandResponseModels;
using CQRS_Mediator.ResponseModels.QueryResponseModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading;
using Xunit;

namespace CQRS_Mediator.Test
{
    public class OrderControllerTest
    {
        private Mock<IMediator> Mediator;
        public OrderControllerTest()
        {
            Mediator = new Mock<IMediator>();
        }
        [Fact]
        public void MakeOrder_Success_Result()
        {
            var makeOrderRequestModel = new MakeOrderRequestModel();
            Mediator.Setup(x => x.Send(It.IsAny<MakeOrderRequestModel>(), new CancellationToken())).
                ReturnsAsync(new MakeOrderResponseModel { IsSuccess = true, OrderId = Guid.NewGuid() });
            var orderController = new OrderController(Mediator.Object);

            //Action
            var result = orderController.MakeOrder(makeOrderRequestModel);

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void GetOrderById_Success_Result()
        {
            var getOrderByIdRequestModel = new GetOrderByIdRequestModel();
            Mediator.Setup(x => x.Send(It.IsAny<GetOrderByIdRequestModel>(), new CancellationToken())).
                ReturnsAsync(new GetOrderByIdResponseModel());
            var orderController = new OrderController(Mediator.Object);

            //Action
            var result = orderController.OrderDetails(getOrderByIdRequestModel);

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
