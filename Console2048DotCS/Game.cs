namespace Console2048DotCS
{
    public class Game
    {
        public enum State
        {
            START,
            PLAY,
            GAME_OVER
        }

        public bool run = true;

        private State _state = State.START;

        private UI _ui = new UI();
        private Board _board = new Board();
        private KeyControl _keyControl = new KeyControl();
        private ScoreSaveLoader _scoreSaveLoader = new ScoreSaveLoader();

        public void InitGame()
        {
            _state = State.START;

            Console.CursorVisible = false; // 커서를 숨깁니다

            _keyControl.RegisterKey(ConsoleKey.UpArrow);
            _keyControl.RegisterKey(ConsoleKey.DownArrow);
            _keyControl.RegisterKey(ConsoleKey.RightArrow);
            _keyControl.RegisterKey(ConsoleKey.LeftArrow);
            _keyControl.RegisterKey(ConsoleKey.Escape);
            _keyControl.RegisterKey(ConsoleKey.Enter);
            _keyControl.RegisterKey(ConsoleKey.F1);

            _ui.PrintBoard();

            _board.InitBoard();

            _board.AddTile();
            _board.AddTile();

            _scoreSaveLoader.LoadScore();
            for (int i = 0; i < _scoreSaveLoader.rankScore.Length; i++)
            {
                var (score, date) = _scoreSaveLoader.rankScore[i];
                Console.SetCursorPosition(10, 9 + i * 2);
                Console.WriteLine(score);
                Console.SetCursorPosition(8, 10 + i * 2);
                Console.WriteLine($"({date})");
            }

            _state = State.PLAY;
        }

        public void Update()
        {
            if (_keyControl.IsKeyPressed(ConsoleKey.Escape))
            {
                run = false;
            }

            if (_keyControl.IsKeyPressed(ConsoleKey.Enter))
            {
                InitGame();
            }

            _keyControl.Update();

            if (_state == State.PLAY)
            {
                if (_board.CheckDeafed() == true)
                {
                    _state = State.GAME_OVER;

                    _scoreSaveLoader.SaveScore(_board.playerScore);

                    Beep.Play();
                    Beep.Play();
                    Beep.Play();
                }

                _board.Update(_keyControl);
            }
        }

        internal void Rander()
        {
            if (_state == State.PLAY)
            {
                _board.Render(_ui);
                _ui.PrintHit(_board.hit);
            }
            else if (_state == State.GAME_OVER)
            {
                _ui.PrintGameOver();
                _ui.PrintHit(Board.Move.NONE);
            }
        }
    }
}
