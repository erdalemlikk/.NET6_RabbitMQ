Need to run rabbitMQ with the following code line on docker : 
```
docker run -it --rm --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3.11-management
```
Sending message to queue with parameter. RabbitMQ should be on localhost and default port.
