using System.Collections;
using UnityEngine;

public class CollectibleSpawn : MonoBehaviour
{
    public float shrinkDuration = 3.0f;
    public int scoreValue = 1;
    public Transform spriteTransform;
    public GameObject spawnPrefab;
    public int spawnCount = 3;

    private bool isCollected = false;

    private void Awake()
    {
        if (spriteTransform == null)
        {
            var sr = GetComponentInChildren<SpriteRenderer>();
            if (sr != null)
                spriteTransform = sr.transform;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!isCollected && other.CompareTag("Player") &&
            PlayerModeManager.Instance.currentMode == PlayerMode.Spawn &&
            Mathf.Abs(Input.GetAxis("Mouse ScrollWheel")) > 0.01f)
        {
            isCollected = true;
            SfxManager.instance.PlaySFX(EventNames.SFXNames.BRUSH,0.5f);
            StartCoroutine(ShrinkAndSpawn());
        }
    }

    private IEnumerator ShrinkAndSpawn()
    {
        Vector3 originalScale = spriteTransform != null ? spriteTransform.localScale : Vector3.one;
        float elapsed = 0f;

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

        if (spawnPrefab != null)
        {
            for (int i = 0; i < spawnCount; i++)
            {
                Vector3 offset = Random.insideUnitSphere;
                offset.y = 0;
                Instantiate(spawnPrefab, transform.position + offset, Quaternion.identity);
            }
        }

        GameManager.Instance.AddScore(scoreValue);

        // Add energy on clean
        if (PlayerEnergyManager.Instance != null)
            PlayerEnergyManager.Instance.GainEnergy(PlayerEnergyManager.Instance.energyGainPerClean);
        if (CleanableCounter.Instance != null)
            CleanableCounter.Instance.DecrementCleanable();
        Destroy(gameObject);
    }
}
