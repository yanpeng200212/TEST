using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace rabbimq基本消费模型消费者
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConnectionFactory connectionFactory = new ConnectionFactory()
            {
                UserName = "guest",
                Password = "guest",
                HostName = "localhost",

            };
            using var connection = connectionFactory.CreateConnection();
            using var channel = connection.CreateModel();
            EventingBasicConsumer consumer = new EventingBasicConsumer(channel);
            consumer.Received += (ch, ea) =>
            {
                var message = Encoding.UTF8.GetString(ea.Body.ToArray());
                Console.WriteLine("收到消息1：" + message);
                channel.BasicAck(ea.DeliveryTag,false);
            };
            channel.BasicConsume("hello1", false,consumer);
            Console.WriteLine("消费者张坤宁1111(YP)已经启动");

            Console.ReadKey();

        }
    }
}


