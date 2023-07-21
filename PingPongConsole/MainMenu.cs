using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPongConsole
{
    internal class MainMenu
    {

        private string _selection = "one";
        /// <summary>
        /// Prints title "Pong"
        /// </summary>
        public void PrintTitle(int posX)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(posX, 0);
            Console.Write("  ___  ___  _  _  ___ ");
            Console.SetCursorPosition(posX, 1);
            Console.Write(" | _ \\/ _ \\| \\| |/ __|");
            Console.SetCursorPosition(posX, 2);
            Console.Write(" |  _/ (_) | .` | (_┌┐");
            Console.SetCursorPosition(posX, 3);
            Console.WriteLine(" |_|  \\___/|_|\\_|\\___|");
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Prints selection for one player
        /// </summary>
        /// <param name="posX"></param>
        public void PrintOnePlayer(int posX)
        {
            Console.SetCursorPosition(posX, 7);
            Console.Write("  _   ___ _                   ");
            Console.SetCursorPosition(posX, 8);
            Console.Write(" / | | _ \\ |__ _ _  _ ___ _ _ ");
            Console.SetCursorPosition(posX, 9);
            Console.Write(" | | |  _/ / o` | || / o_) '_|");
            Console.SetCursorPosition(posX, 10);
            Console.Write(" |_| |_| |_\\__,_|\\_, \\___|_|  ");
            Console.SetCursorPosition(posX, 11);
            Console.WriteLine("                 |__/         ");
        }

        /// <summary>
        /// Prints selection for two players
        /// </summary>
        /// <param name="posX"></param>
        public void PrintTwoPlayers(int posX)
        {
            Console.SetCursorPosition(posX, 13);
            Console.Write("  ___   ___ _                   ");
            Console.SetCursorPosition(posX, 14);
            Console.Write(" |_  ) | _ \\ |__ _ _  _ ___ _ _ ___");
            Console.SetCursorPosition(posX, 15);
            Console.Write("  / /  |  _/ / o` | || / o_) '_(_-<");
            Console.SetCursorPosition(posX, 16);
            Console.Write(" /___| |_| |_\\__,_|\\_, \\___|_| /__/");
            Console.SetCursorPosition(posX, 17);
            Console.WriteLine("                   |__/         ");
        }



        /// <summary>
        /// User input for menu
        /// </summary>
        /// <param name="keyInfo"></param>
        /// <param name="posX"></param>
        public void UserInput(ConsoleKeyInfo keyInfo, int posX)
        {
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    DrawSelectorArrow(posX, 9);
                    DeleteSelectorArrow(posX, 15);
                    _selection = "one";
                    break;
                case ConsoleKey.DownArrow:
                    DrawSelectorArrow(posX, 15);
                    DeleteSelectorArrow(posX, 9);
                    _selection = "two";
                    break;
            }
        }


        public void DrawSelectorArrow(int posX, int posY)
        {
            Console.SetCursorPosition(posX, posY);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("►");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void DeleteSelectorArrow(int posX, int posY)
        {
            Console.SetCursorPosition(posX, posY);
            Console.Write(" ");
        }

        public string UserSelection()
        {
            return _selection;
        }
    }
}
