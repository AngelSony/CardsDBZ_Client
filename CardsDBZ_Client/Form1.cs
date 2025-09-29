using Microsoft.AspNetCore.SignalR.Client;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CardsDBZ_Client
{
    public partial class Form1 : Form
    {
        //private string _url = "http://cardsdbz.somee.com/positionhub";
        private string _url = "https://localhost:7293/positionhub";
        HubConnection connection;
        public Form1()
        {
            InitializeComponent();

            connection = new HubConnectionBuilder().WithUrl(_url).Build();

            connection.Closed += async (error) =>
            {
                Console.WriteLine("Conection attempt");
                await connection.StartAsync();
            };
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                await connection.StartAsync();
            }
            catch
            {
                MessageBox.Show("No se pudo conectar a SignalR");
            }

            connection.On<int, int>("ReceivePosition", (left, top) =>
            {
                Invoke(new Action(() =>
                    label1.Location = new Point(left, top)
                ));

            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                connection.InvokeAsync("SendPosition", 10, 10);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                Application.Exit();
            }
            
        }
    }
}
