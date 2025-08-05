using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace WebApplication2.Services;

public class RecipeConsumerService : BackgroundService
{
    private readonly static string _queueName = "GETRECIPE";
    private readonly ILogger<RecipeConsumerService> _logger;

    public RecipeConsumerService(ILogger<RecipeConsumerService> logger)
    {
        _logger = logger;
        _logger.Log(LogLevel.Error, "loaded");
    }

    protected async override Task<Task> ExecuteAsync(CancellationToken stoppingToken)
    {
        stoppingToken.ThrowIfCancellationRequested();

        _logger.Log(LogLevel.Error, "Start consuming");
        var factory = new ConnectionFactory()
        {
            HostName = "localhost",
            UserName = "guest",
            Password = "guest",
            VirtualHost = "/"
        };
        var connection = await factory.CreateConnectionAsync();
        using var channel = await connection.CreateChannelAsync();
        await channel.QueueDeclareAsync(_queueName, durable: true, exclusive: false, cancellationToken: stoppingToken);
        var consumer = new AsyncEventingBasicConsumer(channel);
        consumer.ReceivedAsync += async (model, eventArgs) =>
        {
            var body = eventArgs.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            //Console.WriteLine($"recipe retrieved - {message}");
            _logger.Log(LogLevel.Information, $"recipe retrieved - {message}");
            await Task.Delay(0);
        };
        await channel.BasicConsumeAsync("GETRECIPE", true, consumer, cancellationToken: stoppingToken);

        return Task.CompletedTask;
    }
}
