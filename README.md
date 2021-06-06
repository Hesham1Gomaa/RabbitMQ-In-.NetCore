# RabbitMQ-In-.NetCore
This implementation for RabbitMQ in .Net Core with using Docker image for RabbitMQ

// To Create Rabbit MQ Docker Image use this command
docker run -d --hostname my-rabbit --name ecomm-rabbit -p 15672:15672 -p 5672:5672 rabbitmq:3-management

// run this command to use Rabbit mq Managment
docker logs ecomm-rabbit  

// you can find Rabbit mq Dash board in this link afer create image "http://localhost:15672/"
