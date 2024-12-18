namespace Console2048DotCS
{
    public class Board
    {
        public static int boardSize = 4;
        private int[,] _gameBoard = new int[boardSize, boardSize];

        private Random _rand = new Random();

        private UI _ui = new UI();
        private KeyControl _keyControl = new KeyControl();


        public void InitGame()
        {
            _keyControl.RegisterKey(ConsoleKey.UpArrow);
            _keyControl.RegisterKey(ConsoleKey.DownArrow);
            _keyControl.RegisterKey(ConsoleKey.RightArrow);
            _keyControl.RegisterKey(ConsoleKey.LeftArrow);
            _keyControl.RegisterKey(ConsoleKey.Escape);

            _ui.PrintBoard();

            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    _gameBoard[i, j] = 0;
                }
            }

            AddTile();
            AddTile();
        }

        public void Update()
        {
            _keyControl.Update();

            bool moved = false;

            if(_keyControl.IsKeyPressed(ConsoleKey.UpArrow))
            {
                moved = MoveUp();
            }

            if (_keyControl.IsKeyPressed(ConsoleKey.DownArrow))
            {
                moved = MoveDown();
            }

            if (_keyControl.IsKeyPressed(ConsoleKey.LeftArrow))
            {
                moved = MoveLeft();
            }

            if (_keyControl.IsKeyPressed(ConsoleKey.RightArrow))
            {
                moved = MoveRight();
            }

            if(moved)
            {
                AddTile();
                Console.Beep();
            }
        }

        public void Rander()
        {
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    if (_gameBoard[i, j] != 0)
                    {
                        _ui.PrintTile(i, j, _gameBoard[i, j]);
                    }
                    else
                    {
                        _ui.ClearTile(i, j);
                    }
                }
            }
        }

        private bool AddTile()
        {
            if (ContainZero())
            {
                while (true)
                {
                    int x = _rand.Next() % boardSize;
                    int y = _rand.Next() % boardSize;

                    if (_gameBoard[x, y] == 0)
                    {
                        _gameBoard[x, y] = (_rand.Next() % 2 + 1) * 2;
                        return true;
                    }
                }
            }

            return false;
        }

        private bool ContainZero()
        {
            foreach (int value in _gameBoard)
            {
                if (value == 0)
                {
                    return true;
                }
            }
            return false;
        }

        private bool CheckDeafed()
        {
            if (ContainZero())
            {
                return false;
            }

            // 가로로 같은 값이 있는지 확인
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize - 1; j++)
                {
                    if (_gameBoard[i, j] == _gameBoard[i, j + 1])
                    {
                        return false;
                    }
                }
            }

            // 세로로 같은 값이 있는지 확인
            for (int i = 0; i < boardSize - 1; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    if (_gameBoard[i, j] == _gameBoard[i + 1, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private bool MoveUp()
        {
            bool moved = false;

            for (int j = 0; j < boardSize; j++)
            {
                for (int i = 1; i < boardSize; i++)
                {
                    if (_gameBoard[i, j] != 0)
                    {
                        int rowIndex = i;

                        while (rowIndex > 0 && _gameBoard[rowIndex - 1, j] == 0)
                        {
                            _gameBoard[rowIndex - 1, j] = _gameBoard[rowIndex, j];
                            _gameBoard[rowIndex, j] = 0;
                            rowIndex--;
                            moved = true;
                        }

                        if (rowIndex > 0 && _gameBoard[rowIndex - 1, j] == _gameBoard[rowIndex, j])
                        {
                            _gameBoard[rowIndex - 1, j] *= 2;
                            _gameBoard[rowIndex, j] = 0;
                            moved = true;
                        }
                    }
                }
            }

            return moved;
        }

        private bool MoveDown()
        {
            bool moved = false;

            for (int j = 0; j < boardSize; j++)
            {
                for (int i = boardSize - 2; i > -1; i--)
                {
                    if (_gameBoard[i, j] != 0)
                    {
                        int rowIndex = i;

                        while (rowIndex < boardSize - 1 && _gameBoard[rowIndex + 1, j] == 0)
                        {
                            _gameBoard[rowIndex + 1, j] = _gameBoard[rowIndex, j];
                            _gameBoard[rowIndex, j] = 0;
                            rowIndex++;
                            moved = true;
                        }

                        if (rowIndex < boardSize - 1 && _gameBoard[rowIndex + 1, j] == _gameBoard[rowIndex, j])
                        {
                            _gameBoard[rowIndex + 1, j] *= 2;
                            _gameBoard[rowIndex, j] = 0;
                            moved = true;
                        }
                    }
                }
            }
            return moved;
        }

        private bool MoveLeft()
        {
            bool moved = false;

            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 1; j < boardSize; j++)
                {
                    if (_gameBoard[i, j] != 0)
                    {
                        int columnIndex = j;

                        while (columnIndex > 0 && _gameBoard[i, columnIndex - 1] == 0)
                        {
                            _gameBoard[i, columnIndex - 1] = _gameBoard[i, columnIndex];
                            _gameBoard[i, columnIndex] = 0;
                            columnIndex--;
                            moved = true;
                        }

                        if (columnIndex > 0 && _gameBoard[i, columnIndex - 1] == _gameBoard[i, columnIndex])
                        {
                            _gameBoard[i, columnIndex - 1] *= 2;
                            _gameBoard[i, columnIndex] = 0;
                            moved = true;
                        }
                    }
                }
            }

            return moved;
        }

        private bool MoveRight()
        {
            bool moved = false;

            for (int i = 0; i < boardSize; i++)
            {
                for (int j = boardSize - 2; j > -1; j--)
                {
                    if (_gameBoard[i, j] != 0)
                    {
                        int columnIndex = j;

                        while (columnIndex < boardSize - 1 && _gameBoard[i, columnIndex + 1] == 0)
                        {
                            _gameBoard[i, columnIndex + 1] = _gameBoard[i, columnIndex];
                            _gameBoard[i, columnIndex] = 0;
                            columnIndex++;
                            moved = true;
                        }

                        if (columnIndex < boardSize - 1 && _gameBoard[i, columnIndex + 1] == _gameBoard[i, columnIndex])
                        {
                            _gameBoard[i, columnIndex + 1] *= 2;
                            _gameBoard[i, columnIndex] = 0;
                            moved = true;
                        }
                    }
                }
            }

            return moved;
        }
    }
}
