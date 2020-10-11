using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CQRS_Mediator.RequestModels.CommandRequestModels;
using CQRS_Mediator.ResponseModels.CommandResponseModels;
using MediatR;
namespace CQRS_Mediator.Handlers.CommandHandlers
{
    public class MakeOrderCommandHandler : IRequestHandler<MakeOrderRequestModel, MakeOrderResponseModel>
    {
        public async Task<MakeOrderResponseModel> Handle(MakeOrderRequestModel request, CancellationToken cancellationToken)
        {
            var result = new MakeOrderResponseModel
            {
                IsSuccess = true,
                OrderId = Guid.NewGuid()
            };
            //business logic here
            return result;
        }
    }
}
