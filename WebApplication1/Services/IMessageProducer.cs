using System;

namespace WebApplication1.Services;

public interface IMessageProducer
{
    public Task SendMessage<T>(T message);
}
