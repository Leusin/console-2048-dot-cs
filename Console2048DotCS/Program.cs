using Console2048DotCS;

var game = new Game();

game.InitGame();

while (game.run)
{
    game.Update();
    game.Rander();
}