using UnityEngine;

public static class GameController
{
    private static int collectableCount;
    private static int score;

    public static int Score
    {
        get { return score; }
    }

    public static bool gameOver
    {
        get { return collectableCount <= 0; }
    }

    public static void Init()
    {
        collectableCount = 5;
        score = 0;
    }

    public static void Collect()
    {
        collectableCount--;
        score++;
    }
}