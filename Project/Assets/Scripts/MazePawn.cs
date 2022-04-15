using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazePawn : MonoBehaviour
{
    [Header("Reference Mini-maze")]
    [SerializeField] GameObject m_Mini;

    Transform m_Transform;
    Rigidbody m_Rigidbody;
    private void Awake()
    {
        m_Transform = GetComponent<Transform>();
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 miniup = m_Mini.transform.up;

        Vector3 antiGravity = -Physics.gravity;
        
        Vector3 xForce = Vector3.Project(miniup, Vector3.right);
        Vector3 yForce = Vector3.Project(-miniup, -(Vector3.up));
        Vector3 zForce = Vector3.Project(miniup, Vector3.forward);

        Vector3 force = (xForce + yForce + zForce) * 9.81f;

        m_Rigidbody.AddForce(antiGravity);
        m_Rigidbody.AddForce(force);
    }
}
