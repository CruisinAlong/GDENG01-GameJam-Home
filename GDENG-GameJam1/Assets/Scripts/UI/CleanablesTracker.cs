using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CleanablesTracker : MonoBehaviour
{
    [SerializeField] private TMP_Text counter;
    private void OnEnable()
    {
        EventBroadcaster.Instance.AddObserver(EventNames.Clean_Events.NUM_CLEANABLES_LEFT, UpdateUI);
    }

    private void OnDisable()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.Clean_Events.NUM_CLEANABLES_LEFT);
    }
    private void UpdateUI(Parameters obj)
    {
        int parameters = obj.GetIntExtra(EventNames.Clean_Events.PARAM_CLEANABLES_LEFT, 0);
        counter.text = $"To Clean: {parameters}";
    }
}
