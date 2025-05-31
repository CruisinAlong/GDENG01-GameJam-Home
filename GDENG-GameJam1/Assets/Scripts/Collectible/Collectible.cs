using System.Collections;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public float shrinkDuration = 0.5f;
    public int scoreValue = 1;
    public Transform spriteTransform; // Assign in Inspector or via code

    private bool isCollected = false;

    private void Awake()
    {
        // Auto-assign if not set
        if (spriteTransform == null)
        {
            var sr = GetComponentInChildren<SpriteRenderer>();
            if (sr != null)
                spriteTransform = sr.transform;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isCollected && other.CompareTag("Player"))
        {
            isCollected = true;
            StartCoroutine(ShrinkAndCollect());
            Debug.Log("Collectible collected by player!");
        }
    }

    private IEnumerator ShrinkAndCollect()
    {
        Vector3 originalScale = spriteTransform != null ? spriteTransform.localScale : Vector3.one;
        float elapsed = 0f;

        // Shrink the sprite visual only
        while (elapsed < shrinkDuration)
        {
            float t = elapsed / shrinkDuration;
            if (spriteTransform != null)
                spriteTransform.localScale = Vector3.Lerp(originalScale, Vector3.zero, t);
            elapsed += Time.deltaTime;
            yield return null;
        }
        if (spriteTransform != null)
            spriteTransform.localScale = Vector3.zero;

        // Add score
        GameManager.Instance.AddScore(scoreValue);

        // Destroy or deactivate the collectible
        Destroy(gameObject);
    }
}
