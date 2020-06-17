using GameCaro;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using static GameCaro_Lan.SocketData;

namespace GameCaro_Lan
{
    public partial class Form1 : Form
    {



        //int[] count_undo;
        int temp_currentplayer;
       
        SocketManager socket;
        int serial_player;
        int temp_newgame = 0;
        int Count_step = 0;
        bool isVsCom = false;
        

        public Form1()
        {
           
            InitializeComponent();
            
            this.player = new List<ClassPlayer>()
            {
                new ClassPlayer("Người chơi 1",Image.FromFile(Application.StartupPath + "\\Resources\\chu-o.png"),0),
                new ClassPlayer("Người chơi 2",Image.FromFile(Application.StartupPath + "\\Resources\\chu-X.png" ),0)
            };
            socket = new SocketManager();
            stepInfos = new Stack<StepInfo>();
            
            PcBCoolDown.Maximum = Cons.Cooldown_max;
            PcBCoolDown.Value = 0;
            PcBCoolDown.Step = Cons.Cooldown_step;
            Timer_CoolDown.Interval = Cons.Cooldown_interval;
            Undo.Enabled = false;
            playerVsPlayerToolStripMenuItem.Enabled = false;
            DrawChessBoard();
            Txb_NoteMark.Text = "1 = O \r\n" + "2 = X";
            pnlChessboard.Enabled = false;

            



        }

        //public void loadRoomData() {

        //    string roomStringData = "room1,room2,room3,rooma,roomb,roomc";
        //    string[] roomArr = roomStringData.Split(',');
        //    for (int i = 0; i < roomArr.Length; i++)
        //    {
        //        System.Windows.Forms.ListViewItem listViewItemTemp = new System.Windows.Forms.ListViewItem(roomArr[i]);
        //        this.Listview_Room.Items.Add(listViewItemTemp);
        //    }
        //}

        #region Properties
        private List<ClassPlayer> player;

        private int CurrentPlayer;

        private List<List<Button>> Matrix;




        public List<ClassPlayer> Player { get => player; set => player = value; }





        public int CurrentPlayer2 { get => CurrentPlayer; set => CurrentPlayer = value; }
        public List<List<Button>> Matrix1 { get => Matrix; set => Matrix = value; }
        public Stack<StepInfo> StepInfos { get => stepInfos; set => stepInfos = value; }


        #endregion
        #region Initialize


        private Stack<StepInfo> stepInfos;


        #endregion
        #region PlayerVsPlayer
        #region Methods






        private void Start_playerMarked(object sender, ButtonClickEvent e)
        {
            Timer_CoolDown.Start();
            
            PcBCoolDown.Value = 0;
            socket.Send(new SocketData((int)SocketCommand.Send_Point, null, e.ClickPoint));
            Menu.Enabled = false;
            pnlChessboard.Enabled = false;
            Listen();
        }
        private void Call_Computer()
        {
            Button btn = Find_aNext_Step();
            PlayerMark(btn);
            StepInfos.Push(new StepInfo(GetChessPoint(btn), CurrentPlayer));
            ChangePlayer();
            if (isEndGame(btn))
            {
                EndgameWithCom();
            }
            
            
        }

        private void EndgameWithCom()
        {
            Timer_CoolDown.Stop();
            PcBCoolDown.Value = 0;
            pnlChessboard.Enabled = false;
            Undo.Enabled = false;
            lastChessBoardToolStripMenuItem.Enabled = true;
            SaveLastChessboard();
            CurrentPlayer = CurrentPlayer == 1 ? 0 : 1;
            player[CurrentPlayer].Count_Win_Player++;
            temp_newgame = 1;
            MessageBox.Show("Chúc mừng" + " " + player[CurrentPlayer].Name1 + " đã chiến thắng", "Thông báo");
            MessageBox.Show("Nhan Newgame(Ctrl + F1) de bat dau lai tro choi ", "Gợi ý"); ;
            
        }
        private void RandomAStep()
        {
            if (PcBCoolDown.Value >= PcBCoolDown.Maximum)
            {
                Button btn = Find_aNext_Step();
                PlayerMark(btn);
                Start_playerMarked(this, new ButtonClickEvent(GetChessPoint(btn)));
                StepInfos.Push(new StepInfo(GetChessPoint(btn), CurrentPlayer));
                Endgame(btn);
                ChangePlayer();
                PcBCoolDown.Value = 0;
            }
        }
        void btn_new_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.BackgroundImage != null)
                return;
            Undo.Enabled = true;
            Count_step++;
            if (Count_step == Cons.Height * Cons.Width)
                EqualGame();
            if (isVsCom == true)
            {


               
                PlayerMark(btn);
                temp_newgame = 2;

                StepInfos.Push(new StepInfo(GetChessPoint(btn), CurrentPlayer));



                ChangePlayer();
                if (isEndGame(btn))
                {
                    lastChessBoardToolStripMenuItem.Enabled = true;
                   
                    EndgameWithCom();
                }
                else
                {
                    Call_Computer();
                    RandomAStep();
                }

            }
            else
            {
                PlayerMark(btn);
                temp_newgame = 2;

                Start_playerMarked(this, new ButtonClickEvent(GetChessPoint(btn)));


                StepInfos.Push(new StepInfo(GetChessPoint(btn), CurrentPlayer));



                ChangePlayer();
                Endgame(btn);
            }
            




        }
        public void OtherPlayerMark(Point point)
        {


            Button btn = Matrix[point.Y][point.X];
            if (btn.BackgroundImage != null)
                return;
            pnlChessboard.Enabled = true;
            PlayerMark(btn);

            StepInfos.Push(new StepInfo(GetChessPoint(btn), CurrentPlayer));
            ChangePlayer();
            Endgame(btn);

        }







        #endregion

        #region processed
        void DrawChessBoard()
        {
            Matrix1 = new List<List<Button>>();
            Button btn_old = new Button() { Location = new Point(0, 0), Width = 0 };
            for (int i = 0; i < Cons.Height; i++)
            {
                Matrix1.Add(new List<Button>());

                for (int j = 0; j < Cons.Width; j++)
                {
                    Button btn_new = new Button()
                    {
                        Location = new Point(btn_old.Location.X + btn_old.Width, btn_old.Location.Y)
                        ,
                        Width = Cons.size_width
                        ,
                        Height = Cons.size_height,
                        BackgroundImageLayout = ImageLayout.Stretch
                        ,
                        Tag = i.ToString()
                    };


                    btn_new.Click += btn_new_Click;

                    pnlChessboard.Controls.Add(btn_new);

                    Matrix1[i].Add(btn_new);

                    btn_old = btn_new;
                }
                btn_old.Location = new Point(0, btn_old.Location.Y + Cons.size_height);
                btn_old.Width = 0;
                btn_old.Height = 0;
            }

        }
        void SaveLastChessboard()
        {
            List<List<int>> SaveMatrix = new List<List<int>>();
            Txb_LastChess.Text = "|";
            for (int i = 0; i < Cons.Height; i++)
            {
                for (int j = 0; j < Cons.Width -1; j++)
                {
                    if (Matrix[i][j].BackgroundImage == null)
                        Txb_LastChess.Text += "    |";
                    else if (Matrix[i][j].BackgroundImage == player[0].Mark1)
                        Txb_LastChess.Text += "1  |";
                    else
                        Txb_LastChess.Text += "2  |";
                }
                if (i<Cons.Height-1)
                    Txb_LastChess.Text +=  Environment.NewLine+"|" ;
            }
            
        }
        private void ChangePlayer()
        {


            TxbPlayer.Text = player[CurrentPlayer].Name1;
            PctMark.Image = player[CurrentPlayer].Mark1;

        }
        private void Endgame(Button btn)
        {
            if (isEndGame(btn))
            {
                try
                {
                    SaveLastChessboard();
                    lastChessBoardToolStripMenuItem.Enabled = true;
                    socket.Send(new SocketData((int)SocketCommand.Endgame, null, new Point()));
                }
                catch { }

            }
        }
        private void EqualGame()
        {
            
                try
                {
                    SaveLastChessboard();
                    lastChessBoardToolStripMenuItem.Enabled = true;
                    socket.Send(new SocketData((int)SocketCommand.Equal, null, new Point()));
                }
                catch { }

          
        }

        private bool isEndGame(Button btn)
        {
            return isHorizonal(btn) || isVertical(btn) || isPrimary(btn) || isSub(btn);
        }


        private Point GetChessPoint(Button btn)
        {
            Point point = new Point();
            int vertical = Convert.ToInt32(btn.Tag);
            int horizontal = Matrix1[vertical].IndexOf(btn);
            point.X = horizontal;
            point.Y = vertical;
            return point;
        }


        private bool isHorizonal(Button btn)
        {
            Point point = new Point();
            point = GetChessPoint(btn);
            //Kiểm tra mảng bên trái
            int count_left = 0;
            int temp = 0;
            int count_preventHead = 0;
            for (int i = point.X; i >= 0; i--)
            {
                if (Matrix1[point.Y][i].BackgroundImage == btn.BackgroundImage)
                {
                    count_left++;
                    temp++;
                }
                else if (Matrix1[point.Y][i].BackgroundImage == null)
                {
                    break;
                }
                else
                {
                    count_preventHead++;
                    break;
                }


            }
            //Kiểm tra mảng bên phải
            int count_right = 0;
            for (int i = point.X + 1; i < point.X + 7; i++)
            {
                if (Matrix1[point.Y][i].BackgroundImage == btn.BackgroundImage)
                    count_right++;
                else if (Matrix1[point.Y][i].BackgroundImage == null)
                {
                    break;
                }
                else
                {
                    count_preventHead++;
                    break;
                }
            }
            if (count_preventHead == 2)
                return false;
            return count_left + count_right >= 5;
        }


        private bool isVertical(Button btn)
        {
            Point point = new Point();
            point = GetChessPoint(btn);
            //Kiểm tra mảng bên trái
            int count_left = 0;
            int count_preventHead = 0;
            for (int i = point.Y; i >= 0; i--)
            {
                if (Matrix1[i][point.X].BackgroundImage == btn.BackgroundImage)
                    count_left++;
                else if (Matrix1[i][point.X].BackgroundImage == null)
                {
                    break;
                }
                else
                {
                    count_preventHead++;
                    break;
                }
            }

            //Kiểm tra mảng bên phải
            int count_right = 0;
            for (int i = point.Y + 1; i < Cons.Height; i++)
            {
                if (Matrix1[i][point.X].BackgroundImage == btn.BackgroundImage)
                    count_right++;
                else if (Matrix1[i][point.X].BackgroundImage == null)
                {
                    break;
                }
                else
                {
                    count_preventHead++;
                    break;
                }
            }
            if (count_preventHead == 2)
                return false;
            return count_left + count_right >= 5;

        }


        private bool isPrimary(Button btn)
        {
            Point point = new Point();
            point = GetChessPoint(btn);


            int count_Top = 0;
            int count_preventHead = 0;
            for (int i = 0; i <= point.X; i++)
            {
                if (point.X - i < 0 || point.Y - i < 0)
                    break;

                if (Matrix[point.Y - i][point.X - i].BackgroundImage == btn.BackgroundImage)
                {
                    count_Top++;
                }
                else if (Matrix[point.Y - i][point.X - i].BackgroundImage == null)
                {
                    break;
                }
                else
                {
                    count_preventHead++;
                    break;
                }
            }


            int count_Bot = 0;
            for (int i = 1; i <= Cons.Width - point.X; i++)
            {
                if (point.Y + i >= Cons.Height || point.X + i >= Cons.Width)
                    break;

                if (Matrix[point.Y + i][point.X + i].BackgroundImage == btn.BackgroundImage)
                {
                    count_Bot++;
                }
                else if (Matrix[point.Y + i][point.X + i].BackgroundImage == null)
                {
                    break;
                }
                else
                {
                    count_preventHead++;
                    break;
                }
            }
            if (count_preventHead == 2)
                return false;

            return count_Top + count_Bot >= 5;


        }


        private bool isSub(Button btn)
        {
            Point point = new Point();
            point = GetChessPoint(btn);



            int count_preventHead = 0;

            int count_Top = 0;
            for (int i = 0; i <= point.X; i++)
            {
                if (point.X + i > Cons.Width || point.Y - i < 0)
                    break;

                if (Matrix[point.Y - i][point.X + i].BackgroundImage == btn.BackgroundImage)
                {
                    count_Top++;
                }
                else if (Matrix[point.Y - i][point.X + i].BackgroundImage == null)
                {
                    break;
                }
                else
                {
                    count_preventHead++;
                    break;
                }
            }





            int count_Bot = 0;
            for (int i = 1; i <= Cons.Width - point.X; i++)
            {
                if (point.Y + i >= Cons.Height || point.X - i < 0)
                    break;

                if (Matrix[point.Y + i][point.X - i].BackgroundImage == btn.BackgroundImage)
                {
                    count_Bot++;
                }
                else if (Matrix[point.Y + i][point.X - i].BackgroundImage == null)
                {
                    break;
                }
                else
                {
                    count_preventHead++;
                    break;
                }
            }
            if (count_preventHead == 2)
                return false;

            return count_Top + count_Bot >= 5;
        }


        private void PlayerMark(Button btn)
        {

            btn.BackgroundImage = player[CurrentPlayer].Mark1;
            temp_currentplayer = CurrentPlayer;
            CurrentPlayer = CurrentPlayer == 1 ? 0 : 1;
        }


        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn dừng trò chơi lại không ? ", " Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                e.Cancel = true;
            else
            {
                try
                {

                    socket.Send(new SocketData((int)SocketCommand.Quit, null, new Point()));
                    PcBCoolDown.Value = 0;
                    Timer_CoolDown.Stop();
                    pnlChessboard.Enabled = false;
                }


                catch {
                }
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Timer_CoolDown_Tick(object sender, EventArgs e)
        {
            PcBCoolDown.PerformStep();
            //Random 1 diem khi time out
            RandomAStep();
        }

        private void Reset_ChessBoard()
        {
            for (int i = 0; i < Cons.Height; i++)
            {
                for (int j = 0; j < Cons.Width; j++)
                {
                    if (Matrix1[i][j].BackgroundImage != null)
                        Matrix1[i][j].BackgroundImage = null;
                }
            }
        }
        private void New_Game()
        {
            pnlChessboard.Enabled = true;
            Undo.Enabled = true;
            PcBCoolDown.Value = 0;
            Timer_CoolDown.Stop();
            
            if (temp_newgame != 1)
                player[CurrentPlayer == 0 ? 1 : 0].Count_Win_Player++;
            temp_newgame = 0;
            CurrentPlayer = 0;

            ChangePlayer();
            //txb_Name1.Visible = false;

            Reset_ChessBoard();



        }


        private void Form1_Shown(object sender, EventArgs e)
        {
            Txb_IP.Text = socket.GetLocalIPv4(NetworkInterfaceType.Ethernet);
            if (string.IsNullOrEmpty(Txb_IP.Text))
                Txb_IP.Text = socket.GetLocalIPv4(NetworkInterfaceType.Wireless80211);
        }

        void Listen()
        {
            //anonymous method
            //you can use a parameter for the delagate but you using the thread , you must use Void reference
            Thread listenThread = new Thread(() =>
            {
                try
                {
                    SocketData data = (SocketData)socket.Receive();
                    Commands(data);
                }
                catch { }
            });
            listenThread.IsBackground = true;
            listenThread.Start();
        }


        private void btn_Lan_Click(object sender, EventArgs e)
        {
        
            Count_step = 0;
            if (isVsCom)
            {
                Reset_ChessBoard();
                CurrentPlayer = CurrentPlayer == 1 ? 0 : 1;
                isVsCom = false;
            }
            pnlChessboard.Enabled = true;
            playerVsPlayerToolStripMenuItem.Enabled = true;
            Btn_PlayerVsCom.Enabled = false;
            playerVsComToolStripMenuItem.Enabled = false;
            Btn_sendmess.Enabled = true;
            if (Txb_IP.Text == "0")
            {
                MessageBox.Show("Room ID phải khác 0"+Environment.NewLine+"Cảm phiền nhập lại số phòng !!!", "Chú ý");
                return;
            }
            socket.IP = Txb_IP.Text ;
            if (!socket.JoinRoom())
            {

                socket.isHost = true;
                pnlChessboard.Enabled = true;
                socket.CreateRoom();
                serial_player = 0;
                ChangePlayer();
                try
                {
                    Thread.Sleep(500);
                    Listen();
                    
                }
                catch
                {

                }

            }
            else
            {
                socket.isHost = false;
                pnlChessboard.Enabled = false;
                Listen();
                serial_player = 1;
                MessageBox.Show("Người chơi có IP : " + Txb_IP.Text + " đã tham gia phòng" ,"Thông báo");

            }



        }
        private void Commands(SocketData data)
        {
            switch (data.Command)
            {
                case (int)SocketCommand.Notify:
                    MessageBox.Show(data.Message1);
                    break;
                case (int)SocketCommand.Equal:
                    Timer_CoolDown.Stop();
                    PcBCoolDown.Value = 0;
                    pnlChessboard.Enabled = false;
                    Undo.Enabled = false;
                    MessageBox.Show("Cả 2 đều chiến thắng", "Chúc Mừng");
                    break;
                case (int)SocketCommand.New_game:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        New_Game();
                        pnlChessboard.Enabled = false;
                    }));
                    break;
                case (int)SocketCommand.Undo:
                    Undo1();
                    PcBCoolDown.Value = 0;
                    break;
                case (int)SocketCommand.Send_Point:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        OtherPlayerMark(data.Point);
                        pnlChessboard.Enabled = true;
                        PcBCoolDown.Value = 0;
                        Timer_CoolDown.Start();
                        Menu.Enabled = true;
                        playerVsPlayerToolStripMenuItem.Enabled = true;
                    }
                    ));
                    break;
                case (int)SocketCommand.Quit:
                    MessageBox.Show("Người chơi đã thoát ");
                    PcBCoolDown.Value = 0;
                    Timer_CoolDown.Stop();
                    pnlChessboard.Enabled = false;
                    break;
                case (int)SocketCommand.Endgame:
                    Timer_CoolDown.Stop();
                    PcBCoolDown.Value = 0;
                    pnlChessboard.Enabled = false;
                    Undo.Enabled = false;
                    CurrentPlayer = CurrentPlayer == 1 ? 0 : 1;
                    player[CurrentPlayer].Count_Win_Player++;
                    temp_newgame = 1;
                    MessageBox.Show("Chúc mừng" + " " + player[CurrentPlayer].Name1 + " đã chiến thắng", "Thông báo");
                    MessageBox.Show("Người thua cuộc được Newgame(Ctrl + N) để bắt đầu lại trò chơi và được ưu tiên đánh trước ", "Gợi ý"); ;
                    break;
                case (int)SocketCommand.Send_Mess:
                    OtherReceive(data.Message1);

                    break;
                default:
                    break;

            }

            Listen();
        }

        void OtherReceive(string txb_send)
        {
            RichTxb_receive.Text += player[serial_player == 1 ? 0 : 1].Name1 + " : " + txb_send + Environment.NewLine;

        }
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            return ;


        }
        public bool Undo1()
        {
            if (stepInfos.Count <= 0)
                return false;

            bool UndoAStep1 = UndoAStep();
            bool UndoAStep2 = UndoAStep();



            StepInfo oldstep = stepInfos.Peek();


            return UndoAStep1 && UndoAStep2;
        }
        private bool UndoAStep()
        {
            if (stepInfos.Count <= 0)
                return false;
            StepInfo oldstep = stepInfos.Pop();

            Button btn = Matrix[oldstep.Point.Y][oldstep.Point.X];
            btn.BackgroundImage = null;
            if (stepInfos.Count <= 0)
            {
                CurrentPlayer = 0;
            }
            else
            {
                oldstep = stepInfos.Peek();


            }
            ChangePlayer();
            return true;
        }
        private void Undo_Click(object sender, EventArgs e)
        {
            Undo1();
            PcBCoolDown.Value = 0;
            if(isVsCom != true)
                socket.Send(new SocketData((int)SocketCommand.Undo, null, new Point()));
        }

        private void messengerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Btn_sendmess_Click(object sender, EventArgs e)
        {


            socket.Send(new SocketData((int)SocketCommand.Send_Mess, RichTxb_Send.Text, new Point()));
            RichTxb_receive.Text += player[serial_player].Name1 + " : " + RichTxb_Send.Text + Environment.NewLine;
            RichTxb_Send.Text = "";
            Listen();

        }

        private void sốLầnThắngCuộcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(player[CurrentPlayer].Name1 + " : " + player[CurrentPlayer].Count_Win_Player.ToString() + Environment.NewLine
              + player[CurrentPlayer == 1 ? 0 : 1].Name1 + " : " + player[CurrentPlayer == 1 ? 0 : 1].Count_Win_Player.ToString());
        }



        #endregion

        #endregion
        #region PlayerVsComputer

        int[] Array_Point_Attack = { 0, 9, 81, 729, 6561, 59049, 531441 };
        int[] Array_Point_Defence = { 0, 3, 27, 243, 2187, 19683, 177147};
        private void Btn_PlayerVsCom_Click(object sender, EventArgs e)
        {
            Reset_ChessBoard();
            
            Count_step = 0;
            playerVsPlayerToolStripMenuItem.Enabled = true;
            pnlChessboard.Enabled = true;
            CurrentPlayer = 0;
            ChangePlayer();
            serial_player = 0;
            isVsCom = true;
            Button btn = Find_aNext_Step();
            Btn_sendmess.Enabled = true;
            PlayerMark(btn);
        }
        private Button Find_aNext_Step()
        {
            Button btn = new Button();
            long Attack_Point = 0;
            long Defence_Point = 0;
            
            long Max = 0;
            if(temp_newgame ==1 && Matrix[Cons.Height / 2][Cons.Width / 2].BackgroundImage == null || temp_newgame == 0 && Matrix[Cons.Height/2][Cons.Width / 2].BackgroundImage == null)
            {
                btn = Matrix[Cons.Height/2][Cons.Width / 2];
            }
            else
            {
                temp_newgame = 0;
                for (int i = 0; i < Cons.Height; i++)
                {
                    for (int j = 0; j < Cons.Width; j++)
                    {
                        if(Matrix[i][j].BackgroundImage == null)
                        {
                            Attack_Point = Attack_Point_Hori(i,j) + Attack_Point_Vertical(i, j) + Attack_Point_Primary(i, j) + Attack_Point_Sub(i, j);

                            Defence_Point = Defence_Point_Hori(i, j) + Defence_Point_Vertical(i, j) + Defence_Point_Primary(i, j) + Defence_Point_Sub(i, j);

                            long temp = Attack_Point + Defence_Point;
                            if(Max < temp)
                            {
                                Max = temp;
                                btn = Matrix[i][j]; 
                            }
                        }
                    }
                }
            }
            return btn;
        }

        #region Defence
        private long Defence_Point_Hori(int currY, int currX)
        {
            long total = 0;
            int Enemy = 0;
            int Army = 0;
         
            // Left Consideration 
            for (int i = 1; i < 6 && currX - i >= 0; i++)
            {
                if (Matrix[currY][currX - i].BackgroundImage == null)
                {
                    
                  
                        break;
                }
                else if (Matrix[currY][currX - i].BackgroundImage != player[serial_player].Mark1)
                {
                    Enemy++;
                }
                else
                {
                    Army++;
                    break;
                }
            }
            //Right Consideration
      
            for (int i = 1; i < 6 && currX + i < Cons.Width; i++)
            {
                if (Matrix[currY][currX + i].BackgroundImage == null)
                {
                      break;
                }
                else if (Matrix[currY][currX + i].BackgroundImage != player[serial_player].Mark1)
                {
                    Enemy++;
                }
                else
                {
                    Army++;
                    break;
                }
            }

            if (Army == 2)
                return 0;
            else if (Army == 1 && Enemy == 3)
                return 80;


            total += Array_Point_Defence[Enemy];
            total -= Array_Point_Defence[Army];
            return total;
        }

        private long Defence_Point_Vertical(int currY, int currX)
        {
            long total = 0;
            int Enemy = 0;
            int Army = 0;
            // Left Consideration 
            for (int i = 1; i < 6 && currY - i >= 0; i++)
            {
                if (Matrix[currY - i][currX].BackgroundImage == null)
                {
                    break;
                }
                else if (Matrix[currY - i][currX].BackgroundImage != player[serial_player].Mark1)
                {
                    Enemy++;
                }
                else
                {
                    Army++;
                    break;
                }
            }
            //Right Consideration
            for (int i = 1; i < 6 && currY + i < Cons.Height; i++)
            {
                if (Matrix[currY + i][currX].BackgroundImage == null)
                {
                    break;
                }
                else if (Matrix[currY + i][currX].BackgroundImage != player[serial_player].Mark1)
                {
                    Enemy++;
                }
                else
                {
                    Army++;
                    break;
                }
            }

            if (Army == 2)
                return 0;
            else if (Army == 1 && Enemy == 3)
                return 80;
            
            
            total += Array_Point_Defence[Enemy];
            total -= Array_Point_Defence[Army];
            return total;
        }

        private long Defence_Point_Primary(int currY, int currX)
        {
            long total = 0;
            int Enemy = 0;
            int Army = 0;
            // Left Consideration 
            for (int i = 1; i < 6 && currY - i >= 0 && currX - i >= 0; i++)
            {
                if (Matrix[currY - i][currX - i].BackgroundImage == null)
                {
                    break;
                }
                else if (Matrix[currY - i][currX - i].BackgroundImage != player[serial_player].Mark1)
                {
                    Enemy++;
                }
                else
                {
                    Army++;
                    break;
                }
            }
            //Right Consideration
            for (int i = 1; i < 6 && currY + i < Cons.Height && currX + i < Cons.Width; i++)
            {
                if (Matrix[currY + i][currX + i].BackgroundImage == null)
                {
                    break;
                }
                else if (Matrix[currY + i][currX + i].BackgroundImage != player[serial_player].Mark1)
                {
                    Enemy++;
                }
                else
                {
                    Army++;
                    break;
                }
            }

            if (Army == 2)
                return 0;
            else if (Army == 1 && Enemy == 3)
                return 80;


            total += Array_Point_Defence[Enemy];
            total -= Array_Point_Defence[Army];
            return total;
        }

        private long Defence_Point_Sub(int currY,int currX)
        {
            long total = 0;
            int Enemy = 0;
            int Army = 0;
            // Left Consideration 
            for (int i = 1; i < 6 && currY - i >= 0 && currX + i < Cons.Width; i++)
            {
                if (Matrix[currY - i][currX + i].BackgroundImage == null)
                {
                    break;
                }
                else if (Matrix[currY - i][currX + i].BackgroundImage != player[serial_player].Mark1)
                {
                    Enemy++;
                }
                else
                {
                    Army++;
                    break;
                }
            }
            //Right Consideration
            for (int i = 1; i < 6 && currY + i < Cons.Height && currX - i >= 0; i++)
            {
                if (Matrix[currY + i][currX - i].BackgroundImage == null)
                {
                    break;
                }
                else if (Matrix[currY + i][currX - i].BackgroundImage != player[serial_player].Mark1)
                {
                    Enemy++;
                }
                else
                {
                    Army++;
                    break;
                }
            }

            if (Army == 2)
                return 0;
            else if (Army == 1 && Enemy == 3)
                return 80;


            total += Array_Point_Defence[Enemy];
            total -= Array_Point_Defence[Army];
            return total;
        }
        #endregion
        #region Attack
        private long Attack_Point_Sub(int currY, int currX)
        {
            long total = 0;
            int Enemy = 0;
            int Army = 0;
            // Left Consideration 
            for (int i = 1; i < 6 && currY - i >= 0 && currX + i < Cons.Width; i++)
            {
                if (Matrix[currY - i][currX + i].BackgroundImage == null)
                {
                    break;
                }
                else if (Matrix[currY - i][currX + i].BackgroundImage == player[serial_player].Mark1)
                {
                    Army++;
                }
                else
                {
                    Enemy++;
                    break;
                }
            }
            //Right Consideration
            for (int i = 1; i < 6 && currY + i < Cons.Height && currX - i >= 0; i++)
            {
                if (Matrix[currY + i][currX - i].BackgroundImage == null)
                {
                    break;
                }
                else if (Matrix[currY + i][currX - i].BackgroundImage == player[serial_player].Mark1)
                {
                    Army++;
                }
                else
                {
                    Enemy++;
                    break;
                }
            }

            if (Enemy == 2)
                return 0;

            total += Array_Point_Attack[Army];
            total -= Array_Point_Attack[Enemy];

            return total;
        }

        private long Attack_Point_Primary(int currY,int currX)
        {
            long total = 0;
            int Enemy = 0;
            int Army = 0;
            // Left Consideration 
            for (int i = 1; i < 6 && currY - i >= 0 && currX - i >=0; i++)
            {
                if (Matrix[currY - i][currX - i].BackgroundImage == null)
                {
                    break;
                }
                else if (Matrix[currY - i][currX - i].BackgroundImage == player[serial_player].Mark1)
                {
                    Army++;
                }
                else
                {
                    Enemy++;
                    break;
                }
            }
            //Right Consideration
            for (int i = 1; i < 6 && currY + i < Cons.Height && currX+i < Cons.Width; i++)
            {
                if (Matrix[currY + i][currX + i].BackgroundImage == null)
                {
                    break;
                }
                else if(Matrix[currY + i][currX+i].BackgroundImage == player[serial_player].Mark1)
                {
                    Army++;
                }
                else
                {
                    Enemy++;
                    break;
                }
            }

            if (Enemy == 2)
                return 0;

            total += Array_Point_Attack[Army];
            total -= Array_Point_Attack[Enemy];

            return total;
        }

        private long Attack_Point_Vertical(int currY , int currX)
        {
            long total = 0;
            int Enemy = 0;
            int Army = 0;
            // Left Consideration 
            for (int i = 1; i < 6 && currY - i >= 0; i++)
            {
                if (Matrix[currY - i][currX].BackgroundImage == null)
                {
                    break;
                }
                else if (Matrix[currY - i][currX].BackgroundImage == player[serial_player].Mark1)
                {
                    Army++;
                }
                else
                {
                    Enemy++;
                    break;
                }
            }
            //Right Consideration
            for (int i = 1; i < 6 && currY + i < Cons.Height; i++)
            {
               
                if (Matrix[currY + i][currX ].BackgroundImage == null)
                {
                    break;
                }
                else if (Matrix[currY + i][currX].BackgroundImage == player[serial_player].Mark1)
                {
                    Army++;
                }
                else
                {
                    Enemy++;
                    break;
                }
            }

            if (Enemy == 2)
                return 0;

            total += Array_Point_Attack[Army];
            total -= Array_Point_Attack[Enemy];

            return total;
        }

        private long Attack_Point_Hori(int currY,int currX)
        {
            long total = 0;
            int Enemy = 0;
            int Army = 0;
            // Left Consideration 
            for (int i = 1; i < 6 && currX - i >= 0; i++)
            {
                if (Matrix[currY][currX - i].BackgroundImage == null)
                {
                    break;
                }
                else if (Matrix[currY][currX - i].BackgroundImage == player[serial_player].Mark1)
                {
                    Army++;
                }
                else
                {
                    Enemy++;
                    break;
                }
            }
            //Right Consideration
            for (int i = 1; i < 6 && currX + i < Cons.Width; i++)
            {
                if (Matrix[currY][currX + i].BackgroundImage == null)
                {
                    break;
                }
                else if (Matrix[currY][currX + i].BackgroundImage == player[serial_player].Mark1)
                {
                    Army++;
                }
                else
                {
                    Enemy++;
                    break;
                }
            }

            if (Enemy == 2)
                return 0;

            total += Array_Point_Attack[Army];
            total -= Array_Point_Attack[Enemy];

            return total;
        }
        #endregion

        #endregion

        private void playerVsComToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Count_step = 0;
            Reset_ChessBoard();
            pnlChessboard.Enabled = true;
            CurrentPlayer = 0;
            ChangePlayer();
            serial_player = 0;
            isVsCom = true;
            Button btn = Find_aNext_Step();
            PlayerMark(btn);
        }

        private void playerVsPlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Count_step = 0;
            New_Game();
            socket.Send(new SocketData((int)SocketCommand.New_game, null, new Point()));
        }

        //private void Btn_RoomCreation_Click(object sender, EventArgs e)
        //{
        //    string roomStringData = "room1";
        //    System.Windows.Forms.ListViewItem listViewItemTemp = new System.Windows.Forms.ListViewItem(roomStringData);
        //    this.Listview_Room.Items.Add(listViewItemTemp);
        
        //}

        private void lastChessBoardToolStripMenuItem_Click(object sender, EventArgs e)
        {

            return;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            PcBCoolDown.Value = 0;
            Timer_CoolDown.Stop();
            pnlChessboard.Enabled = false;
            playerVsPlayerToolStripMenuItem.Enabled = false;
            MessageBox.Show(player[CurrentPlayer].Name1 + " : " + player[CurrentPlayer].Count_Win_Player.ToString() + Environment.NewLine
              + player[CurrentPlayer == 1 ? 0 : 1].Name1 + " : " + player[CurrentPlayer == 1 ? 0 : 1].Count_Win_Player.ToString());
        }

        private void Btn_CloseTxbHistory_Click(object sender, EventArgs e)
        {
            Txb_LastChess.Visible = false;
            
        }

        private void Txb_LastChess_TextChanged(object sender, EventArgs e)
        {

        }

        private void openHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Txb_NoteMark.Visible = true;
            
            Txb_LastChess.Visible = true;
        }

        private void closeHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Txb_LastChess.Visible = false;
            Txb_NoteMark.Visible = false;
        }

        private void Menu_Click(object sender, EventArgs e)
        {
            return; 
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void pnlChessboard_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PcBCoolDown_Click(object sender, EventArgs e)
        {

        }
    }

    public class ButtonClickEvent : EventArgs
    {
        private Point clickPoint;

        public Point ClickPoint { get => clickPoint; set => clickPoint = value; }

        public ButtonClickEvent(Point point)
        {
            this.clickPoint = point;
        }
    }

}
