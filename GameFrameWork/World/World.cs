using GameFrameWork.Creatures;
using GameFrameWork.Creatures.General;
using GameFrameWork.Items.Templates;
using GameFrameWork.World.WorldObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFrameWork.World
{
    public class World
    {
        private int maxX;
        private int maxY;
        public int MaxX { get { return maxX; } set { maxX = value; CursorX = maxX / 2; } }
        public int MaxY { get { return maxY; } set { maxY = value; CursorY = maxY / 2; } }
        public int CursorX { get; set; }
        public int CursorY { get; set; }

        public int BufferY = 1;
        public int BufferX = 1;
        private bool CursorDrawn;
        private List<WorldObject> WOList = new List<WorldObject>();
        private static CreaturesManager creatman = new CreaturesManager();
        public void PrintGameworld()
        {
            Console.Clear();
            CursorDrawn = false;
            if (BufferY > 0)
            {
                setpos(-BufferX, -BufferY);
                Console.Write("+");
                for (int j = 1; j < MaxX + (BufferX * 2) - 1; j++)
                {
                    setpos(j - BufferX, -BufferY);
                    Console.Write("-");
                    setpos(j - BufferX, MaxY - 1 + BufferY);
                    Console.Write("-");
                }
                setpos(MaxX - 1 + BufferX, -BufferY);
                Console.Write("+");
                for (int i = 1; i < MaxY + (BufferY * 2) - 1; i++)
                {
                    setpos(-BufferX, i - BufferY);
                    Console.Write("|");
                    setpos(MaxX - 1 + BufferX, i - BufferY);
                    Console.Write("|");
                }
                setpos(MaxX - 1 + BufferX, MaxY - 1 + BufferY);
                Console.Write("+");
                setpos(-BufferX, MaxY - 1 + BufferY);
                Console.Write("+");
            }
            for (int i = 0; i < MaxY; i++)
            {
                for (int j = 0; j < MaxX; j++)
                {
                    setpos(j, i);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
            PrintCharacters();
        }
        private void PrintCharacters()
        {
            foreach (CharacterAndPosition Character in creatman.Returnlist())
            {
                setpos(Character.PosX, Character.PosY);
                if (Character.Player1) { Console.ForegroundColor = ConsoleColor.Blue; }
                else { Console.ForegroundColor = ConsoleColor.Red; }
                if (Character.PosX == CursorX && Character.PosY == CursorY) { Console.BackgroundColor = ConsoleColor.DarkGray; CursorDrawn = true; }
                Console.Write(Character.GA.Name.Substring(0, 1));
                if (CursorDrawn) { Console.ResetColor(); }
            }
            Console.ResetColor();
            if (!CursorDrawn)
            {
                Console.BackgroundColor = ConsoleColor.DarkGray;
                setpos(CursorX, CursorY);
                Console.Write(" ");
                Console.ResetColor();
            }
            setpos(-BufferX, MaxY + BufferY);
            CursorInfo();
        }
        public void CursorInfo()
        {
            if (CursorDrawn)
            {
                CharacterAndPosition characterpos = creatman.Returnlist().Find(r => r.PosX == CursorX && r.PosY == CursorY);
                Console.WriteLine(characterpos);
                foreach (GenericItem item in characterpos.GA.InventoryList)
                {
                    Console.WriteLine(item);
                }
            }
        }
        public CharacterAndPosition AddCharacter(CharacterAndPosition Char)
        {
            if (Char.PosX >= MaxX || Char.PosY >= MaxY) { return Char; }
            creatman.Add(Char);
            return Char;
        }
        public List<CharacterAndPosition> ReturnList() 
        {
            return creatman.Returnlist();
        }
        private void setpos(int x, int y) 
        {
            Console.SetCursorPosition(x + BufferX, y + BufferY);
        }
        public void MoveCursor(char input) 
        {
            switch (input)
            {
                case 'w':
                case 'W':
                    CursorY -= 1;
                    if (CursorY < 0) { CursorY += 1; }
                    break;
                case 'a':
                case 'A':
                    CursorX -= 1;
                    if (CursorX < 0) { CursorX += 1; }
                    break;
                case 's':
                case 'S':
                    CursorY += 1;
                    if (CursorY > MaxY - 1) { CursorY -= 1; }
                    break;
                case 'd':
                case 'D':
                    CursorX += 1;
                    if (CursorX > MaxX - 1) { CursorX -= 1; }
                    break;
            }
        }

        public void SelectSpace() 
        {
            throw new NotImplementedException();
        }
    }
}
