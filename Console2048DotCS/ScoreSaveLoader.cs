using System;
using System.IO;

namespace Console2048DotCS
{
    public class ScoreSaveLoader
    {
        public (ulong score, string date)[] rankScore = new (ulong, string)[9];
        public readonly string filePath = "scores.txt";

        public void SaveScore(ulong score)
        {
            try
            {
                // 현재 날짜와 시간 가져오기
                string currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                // 점수를 파일에 추가
                using (StreamWriter writer = new StreamWriter(filePath, append: true))
                {
                    writer.WriteLine($"{score},{currentTime}");
                }
            }
            catch (Exception ex)
            {
                PrintMessage($"파일을 열거나 기록하는 중 오류가 발생했습니다: {ex.Message}");
            }
        }

        public void LoadScore()
        {
            try
            {
                if (File.Exists(filePath))
                {
                    // 파일에서 모든 점수를 읽어들임
                    string[] lines = File.ReadAllLines(filePath);
                    var parsedScores = lines
                        .Select(line =>
                        {
                            // 점수와 날짜를 분리
                            var parts = line.Split(',');
                            if (parts.Length == 2 &&
                                ulong.TryParse(parts[0], out ulong score) &&
                                DateTime.TryParse(parts[1], out DateTime date))
                            {
                                return (score, parts[1]);
                            }
                            return (score: 0UL, date: "0000-00-00 00:00:00");
                        })
                        .Where(entry => entry.score > 0) // 유효한 점수만 필터링
                        .ToArray();

                    // 내림차순으로 정렬 후 상위 9개를 rankScore에 저장
                    rankScore = parsedScores
                        .OrderByDescending(entry => entry.score)
                        .Take(9)
                        .ToArray();

                    PrintMessage("점수 불러오기가 완료되었습니다.");
                }
                else
                {
                    PrintMessage("점수 파일이 존재하지 않습니다");
                    rankScore = new (ulong, string)[9]; // 초기화
                }
            }
            catch (Exception ex)
            {
                PrintMessage($"파일을 읽거나 처리하는 중 오류가 발생했습니다: {ex.Message}");
            }
        }


        private void PrintMessage(string message)
        {
            Console.SetCursorPosition(2, 28);
            Console.WriteLine($"{message}");
        }
    }
}
