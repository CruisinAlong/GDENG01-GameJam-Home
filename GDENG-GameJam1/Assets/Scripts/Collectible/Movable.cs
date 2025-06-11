using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable : MonoBehaviour
{
    public int scoreValue = 1; // Score to add when collected by the Mode4 hitbox

    // This method can be called by the Mode4 hitbox when this object enters it
    public void Collect()
    {
        // Add to score
        GameManager.Instance.AddScore(scoreValue);

        // Optionally, play a sound or effect here

        // Destroy this object
        Destroy(gameObject);
    }
}
