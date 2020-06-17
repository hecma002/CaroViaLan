using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCaro_Lan
{
    [Serializable]
    public class SocketData
    {
        private int command;

        public int Command { get => command; set => command = value; }
        public Point Point { get => point; set => point = value; }
        public string Message1 { get => Message; set => Message = value; }

        private Point point;
        public SocketData(int command,  string message ,Point point )
        {
            this.Message = message;
            this.command = command;
            this.point = point;
        }
        private string Message;
        public enum SocketCommand
        {
            Send_Point,
            Notify,
            New_game,
            Equal,
            Endgame,
            Undo,
            Quit,
            Send_Mess
        }

    }
}
