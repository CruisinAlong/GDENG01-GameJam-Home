using UnityEngine;

public class VacuumHitbox : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        // Only activate in Vacuum mode and while holding left mouse button
        if (PlayerModeManager.Instance.currentMode == PlayerMode.Vacuum && Input.GetMouseButton(0))
        {
           
            var vacuumCollectible = other.GetComponent<CollectibleVacuum>();
            if (vacuumCollectible != null)
            {
                vacuumCollectible.TryStartVacuum(transform.root); // Pass the player transform
                Debug.Log("VacuumHitbox: Vacuuming +" + vacuumCollectible.scoreValue + " points");
            }
        }
    }

    void Update()
    {
        if (PlayerModeManager.Instance.currentMode == PlayerMode.Vacuum && Input.GetMouseButton(0))
        {
            SfxManager.instance.PlaySFX(EventNames.SFXNames.SUCTION, 0.5f);
        }
        else
        {
            SfxManager.instance.StopSFX(EventNames.SFXNames.SUCTION);
        }
    }
}
