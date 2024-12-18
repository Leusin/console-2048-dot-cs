
namespace Console2048DotCS
{
    public class Game
    {
        private UI _ui = new UI();
        private Board _board = new Board();
        private KeyControl _keyControl = new KeyControl();


        public void InitGame()
        {
            _keyControl.RegisterKey(ConsoleKey.UpArrow);
            _keyControl.RegisterKey(ConsoleKey.DownArrow);
            _keyControl.RegisterKey(ConsoleKey.RightArrow);
            _keyControl.RegisterKey(ConsoleKey.LeftArrow);
            _keyControl.RegisterKey(ConsoleKey.Escape);

            _ui.PrintBoard();

            _board.InitBoard();

            _board.AddTile();
            _board.AddTile();
        }

        public void Update()
        {
            _keyControl.Update();
            _board.Update(_keyControl);
        }

        internal void Rander()
        {
            _board.Rander(_ui);

            if (_board.CheckDeafed() == true)
            {

            }
        }
    }
}
