using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAbleObject : MonoBehaviour
{

    [SerializeField]
    GameObject Firezone;

    [SerializeField]
    GameObject LightFire;



    bool inFire;
    // Start is called before the first frame update
    void Start()
    {
        inFire = true;
        extinguishFire();

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void lightFire()
    {
        if (!inFire)
        {
            inFire = true;
            Firezone.SetActive(true);
            LightFire.SetActive(true);
            Debug.Log("LightFire");
        }

    }
    private void extinguishFire()
    {
        if (inFire)
        {
            inFire = false;
            Firezone.SetActive(false);
            LightFire.SetActive(false);
            Debug.Log("extinguishFire");
        }
    }
    private void OnCollisionEnter(Collision col)
    {
        Debug.Log(col);
        if (col.gameObject.tag == "TorchWithoutFire")
        {
            Debug.Log("TorchWithoutFire");
            lightFire();
        }
    }
}
