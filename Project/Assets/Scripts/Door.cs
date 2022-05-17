using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // WIP

    public void open()
    {
        this.gameObject.GetComponent<Renderer>().material.color = Color.green;
    }
}
