using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ContinuousMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    public XRNode inputSource;
    public LayerMask groundLayer;

    private const float gravity = -9.81f;

    private Vector2 inputAxis;
    private CharacterController character;
    private XRRig rig;
    private float fallingSpeed = 0f;

    public bool IsGrounded
    {
        get
        {
            Vector3 rayStart = transform.TransformPoint(character.center);
            float rayLength = character.center.y - character.radius + 0.01f;
            bool hasHit = Physics.SphereCast(rayStart, character.radius, Vector3.down, out RaycastHit hitInfo, rayLength);
            return hasHit;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        rig = GetComponent<XRRig>();
    }

    // Update is called once per frame
    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);
    }

    private void FixedUpdate()
    {
        followHeadset();

        // Move X/Y
        Quaternion headYaw = Quaternion.Euler(0, rig.cameraGameObject.transform.eulerAngles.y, 0);
        Vector3 direction = headYaw * new Vector3(inputAxis.x, 0, inputAxis.y);

        character.Move(direction *  Time.fixedDeltaTime * moveSpeed);

        // Move Y (Gravity)
        if (IsGrounded)
            fallingSpeed = 0f;
        else
            fallingSpeed += gravity * Time.fixedDeltaTime;

        character.Move(Vector3.up * fallingSpeed * Time.fixedDeltaTime);
    }

    void followHeadset()
    {
        character.height = rig.cameraInRigSpaceHeight;
        Vector3 capsuleCenter = transform.InverseTransformPoint(rig.cameraGameObject.transform.position);
        character.center = new Vector3(capsuleCenter.x, character.height / 2, capsuleCenter.z);
    }
}
