using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingRoomBG : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SfxManager.instance.PlayLoopingSFX(EventNames.SFXNames.BG_TV,0.6f);
    }

    private void OnEnable()
    {
        EventBroadcaster.Instance.AddObserver(EventNames.SFXNames.STOP_BG, StopBG);
    }

    private void OnDisable()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.SFXNames.STOP_BG);
    }
    
    private void StopBG()
    {
        Debug.Log("Stop BG");
        SfxManager.instance.StopSFX(EventNames.SFXNames.BG_TV);
    }

    // Update is called once per frame
    void Update()
    {
            
    }
}
