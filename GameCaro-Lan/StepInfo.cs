using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCaro_Lan
{
    public class StepInfo
    {
        private Point point;
        public Point Point { get => point; set => point = value; }
        public int CurrentPlayer { get => currentPlayer; set => currentPlayer = value; }
        

        private int currentPlayer;
      
        public StepInfo(Point point , int currentplayer )
        {
            this.point = point;
            this.currentPlayer = currentplayer;
           
        }

    }
}
