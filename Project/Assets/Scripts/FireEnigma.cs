using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEnigma : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] string password;
    private string playerPassword;
    
    void Start()
    {
        EventManager.LightEnigmaFireEvent += ChangePassword;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangePassword()
    {
        Debug.Log("Changed");
    }

    private void OnDestroy()
    {
        EventManager.LightEnigmaFireEvent -= ChangePassword;
    }

}
