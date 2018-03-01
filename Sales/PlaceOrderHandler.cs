using System;
using System.Threading.Tasks;
using Messages;
using NServiceBus;
using NServiceBus.Logging;

namespace Sales
{
    public class PlaceOrderHandler : IHandleMessages<PlaceOrder>
    {
        private static ILog _log = LogManager.GetLogger<PlaceOrderHandler>();
        private static Random _random = new Random();

        public Task Handle(PlaceOrder message, IMessageHandlerContext context)
        {
            _log.Info($"Received PlaceOrder, OrderId = {message.OrderId}");

            if (_random.Next(0, 5) == 0)
            {
                throw new Exception("BOOM");
            }

            var orderPlaced = new OrderPlaced
            {
                OrderId = message.OrderId
            };

            return context.Publish(orderPlaced);
        }
    }
}