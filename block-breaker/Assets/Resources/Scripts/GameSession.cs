using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    // Configuration parameters
    [Range(0f, 10f)]
    [SerializeField]
    private float gameSpeed = 1f;

    [SerializeField]
    private int pointsPerBlockDestroyed = 83;

    [SerializeField]
    private TextMeshProUGUI scoreText;

    [SerializeField]
    private bool isAutoPlayEnabled;

    // State variables
    [SerializeField]
    private int currentScore = 0;

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }

    private void Awake()
    {
        // Implementa Singleton
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;

        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    private void Update()
    {
        Time.timeScale = gameSpeed;
    }

    // Atualiza score
    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }

    // Reseta game e exclui esse gameobject
    public void ResetGame()
    {
        Destroy(gameObject);
    }
}