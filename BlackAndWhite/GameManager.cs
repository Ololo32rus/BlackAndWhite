using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackAndWhite;

namespace BlackAndWhite
{
    class GameManager
    {
        private WhiteFace whiteFace;
        private BlackFace[] blackFaces;

        private int countEaten;

        private Random rnd;

        private int xMin, xMax, yMin, yMax;

        public GameManager(int countBlackFaces)
        {
            int countEaten = 0;
            xMin = 0;
            xMax = Console.WindowWidth - 2;
            yMin = 2;
            yMax = Console.WindowWidth - 2;

            rnd = new Random();

            whiteFace = new WhiteFace(xMin, yMin, 10);
            blackFaces = new BlackFace[countBlackFaces];

            InitBlackFaces();
            RandomBlackFacesPosition();
        }
        public void Play()
        {
            while (whiteFace.HP > 0)
            {
                Console.Clear();

                Console.SetCursorPosition(0, 0);
                Console.Write($"X:{whiteFace.X} Y:{whiteFace.Y} HP:{whiteFace.HP} Count Eaten:{countEaten}");

                whiteFace.Draw();

                for (int i = 0; i < blackFaces.Length; i++)
                {
                    blackFaces[i].Draw();
                }

                whiteFace.Move(Console.ReadKey().Key, xMin, xMax, yMin, yMax);
                bool isCollision = false;

                for (int i = 0; i < blackFaces.Length; i++)
                {
                    if (whiteFace.IsCollisionWithAnother(blackFaces[i]) == true)
                    {
                        whiteFace.Eat(blackFaces[i]);
                        countEaten++;
                        isCollision = true;
                        break;
                    }
                }

                if (isCollision == true)
                {
                    RandomBlackFacesPosition();
                }

            }

        }

        private void InitBlackFaces()
        {
            for (int i = 0; i < blackFaces.Length / 2; i++)
            {
                blackFaces[i] = new BlackFace(xMin, yMin, rnd.Next(-5, 0 + 1));
            }

            for (int i = blackFaces.Length / 2; i < blackFaces.Length; i++)
            {
                blackFaces[i] = new BlackFace(xMin, yMin, rnd.Next(1, 5 + 1));
            }
        }

        private void RandomBlackFacesPosition()
        {
            for (int i = 0; i < blackFaces.Length; i++)
            {
                bool isCollision;

                do
                {
                    isCollision = false;

                    blackFaces[i].RandomPosition(rnd, xMin, xMax, yMin, yMax);
                    for (int j = 0; j < blackFaces.Length; j++)
                    {
                        if (i == j) { continue; }

                        if (blackFaces[i].IsCollisionWithAnother(blackFaces[j]) == true || blackFaces[i].IsCollisionWithAnother(whiteFace) == true)
                        {
                            isCollision = true;
                            break;
                        }
                    }

                    Console.Clear();

                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("You are died");
                    Console.Write($"Final HP:{whiteFace.HP} Count Eaten:{countEaten}");

                } while (isCollision == true);
            }
        }
    }
}
