using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS_Mediator.ResponseModels.QueryResponseModels;
using MediatR;

namespace CQRS_Mediator.RequestModels.QueryRequestModels
{
    public class GetOrderByIdRequestModel:IRequest<GetOrderByIdResponseModel>
    {
        public Guid OrderId { get; set; }
    }
}
