
namespace RabbitMQ.ProduceAndConsumeWorker;
public class RabbitMQWorker : BackgroundService
{
    private IProducerService _producerService;
    private IConsumerService _consumerService;
    public RabbitMQWorker(IProducerService _producerService,
                          IConsumerService _consumerService)
    {
        this._producerService = _producerService;
        this._consumerService = _consumerService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _producerService.ProduceMessage("Testing RabbitMQ");
            _consumerService.ConsumeMessage();
            var delay = (int)TimeSpan.FromMinutes(1).TotalMilliseconds; 
            await Task.Delay(delay);
        }
    }
}
