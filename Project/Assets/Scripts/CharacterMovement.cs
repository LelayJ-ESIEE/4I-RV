using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] float playerSpeed;
    [SerializeField] float rotationSpeed;

    CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = transform.forward * Input.GetAxis("Vertical");
        controller.Move(move * Time.deltaTime * playerSpeed);

        Quaternion q = Quaternion.Euler(0, Input.GetAxis("Horizontal") * rotationSpeed, 0);
        transform.rotation *= q;
    }
}
