using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] private int starCost = 100;
    private StarDisplay starDisplay;

    public int GetStarCost()
    {
        return starCost;
    }

    private void Start()
    {
        starDisplay = FindObjectOfType<StarDisplay>();
    }

    // Adiciona estrelas
    public void AddStars(int amount)
    {
        starDisplay.AddStars(amount);
    }
}