using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodStick : MonoBehaviour
{

    bool inFire;
    // Start is called before the first frame update
    void Start()
    {
        inFire = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void touchFire()
    {
        inFire = true;
        Debug.Log("Touch a fire");
    }
    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Fire")
        {
            touchFire();
        }
       

    }
}
