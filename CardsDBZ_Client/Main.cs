using CardsDBZ_Server;
using Microsoft.AspNetCore.SignalR.Client;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CardsDBZ_Client
{
    public partial class Main : Form
    {
        //private string _url = "http://cardsdbz.somee.com/lobby";
        private string _url = "https://localhost:7012/lobby";
        private HubConnection _connection;
        private string _playerName;
        private List<TableData> _tableList;
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
                    txtPlayerList.Text = "Se perdió la cconexión";
                    btnConnect.Enabled = true;
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
            _connection.On<List<TableData>>("TableListUpdate", (tableList) =>
            {
                Invoke(new Action(() =>
                    UpdateTableList(tableList)
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
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al conectarse al servidor", "Connection error");
                txtName.ReadOnly = false;
                btnConnect.Enabled = true;
                txtPlayerList.Text = "Error al conectar";
            }
        }
        private void Main_Load(object sender, EventArgs e)
        {
            BuildConnection();
        }
        private async void btnConnect_Click(object sender, EventArgs e)
        {
            btnConnect.Enabled = false;
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
                btnConnect.Enabled = true;
            }
        }
        private async void timePlayerListUpdate_Tick(object sender, EventArgs e)
        {
            if (_connection.State == HubConnectionState.Connected)
            {
                await _connection.InvokeAsync("PlayerListUpdate");
            }
        }
        private void UpdateTableList(List<TableData> tableList)
        {
            //Reset talpGameTables to title only
            tlpGameTables.Controls.Clear();
            tlpGameTables.RowStyles.Clear();
            tlpGameTables.RowCount = 1;
            tlpGameTables.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tlpGameTables.Controls.Add(lblGameTables, 0, 0);
            tlpGameTables.Controls.Add(btnUpdate, 2, 0);

            //Adding rows for each GameTable
            foreach (TableData table in tableList)
            {
                tlpGameTables.RowStyles.Add(new RowStyle(SizeType.AutoSize, 80F));
                tlpGameTables.RowCount++;

                Label lblTable = new Label();
                    lblTable.AutoSize = true;
                    lblTable.Dock = DockStyle.Fill;
                    lblTable.Name = "lblTable" + table.TableId;
                    lblTable.Text = $"Mesa {table.TableId}\r\nJugadores ({table.PlayerCount}/2)";
                    lblTable.TextAlign = ContentAlignment.MiddleCenter;
                tlpGameTables.Controls.Add(lblTable, 0, tlpGameTables.RowCount - 1);

                Button btnJoin = new Button();
                    btnJoin.Dock = DockStyle.Fill;
                    btnJoin.Name = "btnJoin" + table.TableId;
                    btnJoin.TabIndex = table.TableId + 1;
                    btnJoin.Text = "Unirse";
                    //btnJoin.UseVisualStyleBackColor = true;
                    btnJoin.Click += btnJoin_Click;
                tlpGameTables.Controls.Add(btnJoin, 1, tlpGameTables.RowCount - 1);
                tlpGameTables.SetColumnSpan(btnJoin, 2);
                    
                
            }
            
            tlpGameTables.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpGameTables.RowCount++;
        }
        private void btnJoin_Click(object sender, EventArgs e)
        {

        }
        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_connection.State == HubConnectionState.Connected)
            {
                await _connection.InvokeAsync("TableListUpdate");
            }
        }
    }
}
