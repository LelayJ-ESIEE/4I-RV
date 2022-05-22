using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightable : MonoBehaviour
{

    [SerializeField]
    GameObject Firezone;

    [SerializeField]
    GameObject LightFire;



    [SerializeField] bool inFire;
    // Start is called before the first frame update
    void Start()
    {
        if (inFire)
        {
            lightFire();
            return;
        }
        extinguishFire();

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void lightFire()
    {
        inFire = true;
        Firezone.SetActive(true);
        LightFire.SetActive(true);
        Debug.Log("LightFire");

    }
    private void extinguishFire()
    {
        inFire = false;
        Firezone.SetActive(false);
        LightFire.SetActive(false);
        Debug.Log("extinguishFire");
    }



    /*private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if (other.tag == "TorchWithoutFire")
        {
            Debug.Log("TorchWithoutFire");
            lightFire();
        }
    }*/


    protected virtual void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision);
        GameObject collisionObject = collision.gameObject;
        Lightable l = collisionObject.GetComponent<Lightable>();
        if (l == null || l.inFire != true) return;
        Debug.Log(collisionObject);
        lightFire();

    }

    public bool IsInFire()
    {
        return inFire;
    }
}
