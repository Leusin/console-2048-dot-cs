using Console2048DotCS;

var game = new Game();

game.InitGame();
game.Rander();

Console.CursorVisible = false; // 커서를 숨깁니다

while (true)
{
    game.Update();
    game.Rander();
}