using UnityEngine;

public class Player : MonoBehaviour
{
    // Config
    [SerializeField] private float runSpeed = 250f;
    [SerializeField] private float jumpSpeed = 350f;
    [SerializeField] private float climbSpeed = 250f;
    [SerializeField] private Vector2 deathKick = new Vector2(5f, 2f);

    // State
    private bool isAlive = true;

    // Cached components references
    private Rigidbody2D myRigidbody2D;
    private Animator myAnimator;
    private BoxCollider2D myBodyCollider;
    private CapsuleCollider2D myFeetCollider;
    private GameSession gameSession;
    private float gravityScaleAtStart;

    private void Awake()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBodyCollider = GetComponent<BoxCollider2D>();
        myFeetCollider = GetComponent<CapsuleCollider2D>();
    }

    private void Start()
    {
        gravityScaleAtStart = myRigidbody2D.gravityScale;
        gameSession = FindObjectOfType<GameSession>();
    }

    // Utilizado para fisica com Rigidbody 2D
    private void FixedUpdate()
    {
        if (!isAlive) { return; }

        Run();
        Jump();
        ClimbLadder();
        FlipSprite();
        Die();
    }

    private void Run()
    {
        // Define velocidade do input com outros valores
        float controlThrow = Input.GetAxisRaw("Horizontal");
        controlThrow *= runSpeed * Time.deltaTime;
        Vector2 playerVelocity = new Vector2(controlThrow, myRigidbody2D.velocity.y);
        myRigidbody2D.velocity = playerVelocity;

        // Atualiza animator
        myAnimator.SetBool("Running", PlayerHasHorizontalSpeed());
    }

    private void Jump()
    {
        // Cancela
        if (!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }

        // Adiciona valores de pulo
        if (Input.GetButtonDown("Jump"))
        {
            Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed * Time.deltaTime);
            myRigidbody2D.velocity += jumpVelocityToAdd;
        }
    }

    private void ClimbLadder()
    {
        // Cancela
        if (!myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            myAnimator.SetBool("Climbing", false);
            myRigidbody2D.gravityScale = gravityScaleAtStart;
            return;
        }

        // Controla movimentacao da escada
        float controlThrow = Input.GetAxisRaw("Vertical");
        controlThrow *= climbSpeed * Time.deltaTime;
        Vector2 climbVelocity = new Vector2(myRigidbody2D.velocity.x, controlThrow);
        myRigidbody2D.velocity = climbVelocity;
        myRigidbody2D.gravityScale = 0;

        // Controla animator
        bool playerHasVerticalSpeed = Mathf.Abs(myRigidbody2D.velocity.y) > Mathf.Epsilon;
        myAnimator.SetBool("Climbing", playerHasVerticalSpeed);
    }

    // Retorna se tem velocidade
    private bool PlayerHasHorizontalSpeed()
    {
        return Mathf.Abs(myRigidbody2D.velocity.x) > Mathf.Epsilon;
    }

    // Inverte sprite
    private void FlipSprite()
    {
        if (PlayerHasHorizontalSpeed())
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidbody2D.velocity.x), 1f);
        }
    }

    // Trata parametros de morte
    private void Die()
    {
        if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazards")))
        {
            myAnimator.SetTrigger("Die");
            myRigidbody2D.velocity = deathKick;
            myRigidbody2D.bodyType = RigidbodyType2D.Kinematic;
            myRigidbody2D.velocity = new Vector2(0, 0);
            isAlive = false;
            gameSession.ProcessPlayerDeath();
        }
    }
}