using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWoodEnigma : Lightable
{
    [SerializeField] int id;
    private void Awake()
    {
        EventManager.WrongAnswerEvent += base.ExtinguishFire;
    }
    protected override void OnCollisionEnter(Collision collision)
    {
        if (base.IsInFire()) return;
        base.OnCollisionEnter(collision);
        EventManager.LightEnigmaFire(id.ToString());

    }

    private void OnDestroy()
    {
        EventManager.WrongAnswerEvent -= base.ExtinguishFire;
    }

    

}
