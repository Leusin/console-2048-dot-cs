namespace Console2048DotCS
{
    public class Board
    {
        static int boardSize = 4;
        int[,] gameBoard = new int[boardSize, boardSize];

        private Random _rand = new Random();

        private UI ui = new UI();

        public void InitGame()
        {
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    gameBoard[i, j] = 0;
                }
            }

            AddTile();
            AddTile();
        }

        public void Update(ConsoleKeyInfo key)
        {
            bool moved = false;

            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    {
                        moved = MoveUp();
                        break;
                    }
                case ConsoleKey.DownArrow:
                    {
                        moved = MoveDown();
                        break;
                    }
                case ConsoleKey.LeftArrow:
                    {
                        moved = MoveLeft();
                        break;
                    }
                case ConsoleKey.RightArrow:
                    {
                        moved = MoveRight();
                        break;
                    }
            }

            if(moved)
            {
                AddTile();
            }
        }

        public void Rander()
        {
            Console.Clear();

            ui.PrintBoard();

            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    if (gameBoard[i, j] != 0)
                    {
                        ui.PrintTile(i, j, gameBoard[i, j]);
                    }
                    else
                    {
                        ui.ClearTile(i, j);
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

                    if (gameBoard[x, y] == 0)
                    {
                        gameBoard[x, y] = (_rand.Next() % 2 + 1) * 2;
                        return true;
                    }
                }
            }

            return false;
        }

        private bool ContainZero()
        {
            foreach (int value in gameBoard)
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
                    if (gameBoard[i, j] == gameBoard[i, j + 1])
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
                    if (gameBoard[i, j] == gameBoard[i + 1, j])
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
                    if (gameBoard[i, j] != 0)
                    {
                        int rowIndex = i;

                        while (rowIndex > 0 && gameBoard[rowIndex - 1, j] == 0)
                        {
                            gameBoard[rowIndex - 1, j] = gameBoard[rowIndex, j];
                            gameBoard[rowIndex, j] = 0;
                            rowIndex--;
                            moved = true;
                        }

                        if (rowIndex > 0 && gameBoard[rowIndex - 1, j] == gameBoard[rowIndex, j])
                        {
                            gameBoard[rowIndex - 1, j] *= 2;
                            gameBoard[rowIndex, j] = 0;
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
                    if (gameBoard[i, j] != 0)
                    {
                        int rowIndex = i;

                        while (rowIndex < boardSize - 1 && gameBoard[rowIndex + 1, j] == 0)
                        {
                            gameBoard[rowIndex + 1, j] = gameBoard[rowIndex, j];
                            gameBoard[rowIndex, j] = 0;
                            rowIndex++;
                            moved = true;
                        }

                        if (rowIndex < boardSize - 1 && gameBoard[rowIndex + 1, j] == gameBoard[rowIndex, j])
                        {
                            gameBoard[rowIndex + 1, j] *= 2;
                            gameBoard[rowIndex, j] = 0;
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
                    if (gameBoard[i, j] != 0)
                    {
                        int columnIndex = j;

                        while (columnIndex > 0 && gameBoard[i, columnIndex - 1] == 0)
                        {
                            gameBoard[i, columnIndex - 1] = gameBoard[i, columnIndex];
                            gameBoard[i, columnIndex] = 0;
                            columnIndex--;
                            moved = true;
                        }

                        if (columnIndex > 0 && gameBoard[i, columnIndex - 1] == gameBoard[i, columnIndex])
                        {
                            gameBoard[i, columnIndex - 1] *= 2;
                            gameBoard[i, columnIndex] = 0;
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
                    if (gameBoard[i, j] != 0)
                    {
                        int columnIndex = j;

                        while (columnIndex < boardSize - 1 && gameBoard[i, columnIndex + 1] == 0)
                        {
                            gameBoard[i, columnIndex + 1] = gameBoard[i, columnIndex];
                            gameBoard[i, columnIndex] = 0;
                            columnIndex++;
                            moved = true;
                        }

                        if (columnIndex < boardSize - 1 && gameBoard[i, columnIndex + 1] == gameBoard[i, columnIndex])
                        {
                            gameBoard[i, columnIndex + 1] *= 2;
                            gameBoard[i, columnIndex] = 0;
                            moved = true;
                        }
                    }
                }
            }

            return moved;
        }
    }
}
