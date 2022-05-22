using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : Lightable
{
    protected override void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Torche");
        Debug.Log(base.IsInFire());
        base.OnCollisionEnter(collision);
    }
}
