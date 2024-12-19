namespace Console2048DotCS
{
    public class Board : ICloneable
    {
        public enum Move
        {
            NONE,
            UP,
            DOWN,
            LEFT,
            RIGHT,
        }

        public ulong playerScore;
        public long moveScore;
        public static int boardSize = 4;
        public Move hit;

        private int[,] _gameBoard = new int[boardSize, boardSize];
        private Random _rand = new Random();

        public object Clone()
        {
            Board clone = new Board();
            clone._gameBoard = (int[,])this._gameBoard.Clone(); // 깊은 복사 수행
            return clone;
        }

        public void InitBoard()
        {
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    _gameBoard[i, j] = 0;
                }
            }
        }

        public void Update(KeyControl keyControl)
        {
            int score = 0;

            if (keyControl.IsKeyPressed(ConsoleKey.UpArrow))
            {
                score = MoveUp();
            }
            else if (keyControl.IsKeyPressed(ConsoleKey.DownArrow))
            {
                score = MoveDown();
            }
            else if (keyControl.IsKeyPressed(ConsoleKey.LeftArrow))
            {
                score = MoveLeft();
            }
            else if (keyControl.IsKeyPressed(ConsoleKey.RightArrow))
            {
                score = MoveRight();
            }
            else if (keyControl.IsKeyPressed(ConsoleKey.F1))
            {
                SetDefeatConditionForDebug();
            }

            if (score != 0)
            {
                moveScore = score;
                hit = SarchNextHint();

                if (playerScore == 0 && moveScore == -1)
                {
                    playerScore = 0;
                }
                else
                {
                    playerScore += (ulong)moveScore;
                }

                if (score > 0)
                {
                    Beep.Play(Tone.Gsharp, Duration.SIXTEENTH);
                    AddTile();
                }
                else if (score < 0)
                {
                    Beep.Play();
                }
            }
        }

        public void Render(UI ui)
        {
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    if (_gameBoard[i, j] != 0)
                    {
                        ui.PrintTile(i, j, _gameBoard[i, j]);
                    }
                    else
                    {
                        ui.ClearTile(i, j);
                    }
                }
            }
        }

        public bool AddTile()
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

        public bool CheckDeafed()
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

        private Dictionary<Move, int> _moveScores = new Dictionary<Move, int>();
        public Move SarchNextHint()
        {

            Board tempBoard = (Board)this.Clone();
            _moveScores[Move.UP] = tempBoard.MoveUp();

            tempBoard = (Board)this.Clone();
            _moveScores[Move.DOWN] = tempBoard.MoveDown();

            tempBoard = (Board)this.Clone();
            _moveScores[Move.LEFT] = tempBoard.MoveLeft();

            tempBoard = (Board)this.Clone();
            _moveScores[Move.RIGHT] = tempBoard.MoveRight();

            // 모든 점수가 -1이면 NONE 반환
            if (_moveScores.All(m => m.Value < 0))
            {
                return Move.NONE;
            }

            // 가장 높은 점수를 가진 방향 반환
            Move bestMove = _moveScores.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;

            return bestMove;
        }

        private void SetDefeatConditionForDebug()
        {
            Random random = new Random();
            int[] possibleNumbers = { 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024, 2048 };

            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    int number;
                    do
                    {
                        number = possibleNumbers[random.Next(possibleNumbers.Length)];
                    }
                    while (!IsPlacementValid(_gameBoard, i, j, number));

                    _gameBoard[i, j] = number;
                }
            }
        }

        private bool IsPlacementValid(int[,] grid, int row, int col, int number)
        {
            // 좌우로 이웃하는 타일 검사
            if (col > 0 && grid[row, col - 1] == number)
            {
                return false;
            }

            // 위 아래로 이웃하는 타일 검사
            if (row > 0 && grid[row - 1, col] == number)
            {
                return false;
            }

            return true;
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

        private int MoveUp()
        {
            int score = -1;

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

                            if (score == -1)
                            {
                                score = 1;
                            }
                        }

                        if (rowIndex > 0 && _gameBoard[rowIndex - 1, j] == _gameBoard[rowIndex, j])
                        {
                            _gameBoard[rowIndex - 1, j] *= 2;
                            _gameBoard[rowIndex, j] = 0;

                            score += _gameBoard[rowIndex - 1, j];
                        }
                    }
                }
            }

            return score;
        }

        private int MoveDown()
        {
            int score = -1;

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

                            if (score == -1)
                            {
                                score = 1;
                            }
                        }

                        if (rowIndex < boardSize - 1 && _gameBoard[rowIndex + 1, j] == _gameBoard[rowIndex, j])
                        {
                            _gameBoard[rowIndex + 1, j] *= 2;
                            _gameBoard[rowIndex, j] = 0;

                            score += _gameBoard[rowIndex + 1, j];
                        }
                    }
                }
            }
            return score;
        }

        private int MoveLeft()
        {
            int score = -1;

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
                            if (score == -1)
                            {
                                score = 1;
                            }
                        }

                        if (columnIndex > 0 && _gameBoard[i, columnIndex - 1] == _gameBoard[i, columnIndex])
                        {
                            _gameBoard[i, columnIndex - 1] *= 2;
                            _gameBoard[i, columnIndex] = 0;

                            score += _gameBoard[columnIndex - 1, j];
                        }
                    }
                }
            }

            return score;
        }

        private int MoveRight()
        {
            int score = -1;

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
                            if (score == -1)
                            {
                                score = 1;
                            }
                        }

                        if (columnIndex < boardSize - 1 && _gameBoard[i, columnIndex + 1] == _gameBoard[i, columnIndex])
                        {
                            _gameBoard[i, columnIndex + 1] *= 2;
                            _gameBoard[i, columnIndex] = 0;

                            score += _gameBoard[i, columnIndex + 1];
                        }
                    }
                }
            }

            return score;
        }
    }
}
