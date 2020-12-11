using UnityEngine;

public class Fox : MonoBehaviour
{
    private Attacker attacker;
    private Animator animator;

    private void Awake()
    {
        attacker = GetComponent<Attacker>();
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Pega referencias
        GameObject otherObject = other.gameObject;
        Defender defender = other.GetComponent<Defender>();
        Gravestone gravestone = other.GetComponent<Gravestone>();

        // Define de acordo com tipo de defensor
        if (gravestone)
        {
            animator.SetTrigger("jumpTrigger");
        }
        else if (defender)
        {
            attacker.Attack(otherObject);
        }
    }
}
