using UnityEngine;
using TMPro;

public class LiveDisplay : MonoBehaviour
{
    [SerializeField] private float baseLives = 3f;
    [SerializeField] private int damage = 1;
    private float lives;
    private TextMeshProUGUI livesText;

    private void Awake()
    {
        livesText = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        lives = baseLives - PlayerPrefsController.GetDifficulty();
        UpdateDisplay();
    }

    // Mostra valor da vida
    private void UpdateDisplay()
    {
        if (lives >= 1f)
        {
            livesText.text = lives.ToString();
        }
        else
        {
            livesText.text = "0";
        }
    }

    // Trata valor da vida
    public void TakeLife()
    {
        lives -= damage;
        UpdateDisplay();

        if (lives <= 0)
        {
            LevelController levelController = FindObjectOfType<LevelController>();
            levelController.HandleLoseCondition();
        }
    }
}