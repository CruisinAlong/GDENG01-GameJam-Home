using System.Collections;
using UnityEngine;

public class CollectibleVacuum : MonoBehaviour
{
    public int scoreValue = 1;
    public float pullSpeed = 8f;

    private bool isPulling = false;

    // Called by the VacuumHitbox
    public void TryStartVacuum(Transform player)
    {
        if (!isPulling)
        {
            isPulling = true;
            StartCoroutine(PullToPlayer(player));
        }
    }

    private IEnumerator PullToPlayer(Transform player)
    {
        while (Vector3.Distance(transform.position, player.position) > 0.5f)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, pullSpeed * Time.deltaTime);
            yield return null;
        }
        GameManager.Instance.AddScore(scoreValue);
        Destroy(gameObject);
    }
}
