using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackAndWhite;
namespace BlackAndWhite
{
    class WhiteFace : Face // (класс создовался отдельно)
    {
        public WhiteFace(int x, int y, int hp) : base(x, y, (char)1, hp)
        {
        }

        public void Eat(BlackFace face)
        {
            hp += face.HP;
        }

        public void Move(ConsoleKey key, int xMin, int xMax, int yMin, int yMax) //движение белого по полю с ограничением мин и макс коорд
        {
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    if (x > xMin)
                    {
                        x--;
                    }
                    break;

                case ConsoleKey.RightArrow:
                    if (x < xMax)
                    {
                        x++;
                    }
                    break;

                case ConsoleKey.UpArrow:
                    if (y > yMin)
                    {
                        y--;
                    }
                    break;

                case ConsoleKey.DownArrow:
                    if (y < yMax)
                    {
                        y++;
                    }
                    break;
            }
        }

    }
}
