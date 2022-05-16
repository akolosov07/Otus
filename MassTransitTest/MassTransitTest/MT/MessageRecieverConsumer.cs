using MassTransit;
using MassTransitTest.Models;

namespace MassTransitTest.MT
{
    public class MessageRecieverConsumer : IConsumer<OtusMessage>
    {
        public async Task Consume(ConsumeContext<OtusMessage> context)
        {
            var test = context.Message;
        }
    }
}
