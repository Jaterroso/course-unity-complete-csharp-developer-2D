using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Slider difficultySlider;
    [SerializeField] private float defaultVolume = 0.8f;
    [SerializeField] private int defaultDifficulty = 1;

    // Cached
    private LevelLoader levelLoader;
    private MusicPlayer musicPlayer;

    private void Start()
    {
        levelLoader = FindObjectOfType<LevelLoader>();
        musicPlayer = FindObjectOfType<MusicPlayer>();
        volumeSlider.value = defaultVolume;
        difficultySlider.value = defaultDifficulty;
    }

    private void Update()
    {
        if (musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value);
        }
        else
        {
            Debug.LogWarning("No music player found");
        }
    }

    // Define valores padroes
    public void SetDefaults()
    {
        volumeSlider.value = defaultVolume;
        difficultySlider.value = defaultDifficulty;
    }

    // Salva valores e muda de cena
    public void SaveAndExit()
    {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        PlayerPrefsController.SetDifficulty(difficultySlider.value);
        levelLoader.LoadMainMenu();
    }
}