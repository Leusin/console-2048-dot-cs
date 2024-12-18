using System.Text;

namespace Console2048DotCS
{
    public enum Tone
    {
        REST = 0,
        GbelowC = 196,
        A = 220,
        Asharp = 233,
        B = 247,
        C = 262,
        Csharp = 277,
        D = 294,
        Dsharp = 311,
        E = 330,
        F = 349,
        Fsharp = 370,
        G = 392,
        Gsharp = 415,
    }

    public enum Duration
    {
        WHOLE = 1600,
        HALF = 800,
        QUARTER = 400,
        EIGHTH = 200,
        SIXTEENTH = 100,
    }

    public class Beep
    {
        public static void Play()
        {
            Console.Beep();
        }

        public static void Play(Tone toneVal, Duration durVal)
        {
            if (toneVal == Tone.REST)
            {
                Thread.Sleep((int)toneVal);
            }
            else
            {
                Console.Beep((int)toneVal, (int)durVal);
            }
        }
    }
}
