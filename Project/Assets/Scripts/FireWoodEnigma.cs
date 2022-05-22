using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWoodEnigma : Lightable
{
    private void Awake()
    {
        
    }
    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
        EventManager.LightEnigmaFire();

    }

    private void OnDestroy()
    {
        
    }

}
