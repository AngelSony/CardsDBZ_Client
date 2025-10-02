using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsDBZ_Client
{
    public class Player
    {
        private string _connectionId;
        private string _playerName;
        private PlayerStates _playerState;
        private int _tableId;
        public Player(){
            _connectionId = "";
            _playerName = "";
            _playerState = PlayerStates.Free;
            _tableId = -1;
        }
        public string ConnectionId { get => _connectionId; set => _connectionId = value; }
        public string PlayerName { get => _playerName; set => _playerName = value; }
        public PlayerStates PlayerState { get => _playerState; set => _playerState = value; }
        public int TableId { get => _tableId; set => _tableId = value; }
        public enum PlayerStates
        {
            InGame,
            InTable,
            Free
        }
    }
}
