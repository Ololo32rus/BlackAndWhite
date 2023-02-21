using BlackAndWhite;
using System;

namespace BlackAndWhite
{
       
    class Program
    {
        static void Main(string[] args)
        {
            GameManager game = new GameManager(5);
            game.Play();

            Console.ReadKey();
        }
    }
}