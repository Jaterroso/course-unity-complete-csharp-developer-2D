using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    private Defender defender;
    private GameObject defenderParent;
    private const string DEFENDER_PARENT_NAME = "Defenders";

    public void SetSelectedDefender(Defender defenderToSelect)
    {
        defender = defenderToSelect;
    }

    private void Start()
    {
        CreateDefenderParent();
    }

    // Evento click do mouse
    private void OnMouseDown()
    {
        AttemptToPlaceDefenderAt(GetSquareClicked());
    }

    // Encontra ou cria objeto
    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if (!defenderParent)
        {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }

    private void AttemptToPlaceDefenderAt(Vector2 gridPosition)
    {
        if (!defender) { return; }

        // Pega parametros
        var starDisplay = FindObjectOfType<StarDisplay>();
        int defenderCost = defender.GetStarCost();

        // Coloca apenas se tiver recursos (estrelas) suficientes
        if (starDisplay.HaveEnoughStars(defenderCost))
        {
            SpawnDefender(gridPosition);
            starDisplay.SpendStars(defenderCost);
        }
    }

    // Captura posicao do click do mouse e converte para 'world position'
    private Vector2 GetSquareClicked()
    {
        Vector2 clickPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(clickPosition);
        Vector2 gridPosition = SnapToGrid(worldPosition);
        return gridPosition;
    }

    // Arredonda valores de X e Y para inteiros
    private Vector2 SnapToGrid(Vector2 position)
    {
        float newX = Mathf.RoundToInt(position.x);
        float newY = Mathf.RoundToInt(position.y);
        return new Vector2(newX, newY);
    }

    // Instancia objeto na posicao informada
    private void SpawnDefender(Vector2 position)
    {
        Defender newDefender = Instantiate(defender, position, Quaternion.identity) as Defender;
        newDefender.transform.parent = defenderParent.transform;
    }
}