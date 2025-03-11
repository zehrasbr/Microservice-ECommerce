﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Commands.OrderingCommands
{
    public class RemoveOrderingRequest : IRequest
    {
        public int Id { get; set; }

        public RemoveOrderingRequest(int id)
        {
            Id = id;
        }
    }
}
