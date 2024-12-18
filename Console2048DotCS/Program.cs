using Console2048DotCS;

var board = new Board();

board.InitGame();
board.Rander();

Console.CursorVisible = false; // 커서를 숨깁니다

while (true)
{
    board.Update();
    board.Rander();
}