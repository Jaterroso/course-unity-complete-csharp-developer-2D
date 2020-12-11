using UnityEngine;

public class Ball : MonoBehaviour
{
    // Configuration parameters
    [SerializeField] private Paddle paddle1;
    [SerializeField] private float xPush = 1f;
    [SerializeField] private float yPush = 10f;
    [SerializeField] private AudioClip[] ballSounds;
    [SerializeField] private float randomFactor = 0.5f;
    [SerializeField] private float speedRangePositive = 1f;
    [SerializeField] private float speedRangeNegative = -1f;

    // State
    private Vector2 paddleToBallVector;
    private bool hasStarted = false;

    // Cached component references
    private AudioSource audioSource;
    private Rigidbody2D rigidBody;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        // Calcula distancia entre a bola e barra
        paddleToBallVector = transform.position - paddle1.transform.position;
        transform.position = new Vector3(paddle1.transform.position.x, paddle1.transform.position.y + 0.5f, paddle1.transform.position.z);
    }

    // Update is called once per frame
    private void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void LaunchOnMouseClick()
    {
        // Solta a bola
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            rigidBody.velocity = new Vector2(xPush, yPush);
        }
    }

    private void LockBallToPaddle()
    {
        // Define posicao da bola junto com a barra
        Vector2 paddlePosition = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePosition + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Trata relacao de direcao da velocidade
        if (rigidBody.velocity.y < speedRangePositive && rigidBody.velocity.y > speedRangeNegative)
        {
            TweakDirectionY();
            SpeedFixX();
        }

        if (rigidBody.velocity.x < speedRangePositive && rigidBody.velocity.x > speedRangeNegative)
        {
            TweakDirectionX();
            SpeedFixY();
        }

        // Toca som da colisao
        if (hasStarted)
        {
            AudioClip clip = ballSounds[Random.Range(0, ballSounds.Length)];
            audioSource.PlayOneShot(clip);
        }
    }

    // Reseta valor se passar de 'xPush'
    private void SpeedFixX()
    {
        if (rigidBody.velocity.x > yPush)
        {
            rigidBody.velocity = new Vector2(yPush, rigidBody.velocity.y);
        }
    }

    // Reseta valor se passar de 'yPush'
    private void SpeedFixY()
    {
        if (rigidBody.velocity.y > yPush)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, yPush);
        }
    }

    // Incrementa ou decrementa valor em X
    private void TweakDirectionX()
    {
        Vector2 velocityTweakX = new Vector2(1f, 0f);

        if (rigidBody.velocity.x < 0)
        {
            rigidBody.velocity -= velocityTweakX;
        }
        else if (rigidBody.velocity.x > 0)
        {
            rigidBody.velocity += velocityTweakX;
        }
    }

    // Incrementa ou decrementa valor em Y
    private void TweakDirectionY()
    {
        Vector2 velocityTweakY = new Vector2(0f, 1f);

        if (rigidBody.velocity.y < 0)
        {
            rigidBody.velocity -= velocityTweakY;
        }
        else if (rigidBody.velocity.y > 0)
        {
            rigidBody.velocity += velocityTweakY;
        }
    }
}