using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbZone : MonoBehaviour
{
    private bool isValidated = false;
    [SerializeField] Counter orbCounter;

    private void OnTriggerEnter(Collider other)
    {
        Orb obj = other.gameObject.GetComponent<Orb>();
        if(obj && !isValidated)
        {
            isValidated = true;
            GameObject.Destroy(other.gameObject);
            this.orbCounter++;
        }
    }
}
