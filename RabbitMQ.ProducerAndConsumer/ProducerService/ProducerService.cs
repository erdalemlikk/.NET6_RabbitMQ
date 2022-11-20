namespace RabbitMQ.ProducerAndConsumer.ProducerService;
public class ProducerService : IProducerService
{
    public void ProduceMessage(string message)
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };
        using (var connection = factory.CreateConnection())
        using (var channel = connection.CreateModel())
        {
            channel.QueueDeclare(queue: "TestQueue",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);
            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: "",
                                 routingKey: "TestQueue",
                                 basicProperties: null,
                                 body: body);

            Console.WriteLine($"{message} Send!");
        }
    }
}
