
using System.Text;

namespace Console2048DotCS
{
    public class Game
    {
        public enum State
        {
            Init,
            OnPlay,
            GameOver
        }

        public bool run = true;

        private State _state = State.Init;

        private UI _ui = new UI();
        private Board _board = new Board();
        private KeyControl _keyControl = new KeyControl();


        public void InitGame()
        {
            _state = State.Init;

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

            _state = State.OnPlay;
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

            if (_state == State.OnPlay)
            {
                if (_board.CheckDeafed() == true)
                {
                    _state = State.GameOver;

                    Beep.Play();
                    Beep.Play();
                    Beep.Play();
                }

                _board.Update(_keyControl);
            }
        }

        internal void Rander()
        {
            if (_state == State.OnPlay)
            {
                _board.Render(_ui);
            }
            else if (_state == State.GameOver)
            {
                _ui.PrintGameOver();
            }
        }
    }
}
