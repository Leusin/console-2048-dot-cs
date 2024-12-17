using System;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Console2048DotCS
{
    public class UI
    {
        const int indent = 36;

        public void PrintBoard()
        {
            ScreenPrint(indent, 0, "   _____  ___ ________  __   ______________     \n");
            ScreenPrint(indent, 1, "  /  __ \\/  //_____  / /  | /  /_  _  __/ /_    \n");
            ScreenPrint(indent, 2, " /  / / /  /___--_/_/ /   |/  /_/ // /_/  _/____.____");
            ScreenPrint(indent, 3, "/  /_/ /  //________// /| |  _/________/_// ___//  __/");
            ScreenPrint(indent, 4, "\\_____/  / / ____ `//_/ |_| / /======  | / /___._` \\");
            ScreenPrint(indent, 5, "     /__/  \\______/     /__/  \\__======(_)____/_____/");

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

        private void ScreenPrint(int x, int y, string str)//x, y좌표에 string을 출력한다 
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(str);
        }
    }
}
