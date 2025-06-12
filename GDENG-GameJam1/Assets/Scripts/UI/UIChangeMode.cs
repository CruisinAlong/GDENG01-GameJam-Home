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
    [SerializeField] Image clawUIImage;
    
    private Color defaultColor;

    void OnEnable()
    {
        EventBroadcaster.Instance.AddObserver(EventNames.PlayerMode.BROOM_MODE,UpdateImageUI);
        EventBroadcaster.Instance.AddObserver(EventNames.PlayerMode.VACUUM_MODE,UpdateImageUI); 
        EventBroadcaster.Instance.AddObserver(EventNames.PlayerMode.MOP_MODE,UpdateImageUI);
        EventBroadcaster.Instance.AddObserver(EventNames.PlayerMode.MODE4,UpdateImageUI);
    }

    void OnDisable()
    {
        EventBroadcaster.Instance.RemoveAllObservers();
    }

    private void Start()
    {
        if (PlayerModeManager.Instance.currentMode == PlayerMode.Collect)
        {
            defaultColor = collectUIImage.color;
            vacuumUIImage.color = defaultColor;
            broomUIImage.color = defaultColor;
            clawUIImage.color = defaultColor;
            var newColor = defaultColor;
            newColor.a = 0;
            collectUIImage.color = newColor;
        }
    }

    void UpdateImageUI()
    {
        switch (PlayerModeManager.Instance.currentMode)
        {
            case PlayerMode.Collect: 
                vacuumUIImage.color = defaultColor;
                broomUIImage.color = defaultColor;
                clawUIImage.color = defaultColor;
                var collectColor = collectUIImage.color;
                collectColor.a = 0;
                collectUIImage.color = collectColor;
                break;
            case PlayerMode.Vacuum:
                var vacuumColor = vacuumUIImage.color;
                collectUIImage.color = defaultColor;
                broomUIImage.color = defaultColor;
                clawUIImage.color = defaultColor;
                vacuumColor.a = 0;
                vacuumUIImage.color = vacuumColor;
                break;
            case PlayerMode.Spawn: 
                var tempColor = broomUIImage.color;
                collectUIImage.color = defaultColor;
                vacuumUIImage.color = defaultColor;
                clawUIImage.color = defaultColor;
                tempColor.a = 0;
                broomUIImage.color = tempColor;
                break;
            case PlayerMode.Mode4:
                var mode4Color = clawUIImage.color;
                collectUIImage.color = mode4Color;
                vacuumUIImage.color = mode4Color;
                broomUIImage.color = mode4Color;
                mode4Color.a = 0;
                clawUIImage.color = mode4Color;
                break;
            default:
                defaultColor = collectUIImage.color;
                vacuumUIImage.color = defaultColor;
                broomUIImage.color = defaultColor;
                clawUIImage.color = defaultColor;
                var newColor = defaultColor;
                newColor.a = 0;
                collectUIImage.color = newColor;
                break;
        }
    }
}
