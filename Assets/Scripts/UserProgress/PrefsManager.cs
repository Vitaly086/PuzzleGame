using UnityEngine;

public class PrefsManager
{
    private const string SCORE_KEY = "Money";
    private const string LEVEL_KEY = "Level";
        
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

    public static int LoadPlayerProgress()
    {
        return PlayerPrefs.GetInt(LEVEL_KEY);
    }
        
    public static void SavePlayerProgress(int id)
    {
        PlayerPrefs.SetInt(LEVEL_KEY, id);
        PlayerPrefs.Save();
    }
}