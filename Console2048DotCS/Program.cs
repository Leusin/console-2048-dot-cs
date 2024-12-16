// See https://aka.ms/new-console-template for more information
using Console2048DotCS;
using System.Text;

Console.WriteLine("Hello, World!");
Console.WriteLine("ESC 키를 누르면 프로그램이 종료됩니다.");


int playerScore = 0;
int moveSocre = 0;

var board = new Board();

board.InitGame();

Console.CursorVisible = false; // 커서를 숨깁니다
var key = Console.ReadKey(true); // true: 입력한 키를 화면에 표시하지 않음

while (true)
{
    // 키 입력이 있을 때만 처리
    if (Console.KeyAvailable != true)
    {
        continue;
    }

        if (key.Key == ConsoleKey.Escape)
    {
        break;
    }

    {   
        Console.SetCursorPosition(0, 0);
        Console.WriteLine($"입력한 키: {key.Key}");

        board.Rander();
    }
}
// 프로그램 종료 후 커서 표시
Console.CursorVisible = true;