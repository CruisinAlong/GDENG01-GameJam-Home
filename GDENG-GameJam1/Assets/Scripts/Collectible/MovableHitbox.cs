using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableHitbox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (PlayerModeManager.Instance.currentMode == PlayerMode.Mode4)
        {
            var mode4Movable = other.GetComponent<Movable>();
            if (mode4Movable != null)
            {
                mode4Movable.Collect();
            }
        }
    }
}
