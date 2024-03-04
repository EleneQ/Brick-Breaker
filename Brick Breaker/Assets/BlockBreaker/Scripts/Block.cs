using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] BreakableBlockManager breakableBlockManager;

    int currentNumberOfHits;

    [SerializeField] Sprite[] hitSprites;
    new private SpriteRenderer renderer;

    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject particleSystemPrefab;

    private void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        breakableBlockManager.CountBlocks();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.CompareTag("Ball"))
        {
            WhenToDestroyBlock();
        }
    }

    private void WhenToDestroyBlock()
    {
        currentNumberOfHits++;
        int maxHits = hitSprites.Length + 1; 

        if (currentNumberOfHits >= maxHits)
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
        int spriteIndex = currentNumberOfHits - 1;

        if (hitSprites[spriteIndex] != null)
        {
            renderer.sprite = hitSprites[spriteIndex];
        }
    }

    private void DestroyBlock()
    {
        ScoreManager.instance.AddToScore();

        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        ParticleEffect();

        breakableBlockManager.BlockDestroyed();
        Destroy(gameObject);
    }

    void ParticleEffect()
    {
        GameObject effectObj = Instantiate(particleSystemPrefab, transform.position, transform.rotation);
        Destroy(effectObj, 0.2f);
    }
}
