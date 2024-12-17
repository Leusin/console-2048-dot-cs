using Console2048DotCS;

int playerScore = 0;
int moveSocre = 0;

var board = new Board();

board.InitGame();
board.Rander();

DateTime lastKeyPressTime = DateTime.MinValue;
TimeSpan keyPressInterval = TimeSpan.FromMilliseconds(200); // 최소 입력 간격

Console.CursorVisible = false; // 커서를 숨깁니다
ConsoleKeyInfo key;
while (true)
{
    // 키 입력 처리
    DateTime currentTime = DateTime.Now;

    // 최소 입력 간격 조건 확인
    if (currentTime - lastKeyPressTime > keyPressInterval)
    {
        key = Console.ReadKey(true); // true: 입력한 키를 화면에 표시하지 않음

        if (key.Key == ConsoleKey.Escape)
        {
            break;
        }

        board.Update(key);
        board.Rander();

        Console.WriteLine($"You pressed: {key.Key}");

        lastKeyPressTime = currentTime;

        // 입력 버퍼 클리어
        while (Console.KeyAvailable)
        {
            Console.ReadKey(true);
        }
    }
}

// 프로그램 종료 후 커서 표시
Console.CursorVisible = true;