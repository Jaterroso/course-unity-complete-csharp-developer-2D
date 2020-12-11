using UnityEngine;

public class AudioSession : MonoBehaviour
{
    [SerializeField] private AudioClip coinSound;

    private AudioSource myAudioSource;

    private void Awake()
    {
        myAudioSource = GetComponent<AudioSource>();
        SetupSingleton();
    }

    private void SetupSingleton()
    {
        int numberOfAudioSessions = FindObjectsOfType<AudioSession>().Length;

        if (numberOfAudioSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Toca efeito de moeda uma vez
    public void PlayCoinSound()
    {
        myAudioSource.PlayOneShot(coinSound);
    }
}