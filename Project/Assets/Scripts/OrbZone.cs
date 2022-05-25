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

            Animator activationAnim = this.gameObject.GetComponentInChildren<Animator>();
            if(activationAnim)
            {
                activationAnim.Play("Activated", 0, 0f);
            }
            GetComponent<Collider>().enabled = false;
        }

    }
}
