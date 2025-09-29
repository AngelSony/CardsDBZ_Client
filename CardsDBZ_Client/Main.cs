using Microsoft.AspNetCore.SignalR.Client;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace CardsDBZ_Client
{
    public partial class Main : Form
    {
        private string _url = "http://cardsdbz.somee.com/lobby";
        //private string _url = "https://localhost:7012/lobby";
        private HubConnection _connection;
        private string _playerName;
        public Main()
        {
            InitializeComponent();
            txtName.AutoSize = false;


            //Create connection to the server with SignalR
            _connection = new HubConnectionBuilder()
                .WithUrl(_url)
                .WithAutomaticReconnect()
                .Build();

            //Do something when connection is lost
            _connection.Closed += async (error) =>
            {
                timePlayerListUpdate.Stop();
                MessageBox.Show("Se perdió la conexión");
                Invoke(new Action(() =>
                {
                    txtName.ReadOnly = false;
                    btnJoin.Enabled = true;
                }
                ));
            };
        }
        private void BuildConnection()
        {
            _connection.On<string>("PlayerListUpdate", (playerList) =>
            {
                Invoke(new Action(() =>
                    txtPlayerList.Text = "Jugadores:" + Environment.NewLine + playerList
                ));
            });
            timePlayerListUpdate.Start();
        }
        private async Task Connect(string playerName)
        {
            try
            {
                await _connection.StartAsync();
                await _connection.InvokeAsync("JoinServer", playerName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectarse al servidor", "Connection error");
                txtName.ReadOnly = false;
                btnJoin.Enabled = true;
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            BuildConnection();
        }

        private async void btnJoin_Click(object sender, EventArgs e)
        {
            btnJoin.Enabled = false;
            string playerName = txtName.Text.Trim();
            if (!playerName.Equals(""))
            {
                _playerName = playerName;
                txtName.ReadOnly = true;
                txtPlayerList.Text = "Conectando...";
                await Connect(_playerName);
            }
            else
            {
                MessageBox.Show("Debes tener un Nombre válido para conectarte");
                txtName.Focus();
                btnJoin.Enabled = true;
            }
        }
        private async void timePlayerListUpdate_Tick(object sender, EventArgs e)
        {
            if(_connection.State == HubConnectionState.Connected)
            {
                await _connection.InvokeAsync("PlayerListUpdate");
            }
        }
    }
}
