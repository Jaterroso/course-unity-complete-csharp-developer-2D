using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    // Constantes
    private const string MASTER_VOLUME_KEY = "Master_Volume";
    private const string DIFFICULTY_KEY = "Difficulty";
    private const float MIN_VOLUME = 0f;
    private const float MAX_VOLUME = 1f;
    private const float MIN_DIFFICULTY = 0;
    private const float MAX_DIFFICULTY = 2;

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static void SetMasterVolume(float volume)
    {
        if (volume >= MIN_VOLUME && volume <= MAX_VOLUME)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
        else
        {
            Debug.LogError("Master volume is out of range");
        }
    }

    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }

    public static void SetDifficulty(float difficulty)
    {
        if (difficulty >= MIN_DIFFICULTY && difficulty <= MAX_DIFFICULTY)
        {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
        }
        else
        {
            Debug.LogError("Difficulty is out of range");
        }
    }
}