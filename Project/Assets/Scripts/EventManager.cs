using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static event Action LightEnigmaFireEvent;
    public static void LightEnigmaFire()
    {
        if (LightEnigmaFireEvent != null)
        {
            LightEnigmaFireEvent();
        }
    }
    // Start is called before the first frame update
    

}
