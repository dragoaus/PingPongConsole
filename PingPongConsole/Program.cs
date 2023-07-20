namespace PingPongConsole
{
    internal class Program
    {


        ConsoleColor defaultColor = ConsoleColor.White;
        
        static void Main(string[] args)
        {
            Console.WindowHeight = 50;
            Console.BufferHeight = 50;
            Game game = new Game();

            game.RunGame();

            
            Console.ReadKey();
        }

         

    }
}