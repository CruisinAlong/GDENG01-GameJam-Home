using System.Collections;
using UnityEngine;

public class Mop : MonoBehaviour
{
    public float shrinkDuration = 3.0f;
    public int scoreValue = 1;
    public Transform spriteTransform;

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
        if (!isCollected && other.CompareTag("Player") && PlayerModeManager.Instance.currentMode == PlayerMode.Collect)
        {
            isCollected = true;
            StartCoroutine(ShrinkAndCollect());
        }
    }

    private IEnumerator ShrinkAndCollect()
    {
        Vector3 originalScale = spriteTransform != null ? spriteTransform.localScale : Vector3.one;
        float elapsed = 0f;

        while (elapsed < shrinkDuration)
        {
            if (PlayerMovement.isMoving)
            {
                float t = elapsed / shrinkDuration;
                if (spriteTransform != null)
                    spriteTransform.localScale = Vector3.Lerp(originalScale, Vector3.zero, t);
                elapsed += Time.deltaTime;
            }
            yield return null;
        }
        if (spriteTransform != null)
            spriteTransform.localScale = Vector3.zero;

        GameManager.Instance.AddScore(scoreValue);

        // Add energy on clean
        if (PlayerEnergyManager.Instance != null)
            PlayerEnergyManager.Instance.GainEnergy(PlayerEnergyManager.Instance.energyGainPerClean);

        Destroy(gameObject);
    }
}
