using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Destroi quem colidiu e decrementa "vida" 
        Destroy(other.gameObject);
        LiveDisplay liveDisplay = FindObjectOfType<LiveDisplay>();
        liveDisplay.TakeLife();
    }
}