using UnityEngine;
using TMPro;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] private int stars = 500;
    private TextMeshProUGUI startText;

    private void Awake()
    {
        startText = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        UpdateDisplay();
    }

    // Atualiza informacao no Text
    private void UpdateDisplay()
    {
        startText.text = stars.ToString();
    }

    // Retorna se pode gastar
    public bool HaveEnoughStars(int amount)
    {
        return stars >= amount;
    }

    // Adiciona
    public void AddStars(int amount)
    {
        stars += amount;
        UpdateDisplay();
    }

    // Gasta
    public void SpendStars(int amount)
    {
        if (stars >= amount)
        {
            stars -= amount;
            UpdateDisplay();
        }
    }
}