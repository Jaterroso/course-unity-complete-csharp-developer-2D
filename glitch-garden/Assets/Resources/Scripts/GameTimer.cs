using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Our level timer in seconds")]
    private float levelTimeInSeconds = 60f;
    private bool trigerredLevelFinished = false;

    // Cached
    private Slider slider;
    private LevelController levelController;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    private void Start()
    {
        levelController = FindObjectOfType<LevelController>();
    }

    private void Update()
    {
        // Cancela resto do script
        if (trigerredLevelFinished) { return; }

        // timeSinceLevelLoad = Retorna o tempo em segundos desde que a cena foi carregada
        slider.value = Time.timeSinceLevelLoad / levelTimeInSeconds;

        bool timerFinished = (Time.timeSinceLevelLoad >= levelTimeInSeconds);
        if (timerFinished)
        {
            levelController.LevelTimerFinished();
            trigerredLevelFinished = true;
        }
    }
}