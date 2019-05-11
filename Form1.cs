using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using Dapper.Contrib.Extensions;
 
using Devart.Data.Universal;
using Oracle.ManagedDataAccess.Client;

using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Z.Dapper.Plus;

namespace My.RabbitMQ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var factory = new ConnectionFactory() { HostName = "192.168.1.130" };
            factory.UserName = "yufc";
            factory.Password = "123456";

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "hello", durable: false, exclusive: false, autoDelete: false, arguments: null);

                string message = tbSend.Text.Trim();
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "", routingKey: "hello", basicProperties: null, body: body);
            
            }

      

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var factory = new ConnectionFactory() { HostName = "192.168.1.130" };
            factory.UserName = "yufc";
            factory.Password = "123456";
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "hello", durable: false, exclusive: false, autoDelete: false, arguments: null);

         

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    tbReceive.Text = message;
                };
                channel.BasicConsume(queue: "hello", noAck: true, consumer: consumer);

            }
        }


        /// <summary>
        /// 连接配置
        /// </summary>
        private static ConnectionFactory rabbitMqFactory = new ConnectionFactory()
        {
            HostName = "192.168.1.130",
            UserName = "yufc",
            Password = "123456",
            Port = 5672,
            AutomaticRecoveryEnabled = true
        };
        /// <summary>
        /// 路由名称
        /// </summary>
        const string TopExchangeName = "topic.justin.exchange";

        //队列名称
        const string TopQueueName = "topic.justin.queue";

        private const string routingKey = "topic.justin.key";

        private void Button3_Click(object sender, EventArgs e)
        {

            IConnection conn = rabbitMqFactory.CreateConnection();
           
                IModel channel = conn.CreateModel();
            
//                    model.QueueDeclare(queueName, RabbitMQConfig.IsDurable, false, false, null);
                    var properties = channel.CreateBasicProperties();
                    properties.Persistent = true;
                    properties.DeliveryMode = 2;

                channel.ExchangeDeclare(TopExchangeName, "topic", durable: true, autoDelete: false, arguments: null);
                    channel.QueueDeclare(TopQueueName, durable: true, autoDelete: false, exclusive: false, arguments: null);
                    channel.QueueBind(TopQueueName, TopExchangeName, routingKey: routingKey);
                    //var props = channel.CreateBasicProperties();
                    //props.Persistent = true;
                    string vadata = tbSend.Text.Trim();
                 
                        var msgBody = Encoding.UTF8.GetBytes(vadata);
                        channel.BasicPublish(exchange: TopExchangeName, routingKey: routingKey, basicProperties: properties, body: msgBody);
                
              
        }

        private Task TaskCustomer { get; set; }

        private void Button4_Click(object sender, EventArgs e)
        {
            //            this.TaskCustomer = new Task(new Action(this.receive));
            //            this.TaskCustomer.Start();
            receive();
        }

//        private IConnection conn = rabbitMqFactory.CreateConnection();

        private void receive()
        {
//            rabbitMqFactory.AutomaticRecoveryEnabled = true;   //设置端口后自动恢复连接属性即可

            IConnection conn = rabbitMqFactory.CreateConnection();
            
                IModel channel = conn.CreateModel();
                
                    channel.ExchangeDeclare(TopExchangeName, "topic", durable: true, autoDelete: false, arguments: null);
                    channel.QueueDeclare(TopQueueName, durable: true, autoDelete: false, exclusive: false, arguments: null);
                    channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);
                    channel.QueueBind(TopQueueName, TopExchangeName, routingKey: routingKey);
                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var msgBody = Encoding.UTF8.GetString(ea.Body);

                        this.Invoke((EventHandler)delegate
                        {
//                            InterveneMessage msgReceive =
//                                Biona.JsonManage.Deserialize.DeserializeObject<InterveneMessage>(message);
//                            ShowDialogMessage(msgReceive.Content, msgReceive.SendName, DateTime.Now, 2);
                            this.tbReceive.Text = msgBody;
                        });

                        if (channel != null && !channel.IsClosed)
                        {
                            channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                        }
                    };
                    channel.BasicConsume(TopQueueName, noAck: false, consumer: consumer);
                
          
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            string sqlUserRole = "SELECT * FROM SMART_BD_USERROLE";
//            string sqlOrderDetail = "SELECT * FROM OrderDetails WHERE OrderDetailID = @OrderDetailID;";
//            string sqlCustomerInsert = "INSERT INTO Customers (CustomerName) Values (@CustomerName);";


            using (var connection = new UniConnection("provider=Oracle;User Id=smart;Password=smart;Server=121.40.101.29;Direct=True;Port=1521;Sid=orcl;"))
            {
                var orderDetails = connection.Query<UserRole>(sqlUserRole).ToList();
//                var orderDetail = connection.QueryFirstOrDefault<OrderDetail>(sqlOrderDetail, new { OrderDetailID = 1 });
//                var affectedRows = connection.Execute(sqlCustomerInsert, new { CustomerName = "Mark" });
//
//                Console.WriteLine(orderDetails.Count);
//                Console.WriteLine(affectedRows);
//
//                FiddleHelper.WriteTable(orderDetails);
//                FiddleHelper.WriteTable(new List<OrderDetail>() { orderDetail });

            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO BD_TABLELOG(tablename,createtime) Values (@name, to_date(@time,'yyyy-MM-dd HH:mm:ss'))";

            using (var connection = new UniConnection("provider=Oracle;User Id=smart;Password=smart;Server=121.40.101.29;Direct=True;Port=1521;Sid=orcl;"))
//            using (var connection = new UniConnection("provider=SQL Server;Data Source=121.40.101.29;Initial Catalog=scm_main;Password=sa123;User ID=sa;"))
            {
                var affectedRows = connection.Execute(sql, new { name = "Mark", time= "2019-01-01 12:35:00" });

//                var tableLog = new TableLog();
//                tableLog.tableName = "aaa";
//                tableLog.createTime=DateTime.Now;
//                
//
//                var identity = connection.Insert(sql);

                // Only for see the Insert.
                //                var customer = connection.Query<Customer>("Select * FROM CUSTOMERS WHERE CustomerName = 'Mark'").ToList();
                //
                //                FiddleHelper.WriteTable(customer);
            }

       
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            DapperPlusManager.AddLicense("974;700-IRDEVELOPERS.COM", "FB90FB42600315DC035C24AADC7A6495D213");
            DapperPlusManager.Entity<TableLog>().Table("TableLog");

            string oracleStr = "User Id=smart;Password=smart;Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=121.40.101.29)(PORT=1521)))(CONNECT_DATA=(SERVICE_NAME=orcl)))";
            string oracleDevartStr = "User Id=smart;Password=smart;Server=121.40.101.29;Direct=True;Sid=orcl;";

//            using (var connection = new SqlConnection("Data Source=121.40.101.29;Initial Catalog=scm_main;Integrated Security=False;Password=sa123;Persist Security Info=True;User ID=sa"))
//            using (var connection = new OracleConnection("User Id=smart;Password=smart;Server=121.40.101.29;Direct=True;Sid=orcl;"))
            using (var connection = new OracleConnection(oracleStr))
            {
               
                var tableLog = new TableLog();
                tableLog.tableName = "aaa";
                tableLog.createTime=DateTime.Now;

                connection.BulkInsert(new List<bd_TableLog>() { new bd_TableLog() { tableName = "ExampleBulkInsert", createTime = DateTime.Now } });
            }


//            using (var connection = new SqlConnection(FiddleHelper.GetConnectionStringSqlServerW3Schools()))
//            {
//                var customer = connection.Query<Customer>("Select * FROM CUSTOMERS WHERE CustomerName = 'ExampleBulkInsert'").ToList();
//
//                Console.WriteLine("Row Insert : " + customer.Count());
//
//                FiddleHelper.WriteTable(connection.Query<Customer>("Select TOP 10 * FROM CUSTOMERS WHERE CustomerName = 'ExampleBulkInsert'").ToList());
//            }
        }
    }

    public class UserRole
    {
        public UserRole()
        {

        }

        public int smt_RoleId { get; set; }

        public int SMT_USERID { get; set; }
            
    }

    [Table("BD_TABLELOG")]
    public class TableLog
    {
        public string tableName { get; set; }

        public DateTime createTime{ get; set; }
    }

    [Table("BD_TABLELOG")]
    public class bd_TableLog
    {
        public string tableName { get; set; }

        public DateTime createTime { get; set; }
    }
}
