using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackAndWhite;
namespace BlackAndWhite
{
    /// класс описывающий рожу (класс создавался отдельно)
    class Face
    {
        protected int x, y;
        private char look;
        protected int hp;

        protected Face(int x, int y, char look, int hp) // Переопределяем коорд,рожу,хп
        {
            this.x = x;
            this.y = y;
            this.look = look;
            this.hp = hp;
        }

        public int HP
        {
            get { return hp; }
        }

        public int X
        {
            get { return x; }
        }

        public int Y
        {
            get { return y; }
        }


        public void Draw() //отрисовка курсора и рожи
        {
            Console.SetCursorPosition(x, y);
            Console.Write(look);
        }

        public bool IsCollisionWithAnother(Face face) // Если координаты совпадают
        {
            return x == face.x && y == face.y;
        }
    }
}
