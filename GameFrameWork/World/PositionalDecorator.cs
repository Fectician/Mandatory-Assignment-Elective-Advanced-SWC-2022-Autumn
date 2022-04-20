using GameFrameWork.Creatures.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFrameWork.World
{
    public class CharacterAndPosition
    {
        public int PosX;
        public int PosY;
        public bool Player1;
        public GeneralAttributes GA;
        public CharacterAndPosition(GeneralAttributes character, int posX, int posY, bool player1)
        {
            this.GA = character;
            PosX = posX;
            PosY = posY;
            Player1 = player1;
        }
        public override string ToString()
        {
            return GA.ToString();
        }
    }
}
