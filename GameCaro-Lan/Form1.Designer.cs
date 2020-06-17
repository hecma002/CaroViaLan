namespace GameCaro_Lan
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Btn_PlayerVsCom = new System.Windows.Forms.Button();
            this.PctMark = new System.Windows.Forms.PictureBox();
            this.btn_Lan = new System.Windows.Forms.Button();
            this.Txb_IP = new System.Windows.Forms.TextBox();
            this.PcBCoolDown = new System.Windows.Forms.ProgressBar();
            this.TxbPlayer = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.Timer_CoolDown = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playerVsPlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playerVsComToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Undo = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sốLầnThắngCuộcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lastChessBoardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Btn_sendmess = new System.Windows.Forms.Button();
            this.Chat = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.RichTxb_Send = new System.Windows.Forms.RichTextBox();
            this.RichTxb_receive = new System.Windows.Forms.RichTextBox();
            this.pnlChessboard = new System.Windows.Forms.Panel();
            this.Txb_NoteMark = new System.Windows.Forms.TextBox();
            this.Txb_LastChess = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PctMark)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pnlChessboard.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.ID);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.Btn_PlayerVsCom);
            this.panel2.Controls.Add(this.PctMark);
            this.panel2.Controls.Add(this.btn_Lan);
            this.panel2.Controls.Add(this.Txb_IP);
            this.panel2.Controls.Add(this.PcBCoolDown);
            this.panel2.Controls.Add(this.TxbPlayer);
            this.panel2.Location = new System.Drawing.Point(562, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(327, 157);
            this.panel2.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(-6, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Name :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(-4, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Timer :";
            this.label2.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // ID
            // 
            this.ID.AutoSize = true;
            this.ID.BackColor = System.Drawing.SystemColors.Control;
            this.ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID.Location = new System.Drawing.Point(-4, 99);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(66, 20);
            this.ID.TabIndex = 4;
            this.ID.Text = "Room :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poor Richard", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-7, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(332, 41);
            this.label1.TabIndex = 7;
            this.label1.Text = "Rule : 5 in a line to win";
            // 
            // Btn_PlayerVsCom
            // 
            this.Btn_PlayerVsCom.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Btn_PlayerVsCom.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Btn_PlayerVsCom.Location = new System.Drawing.Point(86, 126);
            this.Btn_PlayerVsCom.Name = "Btn_PlayerVsCom";
            this.Btn_PlayerVsCom.Size = new System.Drawing.Size(83, 28);
            this.Btn_PlayerVsCom.TabIndex = 6;
            this.Btn_PlayerVsCom.Text = "PVC";
            this.Btn_PlayerVsCom.UseVisualStyleBackColor = false;
            this.Btn_PlayerVsCom.Click += new System.EventHandler(this.Btn_PlayerVsCom_Click);
            // 
            // PctMark
            // 
            this.PctMark.BackColor = System.Drawing.SystemColors.ControlLight;
            this.PctMark.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PctMark.Location = new System.Drawing.Point(175, 44);
            this.PctMark.Name = "PctMark";
            this.PctMark.Size = new System.Drawing.Size(152, 110);
            this.PctMark.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PctMark.TabIndex = 5;
            this.PctMark.TabStop = false;
            // 
            // btn_Lan
            // 
            this.btn_Lan.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_Lan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Lan.Location = new System.Drawing.Point(0, 126);
            this.btn_Lan.Name = "btn_Lan";
            this.btn_Lan.Size = new System.Drawing.Size(88, 28);
            this.btn_Lan.TabIndex = 4;
            this.btn_Lan.Text = "PVP";
            this.btn_Lan.UseVisualStyleBackColor = false;
            this.btn_Lan.Click += new System.EventHandler(this.btn_Lan_Click);
            // 
            // Txb_IP
            // 
            this.Txb_IP.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txb_IP.Location = new System.Drawing.Point(62, 97);
            this.Txb_IP.Name = "Txb_IP";
            this.Txb_IP.Size = new System.Drawing.Size(107, 26);
            this.Txb_IP.TabIndex = 3;
            this.Txb_IP.Text = "1";
            this.Txb_IP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PcBCoolDown
            // 
            this.PcBCoolDown.Location = new System.Drawing.Point(62, 71);
            this.PcBCoolDown.Name = "PcBCoolDown";
            this.PcBCoolDown.Size = new System.Drawing.Size(107, 23);
            this.PcBCoolDown.TabIndex = 2;
            this.PcBCoolDown.Click += new System.EventHandler(this.PcBCoolDown_Click);
            // 
            // TxbPlayer
            // 
            this.TxbPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxbPlayer.Location = new System.Drawing.Point(62, 44);
            this.TxbPlayer.Name = "TxbPlayer";
            this.TxbPlayer.ReadOnly = true;
            this.TxbPlayer.ShortcutsEnabled = false;
            this.TxbPlayer.Size = new System.Drawing.Size(107, 24);
            this.TxbPlayer.TabIndex = 1;
            this.TxbPlayer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackgroundImage = global::GameCaro_Lan.Properties.Resources.unnamed1;
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.Location = new System.Drawing.Point(562, 295);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(327, 266);
            this.panel4.TabIndex = 0;
            // 
            // Timer_CoolDown
            // 
            this.Timer_CoolDown.Tick += new System.EventHandler(this.Timer_CoolDown_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu,
            this.sốLầnThắngCuộcToolStripMenuItem,
            this.lastChessBoardToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(901, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Menu
            // 
            this.Menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.Undo,
            this.quitToolStripMenuItem});
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(50, 20);
            this.Menu.Text = "Menu";
            this.Menu.Click += new System.EventHandler(this.Menu_Click);
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playerVsPlayerToolStripMenuItem,
            this.playerVsComToolStripMenuItem});
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newGameToolStripMenuItem.Text = "New Game";
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
            // 
            // playerVsPlayerToolStripMenuItem
            // 
            this.playerVsPlayerToolStripMenuItem.Name = "playerVsPlayerToolStripMenuItem";
            this.playerVsPlayerToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.playerVsPlayerToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.playerVsPlayerToolStripMenuItem.Text = "Player Vs Player";
            this.playerVsPlayerToolStripMenuItem.Click += new System.EventHandler(this.playerVsPlayerToolStripMenuItem_Click);
            // 
            // playerVsComToolStripMenuItem
            // 
            this.playerVsComToolStripMenuItem.Name = "playerVsComToolStripMenuItem";
            this.playerVsComToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.playerVsComToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.playerVsComToolStripMenuItem.Text = "Player Vs Com";
            this.playerVsComToolStripMenuItem.Click += new System.EventHandler(this.playerVsComToolStripMenuItem_Click);
            // 
            // Undo
            // 
            this.Undo.Name = "Undo";
            this.Undo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.Undo.Size = new System.Drawing.Size(180, 22);
            this.Undo.Text = "Undo";
            this.Undo.Click += new System.EventHandler(this.Undo_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // sốLầnThắngCuộcToolStripMenuItem
            // 
            this.sốLầnThắngCuộcToolStripMenuItem.Name = "sốLầnThắngCuộcToolStripMenuItem";
            this.sốLầnThắngCuộcToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.sốLầnThắngCuộcToolStripMenuItem.Text = "Tỉ số";
            this.sốLầnThắngCuộcToolStripMenuItem.Click += new System.EventHandler(this.sốLầnThắngCuộcToolStripMenuItem_Click);
            // 
            // lastChessBoardToolStripMenuItem
            // 
            this.lastChessBoardToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openHistoryToolStripMenuItem,
            this.closeHistoryToolStripMenuItem});
            this.lastChessBoardToolStripMenuItem.Enabled = false;
            this.lastChessBoardToolStripMenuItem.Name = "lastChessBoardToolStripMenuItem";
            this.lastChessBoardToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.lastChessBoardToolStripMenuItem.Text = "History";
            this.lastChessBoardToolStripMenuItem.Click += new System.EventHandler(this.lastChessBoardToolStripMenuItem_Click);
            // 
            // openHistoryToolStripMenuItem
            // 
            this.openHistoryToolStripMenuItem.Name = "openHistoryToolStripMenuItem";
            this.openHistoryToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.openHistoryToolStripMenuItem.Text = "Open History";
            this.openHistoryToolStripMenuItem.Click += new System.EventHandler(this.openHistoryToolStripMenuItem_Click);
            // 
            // closeHistoryToolStripMenuItem
            // 
            this.closeHistoryToolStripMenuItem.Name = "closeHistoryToolStripMenuItem";
            this.closeHistoryToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.closeHistoryToolStripMenuItem.Text = "Close History";
            this.closeHistoryToolStripMenuItem.Click += new System.EventHandler(this.closeHistoryToolStripMenuItem_Click);
            // 
            // Btn_sendmess
            // 
            this.Btn_sendmess.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Btn_sendmess.Enabled = false;
            this.Btn_sendmess.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_sendmess.Location = new System.Drawing.Point(239, 13);
            this.Btn_sendmess.Name = "Btn_sendmess";
            this.Btn_sendmess.Size = new System.Drawing.Size(75, 27);
            this.Btn_sendmess.TabIndex = 2;
            this.Btn_sendmess.Text = "Send";
            this.Btn_sendmess.UseVisualStyleBackColor = false;
            this.Btn_sendmess.Click += new System.EventHandler(this.Btn_sendmess_Click);
            // 
            // Chat
            // 
            this.Chat.AutoSize = true;
            this.Chat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Chat.Location = new System.Drawing.Point(3, -3);
            this.Chat.Name = "Chat";
            this.Chat.Size = new System.Drawing.Size(32, 15);
            this.Chat.TabIndex = 3;
            this.Chat.Text = "Chat";
            this.Chat.Click += new System.EventHandler(this.label2_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.RichTxb_Send);
            this.panel3.Controls.Add(this.RichTxb_receive);
            this.panel3.Controls.Add(this.Btn_sendmess);
            this.panel3.Controls.Add(this.Chat);
            this.panel3.Location = new System.Drawing.Point(562, 190);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(327, 104);
            this.panel3.TabIndex = 0;
            // 
            // RichTxb_Send
            // 
            this.RichTxb_Send.Location = new System.Drawing.Point(3, 13);
            this.RichTxb_Send.Name = "RichTxb_Send";
            this.RichTxb_Send.Size = new System.Drawing.Size(230, 28);
            this.RichTxb_Send.TabIndex = 6;
            this.RichTxb_Send.Text = "";
            // 
            // RichTxb_receive
            // 
            this.RichTxb_receive.Location = new System.Drawing.Point(3, 46);
            this.RichTxb_receive.Name = "RichTxb_receive";
            this.RichTxb_receive.ReadOnly = true;
            this.RichTxb_receive.Size = new System.Drawing.Size(321, 58);
            this.RichTxb_receive.TabIndex = 5;
            this.RichTxb_receive.Text = "";
            // 
            // pnlChessboard
            // 
            this.pnlChessboard.Controls.Add(this.Txb_NoteMark);
            this.pnlChessboard.Controls.Add(this.Txb_LastChess);
            this.pnlChessboard.Location = new System.Drawing.Point(12, 27);
            this.pnlChessboard.Name = "pnlChessboard";
            this.pnlChessboard.Size = new System.Drawing.Size(544, 534);
            this.pnlChessboard.TabIndex = 2;
            this.pnlChessboard.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlChessboard_Paint);
            // 
            // Txb_NoteMark
            // 
            this.Txb_NoteMark.Location = new System.Drawing.Point(134, 101);
            this.Txb_NoteMark.Multiline = true;
            this.Txb_NoteMark.Name = "Txb_NoteMark";
            this.Txb_NoteMark.ReadOnly = true;
            this.Txb_NoteMark.Size = new System.Drawing.Size(277, 38);
            this.Txb_NoteMark.TabIndex = 3;
            this.Txb_NoteMark.Visible = false;
            this.Txb_NoteMark.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Txb_LastChess
            // 
            this.Txb_LastChess.Location = new System.Drawing.Point(134, 141);
            this.Txb_LastChess.Multiline = true;
            this.Txb_LastChess.Name = "Txb_LastChess";
            this.Txb_LastChess.ReadOnly = true;
            this.Txb_LastChess.Size = new System.Drawing.Size(277, 257);
            this.Txb_LastChess.TabIndex = 0;
            this.Txb_LastChess.Visible = false;
            this.Txb_LastChess.TextChanged += new System.EventHandler(this.Txb_LastChess_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 573);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlChessboard);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Cờ Caro";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PctMark)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.pnlChessboard.ResumeLayout(false);
            this.pnlChessboard.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox PctMark;
        private System.Windows.Forms.Button btn_Lan;
        private System.Windows.Forms.TextBox Txb_IP;
        private System.Windows.Forms.ProgressBar PcBCoolDown;
        private System.Windows.Forms.TextBox TxbPlayer;
        private System.Windows.Forms.Timer Timer_CoolDown;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Menu;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Undo;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.Button Btn_sendmess;
        private System.Windows.Forms.Label Chat;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RichTextBox RichTxb_receive;
        private System.Windows.Forms.RichTextBox RichTxb_Send;
        private System.Windows.Forms.ToolStripMenuItem sốLầnThắngCuộcToolStripMenuItem;
        private System.Windows.Forms.Button Btn_PlayerVsCom;
        private System.Windows.Forms.ToolStripMenuItem playerVsPlayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playerVsComToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem lastChessBoardToolStripMenuItem;
        private System.Windows.Forms.Panel pnlChessboard;
        private System.Windows.Forms.ToolStripMenuItem openHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeHistoryToolStripMenuItem;
        private System.Windows.Forms.TextBox Txb_LastChess;
        private System.Windows.Forms.TextBox Txb_NoteMark;
        private System.Windows.Forms.Label ID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

