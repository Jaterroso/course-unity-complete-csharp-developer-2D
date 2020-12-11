using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    // Cached
    private TextMeshProUGUI scoreText;
    private GameSession gameSession;

    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
    }

    private void Update()
    {
        scoreText.text = gameSession.GetScore().ToString();
    }
}