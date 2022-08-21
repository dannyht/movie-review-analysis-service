using movie_review_analysis_service.Models;
using Movies.RabbitMQ;
using RabbitMQ.Client;

namespace movie_review_analysis_service.RabbitMQ
{
    public class RabbitMQClient
    {
        private static ConnectionFactory _factory;
        private static IConnection _connection;
        private static IModel _model;

        private const string ExchangeName = "Topic_Exchange";
        private const string MovieQueueName = "MovieTopic_Queue";

        public RabbitMQClient() => CreateConnection();

        private static void CreateConnection()
        {
            _factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "user",
                Password = "password",
            };

            _connection = _factory.CreateConnection();
            _model = _connection.CreateModel();
            _model.ExchangeDeclare(ExchangeName, "topic");
            _model.QueueDeclare(MovieQueueName, true, false, false, null);

            _model.QueueBind(MovieQueueName, ExchangeName, "moviequeue.movie");

        }

        public void SendMovieDetails(Movie movie)
        {
            SendMessage(movie.Serialize(), "moviequeue.movie");
            // Log action
        }

        public void SendMessage(byte[] message, string routingKey)
        {
            _model.BasicPublish(ExchangeName, routingKey, null, message);
            // Log action
        }
    }
}
