using RabbitMQ.Client;
using System.Text;

namespace rabbitmq基本消费模型生产者
{
    internal class Program
    {
        static void Main(string[] args)
        {
             ConnectionFactory connectionFactory = new ConnectionFactory() { 
             UserName="guest",
             Password="guest",
             HostName="localhost",

             };
            using var connection = connectionFactory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare("hello1", false, false, false, null);
            Console.WriteLine("rabbitmq连接成功，输入exit退出");
            string ?input;
            do
            {
                input = Console.ReadLine();
                var message=Encoding.UTF8.GetBytes(input);
                channel.BasicPublish("","hello张坤林",null,message);

            } while (input.Trim().ToLower()!="exit");

        }
    }
}
