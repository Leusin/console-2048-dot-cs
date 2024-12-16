namespace Console2048DotCS
{
    public class Board
    {
        const int BOARD_SIZE = 4;
        int[,] gameBoard = new int[BOARD_SIZE, BOARD_SIZE];

        private Random _rand = new Random();

        public void InitGame()
        {
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                for (int j = 0; j < BOARD_SIZE; j++)
                {
                    gameBoard[i, j] = 0;
                }
            }

            int count = 0;
            while (count < 2)
            {
                int x = _rand.Next() % BOARD_SIZE;
                int y = _rand.Next() % BOARD_SIZE;

                if (gameBoard[x, y] == 0)
                {
                    gameBoard[x, y] = (_rand.Next() % 2 + 1) * 2;
                    count++;
                }
            }
        }

        public void Rander()
        {
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                for (int j = 0; j < BOARD_SIZE; j++)
                {
                    Console.Write($"{gameBoard[i, j]} ");
                }
                Console.Write($"\n");
            }
        }
    }
}
