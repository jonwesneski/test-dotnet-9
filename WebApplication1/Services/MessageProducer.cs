using System;
using System.Text;
using System.Text.Json;
using RabbitMQ.Client;

namespace WebApplication1.Services;

public class MessageProducer : IMessageProducer
{
    public async Task SendMessage<T>(T message)
    {
        var factory = new ConnectionFactory()
        {
            HostName = "localhost",
            UserName = "guest",
            Password = "guest",
            VirtualHost = "/"
        };
        var connection = await factory.CreateConnectionAsync();
        using var channel = await connection.CreateChannelAsync();
        await channel.QueueDeclareAsync("GETRECIPE", durable: true, exclusive: false);
        var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));
        await channel.BasicPublishAsync("", "GETRECIPE", body: body);
    }
}
