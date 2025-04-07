using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class Movement : MonoBehaviour
{

    [SerializeField] InputAction thrust;
    [SerializeField] InputAction rotation;

    [SerializeField] float thrustStrenght = 10f;
    [SerializeField] float rotationStrength = 10f;
    [SerializeField] AudioClip mainEngine;

    [SerializeField] ParticleSystem mainBooster;
    [SerializeField] ParticleSystem leftBooster;
    [SerializeField] ParticleSystem rightBooster;

    Rigidbody rb;
    AudioSource audioSource;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Input action enabled, it can also be disabled and called multiple times!
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
    // Thrust Audio Player and Upward Force!
    private void ProccessThrust()
    {
        if (thrust.IsPressed())
        {
            rb.AddRelativeForce(Vector3.up * thrustStrenght * Time.fixedDeltaTime);
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(mainEngine);
            }
            if (!mainBooster.isPlaying)
            {
                mainBooster.Play();
            }
        }
        else
        {
            audioSource.Stop();
            mainBooster.Stop();
        }
    }

    private void ProcessRotation()
    {
        // No motivation today so Imma just leave this here...monday the sun will rise again and so will I - 1 days left
        float rotationInput = rotation.ReadValue<float>();
        if (rotationInput < 0)
        {
            ApplyRotation(rotationStrength);
            if (!rightBooster.isPlaying)
            {
                leftBooster.Stop();
                rightBooster.Play();
            }
        }
        else if (rotationInput > 0)
        {
            ApplyRotation(-rotationStrength);
            if (!leftBooster.isPlaying)
            {
                rightBooster.Stop();
                leftBooster.Play();
            }
        }
        else
        {
            rightBooster.Stop();
            leftBooster.Stop();
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
