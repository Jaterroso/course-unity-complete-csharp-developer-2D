using UnityEngine;

public class Paddle : MonoBehaviour
{
    // Configuration parameters
    [SerializeField] private float screenWidthInUnits = 16f;
    [SerializeField] private float minX = 1f;
    [SerializeField] private float maxX = 15f;
    [SerializeField] private float moveSpeed = 10f;

    // Cache components
    private GameSession theGameSession;
    private Ball theBall;

    // Start is called before the first frame update
    private void Start()
    {
        theGameSession = FindObjectOfType<GameSession>();
        theBall = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    private void Update()
    {
        // Retorna a posicao do mouse em Vector3
        //Input.mousePosition

        // Bloqueia a posicao do mouse em X
        Vector2 paddlePosition = new Vector2(transform.position.x, transform.position.y);
        paddlePosition.x = Mathf.Clamp(GetXPosition(), minX, maxX);
        transform.position = paddlePosition;
    }

    // Retorna posicao em X do mouse ou da bola
    private float GetXPosition()
    {
        if (theGameSession.IsAutoPlayEnabled())
        {
            return theBall.transform.position.x;
        }
        else
        {
            return (Input.mousePosition.x / Screen.width * screenWidthInUnits);
        }
    }
}