using UnityEngine;

public class PrefsManager
{
    private const string SCORE_KEY = "Money";
    private const string ROLLS_COUNT = "LevelProgress";
        
    public static bool HasUserProfile()
    {
        return PlayerPrefs.HasKey(SCORE_KEY);
    }

    public static int LoadScore()
    {
        return PlayerPrefs.GetInt(SCORE_KEY);
    }

    public static void SaveScoreProgress(int level)
    {
        PlayerPrefs.SetInt(SCORE_KEY, level);
        PlayerPrefs.Save();
    }

    public static int LoadRollsCount()
    {
        return PlayerPrefs.GetInt(ROLLS_COUNT);
    }
        
    // Количество бросков
    public static void SaveRollsCount(int rollsCount)
    {
        PlayerPrefs.SetInt(ROLLS_COUNT, rollsCount);
        PlayerPrefs.Save();
    }
}