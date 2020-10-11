using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CQRS_Mediator.RequestModels.QueryRequestModels;
using CQRS_Mediator.ResponseModels.QueryResponseModels;
using MediatR;
namespace CQRS_Mediator.Handlers.QueryHandlers
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdRequestModel, GetOrderByIdResponseModel>
    {
        public async Task<GetOrderByIdResponseModel> Handle(GetOrderByIdRequestModel request, CancellationToken cancellationToken)
        {
            var orderDetails = new GetOrderByIdResponseModel();
            // Your logic here
            return orderDetails;
        }
    }
}
