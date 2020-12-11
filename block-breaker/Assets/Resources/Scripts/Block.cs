using UnityEngine;

public class Block : MonoBehaviour
{
    // Configuration params
    [SerializeField] private AudioClip breakSound;
    [SerializeField] private GameObject blockSparksVFX;
    [SerializeField] private Sprite[] hitSprites;

    // Cached component references
    private Level level;
    private GameSession gameSession;
    private SpriteRenderer spriteRenderer;

    // State variables
    [SerializeField] private int timesHit;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        CountBreakableBlocks();
    }

    // Quando colide
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (tag == "Breakable")
        {
            HandleHit();
        }
    }

    // Conta a quantidade de blocos quebraveis
    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        gameSession = FindObjectOfType<GameSession>();

        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    // Lida quando a bola acerta o bloco
    private void HandleHit()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;

        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;

        if (hitSprites[spriteIndex] != null)
        {
            spriteRenderer.sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block Sprite is missing from array: " + gameObject.name);
        }
    }

    // Atualiza score, toca som e destroi objeto
    private void DestroyBlock()
    {
        PlayBlockDestroySFX();
        Destroy(gameObject);
        level.BlockDestroyed();
        TriggerSparksVFX();
    }

    // Toca audio
    private void PlayBlockDestroySFX()
    {
        gameSession.AddToScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    // Instancia particulas de efeito
    private void TriggerSparksVFX()
    {
        GameObject sparkles = Instantiate(blockSparksVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}