namespace Console2048DotCS
{

    public class KeyControl
    {
        public enum State
        {
            DISABLED,
            WAITING,
            STARTED,
            PERFORMED,
            CANCELED,
        }

        private Dictionary<ConsoleKey, State> keyStates = new();
        private Dictionary<ConsoleKey, bool> currentKeyInputs = new();
        private Dictionary<ConsoleKey, bool> previousKeyInputs = new();

        private DateTime _lastkeyPressTime = DateTime.MinValue;
        private readonly TimeSpan _lastkeyPressTimeout = TimeSpan.FromMicroseconds(200);

        public void RegisterKey(ConsoleKey key)
        {
            // 키 등록 및 초기 상태 설정
            keyStates[key] = State.WAITING;
            currentKeyInputs[key] = false;
            previousKeyInputs[key] = false;
        }

        public void Update()
        {
            DateTime currentTime = DateTime.Now;

            if (currentTime - _lastkeyPressTime > _lastkeyPressTimeout)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    ConsoleKey input = keyInfo.Key;

                    if (keyStates.ContainsKey(input))
                    {
                        currentKeyInputs[input] = true;
                    }
                }
            }

            // 키 상태 갱신
            foreach (var key in keyStates.Keys)
            {
                bool isCurrentlyPressed = currentKeyInputs[key];
                bool wasPreviouslyPressed = previousKeyInputs[key];

                if (isCurrentlyPressed && !wasPreviouslyPressed)
                {
                    keyStates[key] = State.STARTED; // 막 눌림
                }
                else if (isCurrentlyPressed && wasPreviouslyPressed)
                {
                    keyStates[key] = State.PERFORMED; // 계속 눌림
                }
                else if (!isCurrentlyPressed && wasPreviouslyPressed)
                {
                    keyStates[key] = State.CANCELED; // 막 떨어짐
                }
                else
                {
                    keyStates[key] = State.WAITING;
                }

                previousKeyInputs[key] = isCurrentlyPressed;
                currentKeyInputs[key] = false;
            }

            _lastkeyPressTime = currentTime;
        }

        public State GetKeyState(ConsoleKey key)
        {
            return keyStates.ContainsKey(key) ? keyStates[key] : State.WAITING;
        }

        public bool IsKeyPressed(ConsoleKey key)
        {
            return GetKeyState(key) == State.STARTED;
        }

        public bool IsKeyHeld(ConsoleKey key)
        {
            return GetKeyState(key) == State.PERFORMED;
        }

        public bool IsKeyReleased(ConsoleKey key)
        {
            return GetKeyState(key) == State.CANCELED;
        }
    }
}
