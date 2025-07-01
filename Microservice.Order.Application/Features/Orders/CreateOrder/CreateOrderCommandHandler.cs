using System.Net;
using MediatR;
using Microservice.Order.Application.Contracts.Repositories;
using Microservice.Order.Application.Contracts.UnitOfWork;
using Microservice.Order.Domain.Entities;
using Microservice.Shared;
using Microservice.Shared.Services;

namespace Microservice.Order.Application.Features.Orders.CreateOrder;

public class CreateOrderCommandHandler
    (IOrderRepository orderRepository, 
        IGenericRepository<int,Address> addressRepository, IIdentityService identityService, IUnitOfWork unitOfWork) : IRequestHandler<CreateOrderCommand, ServiceResult>
{
    public async Task<ServiceResult> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        if (request.Items.Any())
        {
            return ServiceResult.Error("Order items not found","Order must have at least one item ",HttpStatusCode.BadRequest);
        }
        
        /*
         * eğer burada nosql veri tabanı olsaydı, yani navigation prop ile address class object' e gidemeseydik o zaman
         * transaction başlatıp dbye commit atmak zorunda kalırdık. çünkü id bize gerekli, ama şu an elimizde relational db var.
         * bu yüzden kapalı olarak transaction yapabiliriz ve tek committe hem address hemde order bilgisi gönderebiliriz.
         */
        
        
        var newAddress = new Address()
        {
            Province = request.Address.Province,
            District = request.Address.District,
            Street = request.Address.Street,
            ZipCode = request.Address.ZipCode,
            Line = request.Address.Line
        };

        var order = Order.Domain.Entities.Order.CreateUnPaidOrder(identityService.GetUserId, request.DiscountRate,
            newAddress.Id);
        
        order.Address = newAddress;

        foreach (var orderItem in request.Items)
        {
            order.AddOrderItem(orderItem.ProductId, orderItem.ProductName, orderItem.UnitPrice);
        }
        
        //bu yaklaşım relational db'de hem order'ı hemde address'i ekledi.
        orderRepository.Add(order);
        await unitOfWork.CommitAsync(cancellationToken);

        var paymentId = Guid.Empty;
        //Payment işlemleri yapılacak
        
        order.SetPaidStatus(paymentId);
        
        orderRepository.Update(order);
        await unitOfWork.CommitAsync(cancellationToken);
        
        return ServiceResult.SuccessAsNoContent();
    }
}