using CardsDBZ_Server;
using Microsoft.AspNetCore.SignalR.Client;
using System.Collections.Immutable;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using static CardsDBZ_Client.Player;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CardsDBZ_Client
{
    public partial class Main : Form
    {
        private string _url = "http://cardsdbz.somee.com/lobby";
        //private string _url = "https://localhost:7012/lobby";
        private HubConnection _connection;
        private Player _player;
        private Dictionary<int, TableData> _tableList;
        private List<CustomButton> _joinButtons;
        private List<Label> _tableLabels;
        public Main()
        {
            InitializeComponent();
            _player = new Player();
            _tableList = new Dictionary<int, TableData>();
            _joinButtons = new List<CustomButton>();
            _tableLabels = new List<Label>();

            //Create connection to the server with SignalR
            _connection = new HubConnectionBuilder()
                .WithUrl(_url)
                //.WithAutomaticReconnect()
                .Build();

            //Do something when connection is lost
            _connection.Closed += (error) =>
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
                return Task.CompletedTask;
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
            _connection.On<Dictionary<int, TableData>>("TableListUpdate", (newTables) =>
            {
                Invoke(new Action(() =>
                    UpdateTableList(newTables)
                ));
            });
            _connection.On<Player>("JoinTableUpdate", (playerData) =>
            {
                Invoke(new Action(() => {
                    JoinTableUpdate(playerData);
                }));
            });
            _connection.On<Player>("LeaveTableUpdate", (playerData) =>
            {
                Invoke(new Action(() => {
                    LeaveTableUpdate(playerData);
                }));
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
                _player.PlayerName = playerName;
                txtName.ReadOnly = true;
                txtPlayerList.Text = "Conectando...";
                await Connect(_player.PlayerName);
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
                await _connection.InvokeAsync("TableListUpdate");
            }
        }
        private void UpdateTableList(Dictionary<int, TableData> newTables)
        {
            btnUpdate.Enabled = false;
            for(int i = 0; i < _tableList.Count && i < _joinButtons.Count; i++)
                _joinButtons[i].Enabled = false;
            
            int rowCount = 0;
            //For the tables I had loaded, check if they need to be updated or removed
            foreach(TableData table in _tableList.Values)
            {
                if (newTables.ContainsKey(table.TableId))
                {
                    //Update table
                    UpdateJoinButton(rowCount, newTables[table.TableId]);
                    newTables.Remove(table.TableId);
                    rowCount++;
                }
                else
                {
                    //Remove table
                }
                newTables.Remove(table.TableId);
            }
            //The remaining ones will be added
            foreach(TableData table in newTables.Values)
            {
                //Add table
                if (rowCount >= _joinButtons.Count)
                    AddJoinButton(rowCount, table);
                else
                    UpdateJoinButton(rowCount, table);
                rowCount++;


                _tableList.Add(table.TableId, table);
            }

            btnUpdate.Enabled = true;
        }
        private void AddJoinButton(int rowCount, TableData table)
        {
            tlpGameTables.RowCount++;
            tlpGameTables.RowStyles.Insert(rowCount + 1, new RowStyle(SizeType.AutoSize, 80F));

            Label lblTable = new Label();
            lblTable.AutoSize = true;
            lblTable.Dock = DockStyle.Fill;
            lblTable.Name = $"lblTable{rowCount}";
            lblTable.Text = $"Mesa {table.TableId}\r\nJugadores ({table.PlayerCount}/2)";
            lblTable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            tlpGameTables.Controls.Add(lblTable, 0, rowCount + 1);
            _tableLabels.Add(lblTable);

            CustomButton btnJoin = new CustomButton(table.TableId, $"btnJoin{rowCount}");
            btnJoin.Click += btnJoin_Click;
            if(_player.PlayerState != PlayerStates.Free)
            {
                if (_player.TableId == table.TableId)
                {
                    btnJoin.Text = "Salir";
                    btnJoin.Enabled = true;
                } 
            }
            else
            {
                if (table.PlayerCount != 2)
                {
                    btnJoin.Enabled = true;
                }
                else
                    btnJoin.Text = "Mesa Llena";
            }
            tlpGameTables.Controls.Add(btnJoin, 1, rowCount + 1);
            tlpGameTables.SetColumnSpan(btnJoin, 2);
            _joinButtons.Add(btnJoin);
        }
        private void UpdateJoinButton(int rowCount, TableData table)
        {
            Label lblTable = _tableLabels[rowCount];
            lblTable.Text = $"Mesa {table.TableId}\r\nJugadores ({table.PlayerCount}/2)";
            tlpGameTables.Controls.Add(lblTable, 0, rowCount + 1);

            CustomButton btnJoin = _joinButtons[rowCount];
            if (_player.PlayerState != PlayerStates.Free)
            {
                if (_player.TableId == table.TableId)
                {
                    btnJoin.Text = "Salir";
                    btnJoin.Enabled = true;
                }
            }
            else
            {
                if (table.PlayerCount != 2)
                {
                    btnJoin.Text = "Unirse";
                    btnJoin.Enabled = true;
                }
                else
                    btnJoin.Text = "Mesa Llena";
            }
            tlpGameTables.Controls.Add(btnJoin, 1, rowCount + 1);
            tlpGameTables.SetColumnSpan(btnJoin, 2);
        }
        private async void btnJoin_Click(object sender, EventArgs e)
        {
            CustomButton btn = sender as CustomButton;
            btn.Enabled = false;
            int tableId = btn.TableId;

            if (btn.Text.Equals("Unirse"))
            {
                if (_connection.State == HubConnectionState.Connected)
                    await _connection.InvokeAsync("JoinTable", tableId);
            }
            else if(btn.Text.Equals("Salir"))
            {
                if (_connection.State == HubConnectionState.Connected)
                    await _connection.InvokeAsync("LeaveTable", tableId);
            }
            
        }
        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_connection.State == HubConnectionState.Connected)
            {
                await _connection.InvokeAsync("TableListUpdate");
            }
        }
        private void JoinTableUpdate(Player playerData)
        {
            if (playerData.PlayerName.Equals(""))
            {
                _player.TableId = playerData.TableId;
                MessageBox.Show("La mesa se encuentra llena.");
            }
            else
            {
                _player = playerData;
            }
        }
        private void LeaveTableUpdate(Player playerData)
        {
            if (playerData.PlayerName.Equals(""))
            {
                MessageBox.Show("Error, no se pudo dejar la mesa.");
            }
            else
            {
                _player = playerData;
            }
        }
    }
}
