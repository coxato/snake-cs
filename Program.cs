using System;
using snake_cs.GameObjects;
using static System.Console;

namespace snake_cs
{
    class Program
    {
        static void Main(string[] args)
        {
            Snake s = new Snake(0, 0);
            WriteLine(s.SnakeBodyParts[0].character);
        }
    }
}
