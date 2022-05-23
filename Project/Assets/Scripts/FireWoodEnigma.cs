using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWoodEnigma : Lightable
{
    [SerializeField] int id;
    private void Awake()
    {
    }
    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
        EventManager.LightEnigmaFire(id.ToString());

    }

    private void OnDestroy()
    {
        
    }

}
