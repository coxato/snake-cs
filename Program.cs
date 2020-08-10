using static System.Threading.Thread;
using static System.Console;
using snake_cs.App;

namespace snake_cs
{
    class Program
    {
        static void Main(string[] args)
        {
            GameController game = new GameController();
            game.play();
        }
    }
}
