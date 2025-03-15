using UnityEngine;
using UnityEngine.InputSystem;


public class NewMonoBehaviourScript : MonoBehaviour
{

    [SerializeField] InputAction thrust;
    [SerializeField] InputAction rotation;

    [SerializeField] float thrustStrenght = 10f;
    [SerializeField] float rotationStrength = 10f;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Input action enabled, it can also be disabled and called multiple times
    private void OnEnable()
    {
        thrust.Enable();
        rotation.Enable();
    }

    private void FixedUpdate()
    {
        ProccessThrust();
        ProcessRotation();
    }

    private void ProccessThrust()
    {
        if (thrust.IsPressed())
        {
            rb.AddRelativeForce(Vector3.up * thrustStrenght * Time.fixedDeltaTime);
        }
    }

    private void ProcessRotation()
    {
        float rotationInput = rotation.ReadValue<float>();
        if (rotationInput < 0)
        {
            ApplyRotation(rotationStrength);
        }
        else if (rotationInput > 0)
        {
            ApplyRotation(-rotationStrength);
        }
    }
    // At the start of this method, rigid body is frozen but when buttons are pressed rigid body is unfrozen
    private void ApplyRotation(float rotationPerFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationPerFrame * Time.fixedDeltaTime);
        rb.freezeRotation = false;
    }
}
