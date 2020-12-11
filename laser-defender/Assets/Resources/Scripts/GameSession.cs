using UnityEngine;

public class GameSession : MonoBehaviour
{
    [SerializeField] private int score = 0;

    public int GetScore()
    {
        return score;
    }

    private void Awake()
    {
        SetupSingleton();
    }

    private void SetupSingleton()
    {
        int numberOfGameSessions = FindObjectsOfType(GetType()).Length;
        if (numberOfGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Incrementa
    public void AddScore(int scoreValue)
    {
        score += scoreValue;
    }

    // Reseta jogo
    public void ResetGame()
    {
        Destroy(gameObject);
    }
}