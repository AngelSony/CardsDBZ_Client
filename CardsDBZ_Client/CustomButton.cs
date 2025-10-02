using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsDBZ_Client
{
    public class CustomButton : Button
    {
        private int _tableId;
        public CustomButton(int tableId, string name)
        {
            _tableId = tableId;
            Name = name;
            Dock = DockStyle.Fill;
            UseVisualStyleBackColor = true;
            Text = "Unirse";
            Enabled = false;
        }
        public int TableId { get => _tableId; set => _tableId = value; }
    }
}
