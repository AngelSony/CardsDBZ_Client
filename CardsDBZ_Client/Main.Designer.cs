namespace CardsDBZ_Client
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            btnConnect = new Button();
            label2 = new Label();
            txtName = new TextBox();
            tlpGameTables = new TableLayoutPanel();
            lblGameTables = new Label();
            btnUpdate = new Button();
            txtPlayerList = new TextBox();
            timePlayerListUpdate = new System.Windows.Forms.Timer(components);
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tlpGameTables.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 400F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 1);
            tableLayoutPanel1.Controls.Add(tlpGameTables, 3, 1);
            tableLayoutPanel1.Controls.Add(txtPlayerList, 2, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(1024, 986);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel2.AutoScroll = true;
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(btnConnect, 0, 1);
            tableLayoutPanel2.Controls.Add(label2, 0, 0);
            tableLayoutPanel2.Controls.Add(txtName, 1, 0);
            tableLayoutPanel2.Location = new Point(13, 13);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(394, 960);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // btnConnect
            // 
            btnConnect.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnConnect.AutoSize = true;
            tableLayoutPanel2.SetColumnSpan(btnConnect, 2);
            btnConnect.Location = new Point(3, 48);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(388, 54);
            btnConnect.TabIndex = 1;
            btnConnect.Text = "Conectarse";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(107, 45);
            label2.TabIndex = 1;
            label2.Text = "Nombre:";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtName
            // 
            txtName.Dock = DockStyle.Fill;
            txtName.Location = new Point(116, 3);
            txtName.Name = "txtName";
            txtName.Size = new Size(275, 39);
            txtName.TabIndex = 0;
            // 
            // tlpGameTables
            // 
            tlpGameTables.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tlpGameTables.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tlpGameTables.ColumnCount = 3;
            tlpGameTables.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tlpGameTables.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpGameTables.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
            tlpGameTables.Controls.Add(lblGameTables, 0, 0);
            tlpGameTables.Controls.Add(btnUpdate, 2, 0);
            tlpGameTables.Location = new Point(613, 13);
            tlpGameTables.Name = "tlpGameTables";
            tlpGameTables.RowCount = 2;
            tlpGameTables.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tlpGameTables.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpGameTables.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlpGameTables.Size = new Size(398, 960);
            tlpGameTables.TabIndex = 3;
            // 
            // lblGameTables
            // 
            lblGameTables.AutoSize = true;
            tlpGameTables.SetColumnSpan(lblGameTables, 2);
            lblGameTables.Dock = DockStyle.Fill;
            lblGameTables.Location = new Point(4, 1);
            lblGameTables.Name = "lblGameTables";
            lblGameTables.Size = new Size(329, 60);
            lblGameTables.TabIndex = 1;
            lblGameTables.Text = "Mesas de Juego";
            lblGameTables.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnUpdate
            // 
            btnUpdate.BackgroundImage = Properties.Resources.updateIcon;
            btnUpdate.BackgroundImageLayout = ImageLayout.Zoom;
            btnUpdate.Dock = DockStyle.Fill;
            btnUpdate.Enabled = false;
            btnUpdate.Location = new Point(340, 4);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(54, 54);
            btnUpdate.TabIndex = 0;
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // txtPlayerList
            // 
            txtPlayerList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtPlayerList.Location = new Point(413, 13);
            txtPlayerList.Multiline = true;
            txtPlayerList.Name = "txtPlayerList";
            txtPlayerList.ReadOnly = true;
            txtPlayerList.Size = new Size(194, 960);
            txtPlayerList.TabIndex = 2;
            txtPlayerList.TabStop = false;
            txtPlayerList.Text = "Conéctate con tu nombre para comenzar";
            // 
            // timePlayerListUpdate
            // 
            timePlayerListUpdate.Interval = 5000;
            timePlayerListUpdate.Tick += timePlayerListUpdate_Tick;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1024, 986);
            Controls.Add(tableLayoutPanel1);
            Name = "Main";
            Text = "Menú Principal";
            Load += Main_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tlpGameTables.ResumeLayout(false);
            tlpGameTables.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Button btnConnect;
        private TextBox txtPlayerList;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label2;
        private TextBox txtName;
        private System.Windows.Forms.Timer timePlayerListUpdate;
        private TableLayoutPanel tlpGameTables;
        private Label lblGameTables;
        private Button btnUpdate;
    }
}
