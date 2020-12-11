using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private AudioSource audioSource;

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }

    private void Awake()
    {
        SetupSingleton();
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefsController.GetMasterVolume();
    }

    private void SetupSingleton()
    {
        int musicPlayerCount = FindObjectsOfType<MusicPlayer>().Length;

        if (musicPlayerCount > 1)
        {
            Destroy(this);
        }
        else
        {
            DontDestroyOnLoad(this);
        }
    }
}