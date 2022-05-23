using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static event Action<string> LightEnigmaFireEvent;
    public static event Action WrongAnswerEvent;
    public static event Action RightAnswerEvent;
    public static void LightEnigmaFire(string id)
    {
        if (LightEnigmaFireEvent != null)
        {
            LightEnigmaFireEvent(id);
        }
    }
    // Start is called before the first frame update
    

}
