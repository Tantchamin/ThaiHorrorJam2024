public static class ScoreData
{
    public static int[] stageStars = new int[5];

    public static void SetStar(int score, int stage)
    {
        if (stage < 1 || stage > 5)
        {
            UnityEngine.Debug.LogWarning("Invalid stage number.");
            return;
        }

        int index = stage - 1;

        if (score > stageStars[index])
        {
            stageStars[index] = score;
        }
    }

    public static int GetAllStar()
    {
        int sum = 0;
        foreach(int star in stageStars)
        {
            sum += star;
        }
        return sum;
    }
}
