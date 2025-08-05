// See https://aka.ms/new-console-template for more information
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

Console.WriteLine("Hello, World!");

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
var consumer = new AsyncEventingBasicConsumer(channel);
consumer.ReceivedAsync += async (model, eventArgs) =>
{
    var body = eventArgs.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    Console.WriteLine($"recipe retrieved - {message}");
    await Task.Delay(1);
    return;
};
await channel.BasicConsumeAsync("GETRECIPE", true, consumer);
Console.ReadKey();
