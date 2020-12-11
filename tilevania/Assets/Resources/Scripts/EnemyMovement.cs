using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 100f;

    private Rigidbody2D myRigidBody2D;

    private void Awake()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        transform.localScale = new Vector2(-Mathf.Sign(myRigidBody2D.velocity.x), 1f);
    }

    // Movimentacao
    private void Move()
    {
        if (IsFacingRight())
        {
            Vector2 enemyVelocity = new Vector2(moveSpeed * Time.deltaTime, myRigidBody2D.velocity.y);
            myRigidBody2D.velocity = enemyVelocity;
        }
        else
        {
            Vector2 enemyVelocity = new Vector2(-moveSpeed * Time.deltaTime, myRigidBody2D.velocity.y);
            myRigidBody2D.velocity = enemyVelocity;
        }
    }

    private bool IsFacingRight()
    {
        return transform.localScale.x > 0;
    }
}