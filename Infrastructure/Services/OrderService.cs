using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.OrderAggregate;
using Core.Interfaces;
using Core.Specifications;

namespace Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBasketRepository _basketRepo;
        public OrderService(IUnitOfWork unitOfWork, IBasketRepository basketRepo)
        {
            _unitOfWork = unitOfWork;
            _basketRepo = basketRepo;


        }
        public async Task<Order> CreateOrderAsync(string buyerEmail, int deliverMethodId, string basketId, Address shippingAddress)
        {
            // get basket from the repo

            var basket = await _basketRepo.GetBasketAsync(basketId);

            // get items from the product repo 

            var items = new List<OrderItem>();

            foreach (var item in basket.Items)
            {
                var productItem = await _unitOfWork.Repository<Product>().GetByIdAsync(item.Id);
                var productItemOrdered = new ProductItemOrdered(productItem.Id, productItem.Name, productItem.PictureUrl);
                var orderItem = new OrderItem(productItemOrdered, productItem.Price, item.Quantity);
                items.Add(orderItem);
            }

            // get delivery method from repo

            var deliverMethod = await _unitOfWork.Repository<DeliveryMethod>().GetByIdAsync(deliverMethodId);
            // cal subtotal

            var subTotal = items.Sum(items => items.Price * items.Quantity);

            // create order 

            var order = new Order(items, buyerEmail, shippingAddress, deliverMethod, subTotal);
            _unitOfWork.Repository<Order>().Add(order);

            // save to db
            var  result = await _unitOfWork.Complete();
            if(result <= 0) return null;

            // delete basket
            await _basketRepo.DeleteBasketAsync(basketId);

            // return order 
            return order;
        }

        public async Task<IReadOnlyList<Order>> GetOrderForUserAsync(string buyerEmail)
        {
            var spec = new OrderWithItemsAndOrderingSpecification(buyerEmail);
            return await _unitOfWork.Repository<Order>().ListAsync(spec);
        }
        public async Task<Order> GetOrderByIdAsync(int id, string buyerEmail)
        {
            var spec = new OrderWithItemsAndOrderingSpecification(id,buyerEmail);
            return await _unitOfWork.Repository<Order>().GetEntityWithSpec(spec);
        }

        public async Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync()
        {
            return await _unitOfWork.Repository<DeliveryMethod>().ListAllAsync();
        }
    }
}