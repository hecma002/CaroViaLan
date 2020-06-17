using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCaro_Lan
{
    public class ClassPlayer
    {
        private string Name;

        public string Name1 { get => Name; set => Name = value; }
        public Image Mark1 { get => Mark; set => Mark = value; }
        public int Count_Win_Player { get => serial; set => serial = value; }

        private int serial;
        private Image Mark;
       
        public ClassPlayer(string name ="" , Image mark = null  , int Count_Win_Player = 0)
        {
            this.Name = name;
            this.Mark = mark;
            this.Count_Win_Player = Count_Win_Player;
        }
        
    }
}
