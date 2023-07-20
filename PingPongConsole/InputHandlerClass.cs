using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PingPongConsole
{
    internal class InputHandlerClass
    {
        private PlayerClass playerOne;
        private PlayerClass playerTwo;
        private TableClass field;


        public InputHandlerClass(PlayerClass p1, TableClass field)
        {
            playerOne = p1;
            this.field = field;
        }

        public InputHandlerClass(PlayerClass p1, PlayerClass p2, TableClass field)
        {
            playerOne = p1;
            playerTwo = p2;
            this.field = field;
        }


        /// <summary>
        /// handles user input for player movement 
        /// </summary>
        public void UserInputMovement()
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    if (1 < playerOne.PlayerPosition.Row)
                    {
                        field.RemovePlayerFromBoard(playerOne);
                        playerOne.MoveUp();
                        field.AddPlayerToBoard(playerOne);
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (field.TableRows-5 > playerOne.PlayerPosition.Row)
                    {
                        field.RemovePlayerFromBoard(playerOne);
                        playerOne.MoveDown();
                        field.AddPlayerToBoard(playerOne);
                    }
                    break;
                case ConsoleKey.W:
                    if (playerTwo != null && 1 < playerTwo.PlayerPosition.Row)
                    {
                        field.RemovePlayerFromBoard(playerTwo);
                        playerTwo.MoveUp();
                        field.AddPlayerToBoard(playerTwo);
                    }
                    break;
                case ConsoleKey.S:
                    if (playerTwo != null && field.TableRows - 5 > playerTwo.PlayerPosition.Row)
                    {
                        field.RemovePlayerFromBoard(playerTwo);
                        playerTwo.MoveDown();
                        field.AddPlayerToBoard(playerTwo);
                    }
                    break;
            }
        }
        
    }
}
