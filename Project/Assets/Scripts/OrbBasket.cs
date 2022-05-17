using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbBasket : MonoBehaviour
{
    private bool isValidated = false;
    [SerializeField] private GameObject orbCounter;

    private void OnTriggerEnter(Collider other)
    {
        Orb obj = other.gameObject.GetComponent<Orb>();
        if(obj && !isValidated)
        {
            isValidated = true;
            GameObject.Destroy(other.gameObject);
            Debug.Log("Orbe entrée dans le panier");
        }
    }
}
