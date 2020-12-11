using UnityEngine;
using TMPro;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] private Defender defenderPrefab;
    [SerializeField] private TextMeshProUGUI costText;

    private Color32 defaultButtonColor = new Color32(41, 41, 41, 255);

    // Cached
    private SpriteRenderer spriteRenderer;
    private DefenderButton[] buttons;
    private DefenderSpawner defenderSpawner;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        buttons = FindObjectsOfType<DefenderButton>();
        defenderSpawner = FindObjectOfType<DefenderSpawner>();
        LabelButtonWithCost();
    }

    // Define evento do mouse
    private void OnMouseDown()
    {
        // Reseta cor
        foreach (DefenderButton button in buttons)
        {
            button.spriteRenderer.color = defaultButtonColor;
        }

        spriteRenderer.color = Color.white;
        defenderSpawner.SetSelectedDefender(defenderPrefab);
    }

    // Define conteudo do texto
    private void LabelButtonWithCost()
    {
        if (!costText)
        {
            Debug.LogError(string.Concat("Big problems: ", name, "has not cost text, add some"));
        }
        else
        {
            costText.text = defenderPrefab.GetStarCost().ToString();
        }
    }
}