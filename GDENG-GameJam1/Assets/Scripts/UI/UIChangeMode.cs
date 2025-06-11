using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIChangeMode : MonoBehaviour
{
    [SerializeField] Image collectUIImage;
    [SerializeField] Image vacuumUIImage;
    [SerializeField] Image broomUIImage;

    void OnEnable()
    {
        EventBroadcaster.Instance.AddObserver(EventNames.PlayerMode.BROOM_MODE,UpdateImageUI);
        EventBroadcaster.Instance.AddObserver(EventNames.PlayerMode.VACUUM_MODE,UpdateImageUI); 
        EventBroadcaster.Instance.AddObserver(EventNames.PlayerMode.MOP_MODE,UpdateImageUI);
    }

    void OnDisable()
    {
        EventBroadcaster.Instance.RemoveAllObservers();
    }

    private void Start()
    {
        if (PlayerModeManager.Instance.currentMode == PlayerMode.Collect)
        {
            var defaultColor = collectUIImage.color;
            vacuumUIImage.color = defaultColor;
            broomUIImage.color = defaultColor;
            defaultColor.a = 0;
            collectUIImage.color = defaultColor;
        }
    }

    void UpdateImageUI()
    {
        switch (PlayerModeManager.Instance.currentMode)
        {
            case PlayerMode.Collect: 
                var collectColor = collectUIImage.color;
                vacuumUIImage.color = collectColor;
                broomUIImage.color = collectColor;
                collectColor.a = 0;
                collectUIImage.color = collectColor;
                break;
            case PlayerMode.Vacuum:
                var vacuumColor = vacuumUIImage.color;
                collectUIImage.color = vacuumColor;
                broomUIImage.color = vacuumColor;
                vacuumColor.a = 0;
                vacuumUIImage.color = vacuumColor;
                break;
            case PlayerMode.Spawn: 
                var tempColor = broomUIImage.color;
                collectUIImage.color = tempColor;
                vacuumUIImage.color = tempColor;
                tempColor.a = 0;
                broomUIImage.color = tempColor;
                break;
            default:
                var defaultColor = collectUIImage.color;
                vacuumUIImage.color = defaultColor;
                broomUIImage.color = defaultColor;
                defaultColor.a = 0;
                collectUIImage.color = defaultColor;
                break;
        }
    }
}
