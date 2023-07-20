using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PingPongConsole
{
    internal class ScoreCardClass
    {



        private void Zero(int posX)
        {
            Console.SetCursorPosition(posX, 0);
            Console.WriteLine(" __     ");
            Console.SetCursorPosition(posX, 1);
            Console.WriteLine("/  \\     ");
            Console.SetCursorPosition(posX, 2);
            Console.WriteLine("|()|     ");
            Console.SetCursorPosition(posX, 3);
            Console.WriteLine("\\__/     ");
            Console.WriteLine();
        }

        private void One(int posX)
        {
            Console.SetCursorPosition(posX, 0);
            Console.WriteLine(" _     ");
            Console.SetCursorPosition(posX, 1);
            Console.WriteLine("/ |     ");
            Console.SetCursorPosition(posX, 2);
            Console.WriteLine("| |     ");
            Console.SetCursorPosition(posX, 3);
            Console.WriteLine("|_|     ");
            Console.WriteLine();
        }
        private void Two(int posX)
        {
            Console.SetCursorPosition(posX, 0);
            Console.WriteLine(" ___     ");
            Console.SetCursorPosition(posX, 1);
            Console.WriteLine("|   )     ");
            Console.SetCursorPosition(posX, 2);
            Console.WriteLine(" / /     ");
            Console.SetCursorPosition(posX, 3);
            Console.WriteLine("/___|     ");
            Console.WriteLine();
        }

        private void Three(int posX)
        {
            Console.SetCursorPosition(posX, 0);
            Console.WriteLine(" ___     ");
            Console.SetCursorPosition(posX, 1);
            Console.WriteLine("|__ )     ");
            Console.SetCursorPosition(posX, 2);
            Console.WriteLine(" |_ \\     ");
            Console.SetCursorPosition(posX, 3);
            Console.WriteLine("|___/     ");
            Console.WriteLine();
        }

        private void MidLine(int midPos)
        {
            Console.SetCursorPosition(midPos, 0);
            Console.WriteLine("          ");
            Console.SetCursorPosition(midPos, 1);
            Console.WriteLine("   __      ");
            Console.SetCursorPosition(midPos, 2);
            Console.WriteLine("  |__|     ");
            Console.SetCursorPosition(midPos, 3);
            Console.WriteLine("        ");
            Console.WriteLine();
        }


        /// <summary>
        /// Prints Score Card with current result
        /// </summary>
        /// <param name="firstPlayerScore">player one score</param>
        /// <param name="secondPlayerScore">player two score</param>
        public void PrintScore(int firstPlayerScore, int secondPlayerScore)
        {
            int locP1 = 40;
            switch (firstPlayerScore)
            {
                    
                case 0:
                    Zero(locP1);
                    break;
                case 1:
                    One(locP1);
                    break;
                case 2:
                    Two(locP1);
                    break;
                case 3:
                    Three(locP1);
                    break;

            }
            
            int locLine = 48;

            Console.SetCursorPosition(locLine, 0);
            MidLine(locLine);

            int locP2 = 60;
            switch (secondPlayerScore)
            {
                case 0:
                    Zero(locP2);
                    break;
                case 1:
                    One(locP2);
                    break;
                case 2:
                    Two(locP2);
                    break;
                case 3:
                    Three(locP2);
                    break;

            };
        }

    }
}
