using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace PingPongConsole
{
    internal class TableClass
    {
        private const string Wall = "█";
        private const string UpperBoundary = "▀";
        private const string LowerBoundary = "▄";
        private const string EmptySpace = " ";
        private const string Ball = "O";

        public int TableColumns
        {
            get;
            set;
        }

        public int TableRows
        {
            get;
            set;
        }


        public string[,] Table
        {
            get;
            set;
        }


        public TableClass(int rows = 20, int columns = 100 )
        {
            TableRows = rows;
            TableColumns = columns;
            Table = new string[rows, columns];
        }

        /// <summary>
        /// Generate table with players
        /// </summary>
        public void GenerateTable()
        {

            for (int row = 0; row < TableRows; row++)
            {
                Table[row, 0] = Wall;
                Table[row, TableColumns - 1] = Wall;
            }

            for (int column = 0; column < TableColumns; column++)
            {
                if (column == 0 || column == TableColumns - 1  )
                {
                    Table[0, column] = Wall;
                    continue;
                }
                Table[0, column] = UpperBoundary;
                Table[TableRows - 1, column] = LowerBoundary;
            }
            

        }

        /// <summary>
        /// Print table
        /// </summary>
        public void PrintTable()
        {
            
            for (int row = 0; row < TableRows; row++)
            {
                for (int column = 0; column < TableColumns; column++)
                {
                    string output = " ";
                    if (Table[row, column] != null )
                    {
                        output = Table[row, column];
                    }
                    Console.Write(output);
                }
                Console.WriteLine();
            }
        }


        /// <summary>
        /// Adds player to the board
        /// </summary>
        /// <param name="player"></param>
        public void AddPlayerToBoard(PlayerClass player)
        {
            for (int i = 0; i < player.Size; i++)
            {
                Table[player.PlayerPosition.Row + i, player.PlayerPosition.Column] = Wall;
            }

        }

        /// <summary>
        /// Removes player from the board
        /// </summary>
        /// <param name="player"></param>
        public void RemovePlayerFromBoard(PlayerClass player)
        {
            for (int i = 0; i < player.Size; i++)
            {
                Table[player.PlayerPosition.Row + i, player.PlayerPosition.Column] = EmptySpace;
            }

        }

        /// <summary>
        /// Add ball to the board
        /// </summary>
        /// <param name="ball"></param>
        public void AddBallToBoard(BallClass ball)
        {
            int pointX = ball.BallPosition.Row;

            // adds ball to the table on new position
            if (IsInBounds(pointX))
            {
                Table[ball.BallPosition.Row, ball.BallPosition.Column] = Ball;
            }
        }

        /// <summary>
        /// Remove ball from the board
        /// </summary>
        /// <param name="ball"></param>
        public void RemoveBallFromBoard(BallClass ball)
        {
            int pointX = ball.BallPosition.Row;

            // cleans ball trail
            if (IsInBounds(pointX))
            {
                Table[ball.BallPosition.Row, ball.BallPosition.Column] = EmptySpace;
            }
        }

        /// <summary>
        /// check is ball inbound
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public bool IsInBounds(int x)
        {
            return (x != 0 && x != TableRows-1);
        }


    }
}
