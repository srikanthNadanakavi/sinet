using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Errors;
using API.Extentions;
using AutoMapper;
using Core.Entities.OrderAggregate;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class OrdersController : BaseAPIController
    {
        private readonly IOrderService _ordeService;
        private readonly IMapper _mapper;
        public OrdersController(IOrderService ordeService, IMapper mapper)
        {
            _mapper = mapper;
            _ordeService = ordeService;
        }

        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(OrderDto orderDto)
        {

           var email = HttpContext.User.RetrieveEmailFromPrincipal();

           var addess = _mapper.Map<AddressDto, Address>(orderDto.shipToAddress);

           var order = await _ordeService.CreateOrderAsync(email,orderDto.DeliveryMethodId,orderDto.BasketId,addess);

           if(order == null) return BadRequest(new ApiResponse(400,"Problem creating order"));

           return Ok(order);
        }

        public async Task<ActionResult<IReadOnlyList<OrderToReturnDto>>> GetOrderForUser(){

            var email = HttpContext.User.RetrieveEmailFromPrincipal();

            var order = await _ordeService.GetOrderForUserAsync(email);

            

            return Ok(_mapper.Map<IReadOnlyList<Order>,IReadOnlyList<OrderToReturnDto>>(order));
        }
          
        [HttpGet("{id}")]
         public async Task<ActionResult<OrderToReturnDto>> GetOrderByIdForUser(int id){

            var email = HttpContext.User.RetrieveEmailFromPrincipal();

            var order = await _ordeService.GetOrderByIdAsync(id, email);

            if (order == null) return NotFound(new ApiResponse(404));

            return Ok(_mapper.Map<Order,OrderToReturnDto>(order));
        }
        
          [HttpGet("deliveryMethods")]
         public async Task<ActionResult<IReadOnlyList<DeliveryMethod>>> GetDeliveryMethods(int id){
            return Ok(await _ordeService.GetDeliveryMethodsAsync());
        }
    }
}