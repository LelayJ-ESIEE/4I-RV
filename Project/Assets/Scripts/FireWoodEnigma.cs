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
    protected override void OnTriggerEnter(Collider collider)
    {
        Lightable l = collider.gameObject.GetComponent<Lightable>();
        if (base.IsInFire() || l == null || !l.IsInFire()) return;
        base.OnTriggerEnter(collider);
        EventManager.LightEnigmaFire(id.ToString());

    }

    private void OnDestroy()
    {
        EventManager.WrongAnswerEvent -= base.ExtinguishFire;
    }

    

}
