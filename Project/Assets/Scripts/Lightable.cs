using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightable : MonoBehaviour
{

    GameObject fireZone;
    Light pointLight;



    [SerializeField] bool inFire;
    // Start is called before the first frame update
    void Start()
    {
        pointLight = GetComponentInChildren<Light>();
        fireZone = RecursiveFindChild(transform, "FX_Bonfire_A").gameObject;
        if (inFire)
        {
            LightFire();
            return;
        }
        ExtinguishFire();
    }

    // Update is called once per frame
    void Update()
    {

    }
    protected void LightFire()
    {
        inFire = true;
        fireZone.SetActive(true);
        pointLight.intensity = 1;

    }
    protected void ExtinguishFire()
    {
        inFire = false;
        fireZone.SetActive(false);
        pointLight.intensity = 0;
    }


    protected virtual void OnTriggerEnter(Collider collider)
    {
        GameObject collisionObject = collider.gameObject;
        Lightable l = collisionObject.GetComponent<Lightable>();
        if (l == null || l.inFire != true) return;
        LightFire();

    }

    public bool IsInFire()
    {
        return inFire;
    }

    Transform RecursiveFindChild(Transform parent, string childName)
    {
        foreach (Transform child in parent)
        {
            if (child.name == childName)
            {
                return child;
            }
            else
            {
                Transform found = RecursiveFindChild(child, childName);
                if (found != null)
                {
                    return found;
                }
            }
        }
        return null;
    }
}
