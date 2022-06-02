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

    public static void WrongAnswer()
    {
        if (WrongAnswerEvent != null)
        {
            WrongAnswerEvent();
        }
    }

    public static void RightAnswer()
    {
        if (RightAnswerEvent != null)
        {
            RightAnswerEvent();
        }
    }
    // Start is called before the first frame update


}
