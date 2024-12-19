using static Console2048DotCS.Board;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Console2048DotCS
{
    public class UI
    {
        const int indent = 36;

        public void PrintBoard()
        {
            ScreenPrint(indent - 1, 0, "   _____  ___ ________  __   ______________     \n");
            ScreenPrint(indent - 1, 1, "  /  __ \\/  //_____  / /  | /  /_  _  __/ /_    \n");
            ScreenPrint(indent - 1, 2, " /  / / /  /___--_/_/ /   |/  /_/ // /_/  _/____.____");
            ScreenPrint(indent - 1, 3, "/  /_/ /  //________// /| |  _/________/_// ___//  __/");
            ScreenPrint(indent - 1, 4, "\\_____/  / / ____ `//_/ |_| / /======  |_/ /___._` \\");
            ScreenPrint(indent - 1, 5, "     /__/  \\______/     /__/  \\__======(_)____/_____/");

            ScreenPrint(indent, 7, "┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
            ScreenPrint(indent, 8, "┃                                                  ┃");
            ScreenPrint(indent, 9, "┃                                                  ┃");
            ScreenPrint(indent, 10, "┃                                                  ┃");
            ScreenPrint(indent, 11, "┃                                                  ┃");
            ScreenPrint(indent, 12, "┃                                                  ┃");
            ScreenPrint(indent, 13, "┃                                                  ┃");
            ScreenPrint(indent, 14, "┃                                                  ┃");
            ScreenPrint(indent, 15, "┃                                                  ┃");
            ScreenPrint(indent, 16, "┃                                                  ┃");
            ScreenPrint(indent, 17, "┃                                                  ┃");
            ScreenPrint(indent, 18, "┃                                                  ┃");
            ScreenPrint(indent, 19, "┃                                                  ┃");
            ScreenPrint(indent, 20, "┃                                                  ┃");
            ScreenPrint(indent, 21, "┃                                                  ┃");
            ScreenPrint(indent, 22, "┃                                                  ┃");
            ScreenPrint(indent, 23, "┃                                                  ┃");
            ScreenPrint(indent, 24, "┃                                                  ┃");
            ScreenPrint(indent, 25, "┃                                                  ┃");
            ScreenPrint(indent, 26, "┃                                                  ┃");
            ScreenPrint(indent, 27, "┃                                                  ┃");
            ScreenPrint(indent, 28, "┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");

            ScreenPrint(13, 1, "  만든 사람: 김주영");
            ScreenPrint(13, 2, "-------------------");
            ScreenPrint(13, 3, "         2024-12-19");
            ScreenPrint(13, 4, "           (v1.0.0)");

            ScreenPrint(5, 7, "}----- R A N K I N G -----{");
            ScreenPrint(6, 8, "|                       |");
            ScreenPrint(6, 9, "│ 1.                    │");
            ScreenPrint(6, 10, "│                       │");
            ScreenPrint(6, 11, "│ 2.                    │");
            ScreenPrint(6, 12, "│                       │");
            ScreenPrint(6, 13, "│ 3.                    │");
            ScreenPrint(6, 14, "│                       │");
            ScreenPrint(6, 15, "│ 4.                    │");
            ScreenPrint(6, 16, "│                       │");
            ScreenPrint(6, 17, "│ 5.                    │");
            ScreenPrint(6, 18, "│                       │");
            ScreenPrint(6, 19, "│ 6.                    │");
            ScreenPrint(6, 20, "│                       │");
            ScreenPrint(6, 21, "│ 7.                    │");
            ScreenPrint(6, 22, "│                       │");
            ScreenPrint(6, 23, "│ 8.                    │");
            ScreenPrint(6, 24, "│                       │");
            ScreenPrint(6, 25, "│ 9.                    │");
            ScreenPrint(6, 26, "|                       |");
            ScreenPrint(5, 27, "}========================={");

            ScreenPrint(92, 1, "조작법");
            ScreenPrint(92, 2, "-------------------");
            ScreenPrint(92, 3, "타일 이동 : ↑ ↓ ← →");
            ScreenPrint(92, 4, "재시작 : Enter");
            ScreenPrint(92, 5, "종료 : Escape");

            ScreenPrint(92, 8, "┌ --→ H I N T ←-- ┐");
            ScreenPrint(92, 9, "│  +-----------+  │");
            ScreenPrint(92, 10, "│  |     △     |  │");
            ScreenPrint(92, 11, "│  |  ◁  ○  ▷  |  │");
            ScreenPrint(92, 12, "│  |     ▽     |  │");
            ScreenPrint(92, 13, "│  +-----------+  │");
            ScreenPrint(92, 14, "└ --------------- ┘");
        }

        public void PrintTile(int row, int col, int number)
        {
            int totalWidth = 10; // 한 줄의 최대 출력 너비
            string numberString = number.ToString(); // 숫자를 문자열로 변환

            // 첫 번째 줄 출력: 최대 totalWidth 만큼만 잘라서 출력
            string firstLine = numberString.Length > totalWidth
                ? numberString.Substring(0, totalWidth)
                : numberString;

            // 두 번째 줄 출력: 나머지 부분 출력
            string secondLine = numberString.Length > totalWidth
                ? numberString.Substring(totalWidth)
                : "";

            // 박스 그리기
            ScreenPrint(col * 12 + (indent + 2), row * 5 + 8, "┌──────────┐");
            ScreenPrint(col * 12 + (indent + 2), row * 5 + 9, "│          │");
            ScreenPrint(col * 12 + (indent + 2), row * 5 + 10, $"│{firstLine.PadLeft((totalWidth - firstLine.Length) / 2 + firstLine.Length).PadRight(totalWidth)}│");
            ScreenPrint(col * 12 + (indent + 2), row * 5 + 11, secondLine.Length > 0
                ? $"│{secondLine.PadLeft((totalWidth - secondLine.Length) / 2 + secondLine.Length).PadRight(totalWidth)}│"
                : "│          │");
            ScreenPrint(col * 12 + (indent + 2), row * 5 + 12, "└──────────┘");
        }

        public void ClearTile(int row, int col)
        {
            // 박스 그리기
            ScreenPrint(col * 12 + (indent + 2), row * 5 + 8, "            ");
            ScreenPrint(col * 12 + (indent + 2), row * 5 + 9, "            ");
            ScreenPrint(col * 12 + (indent + 2), row * 5 + 10, "            ");
            ScreenPrint(col * 12 + (indent + 2), row * 5 + 11, "            ");
            ScreenPrint(col * 12 + (indent + 2), row * 5 + 12, "            ");
        }

        public void PrintHit(Move hint)
        {
            switch (hint)
            {
                case Move.NONE:
                    {
                        ScreenPrint(92, 8, "┌ --→ H I N T ←-- ┐");
                        ScreenPrint(92, 9, "│  +-----------+  │");
                        ScreenPrint(92, 10, "│  |     △     |  │");
                        ScreenPrint(92, 11, "│  |  ◁  ○  ▷  |  │");
                        ScreenPrint(92, 12, "│  |     ▽     |  │");
                        ScreenPrint(92, 13, "│  +-----------+  │");
                        ScreenPrint(92, 14, "└ --------------- ┘");
                        break;
                    }
                case Move.LEFT:
                    {
                        ScreenPrint(92, 8, "┌ --→ H I N T ←-- ┐");
                        ScreenPrint(92, 9, "│  +-----------+  │");
                        ScreenPrint(92, 10, "│  |     △     |  │");
                        ScreenPrint(92, 11, "│  |  ◀  ←  ▷  |  │");
                        ScreenPrint(92, 12, "│  |     ▽     |  │");
                        ScreenPrint(92, 13, "│  +-----------+  │");
                        ScreenPrint(92, 14, "└ --------------- ┘");
                        break;
                    }
                case Move.RIGHT:
                    {
                        ScreenPrint(92, 8, "┌ --→ H I N T ←-- ┐");
                        ScreenPrint(92, 9, "│  +-----------+  │");
                        ScreenPrint(92, 10, "│  |     △     |  │");
                        ScreenPrint(92, 11, "│  |  ◁  →  ▶  |  │");
                        ScreenPrint(92, 12, "│  |     ▽     |  │");
                        ScreenPrint(92, 13, "│  +-----------+  │");
                        ScreenPrint(92, 14, "└ --------------- ┘");
                        break;
                    }
                case Move.UP:
                    {
                        ScreenPrint(92, 8, "┌ --→ H I N T ←-- ┐");
                        ScreenPrint(92, 9, "│  +-----------+  │");
                        ScreenPrint(92, 10, "│  |     ▲     |  │");
                        ScreenPrint(92, 11, "│  |  ◁  ↑  ▷  |  │");
                        ScreenPrint(92, 12, "│  |     ▽     |  │");
                        ScreenPrint(92, 13, "│  +-----------+  │");
                        ScreenPrint(92, 14, "└ --------------- ┘");
                        break;
                    }
                case Move.DOWN:
                    {
                        ScreenPrint(92, 8, "┌ --→ H I N T ←-- ┐");
                        ScreenPrint(92, 9, "│  +-----------+  │");
                        ScreenPrint(92, 10, "│  |     △     |  │");
                        ScreenPrint(92, 11, "│  |  ◁  ↓  ▷  |  │");
                        ScreenPrint(92, 12, "│  |     ▼     |  │");
                        ScreenPrint(92, 13, "│  +-----------+  │");
                        ScreenPrint(92, 14, "└ --------------- ┘");
                        break;
                    }
            }
        }


        public void PrintScores(ulong best, ulong current, long move)
        {
            int totalWidth = 22; // 한 줄의 최대 출력 너비

            string bestString = best.ToString();
            ScreenPrint(92, 16, "┌----------------------┐");
            ScreenPrint(92, 17, "│ 최고 점수:           │ ");
            ScreenPrint(92, 18, $"│{bestString.PadLeft((totalWidth - bestString.Length) / 2 + bestString.Length).PadRight(totalWidth)}│ ");
            ScreenPrint(92, 19, "└----------------------┘");

            string currentString = current.ToString();
            ScreenPrint(92, 20, "┌----------------------┐");
            ScreenPrint(92, 21, "│ 현재 점수:           │ ");
            ScreenPrint(92, 22, $"│{currentString.PadLeft((totalWidth - currentString.Length) / 2 + currentString.Length).PadRight(totalWidth)}│ ");
            ScreenPrint(92, 23, "└----------------------┘");


            string moveString = move.ToString();
            ScreenPrint(92, 24, "┌----------------------┐");
            ScreenPrint(92, 25, "│ 이동 점수:           │ ");
            ScreenPrint(92, 26, $"│{moveString.PadLeft((totalWidth - moveString.Length) / 2 + moveString.Length).PadRight(totalWidth)}│ ");
            ScreenPrint(92, 27, "└----------------------┘");
        }

        public void PrintGameOver()
        {
            ScreenPrint(48, 16, " ┏━━━━━━━━━━━━━━━━━━━━━━━━━┓ ");
            ScreenPrint(48, 17, " ┃  = G A M E  O V E R =   ┃ ");
            ScreenPrint(48, 18, " ┗━━━━━━━━━━━━━━━━━━━━━━━━━┛ ");
        }

        private void ScreenPrint(int x, int y, string str)//x, y좌표에 string을 출력한다 
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(str);
        }
    }
}
