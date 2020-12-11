using UnityEngine;
using TMPro;

public class HealthDisplay : MonoBehaviour
{
    // Cached
    private TextMeshProUGUI healthText;
    private Player player;

    private void Awake()
    {
        healthText = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        // Atualiza valor
        int health = player.GetHealth();
        healthText.text = (health >= 0 ? health.ToString() : "0");

        // Atualiza cor
        if (health >= 100)
        {
            healthText.color = Color.green;
        }
        else if (health >= 50 && health < 100)
        {
            healthText.color = Color.yellow;
        }
        else if (health < 50)
        {
            healthText.color = Color.red;
        }
    }
}