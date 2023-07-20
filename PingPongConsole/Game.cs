using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PingPongConsole
{
    internal class Game
    {

        private PlayerClass _playerOne;
        private PlayerClass _playerTwo;
        private BallClass _ball;
        private TableClass _field;
        private InputHandlerClass _inputHandler;
        private ScoreCardClass _scoreCard;
        private MainMenu _mainMenu;

        private bool _isGameModeSelected = false;
        private string _modeSelected = "";
        private bool _isScore = false;
        private bool _isGameOver = false;
        private int _ballDirection = -1;
        
        private int _rows;
        private int _columns;

        private int _scorePlayerOne = 0;
        private int _scorePlayerTwo = 0;


        public Game(int rows = 26, int columns = 100)
        {
            _playerOne = new PlayerClass(rows/2, 3, 4);
            _playerTwo = new PlayerClass(rows/2, 96, 4);
            _ball = new BallClass(rows/2 , columns/2 );
            _field = new TableClass(rows, columns);
            _rows = rows;
            _columns = columns;
            _mainMenu = new MainMenu();
            _scoreCard = new ScoreCardClass();
        }

        /// <summary>
        /// Run game
        /// </summary>
        public void RunGame()
        {
            ModeSelection();

            Console.Clear();
            Console.CursorVisible = false;

            var ballWorker = new Thread(UpdateFrame);
            ballWorker.Start();

            _field.GenerateTable();
            _field.AddPlayerToBoard(_playerOne);
            _field.AddPlayerToBoard(_playerTwo);
            _field.AddBallToBoard(_ball);

            do
            {
                _inputHandler.UserInputMovement();
            } while (!_isGameOver);
        }


        /// <summary>
        /// Select single player vs multi-player
        /// </summary>
        public void ModeSelection()
        {
            _mainMenu.DrawSelectorArrow(38,9);
            do
            {
                _mainMenu.PrintTitle(40);
                _mainMenu.PrintOnePlayer(40);
                _mainMenu.PrintTwoPlayers(40);
                ConsoleKeyInfo input = Console.ReadKey(true);
                if (input.Key == ConsoleKey.Enter)
                {
                    _modeSelected = _mainMenu.UserSelection();
                    _isGameModeSelected = true;
                }
                else
                {
                    _mainMenu.UserInput(input, 38);
                }
            } while (_isGameModeSelected != true);

            switch (_modeSelected)
            {
                case "one":
                    _inputHandler = new InputHandlerClass(_playerOne,  _field);
                    break;
                case "two":
                    _inputHandler = new InputHandlerClass(_playerOne, _playerTwo, _field);
                    break;
                    
            }
        }


        /// <summary>
        /// Update Frame of the game
        /// </summary>
        public void UpdateFrame()
        {
            do
            {
                Console.SetCursorPosition(0, 0);
                CheckIsGameOver();
                PrintScoreCard();

                _field.RemoveBallFromBoard(_ball);
                _ball.BallMovement();
                CheckCollisions();
                _field.AddBallToBoard(_ball);
                _field.AddPlayerToBoard(_playerOne);
                _field.AddPlayerToBoard(_playerTwo);
                _field.PrintTable();
                if (_isScore)
                {
                    TableSetup();
                }

            } while (!_isGameOver );
        }

        /// <summary>
        /// Check for collisions
        /// </summary>
        public void CheckCollisions()
        {
            CheckRacketCollision(_playerOne);
            CheckRacketCollision(_playerTwo);
            CheckWallCollision();
        }

        /// <summary>
        /// Check is ball colliding with Wall, if yes changes ball changes ball velocity
        /// </summary>
        public void CheckRacketCollision(PlayerClass player)
        {
            if (player.PlayerPosition.Row == _ball.BallPosition.Row && player.PlayerPosition.Column == _ball.BallPosition.Column)
            {
                _ballDirection *= -1;
                _ball.BallVelocity = new PixelPoint(-1, _ballDirection);
            }
            else if ((player.PlayerPosition.Row + 1 == _ball.BallPosition.Row || player.PlayerPosition.Row + 2 == _ball.BallPosition.Row) && player.PlayerPosition.Column == _ball.BallPosition.Column)
            {
                _ballDirection *= -1;
                _ball.BallVelocity = new PixelPoint(0, _ballDirection);
            }
            else if (player.PlayerPosition.Row + 3 == _ball.BallPosition.Row && player.PlayerPosition.Column == _ball.BallPosition.Column)
            {
                _ballDirection *= -1;
                _ball.BallVelocity = new PixelPoint(1, _ballDirection);
            }
        }

        /// <summary>
        /// Check is ball colliding with Racket, if yes changes ball changes ball velocity
        /// </summary>
        public void CheckWallCollision()
        {
            if (_ball.BallPosition.Row == 0)
            {
                //upper boundary
                _ball.BallVelocity = new PixelPoint(1, _ballDirection);
            }
            else if (_ball.BallPosition.Row == _field.TableRows - 1)
            {
                //lower boundary
                _ball.BallVelocity = new PixelPoint(-1, _ballDirection);
            }
            else if (_ball.BallPosition.Column == _field.TableColumns - 1)
            {
                _ball.BallVelocity = new PixelPoint(0, -1);
                //score
                _scorePlayerOne++;
                _isScore = true;
            }
            else if (_ball.BallPosition.Column == 0)
            {
                _ball.BallVelocity = new PixelPoint(0, 1);
                //score
                _scorePlayerTwo++;
                _isScore = true;
            }

        }

        /// <summary>
        /// Prints score card
        /// </summary>
        public void PrintScoreCard()
        {
            _scoreCard.PrintScore(_scorePlayerOne, _scorePlayerTwo);
        }

        /// <summary>
        /// Check has one of the players reached enough points to finish the game
        /// </summary>
        public void CheckIsGameOver()
        {
            if (_scorePlayerOne == 3 || _scorePlayerTwo == 3 )
            {
                _isGameOver = true;
            }
        }

        /// <summary>
        /// Resets Ball and Player positions after score
        /// </summary>
        public void TableSetup()
        {
            _field.RemovePlayerFromBoard(_playerOne);
            _field.RemovePlayerFromBoard(_playerTwo);
            _field.GenerateTable();

            _playerOne.PlayerPosition = new PixelPoint(_rows / 2, 3);
            _playerTwo.PlayerPosition = new PixelPoint(_rows / 2, 96);
            
            _ball.BallPosition = new PixelPoint(_rows / 2, _columns / 2);
            _ballDirection *= -1;
            _ball.BallVelocity = new PixelPoint(0, _ballDirection);
            _isScore = false;

        }
    }
}
