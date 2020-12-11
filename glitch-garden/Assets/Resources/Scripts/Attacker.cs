using UnityEngine;

public class Attacker : MonoBehaviour
{
    private float currentSpeed = 1f;
    private GameObject currentTarget;

    // Cached
    private Animator animator;
    private LevelController levelController;

    // Define velocidade de movimento
    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    // Quando o objeto e iniciado antes do Start ()
    private void Awake()
    {
        levelController = FindObjectOfType<LevelController>();

        if (levelController != null)
        {
            levelController.AttackerSpawned();
        }

        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        UpdateAnimationState();
    }

    private void OnDestroy()
    {
        if (levelController != null)
        {
            levelController.AttackerKilled();
        }
    }

    // Define parametro de animacao e alvo atual
    public void Attack(GameObject target)
    {
        animator.SetBool("isAttacking", true);
        currentTarget = target;
    }

    // Define ataque
    public void StrikeCurrentTarget(float damage)
    {
        if (!currentTarget) { return; }

        Health health = currentTarget.GetComponent<Health>();
        if (health)
        {
            health.DealDamage(damage);
        }
    }

    // Atualiza estado da animacao
    private void UpdateAnimationState()
    {
        animator.SetBool("isAttacking", currentTarget);
    }
}