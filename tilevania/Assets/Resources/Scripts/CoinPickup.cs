using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] private int pointsToAdd = 100;

    private AudioSession audioSession;
    private GameSession gameSession;

    private void Start()
    {
        audioSession = FindObjectOfType<AudioSession>();
        gameSession = FindObjectOfType<GameSession>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        gameSession.AddToScore(pointsToAdd);
        audioSession.PlayCoinSound();
        Destroy(gameObject);
    }
}