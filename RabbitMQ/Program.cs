var builder = Host.CreateDefaultBuilder(args);
builder.ConfigureServices(services =>
                                services.AddHostedService<RabbitMQWorker>()
                                .AddScoped<IProducerService, ProducerService>()
                                .AddScoped<IConsumerService, ConsumerService>());

using var host = builder.Build();
host.Run();