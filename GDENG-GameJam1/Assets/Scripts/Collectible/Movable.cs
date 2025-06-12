using UnityEngine;

public class Movable : MonoBehaviour
{
    public int scoreValue = 1;

    public void Collect()
    {
        GameManager.Instance.AddScore(scoreValue);

        // Add energy on clean
        if (PlayerEnergyManager.Instance != null)
            PlayerEnergyManager.Instance.GainEnergy(PlayerEnergyManager.Instance.energyGainPerClean);

        Destroy(gameObject);
    }
}
